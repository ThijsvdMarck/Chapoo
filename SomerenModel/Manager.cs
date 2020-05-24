using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SomerenModel
{
    public class Manager : Personeel
    {
        public Personeel functie { get; set; } // enum
    }
}