using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;
using SomerenModel;
using System.Runtime.CompilerServices;

namespace SomerenDAL
{
    public class Drankje_DAO : Base
    {

        public List<Drankje> Db_Get_All_Drankjes()
        {
            string query = "SELECT DrankID, Dranknaam, Voorraad, Alcoholisch, Prijs, Soortdrankje FROM [Drankje]";
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
                    prijs = (double)dr["Prijs"],
                    soortDrankje = (SoortDrankje)Enum.Parse(typeof(SoortDrankje), (string)dr["Soortdrankje"])
                };
                drankjes.Add(drankje);
            }
            return drankjes;
        }
        public int GetDrankID(string Dranknaam)
        {
            string query = "SELECT DrankID FROM Drankje WHERE Dranknaam = '" + Dranknaam + "'";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTableForDrankID(ExecuteSelectQuery(query, sqlParameters));

        }
        private int ReadTableForDrankID(DataTable dataTable)
        {
            int DrankID = 0;
            foreach (DataRow dr in dataTable.Rows)
            {
                DrankID = (int)dr["DrankID"];
            }
            return DrankID;
        }

        public void Db_Update_Drankje(string naam, string prijs, string alcoholisch, string hoeveelheid)
        {
            string query = "INSERT INTO drankje VALUES ('" + naam + "', " + prijs + ", '" + alcoholisch + "', " + hoeveelheid + ")";

            SqlParameter[] sqlParameters = new SqlParameter[0];
            ExecuteEditQuery(query, sqlParameters);
        }
        
    }
}
