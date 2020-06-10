using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomerenDAL;
using SomerenModel;

namespace SomerenLogic
{
    public class Bestelling_Service
    {
        Bestelling_DAO bestelling_db = new Bestelling_DAO();

        public List<Bestelling> GetBestelling()
        {
            try
            {
               List<Bestelling> bestellingen = bestelling_db.Db_Get_All_Bestellingen();
               return bestellingen;
            }
            catch (Exception)
            {
                // something went wrong connecting to the database, so we will add a fake student to the list to make sure the rest of the application continues working!
                List<Bestelling> bestellingen = new List<Bestelling>();
                Bestelling b = new Bestelling();
                b.BestellingID = 111111;

                bestellingen.Add(b);

                return bestellingen;
                //throw new Exception("Someren couldn't connect to the database");
            }

        }

        public void UpdateBestelling(StatusBestelling status, int bestelling)
        {
            try
            {
                bestelling_db.Db_Update_Bestelling(status, bestelling);
            }
            catch (Exception)
            {
                //
            }
        }
    }
}
