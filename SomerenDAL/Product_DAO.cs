using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;
using SomerenModel;

namespace SomerenDAL
{
    public class Product_DAO : Base
    {

        public List<Product> Db_Get_All_Producten()
        {
            string query = "SELECT ProductID, Naam FROM [Product]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Product> ReadTables(DataTable dataTable)
        {
            List<Product> producten = new List<Product>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Product product = new Product()
                {
                    productId = (int)dr["ProductID"],
                    productNaam = (string)(dr["naam"].ToString()),
                    /*productAantal = (int)(dr["Dranknaam"].ToString*/                           
                 };
                producten.Add(product);
            }
            return producten;
        }

    }
}
