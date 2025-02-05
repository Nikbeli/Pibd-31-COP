using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseContracts.ViewModels
{
	public class EmployeeViewModel
	{
		public int? Id { get; set; }

		[DisplayName("Навык")]
		public string Skill { get; set; }

		public string Photo { get; set; }

		[DisplayName("ФИО")]
		public string FIO { get; set; }

		[DisplayName("Номер телефона")]
		public string PhoneNumber { get; set; }
	}
}
