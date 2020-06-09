using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomerenDAL;
using SomerenModel;

namespace SomerenLogic
{
    public class GerechtlijstItem_Service
    {
        GerechtlijstItem_DAO gerechtlijst_db = new GerechtlijstItem_DAO();

        public List<GerechtlijstItem> GetGerechtlijstItems(int geselecteerdeBestelling)
        {
            try
            {
                List<GerechtlijstItem> gerechtlijstItems = gerechtlijst_db.Db_Get_All_GerechtlijstItems(geselecteerdeBestelling);
                return gerechtlijstItems;
            }
            catch (Exception)
            {
                // something went wrong connecting to the database, so we will add a fake student to the list to make sure the rest of the application continues working!
                List<GerechtlijstItem> gerechtlijstItems = new List<GerechtlijstItem>();
                GerechtlijstItem g = new GerechtlijstItem();
                g.GerechtID = 111111;
                g.status = Status.KlaarVoorServeren;
                g.BestellingID = 69;
                g.Aantal = 420;

                gerechtlijstItems.Add(g);

                return gerechtlijstItems;
                //throw new Exception("Someren couldn't connect to the database");
            }

        }
    }
}
