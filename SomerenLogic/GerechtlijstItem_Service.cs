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
        
        public List<GerechtlijstItem> GetGerechtlijstItemsTafel()
        {
            try
            {
                List<GerechtlijstItem> gerechtlijstItems = gerechtlijst_db.Db_Get_All_GerechtlijstItemsTafel();
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

        public void UpdateGerechtItem(Status status, int bestelling, int gerecht)
        {
            try
            {
                gerechtlijst_db.Db_Update_GerechtItem(status, bestelling, gerecht);
            }
            catch (Exception)
            {
                //
            }
        }

        public void AddGerechtLijstItem(int gerechtID, int bestellingID, int aantal)
        {
            gerechtlijst_db.AddGerechtLijsItem(gerechtID, bestellingID, aantal);

        }
        public void WijzigGerechtLijstItem(int aantal, int bestellingID, int gerechtID)
        {
            gerechtlijst_db.Db_Delete_GerechtItem(aantal, bestellingID, gerechtID);

        }
        public List<GerechtlijstItem> GerechtenBestellingVanTafel(int tafelID)
        {
            try
            {
                List<GerechtlijstItem> gerechtlijstItems = gerechtlijst_db.Db_Get_Gerechten_Bestelling(tafelID);
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
