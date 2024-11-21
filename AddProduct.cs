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

namespace Software1
{
    public partial class AddProduct : Form
    {
        public AddProduct()
        {
            InitializeComponent();
        }

        private void Delete1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddProduct_Load(object sender, EventArgs e)
        {

        }

        private void ProdSave_Click(object sender, EventArgs e)
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

                Product newProduct = new Product()
                {
                    ProductID = randomPartID, 
                    Name = textBox5.Text,
                    Price = decimal.Parse(textBox3.Text),
                    InStock = inventory,
                    Min = min,
                    Max = max
                };


                this.DialogResult = DialogResult.OK;
                this.Close(); 
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numeric values for Inventory, Min, Max, and Price.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
