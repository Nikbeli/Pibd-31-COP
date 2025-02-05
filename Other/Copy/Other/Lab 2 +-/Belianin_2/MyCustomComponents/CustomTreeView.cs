using MyCustomComponents.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MyCustomComponents.Attributes;

namespace MyCustomComponents
{
	public partial class CustomTreeView : UserControl
	{
		public CustomTreeView()
		{
			InitializeComponent();
		}

		// Свойство для получения и установки выбранного узла в TreeView
		public int SelectedTreeNode
		{
			get => treeView.SelectedNode.Index;
			set => treeView.SelectedNode = treeView.Nodes[value];
		}

		public List<string>? Hierarchy { get; set; }


		// Отдельный публичный метод очистки всех узлов дерева
		public void Clear()
		{
			treeView.Nodes.Clear();
		}


		// Публичный метод для получения выбранной записи из древовидной структуры
		public T GetSelectedNode<T>() where T : new()
		{
			if (Hierarchy == null)
			{
				throw new HierarchyNullException("Hierarchy is null");
			}

			if (treeView.SelectedNode == null)
			{
				return new T();
			}

			// Если узел выбран и существует, вызываем приватный метод для получения данных узла
			return _getNode(new T(), treeView.SelectedNode);
		}

		// Приватный метод, рекурсивно идущий по узлам вверх (по иерархии)
		private T _getNode<T>(T obj, TreeNode node)
		{
			// Проверка узла
			if (node != null && node.Tag != null)
			{
				var tag = node.Tag as Tuple<string, object>;

				var property = obj?.GetType().GetProperty(tag!.Item1);
				property?.SetValue(obj, Convert.ChangeType(tag!.Item2, property.PropertyType));

				// Рекурсивный вызов метода для родительского узла
				_getNode(obj, node.Parent);
			}

			return obj;
		}

		/* Параметризированный метод, у которого в передаваемых параметрах
		 * идёт объект какого-то класса и имя свойства/поля, до которого согласно
		 * иерархии будет следовать формирование ветви
		*/
		public void AddNode<T>(T obj, string propertyName)
		{
			if (Hierarchy == null)
			{
				throw new HierarchyNullException("Hierarchy is null");
			}

			if (obj == null)
			{
				throw new ArgumentNullException("Added object is null");
			}

			// Ищем индекс свойства в иерархии
			int index = Hierarchy.IndexOf(propertyName);
			if (index == -1)
			{
				throw new PropertyNullException("Property not found in hierarchy");
			}

			var values = _getValuesWithStructure(obj, propertyName);

			// Создаем новый узел дерева и добавляем в него дочерние узлы
			var treeNode = new TreeNode();
			_addNodesToTreeNode(treeView.Nodes, treeNode.Nodes);

			// Добавляем элементы в дерево через новый узел
			var nodes = _addElementsToParent(values, treeNode);

			// Добавляем элементы в дерево через новый узел
			treeView.Nodes.Clear();
			_addNodesToTreeNode(nodes.Nodes, treeView.Nodes);

		}

		// Приватный метод для клонирования узлов дерева из одного узла в другой
		private void _addNodesToTreeNode(TreeNodeCollection fromNodeCollection, TreeNodeCollection toNodeCollection)
		{
			for (int i = 0; i < fromNodeCollection.Count; i++)
			{
				// Клонируем узел
				var node = fromNodeCollection[i].Clone() as TreeNode;
				toNodeCollection.Add(node);
			}
		}

		// Приватный метод для извлечения значений свойств объекта
		private Dictionary<string, (object, bool)> _getValuesWithStructure<T>(T obj, string propertyName)
		{
			// Получаем все свойства объекта
			PropertyInfo[]? properties = obj?.GetType().GetProperties();

			var dictionary = new Dictionary<string, (object, bool)>();

			// Получаем все значения свойств в структурированном виде (относительно иерархии)
			foreach (var element in Hierarchy!)
			{
				PropertyInfo? property = properties?.Single(property => property.Name == element);

				if (property == null)
				{
					throw new PropertyNullException(nameof(property));
				}

				// Получаем атрибут, отвечающий за необходимость создания новой ветки
				var attribute = property.GetCustomAttributes()?.SingleOrDefault(attribute => attribute is AlwaysCreateAttribute);

				dictionary[element] = (property.GetValue(obj)!, attribute == null ? false : true);

				if (element == propertyName)
				{
					break;
				}
			}

			return dictionary;
		}

		// Приватный метод для добавления элементов в родительский узел
		private TreeNode _addElementsToParent(Dictionary<string, (object, bool)> elements, TreeNode parent)
		{
			// Если пусто в словаре, то родительский узел возвращаем
			if (elements.Count == 0)
			{
				return parent;
			}

			// Получаем первый элемент словаря
			var firstElem = elements.First();

			// Получаем элемент (существующий узел)
			var child = parent.Nodes.Cast<TreeNode>().SingleOrDefault(node => node.Text == (string)firstElem.Value.Item1);

			if (child != null && !firstElem.Value.Item2)
			{
				// Удаляем элемент из словаря и рекурсивно вызываем добавление для дочернего узла
				elements.Remove(firstElem.Key);
				return _addElementsToParent(elements, child).Parent;
			}
			else
			{
				// Создаем новый узел и добавляем его к родительскому
				var newChild = new TreeNode(firstElem.Value.Item1?.ToString() ?? string.Empty);

				newChild.Tag = new Tuple<string, object>(firstElem.Key, firstElem.Value.Item1!);

				// Удаляем текущий элемент из словаря и добавляем дочерний узел
				elements.Remove(firstElem.Key);
				parent.Nodes.Add(_addElementsToParent(elements, newChild));

				return parent;
			}
		}
	}
}
