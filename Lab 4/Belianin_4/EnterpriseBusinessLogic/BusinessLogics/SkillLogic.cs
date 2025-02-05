using EnterpriseContracts.BindingModels;
using EnterpriseContracts.BusinessLogicContracts;
using EnterpriseContracts.StorageContracts;
using EnterpriseContracts.ViewModels;
using EnterpriseDataBaseImplement.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseBusinessLogic.BusinessLogics
{
	public class SkillLogic : ISkillLogic
	{
		private readonly ISkillStorage _skillStorage;

		public SkillLogic()
		{
			_skillStorage = new SkillStorage();
		}

		public SkillLogic(ISkillStorage skillStorage)
		{
			_skillStorage = skillStorage;
		}

		// Создание и обновление записи о навыке
		public void CreateOrUpdate(SkillBindingModel model)
		{
			var element = _skillStorage.GetElement(
				new SkillBindingModel
				{
					Name = model.Name
				});

			if (element != null && element.Id != model.Id)
			{
				throw new Exception("Такой навык уже существует");
			}

			// Если уже создан, то обновляем, иначе создаём
			if (model.Id.HasValue)
			{
				_skillStorage.Update(model);
			}
			else
			{
				_skillStorage.Insert(model);
			}
		}

		// Удаление записи о навыке
		public bool Delete(SkillBindingModel model)
		{
			var element = _skillStorage.GetElement(new SkillBindingModel
			{
				Id = model.Id
			});

			if (element == null)
			{
				throw new Exception("Навык не найден");
			}

			if (_skillStorage.Delete(model) == null)
			{
				return false;
			}

			return true;
		}

		// Чтение записей о навыках
		public List<SkillViewModel> Read(SkillBindingModel model)
		{
			// Если неконкретная запись, то выводим все
			if (model == null)
			{
				return _skillStorage.GetFullList();
			}

			// Если конкретная запись о навыке
			if (model.Id.HasValue)
			{
				return new List<SkillViewModel>
				{
					_skillStorage.GetElement(model)
				};
			}

			return _skillStorage.GetFilteredList(model);
		}
	}
}
