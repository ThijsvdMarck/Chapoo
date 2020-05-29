using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Klant
    {
        public String naam { get; set;} //naam van klant
        public DateTime datum { get; set;} // datum van tafelreservering
        public int telefoonnummer { get; set; } //telefoonnummer van de klant
        public int tafelID { get; set; } 
        internal Tafel Tafel { get; set; }
    }
}
