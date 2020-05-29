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
            string query = "SELECT BestellingID, Status, DrinkID, GerechtID, PersoneelID, Datum FROM [Bestelling]";
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
                    drankID = (int)dr["DrankID"],
                    drankNaam = (string)(dr["Dranknaam"].ToString()),
                    /* prijs = (double)(dr["drankje_prijs"].ToString("C2")),
                     alcholisch = (string)(dr["drankje_alcholisch"].ToString()),
                     aantal = (int)(dr["drankje_aantal"].ToString())                      
                       */
                };
                bestellingen.Add(drankje);
            }
            return bestellingen;
        }
    }
}
