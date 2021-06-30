using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuisnessObject;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;



namespace DataAccess
{
    public class EmployeeDAL
    {
        //SqlConnection conn;
        //SqlCommand cmd;
        //string path;

        OracleConnection conn;
        OracleCommand cmd;
        string conString;

        public EmployeeDAL()
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
        public void AddEmployee(EmployeeBO E, EmployeeDetails ED, SignUp Signup)
        {
            //using (conn = new SqlConnection(@"" + path))
            //{
            //    conn.Open();
            //    String Query1 = "INSERT INTO Employees VALUES(@id,@First,@Last,@contact,@address,GETDATE(),@account)";
            //    cmd = new SqlCommand(Query1, conn);

            formConnection();
            cmd.CommandText = "BEGIN EmployeePg.insertEmployee("+ E.EmployeeID + ",:First,:Last,:contact,:address,:account,:name,:password,:email,"+ ED.Job_ID + "," + ED.Branch_ID + ","+ ED.Department_ID + "); END;";
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Prepare();
            cmd.BindByName = true;

            //cmd.Parameters.Add("id", E.EmployeeID);
            cmd.Parameters.Add("First", E.FirstName);
                cmd.Parameters.Add("Last", E.LastName);
                cmd.Parameters.Add("contact", E.ContactNumber);
                cmd.Parameters.Add("address", E.Address);
                //cmd.Parameters.Add("@hire", "getDate()");
                cmd.Parameters.Add("account", E.AccNumber);
            //cmd.Parameters.Add("jobid", ED.Job_ID);
            //cmd.Parameters.Add("branch", ED.Branch_ID);
            //cmd.Parameters.Add("dept", ED.Department_ID);
            cmd.Parameters.Add("name", Signup.Username);
            cmd.Parameters.Add("password", Signup.Password);
            cmd.Parameters.Add("email", Signup.Email);

            cmd.ExecuteNonQuery();

                  conn.Close();
            
        }

        public void RemoveEmployee(EmployeeBO E)
        {
            //    using (conn = new SqlConnection(@"" + path))
            //    {


//            DELETE FROM Employees WHERE Employee_ID = @id
//DELETE FROM Employees_Details WHERE Employee_ID = @id
//DELETE FROM LogIn_Details WHERE Employee_ID = @id

            formConnection();
            cmd.CommandText = "removeEmployee(:id);";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Prepare();

                cmd.Parameters.Add(":id", E.EmployeeID);
                cmd.ExecuteNonQuery();            
            conn.Close();
            
        }
        public EmployeeBO UpdateEmployee(EmployeeBO E)
        {
            formConnection();
            cmd.CommandText = "UPDATE Employee_tbl SET First_Name = :First , Last_Name = :Last , Contact_Number = :contact , Address = :address , Hire_Date = :hire , Account_Number = :account WHERE Employee_ID = :id";

            cmd.Prepare();


            String Query = "UPDATE Employee_tbl SET First_Name = :First , Last_Name = :Last , Contact_Number = :contact , Address = :address , Hire_Date = :hire , Account_Number = :account WHERE Employee_ID = :id";
                cmd.Parameters.Add("id", E.EmployeeID);
                cmd.Parameters.Add("First", E.FirstName);
                cmd.Parameters.Add("Last", E.LastName);
                cmd.Parameters.Add("contact", E.ContactNumber);
                cmd.Parameters.Add("address", E.Address);
                cmd.Parameters.Add("hire", E.HireDate);
                cmd.Parameters.Add("account", E.AccNumber);
                cmd.ExecuteNonQuery();
                conn.Close();
            
            return E;
        }
        public EmployeeBO RetrieveEmployeeInfo(int id)
        {
            EmployeeBO E = new EmployeeBO();
            E.EmployeeID = id;
            formConnection();
          
            cmd.CommandText = "SELECT * FROM employee_tbl WHERE Employee_ID = " + id;
            cmd.CommandType = System.Data.CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
               
                while (dr.Read())
                {

                    E.FirstName = dr["First_Name"].ToString();
                    E.LastName = dr["Last_Name"].ToString();
                    E.ContactNumber = dr["Contact_Number"].ToString();
                    E.Address = dr["Address"].ToString();
                    E.HireDate = dr["Hire_Date"].ToString();
                    E.AccNumber = dr["Account_Number"].ToString();

                }
            }
            
