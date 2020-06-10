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
    public class Drankje_DAO : Base
    {

        public List<Drankje> Db_Get_All_Drankjes()
        {
            string query = "SELECT DrankID, Dranknaam, Voorraad, Alcoholisch, Prijs FROM [Drankje]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Drankje> ReadTables(DataTable dataTable)
        {
            List<Drankje> drankjes = new List<Drankje>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Drankje drankje = new Drankje()
                {
                    drankID = (int)dr["DrankID"],
                    drankNaam = (string)dr["Dranknaam"],
                    voorraad = (int)dr["Voorraad"],
                    alcholisch = (Alcholisch)Enum.Parse(typeof(Alcholisch), (string)dr["Alcoholisch"]),
                    prijs = (double)dr["Prijs"]

                };
                drankjes.Add(drankje);
            }
            return drankjes;
        }


        public void Db_Update_Drankje(string query)
        {
            SqlParameter[] sqlParameters = new SqlParameter[0];
            ExecuteEditQuery(query, sqlParameters);
        }
        
    }
}
