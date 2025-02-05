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
        readonly List<Transport> transports = new()
        {
            new Transport { Id = 1, RegNumber = "EW-009EC", TransportType = "Воздушный транспорт", Model = "Ан-30" },
            new Transport { Id = 2, RegNumber = "EW-987ZY", TransportType = "Воздушный транспорт", Model = "Ан-28" },
            new Transport { Id = 3, RegNumber = "SSH-988", TransportType = "Морской транспорт", Model = "авианосец 'Нимиц'" },
            new Transport { Id = 4, RegNumber = "B901AУ74", TransportType = "Наземный транспорт", Model = "Renault Logan" },
            new Transport { Id = 5, RegNumber = "Р187КН73", TransportType = "Наземный транспорт", Model = "Daewoo Matiz" },
        };

        public FormMain()
        {
            InitializeComponent();
            var list = new List<string>() { "Значение 1", "Значение 2", "Значение 3", "Значение 4", "Значение 5" };
            customSelectedCheckedListBoxProperty.Items.AddRange(list.ToArray());

            comboBoxTransportType.Items.Add("Наземный транспорт");
            comboBoxTransportType.Items.Add("Воздушный транспорт");
            comboBoxTransportType.Items.Add("Морской транспорт");

            var nodeNames = new Queue<string>();
            nodeNames.Enqueue("TransportType");
            nodeNames.Enqueue("Model");
            nodeNames.Enqueue("RegNumber");
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
            if (!customInputRangeNumber.SetBorders(textBoxMin.Text, textBoxMax.Text))
            {
                labelCheckValue.Text = customInputRangeNumber.Error;
                return;
            }

            labelCheckValue.Text = "Граница установлена";
            customInputRangeNumber.SetBorders(textBoxMin.Text, textBoxMax.Text);
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
            if (textBoxRegNumber.Text == null || textBoxModel.Text == null || comboBoxTransportType.SelectedItem == null)
            {
                return;
            }

            customTreeCell.AddCell<Transport>(2, new(textBoxRegNumber.Text, comboBoxTransportType.SelectedItem.ToString(), textBoxModel.Text));
            customTreeCell.Update();
        }

        private void buttonGetFromTree_Click(object sender, EventArgs e)
        {
            Transport tp = customTreeCell.GetSelectedObject<Transport>();
            if (tp == null)
            {
                return;
            }

            textBoxRegNumber.Text = tp.RegNumber;
            textBoxModel.Text = tp.Model;
            comboBoxTransportType.SelectedItem = tp.TransportType;
        }
    }
}
