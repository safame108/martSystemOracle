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
    public partial class MemberDetails : Form
    {
        public MemberDetails()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            NewMember newmemb = new NewMember();
            newmemb.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Products newProduct = new Products();
            newProduct.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Warning newwarn = new Warning();
            newwarn.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox3.Text);

            EmployeeBO pro = new EmployeeBO();

            EmployeeBL P = new EmployeeBL();

            pro = P.RetrieveEmployeeInfo(id);

            richTextBox1.Text =
            "FirstName \t:" + pro.FirstName + "\n" +
            "LastName \t:" + pro.LastName + "\n" +
            "ContactNumber \t:" + pro.ContactNumber + "\n" +
            "Address \t:" + pro.Address + "\n" +
            "HireDate\t:" + pro.HireDate;
 
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
           
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MemberDetails_Load(object sender, EventArgs e)
        {

        }
    }
}
