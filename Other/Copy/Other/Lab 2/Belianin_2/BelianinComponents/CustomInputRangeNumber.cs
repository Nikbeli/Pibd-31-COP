using BelianinComponents.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BelianinComponents
{
	public partial class CustomInputRangeNumber : UserControl
	{
		// Диапазон
		private string example = "Введите значение от " + decimal.MinValue + " до " + decimal.MaxValue;

		// В случае ошибки
		public string Error { get; protected set; } = string.Empty;

		// Создам 2 публичных поля для настройки границ диапазона
		public decimal? MinValue { get; set; } = null;
		public decimal? MaxValue { get; set; } = null;


		/* Публичное свойство для установки и получения введённого значения (set, get). При получении проводится проверка,
			Если введённое значение не входит в диапозон, возвращать значение null, а в отдельное поле выводить текст ошибки. 
			При установке должна проводиться проверка, если передаваемое значение не входит в диапозон, то не заполнять поле компонента.
		*/

		public decimal? Value
		{
			get
			{
				// Как мы проверим что программист не забыл задать минимальное, максимальное значение?
				// Проверка, что MinValue и MaxValue задан
				if (!MinValue.HasValue || !MaxValue.HasValue)
				{
					throw new RangeException("MinValue и MaxValue должны быть заданы.");
				}

				// Проверяем, что max не может быть min
				if (MaxValue.Value <= MinValue.Value)
				{
					throw new RangeException("MaxValue должно быть больше MinValue");
				}

				decimal currentValue = numericUpDown.Value;

				// Проверка, что значение в диапазоне
				if (currentValue < MinValue.Value || currentValue > MaxValue.Value)
				{
					throw new RangeException($"Введённое значение {currentValue} лежит вне диапазона {MinValue.Value} - {MaxValue.Value}.");
				}

				return currentValue;
			}
			set
			{
				// Проверка, что MinValue и MaxValue заданы
				if (!MinValue.HasValue || !MaxValue.HasValue)
				{
					Error = "MinValue и MaxValue должны быть заданы.";
					return;
				}

				// Проверка, что MinValue меньше MaxValue
				if (MinValue.Value >= MaxValue.Value)
				{
					Error = "Диапазон неверен. MinValue должен быть меньше, чем MaxValue.";
					return;
				}

				// Если число верно в диапозоне, то значение устанавливается
				if (value.HasValue && value.Value >= MinValue.Value && value.Value <= MaxValue.Value)
				{
					numericUpDown.Value = value.Value;

					// Очистить ошибку, если значение установлено успешно
					Error = null;
				}
				else
				{
					Error = $"Значение должно быть в диапазоне от {MinValue.Value} до {MaxValue.Value}.";
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
