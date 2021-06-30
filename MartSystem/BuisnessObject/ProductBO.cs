using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessObject
{
    public class ProductBO
    {
       public int  ProductID { get; set; }
        public String ProductName { get; set; }
        public int SupplierID { get; set; }
        public int CategoryID { get; set; }
        public String ProductDesc { get; set; }
        public Double UnitPrice { get; set; }
        public String ExpireDate { get; set; }
        public int TotalQuantity { get; set; }
    }
}
