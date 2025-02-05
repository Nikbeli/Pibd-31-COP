using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCustomComponents.Extensions
{
	internal class RangeException : Exception
	{
		public RangeException() { }

		public RangeException(string message) : base(message)
		{ }

		public RangeException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}
