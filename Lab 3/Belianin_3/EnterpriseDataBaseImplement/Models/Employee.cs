using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseDataBaseImplement.Models
{
	public class Employee
	{
		public int Id { get; set; }

		[Required]
		public string Skill { get; set; }

		[Required]
		public string Photo { get; set; }

		[Required]
		public string FIO { get; set; }

		[Required]
		public string PhoneNumber { get; set; }
	}
}
