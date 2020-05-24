using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Product
    {

        public int productId { get; set; }
        public string productNaam { get; set; }
        public int productAantal { get; set; }  //Hoeveel nog in voorraad van de producten

       

        internal Gerecht Gerecht
        {
            get => default;
            set
            {
            }
        }

    }
}
