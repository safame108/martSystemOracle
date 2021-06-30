using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using BusinessLayer;
using BuisnessObject;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            Warning newWarn = new Warning();
            newWarn.Show();
            this.Hide();
        }

        private void ManageItems_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            NewMember newMember = new NewMember();
            newMember.Show();
            this.Hide();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            update up = new update();
            up.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ProductBL b = new ProductBL();
            b.RemoveProduct(int.Parse(textBox3.Text));
            richTextBox1.Text = "\t---Deleted---"; 
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MemberDetails newMemb = new MemberDetails();
            newMemb.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox3.Text);

            ProductBO pro = new ProductBO();

            ProductBL P = new ProductBL();

            pro = P.RetrieveProductInfo(id);

            richTextBox1.Text =
            "ProductName\t:" + pro.ProductName + "\n" +
            "SupplierID\t:" + pro.SupplierID + "\n" +
            "CategoryID \t:" + pro.CategoryID + "\n" +
            "ProductDesc\t:" + pro.ProductDesc + "\n" +
            "UnitPrice \t:" + pro.UnitPrice + "\n" +
            "ExpireDate \t:" + pro.ExpireDate + "\n" +
            "TotalQuantity \t:" + pro.TotalQuantity;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            
            this.Hide();
        }

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
