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

namespace MyCustomComponents
{
	public partial class CustomTreeCell : UserControl
	{
		// Отдельный публичный метод очистки списка
		public void Clear()
		{
			treeView.Nodes.Clear();
		}

		// Защищённое свойство для установки и получения индекса выбранной ветки(set, get). Содержит конфигурацию узлов и выстраивает иерархию
		protected DataTreeNodeConfig Levels { get; set; }

		// Загрузка конфигурации дерева
		public void LoadConfig(DataTreeNodeConfig levels)
		{
			if (levels != null)
			{
				Levels = levels;
			}
		}


		// Публичный метод для получения выбранной записи из древовидной структуры (если конечный элемент дерева) 
		public T GetSelectedObject<T>() where T : class, new()
		{
			// Проверяем, что узел выбран, конфигурация уровня не пустая и выбранный узел - конечный (не содержит подузлов)
			if (treeView.SelectedNode == null || Levels == null || treeView.SelectedNode.Nodes.Count > 0)
			{
				return null;
			}

			// Создаём новый объект типа T
			T selectedObject = new T();

			// Получаем имя свойства из Levels, для этого уточняем что именно Levels хранит
			string nodeName = treeView.SelectedNode.Text;

			// Присваиваем значение найденного узла свойству объекта T
			PropertyInfo propertyInfo = typeof(T).GetProperty(Levels.NodeNames.FirstOrDefault());
			if (propertyInfo != null)
			{
				propertyInfo.SetValue(selectedObject, nodeName);
			}

			return selectedObject;
		}


		/* Параметризированный метод, у которого в передаваемых параметрах
		 * идёт объект какого-то класса и имя свойства/поля, до которого согласно
		 * иерархии будет следовать формирование ветки
		*/
		public void AddCell<T>(int columnIndex, T element)
		{
			if (Levels == null || element == null || columnIndex < 0 || columnIndex >= Levels.NodeNames.Count)
			{
				return;
			}

			TreeNodeCollection treeNodeCollection = treeView.Nodes;
			int num = 0;

			foreach (string nodeName in Levels.NodeNames)
			{
				string text = element.GetType().GetProperty(nodeName)?.GetValue(element, null)?.ToString() ?? nodeName;
				TreeNode treeNode = null;

				// Поиск существующего узла дерева с таким же текстом
				foreach (TreeNode item in treeNodeCollection)
				{
					if (item.Text == text)
					{
						treeNode = item;
					}
				}

				// Добавляем новый узел, если не нашли существующий
				treeNodeCollection = ((treeNode == null) ? treeNodeCollection.Add(text).Nodes : treeNode.Nodes);
				
				if (num >= columnIndex)
				{
					break;
				}

				num++;
			}
		}


		public CustomTreeCell()
		{
			InitializeComponent();
		}
	}
}
