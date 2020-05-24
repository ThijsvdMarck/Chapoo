using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Gerecht
    {
        public int gerechtID { get; set; }
        public string gerechtNaam { get; set; }
        public double prijs { get; set; }
        public string soortGerecht { get; set; } // Voorgerecht,hoofdgerecht en nagerecht
        public string dagType { get; set; } // lunch of diner



    }
}
