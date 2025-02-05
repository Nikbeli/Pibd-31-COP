using EnterpriseBusinessLogic.BusinessLogics;
using EnterpriseContracts.BusinessLogicContracts;
using EnterpriseContracts.StorageContracts;
using EnterpriseDataBaseImplement.Implements;
using Unity;
using Unity.Lifetime;

namespace DesktopWithMyVisualComponents
{
	internal static class Program
	{
		private static IUnityContainer container = null;

		public static IUnityContainer Container
		{
			get
			{
				if (container == null)
				{
					container = BuildUnityContainer();
				}
				return container;
			}
		}

		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.SetHighDpiMode(HighDpiMode.SystemAware);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(Container.Resolve<FormMain>());
		}
		private static IUnityContainer BuildUnityContainer()
		{
			var currentContainer = new UnityContainer();

			currentContainer.RegisterType<IEmployeeStorage, EmployeeStorage>(new HierarchicalLifetimeManager());
			currentContainer.RegisterType<ISkillStorage, SkillStorage>(new HierarchicalLifetimeManager());

			currentContainer.RegisterType<IEmployeeLogic, EmployeeLogic>(new HierarchicalLifetimeManager());
			currentContainer.RegisterType<ISkillLogic, SkillLogic>(new HierarchicalLifetimeManager());

			return currentContainer;
		}
	}
}