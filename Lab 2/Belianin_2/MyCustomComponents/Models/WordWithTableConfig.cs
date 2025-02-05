using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCustomComponents.Models
{
	public class WordWithTableConfig : WordConfig
	{
		public bool UseUnion { get; set; }

		public (int Columns, int Rows) ColumnsRowsDataCount { get; set; }

		public List<(int Column, int Row)> ColumnsRowsWidth { get; set; }

		public List<(int StartIndex, int Count)> ColumnUnion { get; set; }

		public List<(int ColumnIndex, int RowIndex, string Header, string PropertyName)> Headers { get; set; }
	}
}
