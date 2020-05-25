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
    public class Klant_Service
    {
        Klant_DAO klant_db = new Klant_DAO();

        public List<Klant> GetKlanten()
        {
            try
            {
                List<Klant> klanten = klant_db.Db_Get_All_Klanten();
                return klanten;
            }
            catch (Exception)
            {
                // something went wrong connecting to the database, so we will add a fake student to the list to make sure the rest of the application continues working!
                List<Klant> klanten = new List<Klant>();
                Klant a = new Klant();
                a.naam = "FrAnX";
                a.datum = DateTime.Now;
                a.tafelID = 11;

                return klanten;
                //throw new Exception("Someren couldn't connect to the database");
            }

        }
    }
}
