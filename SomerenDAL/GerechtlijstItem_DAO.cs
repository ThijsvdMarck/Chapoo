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
            string query = "SELECT BestellingID, Aantal, [Status], Gerecht.Gerechtnaam" +
                           "FROM Gerechtlijst" +
                           "JOIN Gerecht" + 
                           "ON Gerechtlijst.GerechtID = Gerecht.GerechtID" +
                           "WHERE BestellingID = " + geselecteerdeBestelling.ToString();

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
                    GerechtID = (int)dr["GerechtID"],
                    Aantal = (int)dr["Aantal"],
                    status = (Status)Enum.Parse(typeof(Status), (string)dr["Status"]),
                    GerechtNaam = (string)dr["Gerecht.Gerechtnaam"]

                };
                gerechtItems.Add(gerechtlijstItem);
            }
            return gerechtItems;
        }
    }
}
