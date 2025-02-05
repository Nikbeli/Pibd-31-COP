namespace BelianinComponents
{
	partial class CustomTreeView
	{
		/// <summary> 
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором компонентов

		/// <summary> 
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			treeView = new TreeView();
			SuspendLayout();
			// 
			// treeView
			// 
			treeView.Location = new Point(3, 3);
			treeView.Name = "treeView";
			treeView.Size = new Size(517, 259);
			treeView.TabIndex = 0;
			// 
			// CustomTreeCell
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(treeView);
			Name = "CustomTreeCell";
			Size = new Size(525, 269);
			ResumeLayout(false);
		}

		#endregion

		private TreeView treeView;
	}
}
