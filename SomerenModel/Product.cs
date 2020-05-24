using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SomerenModel
{
    public class Product
    {
        public int aantal { get; set; }

        public string naam { get; set; }

        public Gerecht Gerecht { get; set; }
    }
}