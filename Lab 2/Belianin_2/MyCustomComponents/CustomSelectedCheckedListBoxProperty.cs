using MyCustomComponents.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCustomComponents
{
	public partial class CustomSelectedCheckedListBoxProperty : UserControl
	{
		/* Публичное свойство, которое передаёт ссылку на свойство Items 
		 * элемента ComboBox, через которое и идёт заполнение	*/
		public CheckedListBox.ObjectCollection Items => checkedListBox.Items;

		public CustomSelectedCheckedListBoxProperty()
		{
			InitializeComponent();
		}

		// Отдельный публичный метод очистки списка
		public void Clear()
		{
			checkedListBox.Items.Clear();
		}

		private EventHandler _changeEvent;

		private void checkedListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			_changeEvent?.Invoke(sender, e);
		}

		// Событие, вызываемое при смене значения в CheckedListBox
		public event EventHandler Changed
		{
			add
			{
				_changeEvent += value;
			}
			remove
			{
				_changeEvent -= value;
			}
		}


		// Публичное свойство (set, get) для установки и получения выбранного значения (возвращает пустую строку, если нет выбранного значения)
		public string SelectedElement
		{
			get
			{
				return (checkedListBox.SelectedIndex > -1 && checkedListBox.GetItemChecked(checkedListBox.SelectedIndex)) ? checkedListBox.SelectedItem.ToString() : string.Empty; 
			}
			set
			{
				if (!string.IsNullOrEmpty(value))
				{
					int index = checkedListBox.Items.IndexOf(value);

					// Если попытаться установить несуществующий элемент
					if (index == -1)
					{
						// Выбрасываем исключение, если элемент не найден в списке
						throw new InvalidSelectedElementException($"Элемент '{value}' не найден в списке.");
					}

					checkedListBox.SelectedItem = value;
					checkedListBox.SetItemCheckState(checkedListBox.SelectedIndex, CheckState.Checked);
				}
			}
		}


		private void checkedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			if (e.NewValue == CheckState.Checked && checkedListBox.CheckedItems.Count > 0)
			{
				checkedListBox.ItemCheck -= checkedListBox_ItemCheck;
				checkedListBox.SetItemChecked(checkedListBox.CheckedIndices[0], value: false);
				checkedListBox.ItemCheck += checkedListBox_ItemCheck;
			}
		}
	}
}
