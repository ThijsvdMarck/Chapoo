using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    class Bestelling
    {
        public int BestellingID { get; set; }
        public string Status { get; set; } // enum
        public int DrankID { get; set; }
        public int GerechtID { get; set; }
        public int PersoneelID { get; set; }
        public DateTime Datum { get; set; }
    }
}
