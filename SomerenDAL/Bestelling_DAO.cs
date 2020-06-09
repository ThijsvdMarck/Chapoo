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
    public class Bestelling_DAO : Base
    {

        public List<Bestelling> Db_Get_All_Bestellingen()
        {
            string query = "SELECT BestellingID, TafelID, PersoneelID, Datum FROM [Bestelling]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Bestelling> ReadTables(DataTable dataTable)
        {
            List<Bestelling> bestellingen = new List<Bestelling>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Bestelling bestelling = new Bestelling()
                {
                    
                    BestellingID = (int)dr["BestellingID"],
                    TafelID = (int)dr["TafelID"],
                    datum = (DateTime)dr["Datum"]                    
                     
                };
                bestellingen.Add(bestelling);
            }
            return bestellingen;
        }
    }
}
