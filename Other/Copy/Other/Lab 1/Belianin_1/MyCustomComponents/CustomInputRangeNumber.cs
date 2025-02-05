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
	public partial class CustomInputRangeNumber : UserControl
	{
		// Диапазон
		private string example = "Введите значение от " + decimal.MinValue + " до " + decimal.MaxValue;

		// В случае ошибки
		public string Error { get; protected set; } = string.Empty;

		// Создам 2 публичных поля для настройки границ диапазона
		public decimal MinValue { get; set; } = decimal.MinValue;
		public decimal MaxValue { get; set; } = decimal.MaxValue;

		// Метод для установки границ
		public bool SetBorders(string minvalue, string maxvalue)
		{
			if (Decimal.Parse(maxvalue) < Decimal.Parse(minvalue))
			{
				Error = "Ввудённый диапозон \n неверен MinValue должен \n быть меньше, чем MaxValue";
				return false;
			}

			MinValue = Decimal.Parse(minvalue);
			MaxValue = Decimal.Parse(maxvalue);
			example = "Введите значение от " + MinValue + " до " + MaxValue;
			return true;
		}

		/* Публичное свойство для установки и получения введённого значения (set, get). При получении проводится проверка,
			Если введённое значение не входит в диапозон, возвращать значение null, а в отдельное поле выводить текст ошибки. 
			При установке должна проводиться проверка, если передаваемое значение не входит в диапозон, то не заполнять поле компонента.
		*/

		public decimal? Value
		{
			get
			{
				if (numericUpDown.Value >= MinValue && numericUpDown.Value <= MaxValue)
				{
					return numericUpDown.Value;
				}

				Error = "Введённое значение" + " лежит \n вне диапазона " + MinValue + " - " + MaxValue;
				return null;
			}
			set
			{
				decimal? number = value;
				decimal minValue = MinValue;
				int numberTwo;

				if ((number.GetValueOrDefault() > minValue) & number.HasValue)
				{
					number = value;
					minValue = MaxValue;
					numberTwo = (((number.GetValueOrDefault() < minValue) & number.HasValue) ? 1 : 0);
				} 
				else
				{
					numberTwo = 0;
				}

				if (numberTwo == 0)
				{
					numericUpDown.Value = value.Value;
				}
			}
		}


		public CustomInputRangeNumber()
		{
			InitializeComponent();
		}

		private void numericUpDown_Enter(object sender, EventArgs e)
		{
			ToolTip toolTip = new ToolTip();
			toolTip.Show(example, numericUpDown, 30, -20, 1000);
		}

		private void numericUpDown_ValueChanged(object sender, EventArgs e)
		{
			_changeEvent?.Invoke(sender, e);
		}

		private EventHandler _changeEvent;

		// Событие, вызываемое при смене значения
		public event EventHandler ChangeEvent
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
	}
}
