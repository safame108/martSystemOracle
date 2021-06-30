using System;
using BusinessLayer;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using Oracle.ManagedDataAccess.Client;


namespace WindowsFormsApp4
{
    public partial class Sales : Form
    {
        public Sales()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            MProductDetail newPro = new MProductDetail();
            newPro.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            NewMember newMEMB = new NewMember();
            newMEMB.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Salary_Load(object sender, EventArgs e)
        {
            ProductBL p = new ProductBL();
            OracleDataAdapter da = p.Sales();

            DataTable tbl = new DataTable();
            da.Fill(tbl);
            dataGridView1.DataSource = tbl;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://mail.google.com/mail/mu/mp/519/#tl/priority/%5Esmartlabel_personal");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ProductBL p = new ProductBL();
            dataGridView1.DataSource = p.Sales();
            dataGridView1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            supplierForm m = new supplierForm();

            m.Show();
        }
    }
}
