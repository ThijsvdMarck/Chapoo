using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    class Drankje
    {
        public int DrankID { get; set; }
        public string DrankNaam { get; set; }
        public float Prijs { get; set; }
        public string Alcoholisch { get; set; } // bool? 
        public int Aantal { get; set; }
    }
}
