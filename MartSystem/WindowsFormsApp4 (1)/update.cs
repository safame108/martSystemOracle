using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuisnessObject;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class update : Form
    {
        public update()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProductBL P = new ProductBL();
            ProductBO L = new ProductBO();
            L.ProductID = int.Parse(textBox3.Text);
            L.UnitPrice = int.Parse(textBox1.Text);
            L.TotalQuantity = int.Parse(textBox2.Text);
            P.UpdateProduct(L);
            MessageBox.Show("Update Inventory!");
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Warning w = new Warning();
            w.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            NewMember newmemb = new NewMember();
            newmemb.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MemberDetails newDet = new MemberDetails();
            newDet.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Products newProduct = new Products();
            newProduct.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void update_Load(object sender, EventArgs e)
        {

        }
    }
}
