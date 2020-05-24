using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SomerenModel
{
    public class Bestelling
    {
        public DateTime datum { get; set; }

        public int status { get; set; } //enum

        public Drankje Drankje { get; set; }

        public Serveerder Serveerder { get; set; }

        public Gerecht Gerecht { get; set; }
    }
}