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
            string query = "SELECT Bestelling.BestellingID, Tafel.TafelID, PersoneelID, Datum, [StatusKeuken], StatusBar FROM Bestelling JOIN Tafel ON Bestelling.BestellingID=Tafel.BestellingID";
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
                    datum = (DateTime)dr["Datum"],
                    statusKeuken = (StatusBestelling)Enum.Parse(typeof(StatusBestelling), (string)dr["StatusKeuken"]),
                    statusBar = (StatusBestelling)Enum.Parse(typeof(StatusBestelling), (string)dr["StatusBar"])
                };
                bestellingen.Add(bestelling);
            }
            return bestellingen;
        }

        public void Db_Update_BestellingKeuken(StatusBestelling status, int bestelling)
        {
            string query = "UPDATE Bestelling SET[StatusKeuken] = '" + status.ToString() + "' WHERE BestellingID = " + bestelling.ToString();

            SqlParameter[] sqlParameters = new SqlParameter[0];
            ExecuteEditQuery(query, sqlParameters);
        }

        public void Db_Update_BestellingBar(StatusBestelling status, int bestelling)
        {
            string query = "UPDATE Bestelling SET[StatusBar] = '" + status.ToString() + "' WHERE BestellingID = " + bestelling.ToString();

            SqlParameter[] sqlParameters = new SqlParameter[0];
            ExecuteEditQuery(query, sqlParameters);
        }

        // Status van huidige bestelling ophalen
        public StatusBestelling GetHuidigeBestellingStatus(int TafelNummer)
        {
            string query = "SELECT StatusBar FROM Tafel JOIN Bestelling ON Bestelling.BestellingID=Tafel.BestellingID WHERE TafelID = " + TafelNummer;
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTableForBestellingStatus(ExecuteSelectQuery(query, sqlParameters));

        }
        private StatusBestelling ReadTableForBestellingStatus(DataTable dataTable)
        {
            StatusBestelling huidigeStatus = StatusBestelling.Open;
            foreach (DataRow dr in dataTable.Rows)
            {
                huidigeStatus = (StatusBestelling)Enum.Parse(typeof(StatusBestelling), (string)dr["StatusBar"]);
            }
            return huidigeStatus;
        }
    }
}
