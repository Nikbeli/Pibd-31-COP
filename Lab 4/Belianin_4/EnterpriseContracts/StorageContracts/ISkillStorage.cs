using EnterpriseContracts.BindingModels;
using EnterpriseContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseContracts.StorageContracts
{
	public interface ISkillStorage
	{
		List<SkillViewModel> GetFullList();

		List<SkillViewModel> GetFilteredList(SkillBindingModel model);

		SkillViewModel GetElement(SkillBindingModel model);

		void Insert(SkillBindingModel model);

		void Update(SkillBindingModel model);

		bool Delete(SkillBindingModel model);
	}
}
