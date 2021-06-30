using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using System.Configuration;


namespace WindowsFormsApp4
{
    public partial class ManageItems : Form
    {
        public ManageItems()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void Button7_Click(object sender, EventArgs e)
        {

        }

        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataTable dt = new DataTable();

            //EmployeeBL em = new EmployeeBL();
            //SqlCommand cmd = em.ShowEmployeeList();


            //SqlDataReader sdr = cmd.ExecuteReader();

            //dt.Load(sdr);
            //dataGridView1.DataSource = dt;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            //EmployeeBL em = new EmployeeBL();
            //SqlDataAdapter da = em.ShowEmployeeList();
            //DataTable tbl = new DataTable();
            //da.Fill(tbl);
            //dataGridView1.DataSource = tbl;

            EmployeeBL em = new EmployeeBL();
            SqlConnection s = em.RetrieveEmployeeInfo("hello");


        }
    }
}
