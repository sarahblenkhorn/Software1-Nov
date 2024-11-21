using Software1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Software1
{
    public partial class AddPart : Form
    {
        public Part NewPart { get; private set; }

        public AddPart()
        {
            InitializeComponent();
            Random rnd = new Random();
            textBox1.Text = rnd.Next(1000).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                int inventory = int.Parse(textBox4.Text);
                int min = int.Parse(textBox6.Text);
                int max = int.Parse(textBox7.Text);

                if (inventory < min || inventory > max)
                {
                    MessageBox.Show("Inventory must be between Min and Max values.");
                    return;
                }

                Random rnd = new Random();
                int randomPartID = rnd.Next(1, 10000);

                if (radioInHouse.Checked)
                {
                    NewPart = new Inhouse()
                    {
                        PartID = randomPartID,
                        Name = textBox5.Text,
                        Price = decimal.Parse(textBox3.Text),
                        InStock = inventory,
                        Min = min,
                        Max = max,
                        MachineID = int.Parse(textBox2.Text)
                    };
                }
                else if (radioOutsourced.Checked)
                {
                    NewPart = new Outsourced()
                    {
                        PartID = randomPartID,
                        Name = textBox5.Text,
                        Price = decimal.Parse(textBox3.Text),
                        InStock = inventory,
                        Min = min,
                        Max = max,
                        CompanyName = textBox2.Text
                    };
                }
                else
                {
                    MessageBox.Show("Please select a part type.");
                    return;
                }

                // Set the result and close the form
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numeric values for Inventory, Min, Max, and other fields.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void radioInHouse_CheckedChanged(object sender, EventArgs e)
        {
            if (radioInHouse.Checked)
            {
                labelCompanyOrMachineID.Text = "Machine ID";
            }
        }

        private void radioOutsourced_CheckedChanged(object sender, EventArgs e)
        {
            if (radioOutsourced.Checked)
            {
                labelCompanyOrMachineID.Text = "Company Name";
            }
        }

    }
}
