using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Windows.Forms;
using BuisnessObject;
using BusinessLayer;

namespace WindowsFormsApp4
{
    public partial class Checkout : Form
    {
        ProductBL PL = new ProductBL();
        MyCart C = new MyCart();
        public Checkout()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            CProductDetails newProd = new CProductDetails();
            newProd.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Checkout_Load(object sender, EventArgs e)
        {
            ReciptRTB.Text = "";
            ReciptRTB.AppendText("=======================================\n");
            ReciptRTB.AppendText("=============== M  A  R  T ==============\n");
            ReciptRTB.AppendText("========    C  H  E  C  K  O  U  T  ========\n");
            ReciptRTB.AppendText("=======================================\n");
            ReciptRTB.AppendText("----------------------------------------------------\n");
            ItemFill();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        protected void ItemFill()
        {
            DataSet ds = new DataSet();

            OracleDataAdapter da = PL.DisplayProducts();
            da.Fill(ds);
            comboBox1.DisplayMember = "Product_Name";
            comboBox1.ValueMember = "Product_ID";
            comboBox1.DataSource = ds.Tables[0];

        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void Recipt()
        {
            ReciptRTB.Text = "";
            ReciptRTB.AppendText("=======================================\n");
            ReciptRTB.AppendText("=============== M  A  R  T ==============\n");
            ReciptRTB.AppendText("========    C  H  E  C  K  O  U  T  ========\n");
            ReciptRTB.AppendText("=======================================\n");
            ReciptRTB.AppendText("----------------------------------------------------\n");
            ReciptRTB.AppendText(" No.     Item      Quantity       Price \n");
            for (int i = 0; i < C.cart.Count; i++)
            {
                int n = i + 1;
                string name = C.cart[i].ProductName;
                string q = (C.cart[i].TotalQuantity).ToString();
                double price = C.cart[i].UnitPrice;

                ReciptRTB.AppendText(" " + (i + 1) + "     " + name + "           " + q + "           " + price + "\n");
            }

            ReciptRTB.AppendText("=========================================\n");
            ReciptRTB.AppendText("                   Total Amount = " + C.TOTALPRICE);


        }

        private void Button5_Click(object sender, EventArgs e)
        {
            //String name = (comboBox1.SelectedItem).ToString();
            //C.removeCart(name);
            //Recipt();
            //MessageBox.Show("done");
        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }

        private void Button5_Click_1(object sender, EventArgs e)
        {
            if(nameT.Text != "" || contactT.Text != "")
            {
                C.name = nameT.Text;
                C.contact = contactT.Text;
                C.UpdateInventory();
                Cart finalcart = new Cart();
                finalcart.contact = C.contact;
                finalcart.name = C.name;
                finalcart.totalItems = C.totalItems;
                finalcart.TOTALPRICE = C.TOTALPRICE;
                PL.AddSales(finalcart);
                //
                nameT.Text = "";
                contactT.Text = "";
                textBox2.Text = "";
                ReciptRTB.Text = "";
                ReciptRTB.AppendText("=======================================\n");
                ReciptRTB.AppendText("=============== M  A  R  T ==============\n");
                ReciptRTB.AppendText("========    C  H  E  C  K  O  U  T  ========\n");
                ReciptRTB.AppendText("=======================================\n");
                ReciptRTB.AppendText("----------------------------------------------------\n");
                MessageBox.Show("RECEIPT GENERATED");
            }
            else
            {
                MessageBox.Show("Please fill customer details");

            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (quantityT.Text != "" || comboBox1.SelectedValue != null)
            {
                if(int.TryParse(quantityT.Text,out int c))
                {
                    int quantity = Convert.ToInt32(quantityT.Text);
                    String name = (comboBox1.SelectedItem).ToString();

                    ProductBO ProductSelected = PL.RetrieveProductInfo(Convert.ToInt32(comboBox1.SelectedValue));
                    ProductBO p = new ProductBO();
                    p.ProductID = Convert.ToInt32(comboBox1.SelectedValue);
                    p.ProductName = ProductSelected.ProductName;
                    p.UnitPrice = ProductSelected.UnitPrice * quantity;
                    p.TotalQuantity = quantity;
                    C.TOTALPRICE += p.UnitPrice;

                    C.addCart(p);
                    textBox2.Text = C.TOTALPRICE.ToString();
                    Recipt();
                }
                else
                {
                    MessageBox.Show("Please write int value");
                }

            }
            else
            {
                MessageBox.Show("Please enter quantity and product");
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            String name = (comboBox1.Text).ToString();
            C.removeCart(name);
            Recipt();
            textBox2.Text = C.TOTALPRICE.ToString();
        }

        private void ReciptRTB_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
