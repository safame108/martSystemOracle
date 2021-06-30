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
using Oracle.ManagedDataAccess.Client;

namespace WindowsFormsApp4
{
    public partial class supplierForm : Form
    {
        public supplierForm()
        {
            InitializeComponent();
           
        }

        private void supplierForm_Load(object sender, EventArgs e)
        {

            ProductBL p = new ProductBL();
            OracleDataAdapter da = p.GetSuppliers1();

            DataTable tbl = new DataTable();
            da.Fill(tbl);
            dataGridView1.DataSource = tbl;
        }

      
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            ProductBL p = new ProductBL();
            dataGridView1.DataSource = p.GetSuppliers1();
            dataGridView1.Show();
        }
    }
}
