using EnterpriseContracts.BindingModels;
using EnterpriseContracts.StorageContracts;
using EnterpriseContracts.ViewModels;
using EnterpriseDataBaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseDataBaseImplement.Implements
{
	public class EmployeeStorage : IEmployeeStorage
	{
		// Создание работника
		private static Employee CreateModel(EmployeeBindingModel model, Employee employee)
		{
			employee.FIO = model.FIO;
			employee.Skill = model.Skill;
			employee.PhoneNumber = model.PhoneNumber;
			employee.Photo = model.Photo;

			return employee;
		}

		private static EmployeeViewModel CreateModel(Employee employee)
		{
			return new EmployeeViewModel
			{
				Id = employee.Id,
				FIO = employee.FIO,
				Photo = employee.Photo,
				PhoneNumber = employee.PhoneNumber,
				Skill = employee.Skill
			};
		}

		// Добавление работника
		public void Insert(EmployeeBindingModel model)
		{
			var context = new EnterpriseDataBase();
			var transaction = context.Database.BeginTransaction();

			try
			{
				context.Employees.Add(CreateModel(model, new Employee()));
				context.SaveChanges();
				transaction.Commit();
			}
			catch
			{
				transaction.Rollback();
				throw;
			}
		}

		// Обновление данных о работнике
		public void Update(EmployeeBindingModel model)
		{
			var context = new EnterpriseDataBase();
			var transaction = context.Database.BeginTransaction();

			try
			{
				var employee = context.Employees.FirstOrDefault(rec => rec.Id == model.Id);

				if (employee == null)
				{
					throw new Exception("Сотрудник не найден");
				}

				CreateModel(model, employee);
				context.SaveChanges();
				transaction.Commit();
			}
			catch
			{
				transaction.Rollback();
				throw;
			}
		}

		public void Delete(EmployeeBindingModel model)
		{
			var context = new EnterpriseDataBase();
			var employee = context.Employees.FirstOrDefault(rec => rec.Id == model.Id);

			if (employee != null)
			{
				context.Employees.Remove(employee);
				context.SaveChanges();
			}
			else
			{
				throw new Exception("Сотрудник не найден");
			}
		}

		// Получение записи о работнике
		public EmployeeViewModel GetElement(EmployeeBindingModel model)
		{
			// Если пусто
			if (model == null)
			{
				return null;
			}

			using var context = new EnterpriseDataBase();

			var employee = context.Employees.ToList()
				.FirstOrDefault(rec => rec.FIO == model.FIO || rec.Id == model.Id);

			return employee != null ? CreateModel(employee) : null;
		}

		// Получение отфильтрованного списка
		public List<EmployeeViewModel> GetFilteredList(EmployeeBindingModel model)
		{
			var context = new EnterpriseDataBase();

			return context.Employees
				.Where(employee => employee.FIO.Contains(model.FIO) && employee.Skill.Contains(model.Skill))
				.ToList().Select(CreateModel).ToList();
		}

		// Получение всех записей
		public List<EmployeeViewModel> GetFullList()
		{
			using (var context = new EnterpriseDataBase())
			{
				return context.Employees.ToList()
					.Select(CreateModel).ToList();
			}
		}
	}
}
