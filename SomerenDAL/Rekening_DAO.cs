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
    public class Rekening_DAO : Base
    {
        public void Db_Insert_Rekening(double fooi, string commentaar, BetaalMethode betaalMethode, int bestellingID, double eindBedrag)
        {
            string query = "INSERT INTO Rekening VALUES(" + fooi + ", '" + commentaar + "', '" + betaalMethode.ToString() + "', " + bestellingID + ", "+ eindBedrag + ")";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            ExecuteEditQuery(query, sqlParameters);
        }
    }
}
