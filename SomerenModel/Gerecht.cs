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
        public SoortGerecht soortGerecht { get; set; } // Voorgerecht,hoofdgerecht en nagerecht
        public DagType dagType { get; set; } // lunch of diner
        public int voorraad { get; set; }
    }
}
