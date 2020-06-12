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
        Barpersoneel, Kok, Serveerder, Manager
        // Barpersoneel = Bar & Voorraad
        // Kok = Keuken & Voorraad
        // Serveerder = Tafels & Bar
        // Manager = Alles
    }

    public enum Status
    {
        Besteld, WordtBereid, KlaarVoorServeren, Geserveerd, Opslag
    }
    public enum SoortDrankje
    {
        Frisdrank, Bier, Wijn, GedestilleerdeDrank, KoffieThee
    }
    public enum StatusBestelling
    {
        Open, Afgerond, Betaald
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

