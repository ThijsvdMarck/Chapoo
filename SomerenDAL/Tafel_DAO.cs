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
    public class Tafel_DAO : Base
    {
        public List<Tafel> Db_Get_All_Tafels()
        {
            string query = "SELECT TafelID, Gereserveerd FROM [Tafel]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Tafel> ReadTables(DataTable dataTable)
        {
            List<Tafel> tafels = new List<Tafel>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Tafel tafel = new Tafel()
                {
                    tafelID = (int)dr["TafelID"],
                    gereserveerd = (Gereserveerd)Enum.Parse(typeof(Gereserveerd), (string)dr["Gereserveerd"])
                };
                tafels.Add(tafel);
            }
            return tafels;
        }
        public int GetHuidigeBestelling(int TafelNummer)
        {
            string query = "SELECT BestellingID FROM Tafel WHERE TafelID = " + TafelNummer;
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTableForBestellingID(ExecuteSelectQuery(query, sqlParameters));

        }
        private int ReadTableForBestellingID(DataTable dataTable)
        {
            int BestellingID = 0;
            foreach (DataRow dr in dataTable.Rows)
            {
                BestellingID = (int)dr["BestellingID"];
            }

            if (BestellingID.ToString() == null)
            {
                BestellingID = 0;
            }
            return BestellingID;
        }

        public void Db_Update_GerechtItem(Status status, int bestelling, int gerecht)
        {
            string query = "UPDATE Gerechtlijst SET [Status] = '" + status.ToString() + "' WHERE BestellingID = " + bestelling.ToString() + " AND GerechtID = " + gerecht.ToString();

            SqlParameter[] sqlParameters = new SqlParameter[0];
            ExecuteEditQuery(query, sqlParameters);
        }

        public void Db_Update_BestellingID_Tafel(int bestelling, int tafelNr)
        {
            string bestellingID;
            bestellingID = bestelling.ToString();

            if (bestelling == 0)
            {
                bestellingID = null;
            }

            string query = "UPDATE Tafel SET [BestellingID] = " + bestellingID + " WHERE TafelID = " + tafelNr.ToString();

            SqlParameter[] sqlParameters = new SqlParameter[0];
            ExecuteEditQuery(query, sqlParameters);
        }

    }
}
