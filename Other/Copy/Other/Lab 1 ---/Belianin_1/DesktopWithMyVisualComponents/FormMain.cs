using MyCustomComponents;
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
    public partial class FormMain : Form
    {
        readonly List<Device> transports = new()
        {
            new Device { Id = 1, SerialNumber = "SM-12345", DeviceType = "Мобильный телефон", Model = "IPhone 13" },
            new Device { Id = 2, SerialNumber = "CO2UD8471", DeviceType = "Ноутбук", Model = "MacBook Pro" },
            new Device { Id = 3, SerialNumber = "R80NZD8812", DeviceType = "Умные часы", Model = "Galaxy Watch 4" },
            new Device { Id = 4, SerialNumber = "SM-G3412", DeviceType = "Мобильный телефон", Model = "Samsung Galaxy S24" },
            new Device { Id = 5, SerialNumber = "FN738214", DeviceType = "Умные часы", Model = "Apple Watch 3",  },
        };

        public FormMain()
        {
            InitializeComponent();
            var list = new List<string>() { "Значение 1", "Значение 2", "Значение 3", "Значение 4", "Значение 5" };
            customSelectedCheckedListBoxProperty.Items.AddRange(list.ToArray());

			comboBoxDeviceType.Items.Add("Мобильный телефон");
			comboBoxDeviceType.Items.Add("Ноутбук");
			comboBoxDeviceType.Items.Add("Умные часы");

            var nodeNames = new Queue<string>();
            nodeNames.Enqueue("DeviceType");
            nodeNames.Enqueue("Model");
            nodeNames.Enqueue("SerialNumber");
            var treeConfig = new DataTreeNodeConfig { NodeNames = nodeNames };

            customTreeCell.LoadConfig(treeConfig);

            int counter = 0;

            foreach (var transport in transports)
            {

                customTreeCell.AddCell(0, transport);
                customTreeCell.AddCell(1, transport);
                customTreeCell.AddCell(2, transport);
                customTreeCell.AddCell(3, transport);

                counter++;
            }
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            labelCheckValue.Text = customInputRangeNumber.Value.ToString();
            if (labelCheckValue.Text == "")
            {
                labelCheckValue.Text = customInputRangeNumber.Error;
            }
        }

        private void buttonSetBorders_Click(object sender, EventArgs e)
        {
            //if (!customInputRangeNumber.SetBorders(textBoxMin.Text, textBoxMax.Text))
            //{
            //    labelCheckValue.Text = customInputRangeNumber.Error;
           //     return;
           // }

            //labelCheckValue.Text = "Граница установлена";
            //customInputRangeNumber.SetBorders(textBoxMin.Text, textBoxMax.Text);
        }

        private void textBoxMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 45)
            {
                e.Handled = true;
            }
        }

        private void textBoxMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 45)
            {
                e.Handled = true;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxAdd.Text != "" && !customSelectedCheckedListBoxProperty.Items.Contains(textBoxAdd.Text))
                customSelectedCheckedListBoxProperty.Items.Add(textBoxAdd.Text);
            else if (customSelectedCheckedListBoxProperty.Items.Contains(textBoxAdd.Text))
                customSelectedCheckedListBoxProperty.SelectedElement = textBoxAdd.Text;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            customSelectedCheckedListBoxProperty.Clear();
        }

        private void buttonGetSelected_Click(object sender, EventArgs e)
        {
            labelSelectedValue.Text = customSelectedCheckedListBoxProperty.SelectedElement;
            if (labelSelectedValue.Text == "")
            {
                labelSelectedValue.Text = "Значение \nне выбрано";
            }
        }

        private void buttonAddToTree_Click(object sender, EventArgs e)
        {
            if (textBoxSerialNumber.Text == null || textBoxModel.Text == null || comboBoxDeviceType.SelectedItem == null)
            {
                return;
            }

            customTreeCell.AddCell<Device>(2, new(textBoxSerialNumber.Text, comboBoxDeviceType.SelectedItem.ToString(), textBoxModel.Text));
            customTreeCell.Update();
        }

        private void buttonGetFromTree_Click(object sender, EventArgs e)
        {
            Device tp = customTreeCell.GetSelectedObject<Device>();
            if (tp == null)
            {
                return;
            }

            textBoxSerialNumber.Text = tp.SerialNumber;
            textBoxModel.Text = tp.Model;
            comboBoxDeviceType.SelectedItem = tp.DeviceType;
        }
    }
}
