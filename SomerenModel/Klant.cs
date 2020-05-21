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

        internal Tafel Tafel
        {
            get => default;
            set
            {
            }
        }
    }
}
