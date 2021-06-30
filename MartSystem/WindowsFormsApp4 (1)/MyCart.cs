using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using BuisnessObject;


namespace WindowsFormsApp4
{
    public class MyCart
    {
        ProductBL PBL = new ProductBL();
        public List<ProductBO> cart = new List<ProductBO>();
        public double TOTALPRICE = 0;
        public string name { get; set; }
        public string contact { get; set; }
        public int totalItems = 0;
        public void addCart(ProductBO p)
        {
            cart.Add(p);
        }
        public void removeCart(string p)
        {
            for (int i = 0; i < cart.Count; i++)
            {
                if (p == cart[i].ProductName)
                {
                    TOTALPRICE -= cart[i].UnitPrice;
                    cart.Remove(cart[i]);
                }
            }
        }

        public void UpdateInventory()
        {

            for (int i = 0; i < cart.Count; i++)
            {
                ProductBO product = PBL.RetrieveProductInfo(cart[i].ProductID);
                product.TotalQuantity -= cart[i].TotalQuantity;
                PBL.UpdateProduct(product);
            }
            totalItems = cart.Count;
        }
    }
}
