using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCustomComponents.Extensions
{
	// Конфигурация дерева или работа с узлами дерева не соответствует ожиданиям
	public class InvalidTreeNodeConfigException : Exception
	{
		public InvalidTreeNodeConfigException() { }

		public InvalidTreeNodeConfigException(string message) : base(message)
		{ }

		public InvalidTreeNodeConfigException(string message, Exception inner) : base(message, inner)
		{ }
	}
}
