using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Drankje
    {
        public String drankNaam { get; set; } // naam van het drankje
        public double prijs { get; set; } // prijs van het drankje
        public String alcholisch { get; set; } // is het drankje alcoholisch (ja of nee)
        public int aantal { get; set; } // voorraad van drankjes
    }
}
