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
    public class Klant_DAO : Base
    {
        public List<Klant> Db_Get_All_Klanten()
        {
            string query = "SELECT Naam, Datum, Tafelnummer, TafelID FROM [Klant]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Klant> ReadTables(DataTable dataTable)
        {
            List<Klant> klanten = new List<Klant>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Klant klant = new Klant()
                {
                    naam = (string)dr["Naam"],
                    datum = (DateTime)dr["Datum"],
                    telefoonnummer = (int)dr["telefoonnummer"],
                    tafelID = (int)dr["TafelID"]
                };
                klanten.Add(klant);
            }
            return klanten;
        }
    }
}