            //using (conn = new SqlConnection(@"" + path))
            //{
            //    conn.Open();
            //    String Query = "SELECT * FROM Employees WHERE Employee_ID = @id";
            //    cmd = new SqlCommand(Query, conn);
            //    cmd.Parameters.Add("@id", id);
            //    using (SqlDataReader reader = cmd.ExecuteReader())
            //    {
            //        if (reader.Read())
            //        {
            //            E.FirstName = reader["First_Name"].ToString();
            //            E.LastName = reader["Last_Name"].ToString();
            //            E.ContactNumber = reader["Contact_Number"].ToString();
            //            E.Address = reader["Address"].ToString();
            //            E.HireDate = reader["Hire_Date"].ToString();
            //            E.AccNumber = reader["Account_Number"].ToString();
            //        }
            //    }

                conn.Close();
            

            return E;
        }
        //public SqlDataAdapter RetrieveEmployeeInfo(string name)
        //{
        //    EmployeeBO E = new EmployeeBO();
        //    E.FirstName = name;

        //    using (conn = new SqlConnection(@"" + path))

        //        conn.Open();
        //    String Query = "SELECT * FROM Employees WHERE First_Name LIKE '%" + name + "%'";
        //    SqlDataAdapter sqa = new SqlDataAdapter(Query, conn);
        //    return sqa;

        //}

