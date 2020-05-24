using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SomerenModel
{
    public class Barman : Personeel
    {
        public Personeel functie { get; set; } //enum
    }
}