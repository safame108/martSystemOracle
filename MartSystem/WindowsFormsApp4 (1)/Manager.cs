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
    public partial class Manager : Form
    {
        public Manager()
        {
            InitializeComponent();
            DateTime now = DateTime.Now;
            string date = now.ToShortDateString().ToString();
            string time = now.ToString("HH:mm:ss");

            richTextBox1.Text = "Date:\t" + date + "\nTime\t" + time;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            MProductDetail newDetail = new MProductDetail();
            newDetail.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sales newPay = new Sales();
            newPay.Show();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NewMember newMem = new NewMember();
            newMem.Show();
            
        }

        private void Manager_Load(object sender, EventArgs e)
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

        private void button5_Click(object sender, EventArgs e)
        {
            SignIn s = new SignIn();
            s.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://mail.google.com/mail/mu/mp/519/#tl/priority/%5Esmartlabel_personal");
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Manager m = new Manager();
            m.Show();
            this.Hide();
        }

        private void supplierB_Click(object sender, EventArgs e)
        {
            supplierForm m = new supplierForm ();
            
            m.Show();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            supplierForm m = new supplierForm();

            m.Show();
        }
    }
}
