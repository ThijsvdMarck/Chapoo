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
    public class Rekening_Service
    {
        Rekening_DAO rekening_db = new Rekening_DAO();

        public void InsertRekening(double fooi, string commentaar, BetaalMethode betaalMethode, int bestellingID, double eindBedrag)
        {
            try
            {
                rekening_db.Db_Insert_Rekening(fooi, commentaar, betaalMethode, bestellingID, eindBedrag);
            }
            catch (Exception)
            {
                //
            }
        }
    }
}
