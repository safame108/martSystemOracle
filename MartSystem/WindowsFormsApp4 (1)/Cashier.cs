using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuisnessObject;
using BusinessLayer;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Cashier : Form
    {
        public Cashier()
        {
            InitializeComponent();
            DateTime now = DateTime.Now;
            string date = now.ToShortDateString().ToString();
            string time = now.ToString("HH:mm:ss");

            richTextBox1.Text = "Date:\t" + date + "\nTime\t" + time;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SignIn s = new SignIn();
            s.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            CProductDetails newProducts = new CProductDetails();
            newProducts.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            Checkout newOut = new Checkout();
            newOut.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Cashier_Load(object sender, EventArgs e)
        {

        }
        public void showdetail(int id)

        {
            
            EmployeeBL emp = new EmployeeBL();
            EmployeeBO ed = new EmployeeBO();
            ed = emp.RetrieveEmployeeInfo(id);
            richTextBox2.Text = "Name:\t\t" + ed.FirstName + " " + ed.LastName +
                               "\nContact:\t" + ed.ContactNumber +
                               "\nEmployeeID:\t" + ed.EmployeeID;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            CProductDetails C = new CProductDetails();
            C.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Checkout c = new Checkout();
            c.Show();
        }
    }
}
