using BelianinComponents;
using BelianinComponents.Models;
using EnterpriseContracts.BindingModels;
using EnterpriseContracts.BusinessLogicContracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EnterpriseContracts.ViewModels;
using EnterpriseDataBaseImplement.Models;
using Unity;
using BarsukovComponents.NotVisualComponents.Configs;

namespace DesktopWithMyVisualComponents
{
	public partial class FormMain : Form
	{
		private readonly IEmployeeLogic _employeeLogic;

		private readonly ISkillLogic _skillLogic;

		// Конструктор
		public FormMain(IEmployeeLogic employeeLogic, ISkillLogic skillLogic)
		{
			InitializeComponent();
			_employeeLogic = employeeLogic;

			krykovItemTable.ConfigColumn(new()
			{
				ColumnsCount = 4,
				NameColumn = new string[] { "Id", "ФИО", "Навык", "Номер телефона" },
				Width = new int[] { 10, 150, 250, 200 },
				Visible = new bool[] { false, true, true, true },
				PropertiesObject = new string[] { "Id", "FIO", "Skill", "PhoneNumber" }
			});

			_skillLogic = skillLogic;
		}

		private void FormMain_Load(object sender, EventArgs e)
		{
			LoadData();
		}

		private void LoadData()
		{
			try
			{
				krykovItemTable.ClearDataGrid();
				// Поиск записей в бд
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
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var form = Program.Container.Resolve<FormEmployee>();
			if (form.ShowDialog() == DialogResult.OK)
			{
				LoadData();
			}
		}

		private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var form = Program.Container.Resolve<FormEmployee>();

			form.Id = Convert.ToInt32(krykovItemTable.GetSelectedObjectInRow<Employee>().Id);

			if (form.ShowDialog() == DialogResult.OK)
			{
				LoadData();
			}
		}

		private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				int id = Convert.ToInt32(krykovItemTable.GetSelectedObjectInRow<Employee>().Id);

				try
				{
					_employeeLogic.Delete(new EmployeeBindingModel { Id = id });
					krykovItemTable.ClearDataGrid();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}

				LoadData();
			}
		}

		private void навыкиToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var form = Program.Container.Resolve<FormSkill>();

			form.ShowDialog();
		}

		private byte[] StringToImage(string bytes)
		{
			byte[] arrayimg = Convert.FromBase64String(bytes);

			return arrayimg;
		}

		private void wordСФотоToolStripMenuItem_Click(object sender, EventArgs e)
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

			wordWithImages.CreateDoc(new WordWithImageConfig
			{
				FilePath = fileName,
				Header = "Фотографии:",
				Images = list_images
			});
		}

		private void pdfТаблицаToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string fileName = "";

			using (var dialog = new
			SaveFileDialog
			{ Filter = "pdf|*.pdf" })
			{
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					fileName = dialog.FileName.ToString();
					MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}

			// Вызов метода CreateTable
			componentTableToPdf.CreateDoc(new ComponentTableToPdfConfig<EmployeeViewModel>
			{
				// Путь к файлу
				FilePath = fileName,
				// Заголовок таблицы
				Header = "Таблица с сотрудниками",
				UseUnion = true,
				// Информация о колонках
				ColumnsRowsWidth = new List<(int, int)> { (20, 0), (20, 0), (20, 0), (20, 0) },
				// Объединённые ячейки
				ColumnUnion = new List<(int StartIndex, int Count)> { (2, 2) },

				Headers = new List<(int ColumnIndex, int RowIndex, string Header, string PropertyName)>()
				{
					(0, 0, "Идент.", "Id"),
					(1, 0, "ФИО", "FIO"),
					(2, 0, "Работа", ""),
					(2, 1, "Номер телефона", "PhoneNumber"),
					(3, 1, "Навык", "Skill")
				},

				// Данные для таблицы
				Data = _employeeLogic.Read(null)
			});
		}

		private void excelГистограммаToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string fileName = "";

			using (var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" })
			{
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					fileName = dialog.FileName.ToString();
					MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
				   MessageBoxIcon.Information);
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

			excelGistogram.CreateDoc(new()
			{
				FilePath = fileName,
				Header = "Chart",
				ChartTitle = "BarChart",
				LegendLocation = KryukovLib.Models.Location.Top,
				Data = new Dictionary<string, List<(string Date, double Value)>>
				{
					{ "Series 1", list2D }
				}
			});
		}
	}
}
