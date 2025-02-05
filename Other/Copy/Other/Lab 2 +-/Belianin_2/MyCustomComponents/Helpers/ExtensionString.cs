using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyCustomComponents.Helpers
{
	public static class ExtensionString
	{
		public static bool HaveText(this string str)
		{
			return !string.IsNullOrEmpty(str);
		}

		public static bool IsEmpty(this string str)
		{
			return string.IsNullOrEmpty(str);
		}
	}
}
