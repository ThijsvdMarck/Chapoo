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
    public class Gerecht_DAO : Base
    {

        public List<Gerecht> Db_Get_All_Gerechten()
        {
            string query = "SELECT GerechtID, GerechtNaam FROM [Gerecht]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Gerecht> ReadTables(DataTable dataTable)
        {
            List<Gerecht> gerechten = new List<Gerecht>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Gerecht gerecht = new Gerecht()
                {
                    gerechtID = (int)dr["GerechtID"],
                    gerechtNaam = (string)(dr["GerechtNaam"].ToString()),
                    /*
                    prijs = (double)(dr["prijs"].ToString("00.00")),
                    soortGerecht = (string)(dr["SoortGerecht"].ToString()),
                    dagType = (string)(dr["DagType"].ToString()),*/

    };
                gerechten.Add(gerecht);
            }
            return gerechten;
        }

    }
}
