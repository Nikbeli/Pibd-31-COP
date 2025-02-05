using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCustomComponents.Models
{
	public class WordWithDiagramConfig : WordConfig
	{
		public string ChartTitle { get; set; }

		public Location LegendLocation { get; set; }

		public Dictionary<string, List<(int Date, double Value)>> Data { get; set; }
	}
}
