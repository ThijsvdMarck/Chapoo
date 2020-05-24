using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SomerenModel
{
    public class Tafel
    {
        public bool gereserveerd { get; set; }

        public Bestelling Bestelling { get; set; }
    }
}