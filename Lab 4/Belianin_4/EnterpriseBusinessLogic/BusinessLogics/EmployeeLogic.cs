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
	public class EmployeeLogic : IEmployeeLogic
	{
		private readonly IEmployeeStorage _employeeStorage;

		public EmployeeLogic()
		{
			_employeeStorage = new EmployeeStorage();
		}

		public EmployeeLogic(IEmployeeStorage employeeStorage)
		{
			_employeeStorage = employeeStorage;
		}

		// Создание и обновление записи о работнике
		public void CreateOrUpdate(EmployeeBindingModel model)
		{
			var element = _employeeStorage.GetElement(new EmployeeBindingModel
			{
				FIO = model.FIO
			});

			if (element != null && element.Id != model.Id)
			{
				throw new Exception("Сотрудник с таким именем уже существует");
			}

			// Если уже создан, то обновляем, иначе создаём
			if (model.Id.HasValue)
			{
				_employeeStorage.Update(model);
			}
			else
			{
				_employeeStorage.Insert(model);
			}
		}

		// Удаление записи о работнике
		public void Delete(EmployeeBindingModel model)
		{
			var element = _employeeStorage.GetElement(new EmployeeBindingModel
			{
				Id = model.Id
			});

			if (element == null)
			{
				throw new Exception("Сотрудник не найден");
			}

			_employeeStorage.Delete(model);
		}

		// Чтение записей о работнике
		public List<EmployeeViewModel> Read(EmployeeBindingModel model)
		{
			// Если неконкретная запись, то выводим все
			if (model == null)
			{
				return _employeeStorage.GetFullList();
			}

			// Если конкретная запись о навыке
			if (model.Id.HasValue)
			{
				return new List<EmployeeViewModel>
				{
					_employeeStorage.GetElement(model)
				};
			}

			return _employeeStorage.GetFullList();
		}
	}
}
