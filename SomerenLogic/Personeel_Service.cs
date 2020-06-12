using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomerenDAL;
using SomerenModel;

namespace SomerenLogic
{
    public class Personeel_Service
    {
        Personeel_DAO personeel_db = new Personeel_DAO();

        public List<Personeel> GetPersoneel()
        {
            try
            {
                List<Personeel> personeels = personeel_db.Db_Get_All_Personeel();
                return personeels;
            }
            catch (Exception)
            {
                // something went wrong connecting to the database, so we will add a fake student to the list to make sure the rest of the application continues working!
                List<Personeel> personeels = new List<Personeel>();
                Personeel a = new Personeel();
                a.PersoneelID = 111111;
                a.Naam = "VLEESSSSS!!!";
                a.functie = Functie.Serveerder;

                personeels.Add(a);

                return personeels;
                //throw new Exception("Someren couldn't connect to the database");
            }

        }

        public int GetIngelogdeID(string naam)
        {
            int ID = personeel_db.Db_Get_Ingelogd_ID(naam);
            return ID;
        }
    }
}
