namespace DesktopWithMyVisualComponents
{
	partial class FormEmployee
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
			labelFIO = new Label();
			textBoxFIO = new TextBox();
			labelPhoneNumber = new Label();
			barsukovTextBoxPhoneNumber = new BarsukovComponents.VisualComponents.CustomTextBox();
			labelSkill = new Label();
			customSelectedCheckedListBoxProperty = new BelianinComponents.CustomSelectedCheckedListBoxProperty();
			buttonPhoto = new Button();
			buttonSave = new Button();
			buttonCancelAdd = new Button();
			pictureBoxPhoto = new PictureBox();
			((System.ComponentModel.ISupportInitialize)pictureBoxPhoto).BeginInit();
			SuspendLayout();
			// 
			// labelFIO
			// 
			labelFIO.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			labelFIO.AutoSize = true;
			labelFIO.Location = new Point(30, 10);
			labelFIO.Name = "labelFIO";
			labelFIO.Size = new Size(45, 20);
			labelFIO.TabIndex = 0;
			labelFIO.Text = "ФИО:";
			// 
			// textBoxFIO
			// 
			textBoxFIO.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			textBoxFIO.Location = new Point(35, 34);
			textBoxFIO.Margin = new Padding(3, 4, 3, 4);
			textBoxFIO.Name = "textBoxFIO";
			textBoxFIO.Size = new Size(493, 27);
			textBoxFIO.TabIndex = 1;
			// 
			// labelPhoneNumber
			// 
			labelPhoneNumber.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			labelPhoneNumber.AutoSize = true;
			labelPhoneNumber.Location = new Point(242, 98);
			labelPhoneNumber.Name = "labelPhoneNumber";
			labelPhoneNumber.Size = new Size(130, 20);
			labelPhoneNumber.TabIndex = 2;
			labelPhoneNumber.Text = "Номер телефона:";
			// 
			// barsukovTextBoxPhoneNumber
			// 
			barsukovTextBoxPhoneNumber.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			barsukovTextBoxPhoneNumber.BorderStyle = BorderStyle.FixedSingle;
			barsukovTextBoxPhoneNumber.Location = new Point(242, 122);
			barsukovTextBoxPhoneNumber.Margin = new Padding(3, 4, 3, 4);
			barsukovTextBoxPhoneNumber.Name = "barsukovTextBoxPhoneNumber";
			barsukovTextBoxPhoneNumber.numberPattern = "";
			barsukovTextBoxPhoneNumber.Size = new Size(275, 81);
			barsukovTextBoxPhoneNumber.TabIndex = 3;
			barsukovTextBoxPhoneNumber.textBoxNumber = "";
			barsukovTextBoxPhoneNumber.Enter += barsukovTextBoxPhoneNumber_Enter;
			// 
			// labelSkill
			// 
			labelSkill.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			labelSkill.AutoSize = true;
			labelSkill.Location = new Point(35, 65);
			labelSkill.Name = "labelSkill";
			labelSkill.Size = new Size(57, 20);
			labelSkill.TabIndex = 4;
			labelSkill.Text = "Навык:";
			// 
			// customSelectedCheckedListBoxProperty
			// 
			customSelectedCheckedListBoxProperty.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			customSelectedCheckedListBoxProperty.Location = new Point(34, 84);
			customSelectedCheckedListBoxProperty.Margin = new Padding(3, 4, 3, 4);
			customSelectedCheckedListBoxProperty.Name = "customSelectedCheckedListBoxProperty";
			customSelectedCheckedListBoxProperty.SelectedElement = "";
			customSelectedCheckedListBoxProperty.Size = new Size(202, 207);
			customSelectedCheckedListBoxProperty.TabIndex = 5;
			// 
			// buttonPhoto
			// 
			buttonPhoto.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			buttonPhoto.Location = new Point(35, 615);
			buttonPhoto.Margin = new Padding(3, 4, 3, 4);
			buttonPhoto.Name = "buttonPhoto";
			buttonPhoto.Size = new Size(494, 48);
			buttonPhoto.TabIndex = 6;
			buttonPhoto.Text = "Загрузить фото";
			buttonPhoto.UseVisualStyleBackColor = true;
			buttonPhoto.Click += buttonPhoto_Click;
			// 
			// buttonSave
			// 
			buttonSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			buttonSave.Location = new Point(309, 671);
			buttonSave.Margin = new Padding(3, 4, 3, 4);
			buttonSave.Name = "buttonSave";
			buttonSave.Size = new Size(101, 41);
			buttonSave.TabIndex = 7;
			buttonSave.Text = "Сохранить";
			buttonSave.UseVisualStyleBackColor = true;
			buttonSave.Click += buttonSave_Click;
			// 
			// buttonCancelAdd
			// 
			buttonCancelAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			buttonCancelAdd.Location = new Point(427, 671);
			buttonCancelAdd.Margin = new Padding(3, 4, 3, 4);
			buttonCancelAdd.Name = "buttonCancelAdd";
			buttonCancelAdd.Size = new Size(102, 41);
			buttonCancelAdd.TabIndex = 8;
			buttonCancelAdd.Text = "Отмена";
			buttonCancelAdd.UseVisualStyleBackColor = true;
			buttonCancelAdd.Click += buttonCancelAdd_Click;
			// 
			// pictureBoxPhoto
			// 
			pictureBoxPhoto.Location = new Point(35, 281);
			pictureBoxPhoto.Margin = new Padding(3, 4, 3, 4);
			pictureBoxPhoto.Name = "pictureBoxPhoto";
			pictureBoxPhoto.Size = new Size(493, 327);
			pictureBoxPhoto.TabIndex = 9;
			pictureBoxPhoto.TabStop = false;
			// 
			// FormEmployee
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(559, 717);
			Controls.Add(pictureBoxPhoto);
			Controls.Add(buttonCancelAdd);
			Controls.Add(buttonSave);
			Controls.Add(buttonPhoto);
			Controls.Add(customSelectedCheckedListBoxProperty);
			Controls.Add(labelSkill);
			Controls.Add(barsukovTextBoxPhoneNumber);
			Controls.Add(labelPhoneNumber);
			Controls.Add(textBoxFIO);
			Controls.Add(labelFIO);
			KeyPreview = true;
			Margin = new Padding(3, 4, 3, 4);
			Name = "FormEmployee";
			Text = "Сотрудник";
			Load += FormEmployee_Load;
			((System.ComponentModel.ISupportInitialize)pictureBoxPhoto).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label labelFIO;
		private TextBox textBoxFIO;
		private Label labelPhoneNumber;
		private BarsukovComponents.VisualComponents.CustomTextBox barsukovTextBoxPhoneNumber;
		private Label labelSkill;
		private BelianinComponents.CustomSelectedCheckedListBoxProperty customSelectedCheckedListBoxProperty;
		private Button buttonPhoto;
		private Button buttonSave;
		private Button buttonCancelAdd;
		private PictureBox pictureBoxPhoto;
	}
}