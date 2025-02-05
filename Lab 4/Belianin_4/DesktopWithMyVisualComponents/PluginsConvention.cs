using BarsukovComponents.NotVisualComponents.Configs;
using BelianinComponents.Models;
using BelianinComponents;
using EnterpriseBusinessLogic.BusinessLogics;
using EnterpriseContracts.BindingModels;
using EnterpriseContracts.BusinessLogicContracts;
using EnterpriseContracts.ViewModels;
using KryukovLib;
using PluginsConventionLibrary.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluginsConventionLibrary;
using BarsukovComponents.NotVisualComponents;

namespace DesktopWithMyVisualComponents
{
	public class PluginsConvention : IPluginsConvention
	{
		private CustomDataGridView krykovItemTable;

		private readonly IEmployeeLogic _employeeLogic;

		private readonly ISkillLogic _skillLogic;

		public PluginsConvention()
		{
			_employeeLogic = new EmployeeLogic();
			_skillLogic = new SkillLogic();

			krykovItemTable = new CustomDataGridView();
			var menu = new ContextMenuStrip();

			var skillMenuItem = new ToolStripMenuItem("Формы");
			menu.Items.Add(skillMenuItem);

			skillMenuItem.Click += (sender, e) =>
			{
				var formSkill = new FormSkill(_skillLogic);
				formSkill.ShowDialog();
			};

			krykovItemTable.ContextMenuStrip = menu;
			ReloadData();
		}

		/// Название плагина
		string IPluginsConvention.PluginName => PluginName();
		public string PluginName()
		{
			return "Сотрудники";
		}

		public UserControl GetControl => krykovItemTable;

		PluginsConventionElement IPluginsConvention.GetElement => GetElement();

		public PluginsConventionElement GetElement()
		{
			var employee = krykovItemTable.GetSelectedObjectInRow<MainPluginConventionElement>(); ;
			MainPluginConventionElement element = null;

			if (krykovItemTable != null)
			{
				element = new MainPluginConventionElement
				{
					Id = employee.Id,
					FIO = employee.FIO,
					PhoneNumber = employee.PhoneNumber,
					Photo = employee.Photo,
					Skill = employee.Skill,
				};
			}

			return (new PluginsConventionElement { Id = element.Id });
		}

		public Form GetForm(PluginsConventionElement element)
		{
			var formEmployee = new FormEmployee(_employeeLogic, _skillLogic);

			if (element != null)
			{
				formEmployee.Id = element.Id;
			}

			return formEmployee;
		}

		public bool DeleteElement(PluginsConventionElement element)
		{
			try
			{
				_employeeLogic.Delete(new EmployeeBindingModel { Id = element.Id });
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}

			return true;
		}

		public void ReloadData()
		{
			krykovItemTable.ClearDataGrid();
			krykovItemTable.ClearDataGrid();

			krykovItemTable.ConfigColumn(new()
			{
				ColumnsCount = 4,
				NameColumn = new string[] { "Id", "ФИО", "Навык", "Номер телефона" },
				Width = new int[] { 10, 150, 250, 200 },
				Visible = new bool[] { false, true, true, true },
				PropertiesObject = new string[] { "Id", "FIO", "Skill", "PhoneNumber" }
			});

			var list = _employeeLogic.Read(null);
			
			if (list != null)
			{
				for (int j = 0; j < list.Count; j++)
				{
					krykovItemTable.AddItem(list[j], j);
					krykovItemTable.Update();
				}
			}
		}

		private byte[] StringToImage(string bytes)
		{
			byte[] arrayimg = Convert.FromBase64String(bytes);
			return arrayimg;
		}

		public bool CreateSimpleDocument(PluginsConventionSaveDocument saveDocument)
		{
			try
			{
				string fileName = "";

				using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" })
				{
					if (dialog.ShowDialog() == DialogResult.OK)
					{
						fileName = dialog.FileName.ToString();
						MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}

				var list = _employeeLogic.Read(null);
				var list_images = new List<byte[]>();

				foreach (var item in list)
				{
					var img = StringToImage(item.Photo);
					list_images.Add(img);
				}

				WordWithImages wordWithImages = new WordWithImages();
				wordWithImages.CreateDoc(new WordWithImageConfig
				{
					FilePath = fileName,
					Header = "Фотографии:",
					Images = list_images
				});
			}
			catch (Exception)
			{
				return false;
			}

			return true;
		}

		public bool CreateTableDocument(PluginsConventionSaveDocument saveDocument)
		{
			try
			{
				string fileName = "";

				using (var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" })
				{
					if (dialog.ShowDialog() == DialogResult.OK)
					{
						fileName = dialog.FileName.ToString();
						MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
						MessageBoxIcon.Information);
					}
				}

				PdfTable componentTableToPdf = new PdfTable();
				componentTableToPdf.CreateDoc(new ComponentTableToPdfConfig<EmployeeViewModel>
				{
					FilePath = fileName,
					Header = "Таблица с сотрудниками",
					UseUnion = true,
					ColumnsRowsWidth = new List<(int, int)> { (20, 0), (20, 0), (20, 0), (20, 0) },
					ColumnUnion = new List<(int StartIndex, int Count)> { (2, 2) },

					Headers = new List<(int ColumnIndex, int RowIndex, string Header, string PropertyName)>
					{
						(0, 0, "Идент.", "Id"),
						(1, 0, "ФИО", "FIO"),
						(2, 0, "Работа", ""),
						(2, 1, "Номер телефона", "PhoneNumber"),
						(3, 1, "Навык", "Skill")
					},
					
					Data = _employeeLogic.Read(null)
				});
			}
			catch (Exception)
			{
				return false;
			}

			return true;
		}

		public bool CreateChartDocument(PluginsConventionSaveDocument saveDocument)
		{
			try
			{
				string fileName = "";

				using (var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" })
				{
					if (dialog.ShowDialog() == DialogResult.OK)
					{
						fileName = dialog.FileName.ToString();
						MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}

				var list2D = new List<(string Date, double Value)>();

				var emps = _employeeLogic.Read(null);
				var skills = _skillLogic.Read(null);

				foreach (var skill in skills)
				{
					double count = 0;

					foreach (var emp in emps)
					{
						if (skill.Name.Equals(emp.Skill))
						{
							count++;
						}
					}

					var elem = (skill.Name, count);
					list2D.Add(elem);
				}

				ExcelGistogram excelGistogram = new ExcelGistogram();

				excelGistogram.CreateDoc(new()
				{
					FilePath = fileName,
					Header = "Chart",
					ChartTitle = "BarChart",
					LegendLocation = KryukovLib.Models.Location.Top,
					Data = new Dictionary<string, List<(string Date, double Value)>> {
						{ "Series 1", list2D }
					}
				});
			}
			catch (Exception)
			{
				return false;
			}

			return true;
		}

		public Form GetThesaurus()
		{
			return new FormSkill(_skillLogic);
		}
	}
}
