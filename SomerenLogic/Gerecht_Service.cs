using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenLogic
{
    public class Gerecht_Service
    {
        Gerecht_DAO gerecht_db = new Gerecht_DAO();

        public List<Gerecht> GetGerechten()
        {
            try
            {
                List<Gerecht> gerecht = gerecht_db.Db_Get_All_Gerechten();
                return gerecht;
            }
            catch (Exception)
            {
                // something went wrong connecting to the database, so we will add a fake student to the list to make sure the rest of the application continues working!
                List<Gerecht> gerecht = new List<Gerecht>();
                Gerecht a = new Gerecht();
                a.gerechtID = 1;
                a.gerechtNaam = "VOEDSEL!!";

                return gerecht;
                //throw new Exception("Someren couldn't connect to the database");
            }

        }
    }
}
