using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using BuisnessObject;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class MProductDetail : Form
    {
        public MProductDetail()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Sales newSAL = new Sales();
            newSAL.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://mail.google.com/mail/mu/mp/519/#tl/priority/%5Esmartlabel_personal");
        }

        private void button3_Click(object sender, EventArgs e)
        {

            NewMember newPro = new NewMember();
            newPro.Show();
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
            "ProductDesc\t:" + pro.ProductDesc + "\n" +
            "UnitPrice \t:" + pro.UnitPrice + "\n" +
            "ExpireDate \t:" + pro.ExpireDate + "\n" +
            "TotalQuantity \t:" + pro.TotalQuantity;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            
            this.Hide();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void MProductDetail_Load(object sender, EventArgs e)
        {

        }
    }
}
