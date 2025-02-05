namespace MyCustomComponents
{
	partial class CustomSelectedCheckedListBoxProperty
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
			checkedListBox = new CheckedListBox();
			SuspendLayout();
			// 
			// checkedListBox
			// 
			checkedListBox.FormattingEnabled = true;
			checkedListBox.Location = new Point(4, 4);
			checkedListBox.Name = "checkedListBox";
			checkedListBox.Size = new Size(164, 180);
			checkedListBox.TabIndex = 0;
			// 
			// CustomSelectedCheckedListBoxProperty
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(checkedListBox);
			Name = "CustomSelectedCheckedListBoxProperty";
			Size = new Size(171, 209);
			ResumeLayout(false);
		}

		#endregion

		private CheckedListBox checkedListBox;
	}
}
