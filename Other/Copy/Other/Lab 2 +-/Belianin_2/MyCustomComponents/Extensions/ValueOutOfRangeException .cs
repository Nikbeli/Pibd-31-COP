using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCustomComponents.Extensions
{
	// Ошибка неверного значения, когда значение выходит за границы диапазона
	public class ValueOutOfRangeException : Exception
	{
		public ValueOutOfRangeException() { }

		public ValueOutOfRangeException(string message) : base(message)
		{
		}

		public ValueOutOfRangeException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}
