using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopWithMyVisualComponents
{
	public class Transport
	{
		public int Id { get; set; }

		public string TransportType { get; set; }

		public string Model { get; set; }

		public string RegNumber { get; set; }

		public Transport(string regNumber, string transportType, string model)
		{
			RegNumber = regNumber;
			TransportType = transportType;
			Model = model;
		}

		public Transport() { }
	}
}
