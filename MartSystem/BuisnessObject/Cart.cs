using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessObject
{
    public class Cart
    {
        public List<ProductBO> cart = new List<ProductBO>();

        public double TOTALPRICE = 0;
        public string name { get; set; }
        public string contact { get; set; }
        public int totalItems = 0;
    }
}
