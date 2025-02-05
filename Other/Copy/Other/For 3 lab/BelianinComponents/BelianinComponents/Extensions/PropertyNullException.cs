using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelianinComponents.Extensions
{
	public class PropertyNullException : Exception
	{
		public PropertyNullException() { }

		public PropertyNullException(string message) : base(message) { }

		public PropertyNullException(string message, Exception inner) : base(message, inner) { }
	}
}
