using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuisnessObject;
using Oracle.ManagedDataAccess.Client;

namespace DataAccess
{
    public class ProductsDAL
    {
        //    SqlConnection conn;
        //    SqlCommand cmd;
        //    string path;
        OracleConnection conn;
    OracleCommand cmd;
    string conString;

    public ProductsDAL()
        {
        }
        public void formConnection()
        {
            conn = new OracleConnection();
            cmd = new OracleCommand();
            conString = "Data Source= (DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))(CONNECT_DATA =  (SERVER = DEDICATED)  (SERVICE_NAME = orcl))  ); User Id=system;Password=12345Admin;";
            conn.ConnectionString = conString;
            conn.Open();
            cmd.Connection = conn;


        }
        public OracleDataAdapter DisplayProducts()
        {
            formConnection();

            //using (conn = new SqlConnection(@"" + path))

            //    conn.Open();
            String Query = "SELECT * FROM products_tbl";
            cmd.Prepare();
            OracleDataAdapter sqa = new OracleDataAdapter(Query, conn);
            return sqa;
        }

        public void AddProduct(ProductBO P)
        {

            formConnection();
            cmd.CommandText = "ProductPg.addProduct(:id,:name,:productdesc,:price,:expire,:quantity,:supplierid)";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Prepare();
            cmd.Parameters.Add("id", P.ProductID);
            cmd.Parameters.Add("name", P.ProductName);
            cmd.Parameters.Add("supplierid", P.SupplierID);
            cmd.Parameters.Add("productdesc", P.ProductDesc);
            cmd.Parameters.Add("price", P.UnitPrice);
            cmd.Parameters.Add("expire", P.ExpireDate);
            cmd.Parameters.Add("quantity", P.TotalQuantity);
            cmd.ExecuteNonQuery();
            conn.Close();
            //using (conn = new SqlConnection(@"" + path))
            //{
            //    conn.Open();
            //    string Query = "INSERT INTO Products VALUES(@id,@name,@supplierid,@categoryid,@productdesc,@price,@expire,@quantity)";
            //    cmd = new SqlCommand(Query, conn);
            //    cmd.Parameters.Add("@id", P.ProductID);
            //    cmd.Parameters.Add("@name", P.ProductName);
            //    cmd.Parameters.Add("@supplierid", P.SupplierID);
            //    cmd.Parameters.Add("@categoryid", P.CategoryID);
            //    cmd.Parameters.Add("@productdesc", P.ProductDesc);
            //    cmd.Parameters.Add("@price", P.UnitPrice);
            //    cmd.Parameters.Add("@expire", P.ExpireDate);
            //    cmd.Parameters.Add("@quantity", P.TotalQuantity);

            //    cmd.ExecuteNonQuery();
            //    conn.Close();

            //}

        }

