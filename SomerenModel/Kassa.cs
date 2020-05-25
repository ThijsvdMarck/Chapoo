using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Kassa
    {
        public Bestelling Bestelling { get; set; }

        internal Tafel Tafel { get; set; }
    }
}
