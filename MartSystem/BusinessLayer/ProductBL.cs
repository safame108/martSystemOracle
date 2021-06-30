using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuisnessObject;
using DataAccess;
using Oracle.ManagedDataAccess.Client;

namespace BusinessLayer
{
    public class ProductBL
    {
        ProductsDAL PDAL;
        public ProductBL()
        {
            PDAL = new ProductsDAL();
        }

        public OracleDataAdapter DisplayProducts()
        {
            return PDAL.DisplayProducts();
        }
        public void AddProduct(ProductBO P)
        {
            PDAL.AddProduct(P);
        }
        public ProductBO UpdateProduct(ProductBO P)
        {
            return PDAL.UpdateProduct(P);
        }
        public ProductBO RetrieveProductInfo(int id)
        {
            return PDAL.RetrieveProductInfo(id);
        }
        public OracleDataAdapter RetrieveProductInfo(string name)
        {
            return PDAL.RetrieveProductInfo(name);
        }
        public List<SupplierBO> GetSuppliers()
        {
            return GetSuppliers();
        }

        public OracleDataAdapter GetSuppliers1()
        {
            return PDAL.GetSuppliers1();
        }
        public List<CategoryBO> GetCategories()
        {
            return GetCategories();

        }
        public OracleDataAdapter WarningList()
        {
            return PDAL.WarningList();
        }

        public OracleDataAdapter Sales()
        {
            return PDAL.Sales();
        }

        public void RemoveProduct(int id)
        {
            PDAL.RemoveProduct(id);
        }
        public void AddSales(Cart c)
        {
            PDAL.AddSales(c);
        }
    }
}
