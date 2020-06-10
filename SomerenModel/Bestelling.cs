using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Bestelling
    {
        public DateTime datum { get; set;}
        public Serveerder Serveerder { get; set; }
        public int TafelID { get; set; }
        public int BestellingID { get; set; }
        public StatusBestelling status { get; set; }
    }
}

