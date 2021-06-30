using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessObject
{
//    Create table Department
//(
//Department_No int Primary Key,
//Department_Name varchar(40),
//No_Of_Employees int,
//Manager varchar(40),
//)

//    Create table Branch
//(
//Branch_ID int Primary Key,
//Branch_Address varchar(140),
//Contact_Number int,
//City varchar(40),

//)

//Create table Jobs
//(
//Job_ID int Primary Key,
//Position varchar(40),
//Salary money,
//)
    public class WorkProperties
    {
        ////JOB
        public String Position { get; set; }
        public String Salary { get; set; }
        ////BRANCH
        public String Branch_Address { get; set; }
        public String ContactNumberBranch { get; set; }
        public String CityBranch { get; set; }
        ///Department
        public string DepartmentName { get; set; }        

    }
}
