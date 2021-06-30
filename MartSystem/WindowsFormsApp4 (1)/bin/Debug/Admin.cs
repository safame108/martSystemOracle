using BuisnessObject;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Admin : Form
    {
        public Admin()
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

        private void button1_Click(object sender, EventArgs e)
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
        private void Admin_Load(object sender, EventArgs e,int id)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            NewMember newMember = new NewMember();
            newMember.Show();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Products newProduct = new Products();
            newProduct.Show();
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Warning newWarnings = new Warning();
            newWarnings.Show();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MemberDetails newDetails = new MemberDetails();
            newDetails.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SignIn s = new SignIn();
            s.Show();
            this.Hide();
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }
    }
}