        public ProductBO UpdateProduct(ProductBO P)
        {


            formConnection();
            cmd.CommandText = " Begin ProductPg.updateProduct(:id,:quantity,:price); end;";
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Prepare();
            cmd.Parameters.Add("id", P.ProductID);
            cmd.Parameters.Add("quantity", P.TotalQuantity);
            cmd.Parameters.Add("price", P.UnitPrice);
            
            cmd.ExecuteNonQuery();
            conn.Close();
            //using (conn = new SqlConnection(@"" + path))
            //{
            //    conn.Open();
            //    string Query = "UPDATE Products  SET Unit_Price = @price,Product_Total_Quantity= @quantity";
            //    cmd = new SqlCommand(Query, conn);
            //    //  cmd.Parameters.Add("@id", P.ProductID);
            //    // cmd.Parameters.Add("@name", P.ProductName);
            //    // cmd.Parameters.Add("@supplierid", P.SupplierID);
            //    // cmd.Parameters.Add("@categoryid", P.CategoryID);
            //    // cmd.Parameters.Add("@productdesc", P.ProductDesc);
            //    cmd.Parameters.Add("@price", P.UnitPrice);
            //    //cmd.Parameters.Add("@expire", P.ExpireDate);
            //    cmd.Parameters.Add("@quantity", P.TotalQuantity);

            //    cmd.ExecuteNonQuery();
            //    conn.Close();

            //}
            return P;
        }
        public ProductBO RetrieveProductInfo(int id)
        {
            ProductBO P = new ProductBO();
            P.ProductID = id;
            formConnection();
            cmd.CommandText = "SELECT * FROM Products_tbl WHERE Product_ID = :id";
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.Add("id", P.ProductID);
            cmd.Prepare();

            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {

                while (dr.Read())
                {

                    P.ProductName = dr["Product_Name"].ToString();
                   // P.SupplierID = Convert.ToInt32(dr["Supplier_ID"].ToString());
                    P.ProductDesc = dr["Product_desc"].ToString();
                    P.UnitPrice = Convert.ToDouble(dr["Unit_Price"].ToString());
                    P.ExpireDate = dr["Expire_Date"].ToString();
                    P.TotalQuantity = Convert.ToInt32(dr["Product_Total_Quantity"].ToString());

                }
            }
            //using (conn = new SqlConnection(@"" + path))
            //{
            //    conn.Open();
            //    String Query = "SELECT * FROM Products WHERE Product_ID = @id";
            //    cmd = new SqlCommand(Query, conn);
            //    cmd.Parameters.Add("@id", id);
            //    using (SqlDataReader reader = cmd.ExecuteReader())
            //    {
            //        if (reader.Read())
            //        {
            //            P.ProductName = reader["Product_Name"].ToString();
            //            P.SupplierID = Convert.ToInt32(reader["Supplier_ID"].ToString());
            //            P.CategoryID = Convert.ToInt32(reader["Category_ID"].ToString());
            //            P.ProductDesc = reader["Product_desc"].ToString();
            //            P.UnitPrice = Convert.ToDouble(reader["Unit_Price"].ToString());
            //            P.ExpireDate = reader["Expire_Date"].ToString();
            //            P.TotalQuantity = Convert.ToInt32(reader["Product_Total_Quantity"].ToString());


            //        }
            //    }

            cmd.ExecuteNonQuery();
                conn.Close();
            

            return P;
        }
        public OracleDataAdapter RetrieveProductInfo(String name)
        {
            ProductBO P = new ProductBO();
            P.ProductName = name;
            formConnection();

            //using (conn = new SqlConnection(@"" + path))

            //    conn.Open();
            String Query = "SELECT * FROM Products_tbl WHERE Product_Name LIKE '%:name%'";
            cmd.Prepare();
            cmd.Parameters.Add("name", name);
            OracleDataAdapter sqa = new OracleDataAdapter(Query, conn);
            return sqa;
        }
        ///showing properids
        //public int IdSelector (string option,string name){
        //    int id=-1;
        //    string Query;
        //    using (conn = new SqlConnection(@"Data Source=ADMINRG-V7F0M8L;Initial Catalog=MartSystem;Integrated Security=True"))
        //    {
        //        conn.Open();
        //        switch (option) {
        //            case "Supplier":
        //                 Query = "SELECT Supplier_ID FROM Supplier WHERE Supplier_Name = '"+name+"'";
        //                cmd = new SqlCommand(Query, conn);
        //                using (SqlDataReader reader = cmd.ExecuteReader())
        //                {
        //                    if (reader.Read())
        //                    {
        //                        id = Convert.ToInt32(reader["Supplier_ID"].ToString());

        //                    }
        //                }
        //                cmd.ExecuteNonQuery();
        //                conn.Close();
        //                break;
        //            case "Category":
        //                Query = "SELECT Category_ID FROM Product_Categories WHERE Category_Name = '" + name + "'";
        //                cmd = new SqlCommand(Query, conn);
        //                using (SqlDataReader reader = cmd.ExecuteReader())
        //                {
        //                    if (reader.Read())
        //                    {
        //                        id = Convert.ToInt32(reader["Supplier_ID"].ToString());

        //                    }
        //                }
        //                cmd.ExecuteNonQuery();
        //                conn.Close();
        //                break;
        //        }

        //    }
        //        return id;
        //}

        public List<SupplierBO> GetSuppliers()
        {
            List<SupplierBO> s = new List<SupplierBO>();
//            Supplier_ID int,
//Supplier_Name varchar2(40),
//contact varchar2(40),
            formConnection();
            cmd.CommandText = "SELECT Supplier_ID,Supplier_Name,contact FROM Supplier_tbl ";
            cmd.CommandType = System.Data.CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {

                while (dr.Read())
                {


                    SupplierBO ss = new SupplierBO();
                    ss.ID = Convert.ToInt32(dr["Supplier_ID"].ToString());
                    ss.Name = dr["Supplier_Name"].ToString();
                    ss.Contact = dr["Contact"].ToString();
                    s.Add(ss);
                    //}

                }
            }
           
            dr.Close();
            //string Query;
            //using (conn = new SqlConnection(@"" + path))

            //    conn.Open();
            //Query = "EXEC SuppliersList";
            //cmd = new SqlCommand(Query, conn);
            //SqlDataReader reader = cmd.ExecuteReader();
            //while (reader.Read())
            //{
            //    SupplierBO ss = new SupplierBO();
            //    ss.ID = Convert.ToInt32(reader["Supplier_ID"].ToString());
            //    ss.Name = reader["Supplier_Name"].ToString();
            //    ss.Contact = reader["Contact"].ToString();
            //    s.Add(ss);
            //}
            conn.Close();
            cmd.ExecuteNonQuery();

            return s;

        }


        public OracleDataAdapter GetSuppliers1()
        {
            //            Supplier_ID int,
            //Supplier_Name varchar2(40),
            //contact varchar2(40),
            formConnection();
            String Query = "SELECT Supplier_ID,Supplier_Name,contact FROM Supplier_tbl";
            cmd.Prepare();
            OracleDataAdapter sqa = new OracleDataAdapter(Query, conn);
            return sqa;

        }

