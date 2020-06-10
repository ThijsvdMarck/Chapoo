using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public enum DagType
    {
        Lunch, Diner
    }

    public enum SoortGerecht
    {
        Voorgerecht, Tussengerecht, Hoofdgerecht, Nagerecht
    }

    public enum Functie
    {
        barpersoneel, kok, bediening, eigenaar
    }

    public enum Status
    {
        Besteld, WordtBereid, KlaarVoorServeren, Geserveerd
    }

    public enum StatusBestelling
    {
        Open, Afgerond
    }

    public enum BetaalMethode
    {
        CreditCard, Contant, Pin
    }

    public enum Gereserveerd
    {
        Ja, Nee
    }
    public enum Alcholisch
    {
        Ja, Nee
    }
}
