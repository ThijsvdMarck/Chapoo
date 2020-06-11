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
    public class DrankLijstItem_DAO : Base
    {

        public List<DrankLijstItem> Db_Get_All_DrankLijstItems(int bestelling)
        {
            string query = "SELECT Dranklijst.BestellingID, Dranklijst.DrankID, Aantal, [Status], Drankje.Dranknaam, Tijd, TafelID FROM Dranklijst JOIN Drankje ON Dranklijst.DrankID = Drankje.DrankID JOIN Bestelling ON Dranklijst.BestellingID=Bestelling.BestellingID JOIN Tafel ON Tafel.BestellingID=Bestelling.BestellingID WHERE Dranklijst.BestellingID = " + bestelling.ToString();
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        public List<DrankLijstItem> Db_Get_All_DrankLijstItemsTafel()
        {
            string query = "SELECT Dranklijst.BestellingID, Dranklijst.DrankID, Aantal, [Status], Drankje.Dranknaam, Tijd, TafelID FROM Dranklijst JOIN Drankje ON Dranklijst.DrankID = Drankje.DrankID JOIN Bestelling ON Dranklijst.BestellingID=Bestelling.BestellingID JOIN Tafel ON Tafel.BestellingID=Bestelling.BestellingID";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<DrankLijstItem> ReadTables(DataTable dataTable)
        {
            List<DrankLijstItem> drankLijstItems = new List<DrankLijstItem>();

            foreach (DataRow dr in dataTable.Rows)
            {
                DrankLijstItem drankLijstItem = new DrankLijstItem()
                {
                    drankNaam = (string)dr["Dranknaam"],
                    bestellingID = (int)dr["BestellingID"],
                    status = (Status)Enum.Parse(typeof(Status), (string)dr["Status"]),
                    aantal = (int)dr["Aantal"],
                    tijd = (DateTime)dr["Tijd"],
                    drankID = (int)dr["DrankID"],
                    TafelID = (int)dr["TafelID"]
                };
                drankLijstItems.Add(drankLijstItem);
            }
            return drankLijstItems; 
        }

        public void AddDrankLijsItem(int drankID, int bestellingID, int aantal)
        {

            string status = Status.Besteld.ToString();
            string AddDrankLijsItem = $"Insert into [Dranklijst] (DrankID, BestellingID, Aantal, Status, Tijd) Values ( {drankID},{bestellingID},{aantal},'{status}',{DateTime.Now})";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            ExecuteEditQuery(AddDrankLijsItem, sqlParameters);
        }


        public void Db_Update_DrankItem(Status status, int bestelling, int drankje)
        {
            string query = "UPDATE Dranklijst SET[Status] = '" + status.ToString() + "' WHERE BestellingID = " + bestelling.ToString() + " AND DrankID = " + drankje.ToString();

            SqlParameter[] sqlParameters = new SqlParameter[0];
            ExecuteEditQuery(query, sqlParameters);
        }

    }
}