        //public List<CategoryBO> GetCategories()
        //{
        //    List<CategoryBO> s = new List<CategoryBO>();
        //    string Query;
        //    conn = new SqlConnection(@"" + path);

        //        conn.Open();
        //    Query = "EXEC CategoryList";
        //    cmd = new SqlCommand(Query, conn);
        //    SqlDataReader reader = cmd.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        CategoryBO ss = new CategoryBO();
        //        ss.ID = Convert.ToInt32(reader["Category_ID"].ToString());
        //        ss.Name = reader["Category_Name"].ToString();
        //        s.Add(ss);
        //    }
        //    cmd.ExecuteNonQuery();

        //    return s;

        //}
        public OracleDataAdapter WarningList()
        {

            formConnection();

            //using (conn = new SqlConnection(@"" + path))

            //    conn.Open();
            String Query = "select * from ProductQuantityWarning_tbl  ";
            cmd.Prepare();
            OracleDataAdapter sqa = new OracleDataAdapter(Query, conn);
            return sqa;
        }

        public OracleDataAdapter Sales()
        {

            formConnection();

            String Query = "SELECT * FROM Sales_tbl";
            cmd.Prepare();
            OracleDataAdapter sqa = new OracleDataAdapter(Query, conn);
            return sqa;
        }

        public void RemoveProduct(int id)
        {
            formConnection();


            cmd.CommandText = " BEGIN ProductPg.removeProducts(:id); END;";
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Prepare();
            cmd.Parameters.Add("id", id);

            cmd.ExecuteNonQuery();
            conn.Close();
            //using (conn = new SqlConnection(@"" + path))
            //{
            //    conn.Open();
            //    String Query = "DELETE FROM Products WHERE Product_ID = @id";
            //    cmd = new SqlCommand(Query, conn);
            //    cmd.Parameters.Add("@id", id);

            //    cmd.ExecuteNonQuery();
            //    conn.Close();
            //}

        }

        public void AddSales(Cart c)
        {
            formConnection();
            DateTime now = DateTime.Now;
            string d = now.ToShortDateString().ToString();
            string t = now.ToString("MM/dd/yyyy HH:mm:ss");

            cmd.CommandText = "insert into sales_tbl values(:id,:cname,:cc,TO_DATE(:cdate, 'mm/dd/yyyy'), TO_TIMESTAMP(:t, 'mm/dd/yyyy HH24:MI:SS'),:payment,:total)";
;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Prepare();
            cmd.Parameters.Add("id", (c.TOTALPRICE - c.totalItems));
            cmd.Parameters.Add("cname", c.name);
            cmd.Parameters.Add("cc", c.contact);
            cmd.Parameters.Add("cdate", d);
             cmd.Parameters.Add("time", t);
            cmd.Parameters.Add("payment", "cash");
            cmd.Parameters.Add("total", c.TOTALPRICE);
            cmd.ExecuteNonQuery();

            //for (int i = 0; i < c.cart.Count; i++)
            //{
            //    string Query1 = "INSERT INTO Sales_Information VALUES(@sid,@pid,@q)";
            //    cmd = new SqlCommand(Query1, conn);
            //    // cmd.Parameters.Add("@id", 12 /*c.TOTALPRICE - c.totalItems*/);
            //    cmd.Parameters.Add("@sid", c.TOTALPRICE - c.totalItems);
            //    cmd.Parameters.Add("@pid", c.cart[i].ProductID);
            //    cmd.Parameters.Add("@q", c.cart[i].TotalQuantity);
            //    cmd.ExecuteNonQuery();

            //}
            //using (conn = new SqlConnection(@"" + path))
            //{
            //    DateTime now = DateTime.Now;
            //    conn.Open();
            //    string Query = "INSERT INTO Sales VALUES(@id,@customername,@customerContact,@date,@time,@payment,@total)";
            //    cmd = new SqlCommand(Query, conn);
            //    cmd.Parameters.Add("@id", c.TOTALPRICE - c.totalItems);
            //    cmd.Parameters.Add("@customername", c.name);
            //    cmd.Parameters.Add("@customerContact", c.contact);
            //    cmd.Parameters.Add("@date", now);
            //    cmd.Parameters.Add("@time", now);
            //    cmd.Parameters.Add("@payment", "cash");
            //    cmd.Parameters.Add("@total", c.TOTALPRICE);

            //    cmd.ExecuteNonQuery();

            //    for (int i = 0; i < c.cart.Count; i++)
            //    {
            //        string Query1 = "INSERT INTO Sales_Information VALUES(@sid,@pid,@q)";
            //        cmd = new SqlCommand(Query1, conn);
            //        // cmd.Parameters.Add("@id", 12 /*c.TOTALPRICE - c.totalItems*/);
            //        cmd.Parameters.Add("@sid", c.TOTALPRICE - c.totalItems);
            //        cmd.Parameters.Add("@pid", c.cart[i].ProductID);
            //        cmd.Parameters.Add("@q", c.cart[i].TotalQuantity);
            //        cmd.ExecuteNonQuery();

            //    }


            conn.Close();
            
        }
    }
}
