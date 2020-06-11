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

    }
}
