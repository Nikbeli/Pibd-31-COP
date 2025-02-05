using EnterpriseContracts.BindingModels;
using EnterpriseContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseContracts.BusinessLogicContracts
{
	public interface ISkillLogic
	{
		List<SkillViewModel> Read(SkillBindingModel model);

		void CreateOrUpdate(SkillBindingModel model);

		bool Delete(SkillBindingModel model);
	}
}
