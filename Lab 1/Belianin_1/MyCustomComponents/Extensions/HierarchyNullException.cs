using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCustomComponents.Extensions
{
	public class HierarchyNullException : Exception
	{
		public HierarchyNullException() { }

		public HierarchyNullException(string message) : base(message) { }

		public HierarchyNullException(string message, Exception inner) : base(message, inner) { }

	}
}
