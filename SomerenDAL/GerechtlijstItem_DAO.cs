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
    public class GerechtlijstItem_DAO : Base
    {
        public List<GerechtlijstItem> Db_Get_All_GerechtlijstItems(int geselecteerdeBestelling)
        {
            string query = "SELECT Bestelling.BestellingID, Gerechtlijst.GerechtID, Aantal, [Status], Gerecht.Gerechtnaam, Tijd, TafelID FROM Gerechtlijst JOIN Gerecht ON Gerechtlijst.GerechtID = Gerecht.GerechtID JOIN Bestelling ON Gerechtlijst.BestellingID=Bestelling.BestellingID JOIN Tafel ON Tafel.BestellingID=Bestelling.BestellingID WHERE Gerechtlijst.BestellingID =" + geselecteerdeBestelling.ToString();

            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        
        public List<GerechtlijstItem> Db_Get_All_GerechtlijstItemsTafel()
        {
            string query = "SELECT Bestelling.BestellingID, Gerechtlijst.GerechtID, Aantal, [Status], Gerecht.Gerechtnaam, Tijd, TafelID FROM Gerechtlijst JOIN Gerecht ON Gerechtlijst.GerechtID = Gerecht.GerechtID JOIN Bestelling ON Gerechtlijst.BestellingID=Bestelling.BestellingID JOIN Tafel ON Tafel.BestellingID=Bestelling.BestellingID";

            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        } 

        private List<GerechtlijstItem> ReadTables(DataTable dataTable)
        {
            List<GerechtlijstItem> gerechtItems = new List<GerechtlijstItem>();

            foreach (DataRow dr in dataTable.Rows)
            {
                GerechtlijstItem gerechtlijstItem = new GerechtlijstItem()
                {
                    BestellingID = (int)dr["BestellingID"],
                    Aantal = (int)dr["Aantal"], 
                    status = (Status)Enum.Parse(typeof(Status), (string)dr["Status"]),
                    GerechtNaam = (string)dr["Gerechtnaam"],
                    Tijd = (DateTime)dr["Tijd"],
                    GerechtID = (int)dr["GerechtID"],
                    TafelID = (int)dr["TafelID"]
                };
                gerechtItems.Add(gerechtlijstItem);
            }
            return gerechtItems;
        }

        public void Db_Update_GerechtItem(Status status, int bestelling, int gerecht)
        {
            string query = "UPDATE Gerechtlijst SET[Status] = '" + status.ToString() + "' WHERE BestellingID = " + bestelling.ToString() + " AND GerechtID = " + gerecht.ToString();

            SqlParameter[] sqlParameters = new SqlParameter[0];
            ExecuteEditQuery(query, sqlParameters);
        }
        public void Db_Delete_GerechtItem(int aantal, int bestelling, int gerecht)
        {
            string query = "UPDATE Gerechtlijst SET[Aantal] = '" + aantal.ToString() + "' WHERE BestellingID = " + bestelling.ToString() + " AND GerechtID = " + gerecht.ToString();

            SqlParameter[] sqlParameters = new SqlParameter[0];
            ExecuteEditQuery(query, sqlParameters);
        }

        public void AddGerechtLijsItem(int gerechtID, int bestellingID, int aantal)
        {
            /*DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")*/
            // 29 - 5 - 20 13:50:00
            DateTime Datum = DateTime.Now;
            string AddGerechtLijsItem = "INSERT into [Gerechtlijst] (GerechtID, BestellingID, Aantal, Status, Tijd) Values (" + gerechtID + "," + bestellingID + "," + aantal + ",'" + Status.Opslag.ToString() + "', '" + Datum.ToString("yyyy/MM/dd HH:mm:ss.fff") + "')";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            ExecuteEditQuery(AddGerechtLijsItem, sqlParameters);
        }


        public List<GerechtlijstItem> Db_Get_Gerechten_Bestelling(int tafelID)
        {
            string query = "SELECT Gerechtnaam, Aantal, Prijs, TafelID FROM Gerechtlijst JOIN Gerecht ON Gerecht.GerechtID=Gerechtlijst.GerechtID JOIN Bestelling ON Bestelling.BestellingID=Gerechtlijst.BestellingID JOIN Tafel ON Tafel.BestellingID=Bestelling.BestellingID WHERE TafelID=" + tafelID.ToString();
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTablesVoorTafelBestelling(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<GerechtlijstItem> ReadTablesVoorTafelBestelling(DataTable dataTable)
        {
            List<GerechtlijstItem> gerechtLijstItems = new List<GerechtlijstItem>();

            foreach (DataRow dr in dataTable.Rows)
            {
                GerechtlijstItem gerechtLijstItem = new GerechtlijstItem()
                {
                    GerechtNaam = (string)dr["Gerechtnaam"],
                    Aantal = (int)dr["Aantal"],
                    Prijs = (double)dr["Prijs"],
                    TafelID = (int)dr["TafelID"]
                };
                gerechtLijstItems.Add(gerechtLijstItem);
            }
            return gerechtLijstItems;
        }


    }
}
