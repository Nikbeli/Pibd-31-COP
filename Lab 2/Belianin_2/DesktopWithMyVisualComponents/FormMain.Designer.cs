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
			this.components = new System.ComponentModel.Container();
			this.customInputRangeNumber = new MyCustomComponents.CustomInputRangeNumber();
			this.buttonCheck = new System.Windows.Forms.Button();
			this.labelCheckValue = new System.Windows.Forms.Label();
			this.groupBoxInput = new System.Windows.Forms.GroupBox();
			this.groupBoxSelected = new System.Windows.Forms.GroupBox();
			this.buttonGetSelected = new System.Windows.Forms.Button();
			this.labelSelectedValue = new System.Windows.Forms.Label();
			this.buttonClear = new System.Windows.Forms.Button();
			this.buttonAdd = new System.Windows.Forms.Button();
			this.textBoxAdd = new System.Windows.Forms.TextBox();
			this.customSelectedCheckedListBoxProperty = new MyCustomComponents.CustomSelectedCheckedListBoxProperty();
			this.groupBoxData = new System.Windows.Forms.GroupBox();
			this.labelDeviceType = new System.Windows.Forms.Label();
			this.labelModel = new System.Windows.Forms.Label();
			this.labelRegNum = new System.Windows.Forms.Label();
			this.buttonGetFromTree = new System.Windows.Forms.Button();
			this.buttonAddToTree = new System.Windows.Forms.Button();
			this.comboBoxDeviceType = new System.Windows.Forms.ComboBox();
			this.textBoxModel = new System.Windows.Forms.TextBox();
			this.textBoxSerialNumber = new System.Windows.Forms.TextBox();
			this.customTreeView = new MyCustomComponents.CustomTreeView();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.Visual = new System.Windows.Forms.TabPage();
			this.Docs = new System.Windows.Forms.TabPage();
			this.buttonWordWithDiagram = new System.Windows.Forms.Button();
			this.buttonWordWithTable = new System.Windows.Forms.Button();
			this.buttonWordWithImage = new System.Windows.Forms.Button();
			this.wordWithImages = new MyCustomComponents.WordWithImages(this.components);
			this.wordWithTable = new MyCustomComponents.WordWithTable(this.components);
			this.wordWithDiagram = new MyCustomComponents.WordWithDiagram(this.components);
			this.groupBoxInput.SuspendLayout();
			this.groupBoxSelected.SuspendLayout();
			this.groupBoxData.SuspendLayout();
			this.tabControl.SuspendLayout();
			this.Visual.SuspendLayout();
			this.Docs.SuspendLayout();
			this.SuspendLayout();
			// 
			// customInputRangeNumber
			// 
			this.customInputRangeNumber.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
			this.customInputRangeNumber.CausesValidation = false;
			this.customInputRangeNumber.Location = new System.Drawing.Point(34, 25);
			this.customInputRangeNumber.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.customInputRangeNumber.MaxValue = new decimal(new int[] { -1, -1, -1, 0});
			this.customInputRangeNumber.MinValue = new decimal(new int[] { -1, -1, -1, -2147483648});
			this.customInputRangeNumber.Name = "customInputRangeNumber";
			this.customInputRangeNumber.Size = new System.Drawing.Size(144, 40);
			this.customInputRangeNumber.TabIndex = 0;
			this.customInputRangeNumber.Value = new decimal(new int[] {	0, 0, 0, 0});
			// 
			// buttonCheck
			// 
			this.buttonCheck.Location = new System.Drawing.Point(193, 29);
			this.buttonCheck.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.buttonCheck.Name = "buttonCheck";
			this.buttonCheck.Size = new System.Drawing.Size(144, 31);
			this.buttonCheck.TabIndex = 1;
			this.buttonCheck.Text = "Check";
			this.buttonCheck.UseVisualStyleBackColor = true;
			this.buttonCheck.Click += new System.EventHandler(this.buttonCheck_Click);
			// 
			// labelCheckValue
			// 
			this.labelCheckValue.AutoSize = true;
			this.labelCheckValue.Location = new System.Drawing.Point(34, 148);
			this.labelCheckValue.Name = "labelCheckValue";
			this.labelCheckValue.Size = new System.Drawing.Size(82, 20);
			this.labelCheckValue.TabIndex = 2;
			this.labelCheckValue.Text = "Enter value";
			// 
			// groupBoxInput
			// 
			this.groupBoxInput.Controls.Add(this.customInputRangeNumber);
			this.groupBoxInput.Controls.Add(this.labelCheckValue);
			this.groupBoxInput.Controls.Add(this.buttonCheck);
			this.groupBoxInput.Location = new System.Drawing.Point(7, 8);
			this.groupBoxInput.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBoxInput.Name = "groupBoxInput";
			this.groupBoxInput.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBoxInput.Size = new System.Drawing.Size(355, 253);
			this.groupBoxInput.TabIndex = 9;
			this.groupBoxInput.TabStop = false;
			this.groupBoxInput.Text = "Input";
			// 
			// groupBoxSelected
			// 
			this.groupBoxSelected.Controls.Add(this.buttonGetSelected);
			this.groupBoxSelected.Controls.Add(this.labelSelectedValue);
			this.groupBoxSelected.Controls.Add(this.buttonClear);
			this.groupBoxSelected.Controls.Add(this.buttonAdd);
			this.groupBoxSelected.Controls.Add(this.textBoxAdd);
			this.groupBoxSelected.Controls.Add(this.customSelectedCheckedListBoxProperty);
			this.groupBoxSelected.Location = new System.Drawing.Point(370, 8);
			this.groupBoxSelected.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBoxSelected.Name = "groupBoxSelected";
			this.groupBoxSelected.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBoxSelected.Size = new System.Drawing.Size(355, 253);
			this.groupBoxSelected.TabIndex = 10;
			this.groupBoxSelected.TabStop = false;
			this.groupBoxSelected.Text = "Selected";
			// 
			// buttonGetSelected
			// 
			this.buttonGetSelected.Location = new System.Drawing.Point(219, 192);
			this.buttonGetSelected.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.buttonGetSelected.Name = "buttonGetSelected";
			this.buttonGetSelected.Size = new System.Drawing.Size(114, 31);
			this.buttonGetSelected.TabIndex = 14;
			this.buttonGetSelected.Text = "Get Selected";
			this.buttonGetSelected.UseVisualStyleBackColor = true;
			this.buttonGetSelected.Click += new System.EventHandler(this.buttonGetSelected_Click);
			// 
			// labelSelectedValue
			// 
			this.labelSelectedValue.AutoSize = true;
			this.labelSelectedValue.Location = new System.Drawing.Point(219, 148);
			this.labelSelectedValue.Name = "labelSelectedValue";
			this.labelSelectedValue.Size = new System.Drawing.Size(105, 20);
			this.labelSelectedValue.TabIndex = 11;
			this.labelSelectedValue.Text = "Selected value";
			// 
			// buttonClear
			// 
			this.buttonClear.Location = new System.Drawing.Point(219, 108);
			this.buttonClear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.buttonClear.Name = "buttonClear";
			this.buttonClear.Size = new System.Drawing.Size(114, 31);
			this.buttonClear.TabIndex = 13;
			this.buttonClear.Text = "Clear";
			this.buttonClear.UseVisualStyleBackColor = true;
			this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
			// 
			// buttonAdd
			// 
			this.buttonAdd.Location = new System.Drawing.Point(219, 69);
			this.buttonAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.Size = new System.Drawing.Size(114, 31);
			this.buttonAdd.TabIndex = 12;
			this.buttonAdd.Text = "Add or Select";
			this.buttonAdd.UseVisualStyleBackColor = true;
			this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
			// 
			// textBoxAdd
			// 
			this.textBoxAdd.Location = new System.Drawing.Point(219, 31);
			this.textBoxAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.textBoxAdd.Name = "textBoxAdd";
			this.textBoxAdd.Size = new System.Drawing.Size(114, 27);
			this.textBoxAdd.TabIndex = 11;
			// 
			// customSelectedCheckedListBoxProperty
			// 
			this.customSelectedCheckedListBoxProperty.Location = new System.Drawing.Point(41, 25);
			this.customSelectedCheckedListBoxProperty.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.customSelectedCheckedListBoxProperty.Name = "customSelectedCheckedListBoxProperty";
			this.customSelectedCheckedListBoxProperty.SelectedElement = "";
			this.customSelectedCheckedListBoxProperty.Size = new System.Drawing.Size(171, 209);
			this.customSelectedCheckedListBoxProperty.TabIndex = 0;
			// 
			// groupBoxData
			// 
			this.groupBoxData.Controls.Add(this.labelDeviceType);
			this.groupBoxData.Controls.Add(this.labelModel);
			this.groupBoxData.Controls.Add(this.labelRegNum);
			this.groupBoxData.Controls.Add(this.buttonGetFromTree);
			this.groupBoxData.Controls.Add(this.buttonAddToTree);
			this.groupBoxData.Controls.Add(this.comboBoxDeviceType);
			this.groupBoxData.Controls.Add(this.textBoxModel);
			this.groupBoxData.Controls.Add(this.textBoxSerialNumber);
			this.groupBoxData.Controls.Add(this.customTreeView);
			this.groupBoxData.Location = new System.Drawing.Point(7, 269);
			this.groupBoxData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBoxData.Name = "groupBoxData";
			this.groupBoxData.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBoxData.Size = new System.Drawing.Size(719, 307);
			this.groupBoxData.TabIndex = 11;
			this.groupBoxData.TabStop = false;
			this.groupBoxData.Text = "Data";
			// 
			// labelDeviceType
			// 
			this.labelDeviceType.AutoSize = true;
			this.labelDeviceType.Location = new System.Drawing.Point(494, 155);
			this.labelDeviceType.Name = "labelDeviceType";
			this.labelDeviceType.Size = new System.Drawing.Size(119, 20);
			this.labelDeviceType.TabIndex = 8;
			this.labelDeviceType.Text = "Тип устройства";
			// 
			// labelModel
			// 
			this.labelModel.AutoSize = true;
			this.labelModel.Location = new System.Drawing.Point(494, 96);
			this.labelModel.Name = "labelModel";
			this.labelModel.Size = new System.Drawing.Size(63, 20);
			this.labelModel.TabIndex = 7;
			this.labelModel.Text = "Модель";
			// 
			// labelRegNum
			// 
			this.labelRegNum.AutoSize = true;
			this.labelRegNum.Location = new System.Drawing.Point(494, 37);
			this.labelRegNum.Name = "labelRegNum";
			this.labelRegNum.Size = new System.Drawing.Size(185, 20);
			this.labelRegNum.TabIndex = 6;
			this.labelRegNum.Text = "Регистрационный номер";
			// 
			// buttonGetFromTree
			// 
			this.buttonGetFromTree.Location = new System.Drawing.Point(494, 260);
			this.buttonGetFromTree.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.buttonGetFromTree.Name = "buttonGetFromTree";
			this.buttonGetFromTree.Size = new System.Drawing.Size(215, 31);
			this.buttonGetFromTree.TabIndex = 5;
			this.buttonGetFromTree.Text = "Get Selected";
			this.buttonGetFromTree.UseVisualStyleBackColor = true;
			this.buttonGetFromTree.Click += new System.EventHandler(this.buttonGetFromTree_Click);
			// 
			// buttonAddToTree
			// 
			this.buttonAddToTree.Location = new System.Drawing.Point(494, 221);
			this.buttonAddToTree.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.buttonAddToTree.Name = "buttonAddToTree";
			this.buttonAddToTree.Size = new System.Drawing.Size(215, 31);
			this.buttonAddToTree.TabIndex = 4;
			this.buttonAddToTree.Text = "Add";
			this.buttonAddToTree.UseVisualStyleBackColor = true;
			this.buttonAddToTree.Click += new System.EventHandler(this.buttonAddToTree_Click);
			// 
			// comboBoxDeviceType
			// 
			this.comboBoxDeviceType.FormattingEnabled = true;
			this.comboBoxDeviceType.Location = new System.Drawing.Point(494, 179);
			this.comboBoxDeviceType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.comboBoxDeviceType.Name = "comboBoxDeviceType";
			this.comboBoxDeviceType.Size = new System.Drawing.Size(214, 28);
			this.comboBoxDeviceType.TabIndex = 3;
			// 
			// textBoxModel
			// 
			this.textBoxModel.Location = new System.Drawing.Point(494, 120);
			this.textBoxModel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.textBoxModel.Name = "textBoxModel";
			this.textBoxModel.Size = new System.Drawing.Size(214, 27);
			this.textBoxModel.TabIndex = 2;
			// 
			// textBoxSerialNumber
			// 
			this.textBoxSerialNumber.Location = new System.Drawing.Point(494, 61);
			this.textBoxSerialNumber.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.textBoxSerialNumber.Name = "textBoxSerialNumber";
			this.textBoxSerialNumber.Size = new System.Drawing.Size(214, 27);
			this.textBoxSerialNumber.TabIndex = 1;
			// 
			// customTreeView
			// 
			this.customTreeView.Location = new System.Drawing.Point(17, 29);
			this.customTreeView.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.customTreeView.Name = "customTreeView";
			this.customTreeView.Size = new System.Drawing.Size(455, 269);
			this.customTreeView.TabIndex = 0;
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.Visual);
			this.tabControl.Controls.Add(this.Docs);
			this.tabControl.Location = new System.Drawing.Point(14, 16);
			this.tabControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(746, 621);
			this.tabControl.TabIndex = 12;
			// 
			// Visual
			// 
			this.Visual.Controls.Add(this.groupBoxData);
			this.Visual.Controls.Add(this.groupBoxInput);
			this.Visual.Controls.Add(this.groupBoxSelected);
			this.Visual.Location = new System.Drawing.Point(4, 29);
			this.Visual.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Visual.Name = "Visual";
			this.Visual.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Visual.Size = new System.Drawing.Size(738, 588);
			this.Visual.TabIndex = 0;
			this.Visual.Text = "Visual";
			this.Visual.UseVisualStyleBackColor = true;
			// 
			// Docs
			// 
			this.Docs.Controls.Add(this.buttonWordWithDiagram);
			this.Docs.Controls.Add(this.buttonWordWithTable);
			this.Docs.Controls.Add(this.buttonWordWithImage);
			this.Docs.Location = new System.Drawing.Point(4, 29);
			this.Docs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Docs.Name = "Docs";
			this.Docs.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Docs.Size = new System.Drawing.Size(738, 588);
			this.Docs.TabIndex = 1;
			this.Docs.Text = "Docs";
			this.Docs.UseVisualStyleBackColor = true;
			// 
			// buttonWordWithDiagram
			// 
			this.buttonWordWithDiagram.Location = new System.Drawing.Point(490, 223);
			this.buttonWordWithDiagram.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.buttonWordWithDiagram.Name = "buttonWordWithDiagram";
			this.buttonWordWithDiagram.Size = new System.Drawing.Size(227, 97);
			this.buttonWordWithDiagram.TabIndex = 13;
			this.buttonWordWithDiagram.Text = "Word With Diagram";
			this.buttonWordWithDiagram.UseVisualStyleBackColor = true;
			this.buttonWordWithDiagram.Click += new System.EventHandler(this.buttonWordWithDiagram_Click);
			// 
			// buttonWordWithTable
			// 
			this.buttonWordWithTable.Location = new System.Drawing.Point(256, 223);
			this.buttonWordWithTable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.buttonWordWithTable.Name = "buttonWordWithTable";
			this.buttonWordWithTable.Size = new System.Drawing.Size(227, 97);
			this.buttonWordWithTable.TabIndex = 14;
			this.buttonWordWithTable.Text = "Word With Table";
			this.buttonWordWithTable.UseVisualStyleBackColor = true;
			this.buttonWordWithTable.Click += new System.EventHandler(this.buttonWordWithTable_Click);
			// 
			// buttonWordWithImage
			// 
			this.buttonWordWithImage.Location = new System.Drawing.Point(22, 223);
			this.buttonWordWithImage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.buttonWordWithImage.Name = "buttonWordWithImage";
			this.buttonWordWithImage.Size = new System.Drawing.Size(227, 97);
			this.buttonWordWithImage.TabIndex = 13;
			this.buttonWordWithImage.Text = "Word With Image";
			this.buttonWordWithImage.UseVisualStyleBackColor = true;
			this.buttonWordWithImage.Click += new System.EventHandler(this.buttonWordWithImage_Click);
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(771, 648);
			this.Controls.Add(this.tabControl);
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "FormMain";
			this.Text = "FormMain";
			this.groupBoxInput.ResumeLayout(false);
			this.groupBoxInput.PerformLayout();
			this.groupBoxSelected.ResumeLayout(false);
			this.groupBoxSelected.PerformLayout();
			this.groupBoxData.ResumeLayout(false);
			this.groupBoxData.PerformLayout();
			this.tabControl.ResumeLayout(false);
			this.Visual.ResumeLayout(false);
			this.Docs.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private MyCustomComponents.CustomInputRangeNumber customInputRangeNumber;
		private TextBox textBoxMin;
		private TextBox textBoxMax;
		private Button buttonCheck;
		private Label labelCheckValue;
		private GroupBox groupBoxInput;
		private GroupBox groupBoxSelected;
		private Button buttonGetSelected;
		private Label labelSelectedValue;
		private Button buttonClear;
		private Button buttonAdd;
		private TextBox textBoxAdd;
		private MyCustomComponents.CustomSelectedCheckedListBoxProperty customSelectedCheckedListBoxProperty;
		private GroupBox groupBoxData;
		private MyCustomComponents.CustomTreeView customTreeView;
		private Button buttonGetFromTree;
		private Button buttonAddToTree;
		private ComboBox comboBoxDeviceType;
		private TextBox textBoxModel;
		private TextBox textBoxSerialNumber;
		private Label labelDeviceType;
		private Label labelModel;
		private Label labelRegNum;
		private TabControl tabControl;
		private TabPage Visual;
		private TabPage Docs;
		private Button buttonWordWithImage;
		private MyCustomComponents.WordWithImages wordWithImages;
		private Button buttonWordWithTable;
		private MyCustomComponents.WordWithTable wordWithTable;
		private Button buttonWordWithDiagram;
		private MyCustomComponents.WordWithDiagram wordWithDiagram;
	}
}