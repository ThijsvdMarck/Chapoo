﻿using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SomerenLogic
{
    public class Tafel_Service
    {
        Tafel_DAO tafel_db = new Tafel_DAO();

        public List<Tafel> GetTafels()
        {
            try
            {
                List<Tafel> tafels = tafel_db.Db_Get_All_Tafels();
                return tafels;
            }
            catch (Exception)
            {
                // something went wrong connecting to the database, so we will add a fake student to the list to make sure the rest of the application continues working!
                List<Tafel> tafels = new List<Tafel>();
                Tafel a = new Tafel();
                a.tafelID = 11;
                a.gereserveerd = Gereserveerd.Ja;

                tafels.Add(a);

                return tafels;
                //throw new Exception("Someren couldn't connect to the database");
            }

        }
        public int GetHuidigeBestelling(int TafelNummer)
        {
           return tafel_db.GetHuidigeBestelling(TafelNummer);
        }

        public void UpdateBestellingIDTafel(int bestelling, int tafelNr)
        {
            tafel_db.Db_Update_BestellingID_Tafel(bestelling, tafelNr);
        }

        public void KoppelBestelling(int bestelling, int tafelNr)
        {
            tafel_db.Db_Koppel_Bestelling(bestelling, tafelNr);
        }
     
    }
}
