using EnterpriseBusinessLogic.BusinessLogics;
using EnterpriseContracts.BusinessLogicContracts;
using EnterpriseContracts.StorageContracts;
using EnterpriseDataBaseImplement.Implements;
using Unity;
using Unity.Lifetime;

namespace DesktopWithPlugins
{
	internal static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			ApplicationConfiguration.Initialize();
			Application.Run(new FormMain());
		}
	}
}