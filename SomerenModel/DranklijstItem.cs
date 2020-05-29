using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class DrankLijstItem
    {
        public int aantal { get; set; }
        public Status status { get; set; }
        public string drankNaam { get; set; }
        public int bestellingID { get; set; }
    }
}
