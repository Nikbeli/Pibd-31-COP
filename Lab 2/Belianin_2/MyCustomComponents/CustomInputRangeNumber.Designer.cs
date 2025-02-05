namespace MyCustomComponents
{
	partial class CustomInputRangeNumber
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
			numericUpDown = new NumericUpDown();
			((System.ComponentModel.ISupportInitialize)numericUpDown).BeginInit();
			SuspendLayout();
			// 
			// numericUpDown
			// 
			numericUpDown.Location = new Point(3, 2);
			numericUpDown.Margin = new Padding(3, 2, 3, 2);
			numericUpDown.Name = "numericUpDown";
			numericUpDown.Size = new Size(131, 23);
			numericUpDown.TabIndex = 0;
			// 
			// CustomInputRangeNumber
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(numericUpDown);
			Margin = new Padding(3, 2, 3, 2);
			Name = "CustomInputRangeNumber";
			Size = new Size(141, 27);
			((System.ComponentModel.ISupportInitialize)numericUpDown).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private NumericUpDown numericUpDown;
	}
}
