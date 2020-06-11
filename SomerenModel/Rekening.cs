using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    class Rekening
    {
        public double fooi { get; set; }
        public string commentaar { get; set; }
        public BetaalMethode betaalMethode { get; set; } // pin cash creditcard
        public Bestelling Bestelling { get; set; }
    }
}
