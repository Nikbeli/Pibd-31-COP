using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelianinComponents.Models
{
	public class WordWithImageConfig : WordConfig
	{
		public List<byte[]> Images { get; set; }
	}
}
