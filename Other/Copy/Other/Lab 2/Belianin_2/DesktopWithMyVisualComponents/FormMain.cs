using BelianinComponents;
using BelianinComponents.Models;
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
			new Device { Id = 1, SerialNumber = "SM-12345", DeviceType = "Мобильный телефон", Model = "IPhone 13", Owner = "Иван Иванов", PurchaseDate = new DateTime(2022, 5, 15),	State = "Новый", Price = 70000, Color = "Синий", WarrantyPeriod = 6 },
			new Device { Id = 2, SerialNumber = "CO2UD8471", DeviceType = "Ноутбук", Model = "MacBook Pro", Owner = "Петр Петров", PurchaseDate = new DateTime(2021, 3, 20), State = "Б/У",	Price = 150000, Color = "Черный", WarrantyPeriod = 12 },
			new Device { Id = 3, SerialNumber = "R80NZD8812", DeviceType = "Умные часы", Model = "Galaxy Watch 4", Owner = "Анна Смирнова",	PurchaseDate = new DateTime(2023, 1, 10), State = "Новый", Price = 25000, Color = "Белый", WarrantyPeriod = 18 },
			new Device { Id = 4, SerialNumber = "SM-G3412", DeviceType = "Мобильный телефон", Model = "Samsung Galaxy S24", Owner = "Елена Кузнецова", PurchaseDate = new DateTime(2023, 7, 25), State = "Новый", Price = 80000, Color = "Синий", WarrantyPeriod = 6 },
			new Device { Id = 5, SerialNumber = "FN738214", DeviceType = "Умные часы", Model = "Apple Watch 3", Owner = "Дмитрий Федоров", PurchaseDate = new DateTime(2020, 8, 5),	State = "Б/У", Price = 15000, Color = "Красный", WarrantyPeriod = 24 },
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

			customTreeView.SelectedTreeNode = 2;

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

		private void buttonWordWithImage_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            bool flag = true;
            var images = new List<byte[]>();
            while (flag)
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    images.Add(File.ReadAllBytes(openFileDialog.FileName));
                }
                else
                {
                    flag = false;
                }
            }
            wordWithImages.CreateDoc(new WordWithImageConfig
            {
                FilePath = "E:\\COP\\Lab 2\\WordWithImageDocx.docx",
                Header = "Картинки:",
                Images = images,
            });
        }

        private void buttonWordWithTable_Click(object sender, EventArgs e)
        {
            wordWithTable.CreateDoc(new WordWithTableDataConfig<Device>
            {
                FilePath = "E:\\COP\\Lab 2\\WordWithTableDocx.docx",
                Header = "Таблица:",
                UseUnion = true,
                ColumnsRowsWidth = new List<(int, int)> { (0, 5), (0, 5), (0, 10), (0, 10), (0, 7), (0, 7), (0, 10), (0, 10), (0, 8) },
                ColumnUnion = new List<(int StartIndex, int Count)> { (2, 3), (5, 3) },
                Headers = new List<(int ColumnIndex, int RowIndex, string Header, string PropertyName)>
                {
					(0, 0, "Номер", "Id"),
					(1, 0, "Серийный номер", "SerialNumber"),
					(2, 0, "Об устройстве", "DeviceType"),
					(2, 1, "Модель", "Model"),
					(3, 1, "Цвет", "Color"),
					(4, 1, "Стоимость", "Price"),
					(5, 0, "Покупатели", ""),
					(5, 1, "Дата покупки", "PurchaseDate"),
					(6, 1, "Владелец", "Owner"),
					(7, 1, "Статус", "State"),
					(8, 0, "Гарантия", "WarrantyPeriod"),
				},
                Data = devices
            });
        }

        private void buttonWordWithDiagram_Click(object sender, EventArgs e)
        {
            wordWithDiagram.CreateDoc(new WordWithDiagramConfig
            {
                FilePath = "E:\\COP\\Lab 2\\WordWithDiagramDocx.docx",
                Header = "Диаграмма",
                ChartTitle = "Круговая диаграмма",
                LegendLocation = BelianinComponents.Models.Location.Bottom,
                Data = new Dictionary<string, List<(int Date, double Value)>>
                {
                    { "Серия 1", new List<(int Date, double Value)> { (1, 20), (2, 30), (3, 50) } }
                }
            });
        }
    }
}
