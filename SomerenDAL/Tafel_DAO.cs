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
    public class Tafel_DAO : Base
    {
        public List<Tafel> Db_Get_All_Tafels()
        {
            string query = "SELECT TafelID, Gereserveerd FROM [Tafel]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Tafel> ReadTables(DataTable dataTable)
        {
            List<Tafel> tafels = new List<Tafel>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Tafel tafel = new Tafel()
                {
                    tafelID = (int)dr["TafelID"],
                    gereserveerd = (Gereserveerd)Enum.Parse(typeof(Gereserveerd), (string)dr["Gereserveerd"])
                };
                tafels.Add(tafel);
            }
            return tafels;
        }
    }
}
