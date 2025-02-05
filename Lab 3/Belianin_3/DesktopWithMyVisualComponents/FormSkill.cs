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

namespace DesktopWithMyVisualComponents
{
	public partial class FormSkill : Form
	{
		private readonly ISkillLogic _skillLogic;

		BindingList<SkillBindingModel> list;

		public FormSkill(ISkillLogic skillLogic)
		{
			InitializeComponent();

			_skillLogic = skillLogic;
			dataGridView.AllowUserToDeleteRows = true;
			list = new BindingList<SkillBindingModel>();
		}

		private void LoadData()
		{
			try
			{
				var list1 = _skillLogic.Read(null);
				list.Clear();

				foreach (var item in list1)
				{
					list.Add(new SkillBindingModel
					{
						Id = item.Id,
						Name = item.Name,
					});
				}

				if (list != null)
				{
					dataGridView.DataSource = list;
					dataGridView.Columns[0].Visible = false;
					dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void FormSkill_Load(object sender, EventArgs e)
		{
			LoadData();
		}

		private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			var typeName = (string)dataGridView.CurrentRow.Cells[1].Value;

			if (!string.IsNullOrEmpty(typeName))
			{
				if (dataGridView.CurrentRow.Cells[0].Value != null)
				{
					_skillLogic.CreateOrUpdate(new SkillBindingModel()
					{
						Id = Convert.ToInt32(dataGridView.CurrentRow.Cells[0].Value),
						Name = (string)dataGridView.CurrentRow.Cells[1].EditedFormattedValue
					});
				}
				else
				{
					_skillLogic.CreateOrUpdate(new SkillBindingModel()
					{
						Name = (string)dataGridView.CurrentRow.Cells[1].EditedFormattedValue
					});
				}
			}
			else
			{
				MessageBox.Show("Введена пустая строка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			LoadData();
		}

		private void dataGridView_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Insert)
			{
				if (dataGridView.Rows.Count == 0)
				{
					list.Add(new SkillBindingModel());
					dataGridView.DataSource = new List<SkillBindingModel>(list);
					dataGridView.CurrentCell = dataGridView.Rows[0].Cells[1];

					return;
				}

				if (dataGridView.Rows[dataGridView.Rows.Count - 1].Cells[1].Value != null)
				{
					list.Add(new SkillBindingModel());
					dataGridView.DataSource = new List<SkillBindingModel>(list);
					dataGridView.CurrentCell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells[1];

					return;
				}
			}

			if (e.KeyData == Keys.Delete)
			{
				if (dataGridView.SelectedRows.Count == 1)
				{
					if (MessageBox.Show("Удалить запись?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["Id"].Value);

						try
						{
							if (!_skillLogic.Delete(new SkillBindingModel() { Id = id }))
							{
								throw new Exception("Ошибка при удалении");
							}

							dataGridView.Rows.RemoveAt(dataGridView.SelectedRows[0].Index);

							LoadData();
						}
						catch (Exception ex)
						{
							MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					}
				}
			}
		}
	}
}
