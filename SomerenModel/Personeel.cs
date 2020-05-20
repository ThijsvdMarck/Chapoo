using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    class Personeel
    {
        public int PersoneelID { get; set; }
        public string Naam { get; set; }
        public DateTime Geboortedatum { get; set; }
        public string Functie { get; set; } // wordt denk enum 
    }
}
