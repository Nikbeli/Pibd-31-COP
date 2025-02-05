using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelianinComponents.Models
{
	public class WordWithTableDataConfig<T> : WordWithTableConfig
	{
		public List<T> Data { get; set; }
	}
}
