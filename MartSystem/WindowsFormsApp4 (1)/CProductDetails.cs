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
    public partial class CProductDetails : Form
    {
        public CProductDetails()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            Checkout newOUT = new Checkout();
            newOUT.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Cashier c = new Cashier();
            c.Show();
            this.Hide();
        }

        private void CProductDetails_Load(object sender, EventArgs e)
        {

        }
    }
}
