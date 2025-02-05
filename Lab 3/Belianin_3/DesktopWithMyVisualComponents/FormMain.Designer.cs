namespace DesktopWithMyVisualComponents
{
	partial class FormMain
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
			components = new System.ComponentModel.Container();
			menuStrip = new MenuStrip();
			справочникиToolStripMenuItem = new ToolStripMenuItem();
			навыкиToolStripMenuItem = new ToolStripMenuItem();
			действияToolStripMenuItem = new ToolStripMenuItem();
			добавитьToolStripMenuItem = new ToolStripMenuItem();
			изменитьToolStripMenuItem = new ToolStripMenuItem();
			удалитьToolStripMenuItem = new ToolStripMenuItem();
			документыToolStripMenuItem = new ToolStripMenuItem();
			wordСФотоToolStripMenuItem = new ToolStripMenuItem();
			pdfТаблицаToolStripMenuItem = new ToolStripMenuItem();
			excelГистограммаToolStripMenuItem = new ToolStripMenuItem();
			wordWithImages = new BelianinComponents.WordWithImages(components);
			componentTableToPdf = new BarsukovComponents.NotVisualComponents.PdfTable(components);
			krykovItemTable = new KryukovLib.CustomDataGridView();
			excelGistogram = new KryukovLib.ExcelGistogram(components);
			menuStrip.SuspendLayout();
			SuspendLayout();
			// 
			// menuStrip
			// 
			menuStrip.ImageScalingSize = new Size(20, 20);
			menuStrip.Items.AddRange(new ToolStripItem[] { справочникиToolStripMenuItem, действияToolStripMenuItem, документыToolStripMenuItem });
			menuStrip.Location = new Point(0, 0);
			menuStrip.Name = "menuStrip";
			menuStrip.Padding = new Padding(7, 3, 0, 3);
			menuStrip.Size = new Size(661, 30);
			menuStrip.TabIndex = 0;
			menuStrip.Text = "menuStrip";
			// 
			// справочникиToolStripMenuItem
			// 
			справочникиToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { навыкиToolStripMenuItem });
			справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
			справочникиToolStripMenuItem.Size = new Size(117, 24);
			справочникиToolStripMenuItem.Text = "Справочники";
			// 
			// навыкиToolStripMenuItem
			// 
			навыкиToolStripMenuItem.Name = "навыкиToolStripMenuItem";
			навыкиToolStripMenuItem.Size = new Size(146, 26);
			навыкиToolStripMenuItem.Text = "Навыки";
			навыкиToolStripMenuItem.Click += навыкиToolStripMenuItem_Click;
			// 
			// действияToolStripMenuItem
			// 
			действияToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { добавитьToolStripMenuItem, изменитьToolStripMenuItem, удалитьToolStripMenuItem });
			действияToolStripMenuItem.Name = "действияToolStripMenuItem";
			действияToolStripMenuItem.Size = new Size(88, 24);
			действияToolStripMenuItem.Text = "Действия";
			// 
			// добавитьToolStripMenuItem
			// 
			добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
			добавитьToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.A;
			добавитьToolStripMenuItem.Size = new Size(213, 26);
			добавитьToolStripMenuItem.Text = "Добавить";
			добавитьToolStripMenuItem.Click += добавитьToolStripMenuItem_Click;
			// 
			// изменитьToolStripMenuItem
			// 
			изменитьToolStripMenuItem.Name = "изменитьToolStripMenuItem";
			изменитьToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.U;
			изменитьToolStripMenuItem.Size = new Size(213, 26);
			изменитьToolStripMenuItem.Text = "Изменить";
			изменитьToolStripMenuItem.Click += изменитьToolStripMenuItem_Click;
			// 
			// удалитьToolStripMenuItem
			// 
			удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
			удалитьToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.D;
			удалитьToolStripMenuItem.Size = new Size(213, 26);
			удалитьToolStripMenuItem.Text = "Удалить";
			удалитьToolStripMenuItem.Click += удалитьToolStripMenuItem_Click;
			// 
			// документыToolStripMenuItem
			// 
			документыToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { wordСФотоToolStripMenuItem, pdfТаблицаToolStripMenuItem, excelГистограммаToolStripMenuItem });
			документыToolStripMenuItem.Name = "документыToolStripMenuItem";
			документыToolStripMenuItem.Size = new Size(101, 24);
			документыToolStripMenuItem.Text = "Документы";
			// 
			// wordСФотоToolStripMenuItem
			// 
			wordСФотоToolStripMenuItem.Name = "wordСФотоToolStripMenuItem";
			wordСФотоToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
			wordСФотоToolStripMenuItem.Size = new Size(271, 26);
			wordСФотоToolStripMenuItem.Text = "Word с фото";
			wordСФотоToolStripMenuItem.Click += wordСФотоToolStripMenuItem_Click;
			// 
			// pdfТаблицаToolStripMenuItem
			// 
			pdfТаблицаToolStripMenuItem.Name = "pdfТаблицаToolStripMenuItem";
			pdfТаблицаToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.T;
			pdfТаблицаToolStripMenuItem.Size = new Size(271, 26);
			pdfТаблицаToolStripMenuItem.Text = "Pdf таблица";
			pdfТаблицаToolStripMenuItem.Click += pdfТаблицаToolStripMenuItem_Click;
			// 
			// excelГистограммаToolStripMenuItem
			// 
			excelГистограммаToolStripMenuItem.Name = "excelГистограммаToolStripMenuItem";
			excelГистограммаToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
			excelГистограммаToolStripMenuItem.Size = new Size(271, 26);
			excelГистограммаToolStripMenuItem.Text = "Excel гистограмма";
			excelГистограммаToolStripMenuItem.Click += excelГистограммаToolStripMenuItem_Click;
			// 
			// krykovItemTable
			// 
			krykovItemTable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			krykovItemTable.Location = new Point(14, 36);
			krykovItemTable.Margin = new Padding(3, 5, 3, 5);
			krykovItemTable.Name = "krykovItemTable";
			krykovItemTable.Size = new Size(630, 477);
			krykovItemTable.TabIndex = 2;
			// 
			// FormMain
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(661, 529);
			Controls.Add(krykovItemTable);
			Controls.Add(menuStrip);
			MainMenuStrip = menuStrip;
			Margin = new Padding(3, 4, 3, 4);
			Name = "FormMain";
			Text = "Главная";
			Load += FormMain_Load;
			menuStrip.ResumeLayout(false);
			menuStrip.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private MenuStrip menuStrip;
		private ToolStripMenuItem справочникиToolStripMenuItem;
		private ToolStripMenuItem навыкиToolStripMenuItem;
		private ToolStripMenuItem действияToolStripMenuItem;
		private ToolStripMenuItem добавитьToolStripMenuItem;
		private ToolStripMenuItem изменитьToolStripMenuItem;
		private ToolStripMenuItem удалитьToolStripMenuItem;
		private ToolStripMenuItem документыToolStripMenuItem;
		private ToolStripMenuItem wordСФотоToolStripMenuItem;
		private ToolStripMenuItem pdfТаблицаToolStripMenuItem;
		private ToolStripMenuItem excelГистограммаToolStripMenuItem;
		private BelianinComponents.WordWithImages wordWithImages;
		private BarsukovComponents.NotVisualComponents.PdfTable componentTableToPdf;
		private KryukovLib.CustomDataGridView krykovItemTable;
		private KryukovLib.ExcelGistogram excelGistogram;
	}
}