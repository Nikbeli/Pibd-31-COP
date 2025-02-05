using EnterpriseContracts.BindingModels;
using EnterpriseContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseContracts.BusinessLogicContracts
{
	public interface IEmployeeLogic
	{
		List<EmployeeViewModel> Read(EmployeeBindingModel model);

		void CreateOrUpdate(EmployeeBindingModel model);

		void Delete(EmployeeBindingModel model);
	}
}
