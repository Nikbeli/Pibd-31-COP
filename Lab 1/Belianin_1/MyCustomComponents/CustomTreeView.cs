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
using System.Xml.Linq;

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
			get
			{
				if (treeView.SelectedNode != null)
				{
					return treeView.SelectedNode.Index;
				}

				return -1;
			}
			set
			{
				if (treeView.Nodes.Count > 0 && value >= 0 && value < treeView.Nodes.Count)
				{
					treeView.SelectedNode = treeView.Nodes[value];
				}
				else
				{
					throw new ArgumentOutOfRangeException(nameof(value), $"Индекс {value} выходит за пределы допустимого диапазона. Допустимый диапазон: от 0 до {treeView.Nodes.Count - 1}.");
				}
			}
		}

		public List<string>? hierarchy { get; set; }

		private Dictionary<string, bool> newBranch { get; set; } = new Dictionary<string, bool>();

		// Отдельный публичный метод очистки всех узлов дерева
		public void Clear()
		{
			treeView.Nodes.Clear();
		}

		// Публичный метод для получения выбранной записи из древовидной структуры
		public T GetSelectedNode<T>() where T : class, new()
		{
			if (hierarchy == null)
			{
				throw new HierarchyNullException("Hierarchy is null");
			}

			if (treeView.SelectedNode == null)
			{
				throw new InvalidSelectedElementException("TreeView null");
			}

			// Проверка, является ли выбранный узел корневым
			if (treeView.SelectedNode.Parent == null)
			{
				// Выбран корневой элемент — возвращаем пустой объект
				throw new InvalidSelectedElementException("Parent is null");
			}

			// Если узел выбран и существует, вызываем приватный метод для получения данных узла
			return _getNode<T>();
		}


		// Приватный метод, идущий по узлам вверх (по иерархии)
		private T _getNode<T>() where T : new()
		{
			TreeNode? node = treeView.SelectedNode;

			var obj = new T();
			int level = hierarchy.Count - 1;

			// Проходим по иерархии от нижнего уровня к верхнему
			while (node != null && level >= 0)
			{
				var property = hierarchy[level];
				obj.GetType().GetProperty(property)?.SetValue(obj, node.Text);

				node = node.Parent;

				level--;
			}

			return obj;
		}

		/* Параметризированный метод, у которого в передаваемых параметрах
		 * идёт объект какого-то класса и имя свойства/поля, до которого согласно
		 * иерархии будет следовать формирование ветви
		*/
		public void AddNode<T>(T obj, string propertyName)
		{
			if (hierarchy == null)
			{
				throw new HierarchyNullException("Hierarchy is null");
			}

			if (obj == null)
			{
				throw new ArgumentNullException("Added object is null");
			}

			// Получаем первый узел в дереве
			TreeNode currentNode = null;

			// Проходимся по иерархии 
			foreach (var property in hierarchy)
			{
				// Получаем значение свойства
				var value = obj.GetType().GetProperty(property)?.GetValue(obj, null)?.ToString();
				bool createNewBranch = newBranch != null && newBranch.ContainsKey(propertyName) && newBranch[propertyName];

				if (currentNode == null)
				{
					currentNode = treeView.Nodes.Cast<TreeNode>().FirstOrDefault(n => n.Text == value)
						?? treeView.Nodes.Add(value);
				}
				else
				{
					var childNode = currentNode.Nodes.Cast<TreeNode>().FirstOrDefault(n => n.Text == value);

					// Проверка нужно ли нам создавать дочерний узел
					if (childNode == null || createNewBranch)
					{
						childNode = currentNode.Nodes.Add(value);
					}

					// Переходим на уровень этого дочернего узла
					currentNode = childNode;
				}

				if (property == propertyName)
				{
					break;
				}

			}
		}


		public void SetHierarchy(List<string> hierarchy, Dictionary<string, bool> newBranch)
		{
			this.hierarchy = hierarchy;
			this.newBranch = newBranch;
		}
	}
}
