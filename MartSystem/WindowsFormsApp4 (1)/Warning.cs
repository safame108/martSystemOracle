using BusinessLayer;
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
using Oracle.ManagedDataAccess.Client;


namespace WindowsFormsApp4
{
    public partial class Warning : Form
    {
        public Warning()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            NewMember newmemb = new NewMember();
            newmemb.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Products newProduct = new Products();
            newProduct.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            MemberDetails newDet = new MemberDetails();
            newDet.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Warning_Load(object sender, EventArgs e)
        {
            ProductBL p = new ProductBL();
            OracleDataAdapter da = p.WarningList();
          
            DataTable tbl = new DataTable();
            da.Fill(tbl);
            dataGridView1.DataSource = tbl;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
