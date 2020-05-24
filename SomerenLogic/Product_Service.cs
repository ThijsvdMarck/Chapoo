using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenLogic
{
    public class Product_Service
    {
        Product_DAO product_db = new Product_DAO();

        public List<Product> GetProducten()
        {
            try
            {
                List<Product> product = product_db.Db_Get_All_Producten();
                return product;
            }
            catch (Exception)
            {
                // something went wrong connecting to the database, so we will add a fake student to the list to make sure the rest of the application continues working!
                List<Product> product = new List<Product>();
                Product a = new Product();
                a.productId = 1;
                a.productNaam = "VLEESSSSS!!!";

                return product;
                //throw new Exception("Someren couldn't connect to the database");
            }

        }
    }
}
