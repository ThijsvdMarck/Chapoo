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
    public class Personeel_DAO : Base
    {
        public List<Personeel> Db_Get_All_Personeel()
        {
            string query = "SELECT PersoneelID, Naam, Functie, Geboortedatum FROM [Personeel]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Personeel> ReadTables(DataTable dataTable)
        {
            List<Personeel> personeels = new List<Personeel>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Personeel personeel = new Personeel()
                {
                    PersoneelID = (int)dr["PersoneelID"],
                    Naam = (string)dr["Naam"],
                    functie = (Functie)Enum.Parse(typeof(Functie), (string)dr["Functie"]),
                    geboortedatum = DateTime.Now
                };
                personeels.Add(personeel);
            }
            return personeels;
        }
    }
}
