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

        public List<DrankLijstItem> Db_Get_All_DrankLijstItems()
        {
            string query = "SELECT DrankID, BestellingID, Aantal, Status FROM [Dranklijst]";
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
                    drankID = (int)dr["DrankID"],
                    bestellingID = (int)dr["BestellingID"],
                    status = (Status)(dr["Status"]),
                    aantal = (int)(dr["Aantal"])

                };
                drankLijstItems.Add(drankLijstItem);
            }
            return drankLijstItems;
        }

    }
}