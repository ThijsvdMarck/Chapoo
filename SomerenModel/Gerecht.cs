using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SomerenModel
{
    public class Gerecht
    {
        public int dagType { get; set; } //enum

        public string gerechtNaam { get; set; }

        public float prijs { get; set; }

        public int soortGerecht { get; set; } //enum
    }
}