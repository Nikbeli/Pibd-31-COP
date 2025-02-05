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
			customInputRangeNumber = new MyCustomComponents.CustomInputRangeNumber();
			buttonCheck = new Button();
			labelCheckValue = new Label();
			textBoxMin = new TextBox();
			textBoxMax = new TextBox();
			buttonSetBorders = new Button();
			labelMin = new Label();
			labelMax = new Label();
			labelRange = new Label();
			groupBoxInput = new GroupBox();
			groupBoxSelected = new GroupBox();
			buttonGetSelected = new Button();
			labelSelectedValue = new Label();
			buttonClear = new Button();
			buttonAdd = new Button();
			textBoxAdd = new TextBox();
			customSelectedCheckedListBoxProperty = new MyCustomComponents.CustomSelectedCheckedListBoxProperty();
			groupBoxData = new GroupBox();
			labelTransportType = new Label();
			labelModel = new Label();
			labelRegNum = new Label();
			buttonGetFromTree = new Button();
			buttonAddToTree = new Button();
			comboBoxTransportType = new ComboBox();
			textBoxModel = new TextBox();
			textBoxRegNumber = new TextBox();
			customTreeCell = new MyCustomComponents.CustomTreeCell();
			groupBoxInput.SuspendLayout();
			groupBoxSelected.SuspendLayout();
			groupBoxData.SuspendLayout();
			SuspendLayout();
			// 
			// customInputRangeNumber
			// 
			customInputRangeNumber.AutoValidate = AutoValidate.Disable;
			customInputRangeNumber.CausesValidation = false;
			customInputRangeNumber.Location = new Point(30, 19);
			customInputRangeNumber.Margin = new Padding(3, 2, 3, 2);
			customInputRangeNumber.MaxValue = new decimal(new int[] { -1, -1, -1, 0 });
			customInputRangeNumber.MinValue = new decimal(new int[] { -1, -1, -1, int.MinValue });
			customInputRangeNumber.Name = "customInputRangeNumber";
			customInputRangeNumber.Size = new Size(126, 30);
			customInputRangeNumber.TabIndex = 0;
			customInputRangeNumber.Value = new decimal(new int[] { 0, 0, 0, 0 });
			// 
			// buttonCheck
			// 
			buttonCheck.Location = new Point(169, 22);
			buttonCheck.Name = "buttonCheck";
			buttonCheck.Size = new Size(126, 23);
			buttonCheck.TabIndex = 1;
			buttonCheck.Text = "Check";
			buttonCheck.UseVisualStyleBackColor = true;
			buttonCheck.Click += buttonCheck_Click;
			// 
			// labelCheckValue
			// 
			labelCheckValue.AutoSize = true;
			labelCheckValue.Location = new Point(30, 111);
			labelCheckValue.Name = "labelCheckValue";
			labelCheckValue.Size = new Size(65, 15);
			labelCheckValue.TabIndex = 2;
			labelCheckValue.Text = "Enter value";
			// 
			// textBoxMin
			// 
			textBoxMin.Location = new Point(30, 71);
			textBoxMin.Name = "textBoxMin";
			textBoxMin.Size = new Size(55, 23);
			textBoxMin.TabIndex = 3;
			textBoxMin.KeyPress += textBoxMin_KeyPress;
			// 
			// textBoxMax
			// 
			textBoxMax.Location = new Point(103, 71);
			textBoxMax.Name = "textBoxMax";
			textBoxMax.Size = new Size(53, 23);
			textBoxMax.TabIndex = 4;
			textBoxMax.KeyPress += textBoxMax_KeyPress;
			// 
			// buttonSetBorders
			// 
			buttonSetBorders.Location = new Point(169, 71);
			buttonSetBorders.Name = "buttonSetBorders";
			buttonSetBorders.Size = new Size(126, 23);
			buttonSetBorders.TabIndex = 5;
			buttonSetBorders.Text = "Set Borders";
			buttonSetBorders.UseVisualStyleBackColor = true;
			buttonSetBorders.Click += buttonSetBorders_Click;
			// 
			// labelMin
			// 
			labelMin.AutoSize = true;
			labelMin.Location = new Point(29, 54);
			labelMin.Name = "labelMin";
			labelMin.Size = new Size(56, 15);
			labelMin.TabIndex = 6;
			labelMin.Text = "MinValue";
			// 
			// labelMax
			// 
			labelMax.AutoSize = true;
			labelMax.Location = new Point(101, 54);
			labelMax.Name = "labelMax";
			labelMax.Size = new Size(58, 15);
			labelMax.TabIndex = 7;
			labelMax.Text = "MaxValue";
			// 
			// labelRange
			// 
			labelRange.AutoSize = true;
			labelRange.Location = new Point(88, 75);
			labelRange.Name = "labelRange";
			labelRange.Size = new Size(12, 15);
			labelRange.TabIndex = 8;
			labelRange.Text = "-";
			// 
			// groupBoxInput
			// 
			groupBoxInput.Controls.Add(customInputRangeNumber);
			groupBoxInput.Controls.Add(labelCheckValue);
			groupBoxInput.Controls.Add(labelRange);
			groupBoxInput.Controls.Add(buttonCheck);
			groupBoxInput.Controls.Add(labelMax);
			groupBoxInput.Controls.Add(textBoxMin);
			groupBoxInput.Controls.Add(labelMin);
			groupBoxInput.Controls.Add(textBoxMax);
			groupBoxInput.Controls.Add(buttonSetBorders);
			groupBoxInput.Location = new Point(12, 252);
			groupBoxInput.Name = "groupBoxInput";
			groupBoxInput.Size = new Size(311, 190);
			groupBoxInput.TabIndex = 9;
			groupBoxInput.TabStop = false;
			groupBoxInput.Text = "Input";
			// 
			// groupBoxSelected
			// 
			groupBoxSelected.Controls.Add(buttonGetSelected);
			groupBoxSelected.Controls.Add(labelSelectedValue);
			groupBoxSelected.Controls.Add(buttonClear);
			groupBoxSelected.Controls.Add(buttonAdd);
			groupBoxSelected.Controls.Add(textBoxAdd);
			groupBoxSelected.Controls.Add(customSelectedCheckedListBoxProperty);
			groupBoxSelected.Location = new Point(340, 253);
			groupBoxSelected.Name = "groupBoxSelected";
			groupBoxSelected.Size = new Size(311, 190);
			groupBoxSelected.TabIndex = 10;
			groupBoxSelected.TabStop = false;
			groupBoxSelected.Text = "Selected";
			// 
			// buttonGetSelected
			// 
			buttonGetSelected.Location = new Point(192, 144);
			buttonGetSelected.Name = "buttonGetSelected";
			buttonGetSelected.Size = new Size(100, 23);
			buttonGetSelected.TabIndex = 14;
			buttonGetSelected.Text = "Get Selected";
			buttonGetSelected.UseVisualStyleBackColor = true;
			buttonGetSelected.Click += buttonGetSelected_Click;
			// 
			// labelSelectedValue
			// 
			labelSelectedValue.AutoSize = true;
			labelSelectedValue.Location = new Point(192, 111);
			labelSelectedValue.Name = "labelSelectedValue";
			labelSelectedValue.Size = new Size(82, 15);
			labelSelectedValue.TabIndex = 11;
			labelSelectedValue.Text = "Selected value";
			// 
			// buttonClear
			// 
			buttonClear.Location = new Point(192, 81);
			buttonClear.Name = "buttonClear";
			buttonClear.Size = new Size(100, 23);
			buttonClear.TabIndex = 13;
			buttonClear.Text = "Clear";
			buttonClear.UseVisualStyleBackColor = true;
			buttonClear.Click += buttonClear_Click;
			// 
			// buttonAdd
			// 
			buttonAdd.Location = new Point(192, 52);
			buttonAdd.Name = "buttonAdd";
			buttonAdd.Size = new Size(100, 23);
			buttonAdd.TabIndex = 12;
			buttonAdd.Text = "Add or Select";
			buttonAdd.UseVisualStyleBackColor = true;
			buttonAdd.Click += buttonAdd_Click;
			// 
			// textBoxAdd
			// 
			textBoxAdd.Location = new Point(192, 23);
			textBoxAdd.Name = "textBoxAdd";
			textBoxAdd.Size = new Size(100, 23);
			textBoxAdd.TabIndex = 11;
			// 
			// customSelectedCheckedListBoxProperty
			// 
			customSelectedCheckedListBoxProperty.Location = new Point(36, 19);
			customSelectedCheckedListBoxProperty.Margin = new Padding(3, 2, 3, 2);
			customSelectedCheckedListBoxProperty.Name = "customSelectedCheckedListBoxProperty";
			customSelectedCheckedListBoxProperty.SelectedElement = "";
			customSelectedCheckedListBoxProperty.Size = new Size(150, 157);
			customSelectedCheckedListBoxProperty.TabIndex = 0;
			// 
			// groupBoxData
			// 
			groupBoxData.Controls.Add(labelTransportType);
			groupBoxData.Controls.Add(labelModel);
			groupBoxData.Controls.Add(labelRegNum);
			groupBoxData.Controls.Add(buttonGetFromTree);
			groupBoxData.Controls.Add(buttonAddToTree);
			groupBoxData.Controls.Add(comboBoxTransportType);
			groupBoxData.Controls.Add(textBoxModel);
			groupBoxData.Controls.Add(textBoxRegNumber);
			groupBoxData.Controls.Add(customTreeCell);
			groupBoxData.Location = new Point(12, 12);
			groupBoxData.Name = "groupBoxData";
			groupBoxData.Size = new Size(639, 230);
			groupBoxData.TabIndex = 11;
			groupBoxData.TabStop = false;
			groupBoxData.Text = "Data";
			// 
			// labelTransportType
			// 
			labelTransportType.AutoSize = true;
			labelTransportType.Location = new Point(432, 116);
			labelTransportType.Name = "labelTransportType";
			labelTransportType.Size = new Size(93, 15);
			labelTransportType.TabIndex = 8;
			labelTransportType.Text = "Тип транспорта";
			// 
			// labelModel
			// 
			labelModel.AutoSize = true;
			labelModel.Location = new Point(432, 72);
			labelModel.Name = "labelModel";
			labelModel.Size = new Size(50, 15);
			labelModel.TabIndex = 7;
			labelModel.Text = "Модель";
			// 
			// labelRegNum
			// 
			labelRegNum.AutoSize = true;
			labelRegNum.Location = new Point(432, 28);
			labelRegNum.Name = "labelRegNum";
			labelRegNum.Size = new Size(146, 15);
			labelRegNum.TabIndex = 6;
			labelRegNum.Text = "Регистрационный номер";
			// 
			// buttonGetFromTree
			// 
			buttonGetFromTree.Location = new Point(432, 195);
			buttonGetFromTree.Name = "buttonGetFromTree";
			buttonGetFromTree.Size = new Size(188, 23);
			buttonGetFromTree.TabIndex = 5;
			buttonGetFromTree.Text = "Get Selected";
			buttonGetFromTree.UseVisualStyleBackColor = true;
			buttonGetFromTree.Click += buttonGetFromTree_Click;
			// 
			// buttonAddToTree
			// 
			buttonAddToTree.Location = new Point(432, 166);
			buttonAddToTree.Name = "buttonAddToTree";
			buttonAddToTree.Size = new Size(188, 23);
			buttonAddToTree.TabIndex = 4;
			buttonAddToTree.Text = "Add";
			buttonAddToTree.UseVisualStyleBackColor = true;
			buttonAddToTree.Click += buttonAddToTree_Click;
			// 
			// comboBoxTransportType
			// 
			comboBoxTransportType.FormattingEnabled = true;
			comboBoxTransportType.Location = new Point(432, 134);
			comboBoxTransportType.Name = "comboBoxTransportType";
			comboBoxTransportType.Size = new Size(188, 23);
			comboBoxTransportType.TabIndex = 3;
			// 
			// textBoxModel
			// 
			textBoxModel.Location = new Point(432, 90);
			textBoxModel.Name = "textBoxModel";
			textBoxModel.Size = new Size(188, 23);
			textBoxModel.TabIndex = 2;
			// 
			// textBoxRegNumber
			// 
			textBoxRegNumber.Location = new Point(432, 46);
			textBoxRegNumber.Name = "textBoxRegNumber";
			textBoxRegNumber.Size = new Size(188, 23);
			textBoxRegNumber.TabIndex = 1;
			// 
			// customTreeCell
			// 
			customTreeCell.Location = new Point(15, 22);
			customTreeCell.Margin = new Padding(3, 2, 3, 2);
			customTreeCell.Name = "customTreeCell";
			customTreeCell.Size = new Size(398, 202);
			customTreeCell.TabIndex = 0;
			// 
			// FormMain
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(667, 450);
			Controls.Add(groupBoxData);
			Controls.Add(groupBoxSelected);
			Controls.Add(groupBoxInput);
			Name = "FormMain";
			Text = "FormMain";
			groupBoxInput.ResumeLayout(false);
			groupBoxInput.PerformLayout();
			groupBoxSelected.ResumeLayout(false);
			groupBoxSelected.PerformLayout();
			groupBoxData.ResumeLayout(false);
			groupBoxData.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private MyCustomComponents.CustomInputRangeNumber customInputRangeNumber;
        private Button buttonCheck;
        private Label labelCheckValue;
        private TextBox textBoxMin;
        private TextBox textBoxMax;
        private Button buttonSetBorders;
        private Label labelMin;
        private Label labelMax;
        private Label labelRange;
        private GroupBox groupBoxInput;
        private GroupBox groupBoxSelected;
        private Button buttonGetSelected;
        private Label labelSelectedValue;
        private Button buttonClear;
        private Button buttonAdd;
        private TextBox textBoxAdd;
        private MyCustomComponents.CustomSelectedCheckedListBoxProperty customSelectedCheckedListBoxProperty;
        private GroupBox groupBoxData;
        private MyCustomComponents.CustomTreeCell customTreeCell;
        private Button buttonGetFromTree;
        private Button buttonAddToTree;
        private ComboBox comboBoxTransportType;
        private TextBox textBoxModel;
        private TextBox textBoxRegNumber;
        private Label labelTransportType;
        private Label labelModel;
        private Label labelRegNum;
    }
}