using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Drankje
    {
        public int drankID { get; set; } //ID van het drankje
        public String drankNaam { get; set; } // naam van het drankje
        public double prijs { get; set; } // prijs van het drankje
        public String alcholisch { get; set; } // heeft het drankje alcohol? (ja of nee)
        public int aantal { get; set; } // voorraad van drankjes
    }
}
