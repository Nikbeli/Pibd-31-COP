using MyCustomComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopWithMyVisualComponents
{
    public partial class FormMain : Form
    {
        readonly List<Device> devices = new()
        {
            new Device { Id = 1, SerialNumber = "SM-12345", DeviceType = "Мобильный телефон", Model = "IPhone 13" },
			new Device { Id = 2, SerialNumber = "SM-G3412", DeviceType = "Мобильный телефон", Model = "Samsung Galaxy S24" },
			new Device { Id = 3, SerialNumber = "CO2UD8471", DeviceType = "Ноутбук", Model = "MacBook Pro" },
            new Device { Id = 4, SerialNumber = "R80NZD8812", DeviceType = "Умные часы", Model = "Galaxy Watch 4" },
            new Device { Id = 5, SerialNumber = "FN738214", DeviceType = "Умные часы", Model = "Apple Watch 3",  },
        };

        public FormMain()
        {
			InitializeComponent();

			// Пример для компонента
			var list = new List<string>() { "Значение 1", "Значение 2", "Значение 3", "Значение 4", "Значение 5" };
			customSelectedCheckedListBoxProperty.Items.AddRange(list.ToArray());

			comboBoxDeviceType.Items.Add("Мобильный телефон");
			comboBoxDeviceType.Items.Add("Ноутбук");
			comboBoxDeviceType.Items.Add("Умные часы");

			// Загрузка дерева с девайсами
			LoadTree();

			// Присоединить обработчик события при изменении значения
			customInputRangeNumber.ChangeEvent += CustomInputRangeNumber_ChangeEvent;
		}

		// Загрузка дерево с иерархией устройств на основе типа устройства, модели и серийного номера
		public void LoadTree()
		{
			// Очистите существующие узлы перед загрузкой новых
			customTreeView.Clear();

			customTreeView.hierarchy = new List<string> { "DeviceType", "Model", "SerialNumber" };

			foreach (Device device in devices)
			{
				customTreeView.AddNode(device, "SerialNumber");
			}
		}

		// Вынесенная логика проверки значения
		private void UpdateLabelWithValue()
		{
			labelCheckValue.Text = customInputRangeNumber.Value.ToString();
			if (string.IsNullOrEmpty(labelCheckValue.Text))
			{
				labelCheckValue.Text = customInputRangeNumber.Error;
			}
		}

		// Добавляем метод для обработки изменения значения
		private void CustomInputRangeNumber_ChangeEvent(object sender, EventArgs e)
		{
			UpdateLabelWithValue();
		}

        // Метод проверки значения в Input
		private void buttonCheck_Click(object sender, EventArgs e)
        {
            UpdateLabelWithValue();
		}

        // Установка границ
        private void buttonSetBorders_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(textBoxMin.Text, out decimal minValue) && decimal.TryParse(textBoxMax.Text, out decimal maxValue))
            {
                // Проверка: MaxValue должно быть больше MinValue
                if (maxValue <= minValue)
                {
                    labelCheckValue.Text = "Ошибка: MaxValue должно быть больше MinValue.";
                    return;
                }

                // Устанавливаем границы
                customInputRangeNumber.MinValue = minValue;
                customInputRangeNumber.MaxValue = maxValue;
                labelCheckValue.Text = "Границы установлены";

				// Проверим текущее значение компонента на соответствие новому диапазону
				/*try
				{
					var currentValue = customInputRangeNumber.Value;

					// Если значение в пределах, выводим сообщение об успехе
					labelCheckValue.Text = "Границы установлены. Текущее значение в пределах диапазона.";
				}
				catch (ArgumentOutOfRangeException ex)
				{
					// Если текущее значение вне диапазона, выводим ошибку
					labelCheckValue.Text = $"Ошибка: {ex.Message}";
				}*/
			}
            else
            {
                labelCheckValue.Text = "Ошибка: неверные значения границ";
            }
		}

        private void textBoxMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 45)
            {
                e.Handled = true;
            }
        }

        private void textBoxMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 45)
            {
                e.Handled = true;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxAdd.Text != "" && !customSelectedCheckedListBoxProperty.Items.Contains(textBoxAdd.Text))
                customSelectedCheckedListBoxProperty.Items.Add(textBoxAdd.Text);
            else if (customSelectedCheckedListBoxProperty.Items.Contains(textBoxAdd.Text))
                customSelectedCheckedListBoxProperty.SelectedElement = textBoxAdd.Text;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            customSelectedCheckedListBoxProperty.Clear();
        }

        private void buttonGetSelected_Click(object sender, EventArgs e)
        {
            labelSelectedValue.Text = customSelectedCheckedListBoxProperty.SelectedElement;
            if (string.IsNullOrEmpty(labelSelectedValue.Text))
            {
                labelSelectedValue.Text = "Значение \nне выбрано";
            }
        }

		// Добавление нового узла в дерево
		private void buttonAddToTree_Click(object sender, EventArgs e)
		{
			Device device = new Device
			{
				SerialNumber = textBoxSerialNumber.Text,
				Model = textBoxModel.Text,
				DeviceType = comboBoxDeviceType.SelectedItem?.ToString()
			};

			customTreeView.AddNode(device, "SerialNumber");
		}

		// Получение данных выбранного узла из дерева
		private void buttonGetFromTree_Click(object sender, EventArgs e)
		{
			Device? device = customTreeView.GetSelectedNode<Device>();
			if (device == null)
			{
				return;
			}

			textBoxSerialNumber.Text = device.SerialNumber;
			textBoxModel.Text = device.Model;
			comboBoxDeviceType.SelectedItem = device.DeviceType;
		}
	}
}
