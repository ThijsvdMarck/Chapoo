using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    class Rekening
    {
        public int RekeningID { get; set; }
        public float Fooi { get; set; }
        public string Commentaar { get; set; }
        public string BetaalMethode { get; set; } // enum
        public int BestellingID { get; set; }
        public float TotaalPrijs { get; set; }
    }
}
