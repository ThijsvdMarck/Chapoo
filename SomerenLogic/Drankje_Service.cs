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
    public class Drankje_Service
    {
        Drankje_DAO drankje_db = new Drankje_DAO();

        public List<Drankje> GetDrankjes()
        {
            try
            {
                List<Drankje> drankje = drankje_db.Db_Get_All_Drankjes();
                return drankje;
            }
            catch (Exception)
            {
                // something went wrong connecting to the database, so we will add a fake student to the list to make sure the rest of the application continues working!
                List<Drankje> drankje = new List<Drankje>();
                Drankje a = new Drankje();
                a.drankID = 1;
                a.drankNaam = "Pussy juice";
                a.voorraad = 42069;
               
                return drankje;
                //throw new Exception("Someren couldn't connect to the database");
            }

        }

        public void UpdateDrankje(string query)
        {
            try
            {
                drankje_db.Db_Update_Drankje(query);
            }
            catch (Exception)
            {
                //
            }
        }
    }
}
