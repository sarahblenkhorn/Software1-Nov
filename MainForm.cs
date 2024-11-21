using Software1.Models;
using System;
using System.Windows.Forms;

namespace Software1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //todo refactor these items to a method to be called from program.cs
            //set data source for parts grid to all parts binding list
            //dataGridView1.Rows.Add(0, "Wheel", 15, 12);
            //dataGridView1.Rows.Add(1, "Pedal", 11, 8);
            //dataGridView1.Rows.Add(2, "Chain", 12, 8);
            //dataGridView1.Rows.Add(3, "Seat", 8, 4);

            //dataGridView2.Rows.Add(0, "Red Bicycle", 15, 11);
            //dataGridView2.Rows.Add(1, "Yellow Bicycle", 19, 9);
            //dataGridView2.Rows.Add(2, "Blue Bicycle", 5, 12);

            dataGridView1.DataSource = Inventory.AllParts;

            dataGridView2.DataSource = Inventory.Products;


            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridView1.ReadOnly = true;
            dataGridView2.ReadOnly = true;

            dataGridView1.MultiSelect = false;
            dataGridView2.MultiSelect = false;

            dataGridView1.AllowUserToAddRows = false;
            dataGridView2.AllowUserToAddRows = false;






        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddPart addPartForm = new AddPart();

            if (addPartForm.ShowDialog() == DialogResult.OK)
            {
                Part newPart = addPartForm.NewPart;

                dataGridView1.Rows.Add(newPart.PartID, newPart.Name, newPart.InStock, newPart.Price);

            }

            this.Show();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Add2_Click(object sender, EventArgs e)
        {
            AddProduct addProductForm = new AddProduct();
            addProductForm.ShowDialog();
        }

        private void Modify1_Click(object sender, EventArgs e)
        {
            ModifyPart modifyPartForm = new ModifyPart();
            modifyPartForm.ShowDialog();
        }

        private void Modify2_Click(object sender, EventArgs e)
        {
            ModifyProd modifyProdForm = new ModifyProd();
            modifyProdForm.ShowDialog();
        }
    }
}
