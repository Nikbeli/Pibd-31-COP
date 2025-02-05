namespace DesktopWithMyVisualComponents
{
	partial class FormSkill
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			dataGridView = new DataGridView();
			((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
			SuspendLayout();
			// 
			// dataGridView
			// 
			dataGridView.AllowUserToAddRows = false;
			dataGridView.AllowUserToDeleteRows = false;
			dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView.Location = new Point(14, 16);
			dataGridView.Margin = new Padding(3, 4, 3, 4);
			dataGridView.Name = "dataGridView";
			dataGridView.RowHeadersWidth = 51;
			dataGridView.RowTemplate.Height = 25;
			dataGridView.Size = new Size(282, 200);
			dataGridView.TabIndex = 0;
			dataGridView.CellEndEdit += dataGridView_CellEndEdit;
			dataGridView.KeyDown += dataGridView_KeyDown;
			// 
			// FormSkill
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(310, 240);
			Controls.Add(dataGridView);
			KeyPreview = true;
			Margin = new Padding(3, 4, 3, 4);
			Name = "FormSkill";
			Text = "Навыки";
			Load += FormSkill_Load;
			((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private DataGridView dataGridView;
	}
}