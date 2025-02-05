using EnterpriseContracts.BindingModels;
using EnterpriseContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseContracts.StorageContracts
{
	public interface IEmployeeStorage
	{
		List<EmployeeViewModel> GetFullList();

		List<EmployeeViewModel> GetFilteredList(EmployeeBindingModel model);

		EmployeeViewModel GetElement(EmployeeBindingModel model);

		void Insert(EmployeeBindingModel model);

		void Update(EmployeeBindingModel model);

		void Delete(EmployeeBindingModel model);
	}
}
