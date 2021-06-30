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
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            EmployeeBL EBL = new EmployeeBL();
            EmployeeBO emp;

            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.SelectedItem == "")
            {
                MessageBox.Show("Please Fill all the textboxes");
            }
            else
            {
                switch (comboBox1.SelectedItem)
                {

                    case "Admin":
                        {

                            emp = EBL.SignAuthentication(textBox1.Text, textBox2.Text, "Admin");
                            if (emp.FirstName != null)
                            {
                                Admin a = new Admin();
                                a.showdetail(emp.EmployeeID);
                                a.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Incorrent credential");
                            }
                            break;
                        }

                    case "Manager":
                        {

                            emp = EBL.SignAuthentication(textBox1.Text, textBox2.Text, "Manager");
                            MessageBox.Show("emp is " + emp.FirstName);

                            if (emp.FirstName != null)
                            {


                                Manager a = new Manager();
                                a.showdetail(emp.EmployeeID);

                                a.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Incorrent credential");

                            }

                            break;
                        }

                    case "Cashier":
                        {
                            emp = EBL.SignAuthentication(textBox1.Text, textBox2.Text, "Cashier");
                            if (emp.FirstName != null)
                            {
                                Cashier a = new Cashier();
                                a.showdetail(emp.EmployeeID);
                                a.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Incorrent credential");

                            }

                            break;
                        }
                }
            }
        }
            //EmployeeBL obj = new EmployeeBL();

            //EmployeeBO emp = new EmployeeBO();

            //EmployeeDetails empd = new EmployeeDetails();

            //emp = obj.authenticate(textBox1.Text,textBox2.Text,comboBox1.Text);

            //if (emp == null)
            //{
            //    SignIn a = new SignIn();
            //    a.Show();
            //}
            //else
            //{
            //    empd = obj.jobid(emp);
            //    if (empd.Job_ID==1)
            //    {
            //Admin a = new Admin();
            //a.showdetail(1);
            //a.Show();
            //    }
            //    else if(empd.Job_ID == 2)
            //    {
            //        Manager m = new Manager();
            //        m.Show();
            //    }
            //    else if (empd.Job_ID == 3)
            //    {
            //        Cashier c = new Cashier();
            //        c.Show();
            //    }
            //}  

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SignIn_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }
    }
}
