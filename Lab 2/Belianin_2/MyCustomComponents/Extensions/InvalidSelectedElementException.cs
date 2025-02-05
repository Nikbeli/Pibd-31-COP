using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCustomComponents.Extensions
{
	// Исключение, если нет выбранного и отмеченного элемента
	public class InvalidSelectedElementException : Exception
	{
		public InvalidSelectedElementException() { }

		public InvalidSelectedElementException(string message) : base(message)
		{
		}

		public InvalidSelectedElementException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}
