using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    class Gerecht
    {
        public int GerechtID { get; set; }
        public string GerechtNaam { get; set; }
        public float Prijs { get; set; }
        public string SoortGerecht { get; set; } // misschien ook enum
        public string DagType { get; set; } // ook enum
    }
}
