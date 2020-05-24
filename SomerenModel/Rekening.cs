using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SomerenModel
{
    public class Rekening
    {
        public int betaalMethode { get; set; } // enum

        public string commentaar { get; set; }

        public float fooi { get; set; }

        public Bestelling Bestelling { get; set; }
    }
}