        private EmployeeDetails EmployeeWorkPropertiesIDs(EmployeeBO E)
        {
            EmployeeDetails ED = new EmployeeDetails();
            ED.Employee_ID = E.EmployeeID;
            formConnection();

            cmd.CommandText = "SELECT * FROM Employees_Details_tbl WHERE Employee_ID = "+ E.EmployeeID;
            cmd.CommandType = System.Data.CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {

                while (dr.Read())
                {


                    ED.Job_ID = Convert.ToInt32(dr["Job_ID"].ToString());
                    ED.Branch_ID = Convert.ToInt32(dr["Branch_ID"].ToString());
                    ED.Department_ID = Convert.ToInt32(dr["Department_ID"].ToString());

                }
            }

            //using (conn = new SqlConnection(@"" + path))
            //{
            //    conn.Open();
            //    String Query = "SELECT * FROM Employees_Details WHERE Employee_ID = @id";
            //    cmd = new SqlCommand(Query, conn);
            //    cmd.Parameters.Add("@id", E.EmployeeID);
            //    using (SqlDataReader reader = cmd.ExecuteReader())
            //    {
            //        if (reader.Read())
            //        {
            //            ED.Job_ID = Convert.ToInt32(reader["Job_ID"].ToString());
            //            ED.Branch_ID = Convert.ToInt32(reader["Branch_ID"].ToString());
            //            ED.Department_ID = Convert.ToInt32(reader["Department_ID"].ToString());

            //        }
            //    }

            //    cmd.ExecuteNonQuery();
            conn.Close();
            
            return ED;
        }
        /// Proper Names
        public WorkProperties EmployeeWorkProperties(EmployeeBO E)
        {
            EmployeeDetails ED = EmployeeWorkPropertiesIDs(E);
            WorkProperties WP = new WorkProperties();
            formConnection();
            //JOB
            cmd.CommandText = "SELECT * FROM Jobs_tbl WHERE Job_ID = " + ED.Job_ID;
            cmd.CommandType = System.Data.CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {

                while (dr.Read())
                {


                    WP.Position = dr["Position"].ToString();
                    WP.Salary = dr["Salary"].ToString();

                }
            }
            //String Query1 = "SELECT * FROM Jobs_tbl WHERE Job_ID = "+id;
            //cmd = new SqlCommand(Query1, conn);
            //cmd.Parameters.Add("@id", ED.Job_ID);

            //    if (reader.Read())
            //    {
            //        WP.Position = reader["Position"].ToString();
            //        WP.Salary = reader["Salary"].ToString();

            //    }

            //BRANCH
            cmd.CommandText = "SELECT * FROM Branch_tbl WHERE Branch_ID = " + ED.Branch_ID;
            cmd.CommandType = System.Data.CommandType.Text;
             dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {

                while (dr.Read())
                {


                    WP.Branch_Address = dr["Branch_Address"].ToString();
                    WP.ContactNumberBranch = dr["Contact_Number"].ToString();
                    WP.CityBranch = dr["City"].ToString();

                }
            }

            //String Query2 = "SELECT * FROM Branch WHERE Branch_ID = @id";
            //    cmd = new SqlCommand(Query2, conn);
            //    cmd.Parameters.Add("@id", ED.Branch_ID);
            //    using (SqlDataReader reader = cmd.ExecuteReader())
            //    {
            //        if (reader.Read())
            //        {
            //            WP.Branch_Address = reader["Branch_Address"].ToString();
            //            WP.ContactNumberBranch = reader["Contact_Number"].ToString();
            //            WP.CityBranch = reader["City"].ToString();

            //        }
            //    }
            //    cmd.ExecuteNonQuery();
            ///deprt
            //BRANCH

            cmd.CommandText = "SELECT * FROM Department_tbl WHERE Department_No = " + ED.Department_ID;
            cmd.CommandType = System.Data.CommandType.Text;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {

                while (dr.Read())
                {


                    WP.DepartmentName = dr["Department_Name"].ToString();


                }
            }

            //String Query3 = "SELECT * FROM Department WHERE Department_No = @id";
            //    cmd = new SqlCommand(Query3, conn);
            //    cmd.Parameters.Add("@id", ED.Department_ID);
            //    using (SqlDataReader reader = cmd.ExecuteReader())
            //    {
            //        if (reader.Read())
            //        {
            //            WP.DepartmentName = reader["Department_Name"].ToString();

            //        }
            //    }
            //    cmd.ExecuteNonQuery();
            conn.Close();
            

            return WP;
        }
        public OracleDataAdapter ShowEmployeeList()
        {

            formConnection();
            String Query = "Select * from employee_tbl";
            OracleDataAdapter sqa = new OracleDataAdapter(Query, conn);
            return sqa;

        }
        public EmployeeBO SignAuthentication(String Username, String password, string option)
        {


           
            EmployeeBO emp = new EmployeeBO();
            formConnection();
            cmd.CommandText = "SELECT * from Employee_tbl e INNER JOIN LogIn_Details_tbl l ON e.Employee_ID=l.Employee_ID INNER JOIN Employee_Details_tbl ed ON l.Employee_ID = ed.Employee_ID INNER JOIN Jobs_tbl j ON j.Job_ID = ed.Job_ID  WHERE l.ePassword = :pass AND l.UserName = :name AND j.Position = :position";
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.Add("pass", password);
            cmd.Parameters.Add("name", Username);
            cmd.Parameters.Add("position", option);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            OracleDataReader dr = cmd.ExecuteReader();



            if (dr.HasRows)
            {

                while (dr.Read())
                {


                    emp.EmployeeID = Convert.ToInt32(dr["Employee_ID"].ToString());
                    emp.FirstName = dr["First_Name"].ToString();
                    emp.LastName = dr["Last_Name"].ToString();
                    emp.ContactNumber = dr["Contact_Number"].ToString();
                    emp.HireDate = dr["Hire_Date"].ToString();
                    emp.AccNumber = dr["Account_Number"].ToString();
                    emp.Address = dr["Address"].ToString();


                }
            }
            dr.Close();
            conn.Close();

            //using (conn = new SqlConnection(@"" + path))
            //{
            //    conn.Open();
            //    //JOB
            //    String Query1 = "EXEC SignInRetriever @pas,@user,@position";
            //    cmd = new SqlCommand(Query1, conn);
            //    cmd.Parameters.Add("@pas", password);
            //    cmd.Parameters.Add("@user", Username);
            //    cmd.Parameters.Add("@position", option);

            //    using (SqlDataReader reader = cmd.ExecuteReader())
            //    {
            //        if (reader.Read())
            //        {
            //            emp.EmployeeID = Convert.ToInt32(reader["Employee_ID"].ToString());
            //            emp.FirstName = reader["First_Name"].ToString();
            //            emp.LastName = reader["Last_Name"].ToString();
            //            emp.ContactNumber = reader["Contact_Number"].ToString();
            //            emp.HireDate = reader["Hire_Date"].ToString();
            //            emp.AccNumber = reader["Account_Number"].ToString();
            //            emp.Address = reader["Address"].ToString();

            //        }
            //    }
            //    cmd.ExecuteNonQuery();
            conn.Close();
            

            return emp;
        }


    }
}
