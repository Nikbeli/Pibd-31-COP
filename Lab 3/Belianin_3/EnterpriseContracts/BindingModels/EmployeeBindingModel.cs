using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseContracts.BindingModels
{
	public class EmployeeBindingModel
	{
		public int? Id { get; set; }

		public string Skill { get; set; }

		public string Photo { get; set; }

		public string FIO { get; set; }

		public string PhoneNumber { get; set; }
	}
}
