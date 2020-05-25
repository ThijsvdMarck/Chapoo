using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Bestelling
    {
        public Status status { get; set;} // Besteld, in bereiding en gereed voor serveren
        public DateTime datum { get; set;}

        public Serveerder Serveerder { get; set; }

        public Drankje Drankje { get; set; }

        internal Gerecht Gerecht { get; set; }
    }
}

