using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Personeel
    {
        public int PersoneelID { get; set; }
        public String Naam { get; set; } // naam van werknemer
        public DateTime geboortedatum { get; set; } // geboortedatum van werknemer
        public Functie functie { get; set; }
    }
}
