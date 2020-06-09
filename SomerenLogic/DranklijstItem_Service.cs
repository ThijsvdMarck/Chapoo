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
    public class DrankLijstItem_Service
    {
        DrankLijstItem_DAO drankLijstItem_db = new DrankLijstItem_DAO();

        public List<DrankLijstItem> GetDrankLijstItems()
        {
            try
            {
                List<DrankLijstItem> drankLijstItem = drankLijstItem_db.Db_Get_All_DrankLijstItems();
                return drankLijstItem;
            }
            catch (Exception)
            {
                // something went wrong connecting to the database, so we will add a fake student to the list to make sure the rest of the application continues working!
                List<DrankLijstItem> drankLijstItem = new List<DrankLijstItem>();
                DrankLijstItem a = new DrankLijstItem();
                a.drankNaam = "Water";
                a.bestellingID = 1;
                a.aantal = 420;
                a.status = Status.Besteld;
                a.tijd = DateTime.Now;

                return drankLijstItem;
                //throw new Exception("Someren couldn't connect to the database");
            }

        }
        public void AddDrankLijsItem(int DrankID, int BestellingID, int Aantal)
        {
            drankLijstItem_db.AddDrankLijsItem( DrankID,  BestellingID,  Aantal);
        }

    }
}
