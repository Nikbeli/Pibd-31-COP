using EnterpriseDataBaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseDataBaseImplement
{
	public class EnterpriseDataBase : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (optionsBuilder.IsConfigured == false)
			{
				optionsBuilder.UseSqlServer(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=EnterpriseDataBase;Integrated Security=True;MultipleActiveResultSets=True; TrustServerCertificate=True");
			}

			base.OnConfiguring(optionsBuilder);
		}

		public virtual DbSet<Employee> Employees { set; get; }

		public virtual DbSet<Skill> Skills { set; get; }
	}
}
