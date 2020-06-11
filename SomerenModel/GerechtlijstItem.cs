using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class GerechtlijstItem
    {
        public int GerechtID { get; set; }
        public int BestellingID { get; set; }
        public int Aantal { get; set; }
        public Status status { get; set; }
        public string GerechtNaam { get; set; }
        public DateTime Tijd { get; set; }
        public int TafelID { get; set; }
    }
}
