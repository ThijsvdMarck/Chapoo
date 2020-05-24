using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SomerenModel
{
    public class Klant
    {
        public DateTime datum { get; set; }

        public string naam { get; set; }

        public Tafel Tafel { get; set; }
    }
}