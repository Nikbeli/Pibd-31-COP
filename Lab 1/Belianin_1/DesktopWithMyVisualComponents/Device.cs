using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopWithMyVisualComponents
{
	public class Device
	{
		public int Id { get; set; }

		public string DeviceType { get; set; }

		public string Model { get; set; }

		public string SerialNumber { get; set; }

		public Device(string serialNumber, string deviceType, string model)
		{
			SerialNumber = serialNumber;
			Model = model;
			DeviceType = deviceType;
		}

		public Device() { }
	}
}
