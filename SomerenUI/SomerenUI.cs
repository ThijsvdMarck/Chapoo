using SomerenLogic;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Test voor save GOGO
namespace SomerenUI
{
    // Friet is lekker
    public partial class SomerenUI : Form
    {
        SomerenLogic.Drankje_Service drankService = new SomerenLogic.Drankje_Service();
        SomerenLogic.Gerecht_Service gerechtService = new SomerenLogic.Gerecht_Service();
        SomerenLogic.Bestelling_Service bestellingService = new SomerenLogic.Bestelling_Service();
        SomerenLogic.GerechtlijstItem_Service gerechtlijstItemService = new SomerenLogic.GerechtlijstItem_Service();
        SomerenLogic.DrankLijstItem_Service drankLijstItemService = new SomerenLogic.DrankLijstItem_Service();
        SomerenLogic.Tafel_Service tafelService = new SomerenLogic.Tafel_Service();
        SomerenLogic.Personeel_Service personeelService = new SomerenLogic.Personeel_Service();
        SomerenLogic.Rekening_Service rekeningService = new SomerenLogic.Rekening_Service();



        int tafelnummer;
        double totaalPrijs;
        bool loggedIn =  false;
        string naamIngelogde;



        public SomerenUI()
        {
            InitializeComponent();
        }

        private void hideAllPanels()
        {
            // Hide all panels niet header
            pnl_LogIn.Hide();
            pnl_Base.Hide();
            pnl_BestellingsOverzicht.Hide();
            pnl_BestellingVersturen.Hide();
            pnl_BestellingVerstuurd.Hide();
            pnl_Bier.Hide();
            pnl_DinerBestelling.Hide();
            pnl_Frisdrank.Hide();
            pnl_GedestilleerdeDranken.Hide();
            pnl_KoffieThee.Hide();
            pnl_LunchBestelling.Hide();
            pnl_Overzicht.Hide();
            pnl_Reservering.Hide();
            pnl_TafelOverzicht.Hide();
            pnl_Voorraad.Hide();
            pnl_Wijn.Hide();
            pnl_MenuBalkBestelling.Hide();
            pnl_MenuBalkTafels.Hide();
            pnl_Dag.Hide();
            pnl_Week.Hide();
            pnl_Maand.Hide();
            pnl_DatumKiezen.Hide();
            pnl_MenuBalkFinanciën.Hide();
            pnl_RekeningOverzicht.Hide();
            pnl_MenuBalkRekening.Hide();
            pnl_Reservering.Hide();
            pnl_MenuBalkReserveringen.Hide();
            pnl_MenuBalkKeukenOverzicht.Hide();
            pnl_MenuBalkBarOverzicht.Hide();
            pnl_KeukenOverzicht.Hide();
            pnl_BarOverzicht.Hide();
            pnl_BestellingBar.Hide();
            pnl_BestellingKeuken.Hide();
            pnl_AfrekenOverzicht.Hide();
            pnl_BestellingVersturen.Hide();
            pnl_BestellingVerstuurd.Hide();

        }
        private void GetItemList()
        {
            CB_Aantal.Hide();
            CB_Items.Items.Clear();
            CB_Items.Hide();
            CB_Items.Text = "";

            List<Gerecht> gerechtList = gerechtService.GetGerechten();
            List<Drankje> drankList = drankService.GetDrankjes();

            //gerechtlijst onderverdelen in soort gerecht Diner
            List<Gerecht> voorgerechtLunchGerechtList = new List<Gerecht>();
            List<Gerecht> hoofdgerechtLunchGerechtList = new List<Gerecht>();
            List<Gerecht> nagerechtLunchGerechtList = new List<Gerecht>();

            //Gerechtlijst onderverdelen in soort gerecht Lunch
            List<Gerecht> voorgerechtDinerGerechtList = new List<Gerecht>();
            List<Gerecht> tussengerechtDinerGerechtList = new List<Gerecht>();
            List<Gerecht> hoofdgerechtDinerGerechtList = new List<Gerecht>();
            List<Gerecht> nagerechtDinerGerechtList = new List<Gerecht>();

            //Dranklijst onderverdelen in soort drankjes
            List<Drankje> frisdrankDrankList = new List<Drankje>();
            List<Drankje> bierListDrankList = new List<Drankje>();
            List<Drankje> wijnListDrankList = new List<Drankje>();
            List<Drankje> gedestilleerdDrankList = new List<Drankje>();
            List<Drankje> koffietheeDrankList = new List<Drankje>();


            foreach (SomerenModel.Gerecht d in gerechtList)
            {
                if (d.dagType == DagType.Lunch)
                {
                    if (d.soortGerecht == SoortGerecht.Voorgerecht)
                    {
                        voorgerechtLunchGerechtList.Add(d);
                    }
                    else if (d.soortGerecht == SoortGerecht.Hoofdgerecht)
                    {
                        hoofdgerechtLunchGerechtList.Add(d);
                    }
                    else if (d.soortGerecht == SoortGerecht.Nagerecht)
                    {
                        nagerechtLunchGerechtList.Add(d);
                    }

                }
                else if (d.dagType == DagType.Diner)
                {
                    if (d.soortGerecht == SoortGerecht.Voorgerecht)
                    {
                        voorgerechtDinerGerechtList.Add(d);
                    }
                    else if (d.soortGerecht == SoortGerecht.Tussengerecht)
                    {
                        tussengerechtDinerGerechtList.Add(d);
                    }
                    else if (d.soortGerecht == SoortGerecht.Hoofdgerecht)
                    {
                        hoofdgerechtDinerGerechtList.Add(d);
                    }
                    else if (d.soortGerecht == SoortGerecht.Nagerecht)
                    {
                        nagerechtDinerGerechtList.Add(d);
                    }
                }
            }
            foreach(SomerenModel.Drankje d in drankList)
            {
                if(d.soortDrankje == SoortDrankje.Frisdrank)
                {
                    frisdrankDrankList.Add(d);
                }
                else if (d.soortDrankje == SoortDrankje.Bier)
                {
                    bierListDrankList.Add(d);
                }
                else if (d.soortDrankje == SoortDrankje.GedestilleerdeDrank)
                {
                    gedestilleerdDrankList.Add(d);
                }
                else if (d.soortDrankje == SoortDrankje.KoffieThee)
                {
                    koffietheeDrankList.Add(d);
                }
                else if (d.soortDrankje == SoortDrankje.Wijn)
                {
                    wijnListDrankList.Add(d);
                }
            }


            if (CB_EtenDrinken.Text == "Drinken")
            {
                CB_LunchDiner.Hide();
                CB_SoortGerechtDiner.Hide();
                CB_SoortGerechtLunch.Hide();
                CB_SoortDrankje.Show();

                if (CB_SoortDrankje.Text == "Frisdrank")
                {
                    CB_Items.Show();
                    foreach (SomerenModel.Drankje d in frisdrankDrankList) { CB_Items.Items.Add(d.drankNaam.ToString()); }
                }
                else if (CB_SoortDrankje.Text == "Bier")
                {
                    CB_Items.Show();
                    foreach (SomerenModel.Drankje d in  bierListDrankList) { CB_Items.Items.Add(d.drankNaam.ToString()); }
                }
                else if (CB_SoortDrankje.Text == "Gedestilleerde Dranken")
                {
                    CB_Items.Show();
                    foreach (SomerenModel.Drankje d in gedestilleerdDrankList) { CB_Items.Items.Add(d.drankNaam.ToString()); }
                }
                else if (CB_SoortDrankje.Text == "Koffie/Thee")
                {
                    CB_Items.Show();
                    foreach (SomerenModel.Drankje d in koffietheeDrankList) { CB_Items.Items.Add(d.drankNaam.ToString()); }
                }
                else if (CB_SoortDrankje.Text == "Wijn")
                {
                    CB_Items.Show();
                    foreach (SomerenModel.Drankje d in wijnListDrankList) { CB_Items.Items.Add(d.drankNaam.ToString()); }                    
                }
            }
            else if (CB_EtenDrinken.Text == "Eten")
            {
                CB_LunchDiner.Show();
                CB_SoortDrankje.Hide();

                if (CB_LunchDiner.Text == "Lunch")
                {
                    CB_SoortGerechtLunch.Show();
                    CB_SoortGerechtDiner.Hide();
                   

                    if (CB_SoortGerechtLunch.Text == "Voorgerecht")
                    {
                        CB_Items.Show();
                        foreach (SomerenModel.Gerecht d in voorgerechtLunchGerechtList) { CB_Items.Items.Add(d.gerechtNaam.ToString()); }
                        CB_SoortGerechtLunch.SelectedIndex = 0;

                    }
                    else if (CB_SoortGerechtLunch.Text == "Hoofdgerecht")
                    {
                        CB_Items.Show();
                        CB_SoortGerechtLunch.SelectedIndex = 1;
                        foreach (SomerenModel.Gerecht d in hoofdgerechtLunchGerechtList) { CB_Items.Items.Add(d.gerechtNaam.ToString()); }
                    }
                    else if (CB_SoortGerechtLunch.Text == "Nagerecht")
                    {
                        CB_Items.Show();
                        CB_SoortGerechtLunch.SelectedIndex = 2;
                        foreach (SomerenModel.Gerecht d in nagerechtLunchGerechtList) { CB_Items.Items.Add(d.gerechtNaam.ToString()); }
                    }
                }
                else if(CB_LunchDiner.Text == "Diner")
                {
                    CB_SoortGerechtDiner.Show();
                    CB_SoortGerechtLunch.Hide();
                    

                    if (CB_SoortGerechtDiner.Text == "Voorgerecht")
                    {
                        CB_Items.Show();
                        foreach (SomerenModel.Gerecht d in voorgerechtDinerGerechtList) { CB_Items.Items.Add(d.gerechtNaam.ToString()); }
                    }
                    else if (CB_SoortGerechtDiner.Text == "Tussengerecht")
                    {
                        CB_Items.Show();
                        foreach (SomerenModel.Gerecht d in hoofdgerechtDinerGerechtList) { CB_Items.Items.Add(d.gerechtNaam.ToString()); }
                    }
                    else if (CB_SoortGerechtDiner.Text == "Hoofdgerecht")
                    {
                        CB_Items.Show();
                        foreach (SomerenModel.Gerecht d in hoofdgerechtDinerGerechtList) { CB_Items.Items.Add(d.gerechtNaam.ToString()); }
                    }
                    else if (CB_SoortGerechtDiner.Text == "Nagerecht")
                    {
                        CB_Items.Show();
                        foreach (SomerenModel.Gerecht d in nagerechtDinerGerechtList) { CB_Items.Items.Add(d.gerechtNaam.ToString()); }
                    }
                }
            }










            /* List<Gerecht> lunchGerechtList = GetGerechtList(DagType.Lunch);
             List<Gerecht> dinerGerechtList = GetGerechtList(DagType.Diner);

             if (CB_DrinkenEten.Text == "Eten")
             {
                 if (CB_LunchDiner.Text == "Lunch")
                 {
                     foreach (SomerenModel.Gerecht d in lunchGerechtList) { comboBox3.Items.Add(d.gerechtNaam.ToString()); }
                 }
                 else if (CB_LunchDiner.Text == "Diner")
                 {
                     foreach (SomerenModel.Gerecht d in dinerGerechtList) { comboBox3.Items.Add(d.gerechtNaam.ToString()); }
                 }

             }
             else if (CB_DrinkenEten.Text == "Drinken")
             {
                 foreach (SomerenModel.Drankje d in drankList) { comboBox3.Items.Add(d.drankNaam.ToString()); }
             }*/
        }
        private List<GerechtlijstItem> GetGerechtItemLijst() {

            List<GerechtlijstItem> gerechtBestellingsOverzichtList = gerechtlijstItemService.GetGerechtlijstItemsTafel();
            return gerechtBestellingsOverzichtList;
        }        
        private List<DrankLijstItem> GetDrankItemLijst()
        {
            List<DrankLijstItem> drankBestellingsOverzichtList = drankLijstItemService.GetDrankLijstItemsTafel();
            return drankBestellingsOverzichtList;
        }

        private void SomerenUI_Load(object sender, EventArgs e)
        {

            showPanel("LogIn");
            

        }


        private void showPanel(string panelName)
        {
            lbl_TijdHeader.Text = DateTime.Now.ToString("HH:mm");
            lbl_NaamMedewerker.Text = naamIngelogde;



            if (panelName == "LogIn")
            {
                hideAllPanels();
                pnl_LogIn.Show();
            }
            else if (panelName == "Base")
            {
                hideAllPanels();
                pnl_Base.Show();

            }
            else if (panelName == "BestellingsOverzicht")
            {
                hideAllPanels();
                pnl_Base.Show();
                pnl_MenuBalkBestelling.Show();
                pnl_BestellingsOverzicht.Show();
                pnl_BestellingVersturen.Hide();
                pnl_BestellingVerstuurd.Hide();

                // clear the listview before filling it again
                lv_BestellingsOverzicht.Clear();

                lv_BestellingsOverzicht.View = View.Details;
                //lv_BestellingsOverzicht.GridLines = true;
                lv_BestellingsOverzicht.FullRowSelect = true;
                lv_BestellingsOverzicht.CheckBoxes = true;

                // Aanmaken van kolommen
                lv_BestellingsOverzicht.Columns.Add("Naam", 200);
                //lv_BestellingsOverzicht.Columns.Add("Prijs", 200);
                lv_BestellingsOverzicht.Columns.Add("Aantal", 100);

                List<DrankLijstItem> drankBestellingsOverzichtList = GetDrankItemLijst();
                List<GerechtlijstItem> gerechtBestellingsOverzichtList = GetGerechtItemLijst();

                string[] bestellingen = new string[3];
                ListViewItem itm;

                foreach (SomerenModel.DrankLijstItem b in drankBestellingsOverzichtList)
                {
                    if (b.status == Status.Opslag && b.aantal > 0)
                    {
                        bestellingen[0] = b.drankID.ToString();
                        bestellingen[1] = b.drankNaam.ToString();
                        //bestellingen[1] = b..ToString();
                        bestellingen[2] = b.aantal.ToString();
                        

                        itm = new ListViewItem(bestellingen);
                        lv_BestellingsOverzicht.Items.Add(itm);
                    }


                }
                foreach (SomerenModel.GerechtlijstItem b in gerechtBestellingsOverzichtList)
                {
                    if (b.status == Status.Opslag && b.Aantal > 0)
                    {
                        bestellingen[0] = b.GerechtID.ToString();
                        bestellingen[1] = b.GerechtNaam.ToString();
                        //bestellingen[1] = b..ToString();
                        bestellingen[2] = b.Aantal.ToString();

                        itm = new ListViewItem(bestellingen);
                        lv_BestellingsOverzicht.Items.Add(itm);
                    }

                }

            }
            else if (panelName == "BestellingVersturen")
            {
                hideAllPanels();
                pnl_Base.Show();
                pnl_MenuBalkBestelling.Show();
                pnl_BestellingsOverzicht.Show();
                pnl_BestellingVersturen.Show();
            }
            else if (panelName == "BestellingVerstuurd")
            {
                hideAllPanels();
                pnl_Base.Show();
                pnl_MenuBalkBestelling.Show();
                pnl_BestellingsOverzicht.Show();
                pnl_BestellingVerstuurd.Show();
            }
            else if (panelName == "Bier")
            {
                hideAllPanels();
                pnl_Base.Show();
                pnl_MenuBalkBestelling.Show();
                pnl_Bier.Show();
            }
            else if (panelName == "DinerBestelling")
            {
                hideAllPanels();
                pnl_Base.Show();
                pnl_MenuBalkBestelling.Show();
                pnl_DinerBestelling.Show();
            }
            else if (panelName == "Frisdrank")
            {
                hideAllPanels();
                pnl_Base.Show();
                pnl_MenuBalkBestelling.Show();
                pnl_Frisdrank.Show();
            }
            else if (panelName == "GedestilleerdeDranken")
            {
                hideAllPanels();
                pnl_Base.Show();
                pnl_MenuBalkBestelling.Show();
                pnl_GedestilleerdeDranken.Show();
            }
            else if (panelName == "KoffieThee")
            {
                hideAllPanels();
                pnl_Base.Show();
                pnl_MenuBalkBestelling.Show();
                pnl_KoffieThee.Show();
            }
            else if (panelName == "LunchBestelling")
            {
                hideAllPanels();
                pnl_Base.Show();
                pnl_MenuBalkBestelling.Show();
                pnl_LunchBestelling.Show();


                //Clear comboboxes
                CB_Items.Items.Clear();
                CB_LunchDiner.Items.Clear();
                CB_EtenDrinken.Items.Clear();
                CB_SoortGerechtDiner.Items.Clear();
                CB_SoortGerechtLunch.Items.Clear();
                CB_SoortDrankje.Items.Clear();
                CB_Aantal.Items.Clear();

                CB_EtenDrinken.DroppedDown = true;
                btn_VoegToeBestelling.Enabled = false;

                CB_LunchDiner.Items.Add(DagType.Lunch.ToString());
                CB_LunchDiner.Items.Add(DagType.Diner.ToString());

                CB_EtenDrinken.Items.Add("Drinken");
                CB_EtenDrinken.Items.Add("Eten");

                CB_SoortGerechtLunch.Items.Add("Voorgerecht");
                CB_SoortGerechtLunch.Items.Add("Hoofdgerecht");
                CB_SoortGerechtLunch.Items.Add("Nagerecht");

                CB_SoortGerechtDiner.Items.Add("Voorgerecht");
                CB_SoortGerechtDiner.Items.Add("Tussengerecht");
                CB_SoortGerechtDiner.Items.Add("Hoofdgerecht");
                CB_SoortGerechtDiner.Items.Add("Nagerecht");

                CB_SoortDrankje.Items.Add("Frisdrank");
                CB_SoortDrankje.Items.Add("Bier");
                CB_SoortDrankje.Items.Add("Wijn");
                CB_SoortDrankje.Items.Add("Gedestilleerde Dranken");
                CB_SoortDrankje.Items.Add("Koffie/Thee");

                CB_Aantal.Items.Add("1");
                CB_Aantal.Items.Add("2");
                CB_Aantal.Items.Add("3");
                CB_Aantal.Items.Add("4");
                CB_Aantal.Items.Add("5");
                CB_Aantal.Items.Add("6");
                CB_Aantal.Items.Add("8");
                CB_Aantal.Items.Add("9");


                CB_LunchDiner.Hide();
                CB_SoortGerechtDiner.Hide();
                CB_SoortGerechtLunch.Hide();
                CB_SoortDrankje.Hide();
                CB_Items.Hide();
                CB_Aantal.Hide();
            }
            else if (panelName == "Overzicht")

            {
                hideAllPanels();
                pnl_Base.Show();
                pnl_Overzicht.Show();
            }
            else if (panelName == "Reservering")
            {
                hideAllPanels();
                pnl_Reservering.Show();
            }
            else if (panelName == "Tafels")
            {
                hideAllPanels();
                pnl_Base.Show();
                pnl_TafelOverzicht.Show();
                pnl_MenuBalkTafels.Show();

                List<Button> buttons = new List<Button>();
                buttons.Add(btn_Tafel1);
                buttons.Add(btn_Tafel2);
                buttons.Add(btn_Tafel3);
                buttons.Add(btn_Tafel4);
                buttons.Add(btn_Tafel5);
                buttons.Add(btn_Tafel6);
                buttons.Add(btn_Tafel7);
                buttons.Add(btn_Tafel8);
                buttons.Add(btn_Tafel9);
                buttons.Add(btn_Tafel10);

                foreach (Button btn in buttons)
                {
                    // Standaard kleur
                    btn.BackColor = Color.White;
                }               

                // kijken of er openstaande bestellingen etc in de keuken zijn
                List<GerechtlijstItem> gerechtlijst = gerechtlijstItemService.GetGerechtlijstItemsTafel();
                CheckStatusGerechten(gerechtlijst);

                foreach (Button btn in buttons)
                {
                    if (btn.BackColor != Color.Green || btn.BackColor != Color.Yellow)
                    {
                        // kijken of er bestellingen met een hogere prioriteit status bij de bar zijn
                        List<DrankLijstItem> dranklijst = drankLijstItemService.GetDrankLijstItemsTafel();
                        CheckStatusDrankjes(dranklijst);
                    }
                }
                
            }
            else if (panelName == "Voorraad")
            {
                hideAllPanels();
                pnl_Base.Show();
                pnl_Voorraad.Show();

                gb_GerechtToevoegen.Hide();
                gb_DrankToevoegen.Show();

                vulDrankVoorraad();
            }
            else if (panelName == "Wijn")
            {
                hideAllPanels();
                pnl_Base.Show();
                pnl_MenuBalkBestelling.Show();
                pnl_Wijn.Show();
            }
            else if (panelName == "MenuBalkBestelling_pnl")
            {
                hideAllPanels();
                pnl_MenuBalkBestelling.Show();
            }
            else if (panelName == "MenuBalkTafels")
            {
                hideAllPanels();
                pnl_MenuBalkTafels.Show();
            }
            else if (panelName == "Dag")
            {
                hideAllPanels();
                pnl_Base.Show();
                pnl_MenuBalkFinanciën.Show();
                pnl_Dag.Show();
            }
            else if (panelName == "Week")
            {
                hideAllPanels();
                pnl_Base.Show();
                pnl_MenuBalkFinanciën.Show();
                pnl_Week.Show();
            }
            else if (panelName == "Maand")
            {
                hideAllPanels();
                pnl_Base.Show();
                pnl_MenuBalkFinanciën.Show();
                pnl_Maand.Show();
            }
            else if (panelName == "DatumKiezen")
            {
                hideAllPanels();
                pnl_Base.Show();
                pnl_MenuBalkFinanciën.Show();
                pnl_DatumKiezen.Show();
            }
            else if (panelName == "RekeningOverzicht")
            {
                hideAllPanels();
                pnl_Base.Show();
                pnl_MenuBalkRekening.Show();
                pnl_RekeningOverzicht.Show();

                StatusBestelling huidigeStatus = bestellingService.GetHuidigeBestellingStatus(tafelnummer);

                lbl_TafelInfo.Text = "Tafel " + tafelnummer.ToString();
               

                if (huidigeStatus != StatusBestelling.Betaald)
                {
                    List<GerechtlijstItem> gerechtList = gerechtlijstItemService.GerechtenBestellingVanTafel(tafelnummer);
                    List<DrankLijstItem> drankList = drankLijstItemService.GetDrankjesBestellingVanTafel(tafelnummer);

                    lv_RekeningOverzicht.Clear();

                    lv_RekeningOverzicht.View = View.Details;
                    lv_RekeningOverzicht.GridLines = true;
                    lv_RekeningOverzicht.FullRowSelect = true;

                    // Aanmaken van kolommen
                    lv_RekeningOverzicht.Columns.Add("Aantal", 80);
                    lv_RekeningOverzicht.Columns.Add("Drankje/Gerecht", 200);
                    lv_RekeningOverzicht.Columns.Add("Prijs", 80);
                    lv_RekeningOverzicht.Columns.Add("Individuele prijs", 100);

                    totaalPrijs = 0;
                    string[] bestellingen = new string[4];
                    ListViewItem itm;

                    foreach (SomerenModel.GerechtlijstItem g in gerechtList)
                    {
                        totaalPrijs += (g.Aantal * g.Prijs);

                        bestellingen[0] = g.Aantal.ToString();
                        bestellingen[1] = g.GerechtNaam;
                        bestellingen[2] = (g.Prijs * g.Aantal).ToString("0.00");
                        bestellingen[3] = g.Prijs.ToString("0.00");

                        itm = new ListViewItem(bestellingen);
                        lv_RekeningOverzicht.Items.Add(itm);
                    }

                    foreach (SomerenModel.DrankLijstItem d in drankList)
                    {
                        totaalPrijs += (d.aantal * d.Prijs);

                        bestellingen[0] = d.aantal.ToString();
                        bestellingen[1] = d.drankNaam;
                        bestellingen[2] = (d.Prijs * d.aantal).ToString("0.00");
                        bestellingen[3] = d.Prijs.ToString("0.00");

                        itm = new ListViewItem(bestellingen);
                        lv_RekeningOverzicht.Items.Add(itm);
                    }
                }

                lbl_TotaalBedragRekeningOverzicht.Text = "€" + totaalPrijs.ToString();
            }
            else if (panelName == "Reserveringen")
            {
                hideAllPanels();
                pnl_Base.Show();
                pnl_MenuBalkReserveringen.Show();
                pnl_Reservering.Show();
            }
            else if (panelName == "KeukenOverzicht")
            {
                hideAllPanels();
                pnl_Base.Show();
                pnl_MenuBalkKeukenOverzicht.Show();
                pnl_KeukenOverzicht.Show();

                List<Bestelling> bestellingList = bestellingService.GetBestelling();

                // clear the listview before filling it again
                lv_KeukenOverzicht.Clear();

                lv_KeukenOverzicht.View = View.Details;
                lv_KeukenOverzicht.GridLines = true;
                lv_KeukenOverzicht.FullRowSelect = true;
                lv_KeukenOverzicht.CheckBoxes = true;

                // Aanmaken van kolommen
                lv_KeukenOverzicht.Columns.Add("Tafel", 200);
                lv_KeukenOverzicht.Columns.Add("BestellingID", 200);
                lv_KeukenOverzicht.Columns.Add("Status gerechten", 100);

                string[] bestellingen = new string[3];
                ListViewItem itm;

                foreach (SomerenModel.Bestelling b in bestellingList)
                {
                    if (b.statusBar != StatusBestelling.Betaald)
                    {
                        bestellingen[0] = "Tafel " + b.TafelID.ToString();
                        bestellingen[1] = b.BestellingID.ToString();
                        bestellingen[2] = b.statusKeuken.ToString();

                        itm = new ListViewItem(bestellingen);
                        lv_KeukenOverzicht.Items.Add(itm);
                    }                      
                }

            }
            else if (panelName == "BarOverzicht")
            {
                hideAllPanels();
                pnl_Base.Show();
                pnl_MenuBalkBarOverzicht.Show();
                pnl_BarOverzicht.Show();


                List<Bestelling> bestellingList = bestellingService.GetBestelling();

                // clear the listview before filling it again
                lv_BarOverzicht.Clear();

                lv_BarOverzicht.View = View.Details;
                lv_BarOverzicht.GridLines = true;
                lv_BarOverzicht.FullRowSelect = true;
                lv_BarOverzicht.CheckBoxes = true;

                // Aanmaken van kolommen
                lv_BarOverzicht.Columns.Add("Tafel", 200);
                lv_BarOverzicht.Columns.Add("BestellingID", 200);
                lv_BarOverzicht.Columns.Add("Status drankjes", 100);

                string[] bestellingen = new string[3];
                ListViewItem itm;

                foreach (SomerenModel.Bestelling b in bestellingList)
                {
                    if (b.statusBar != StatusBestelling.Betaald)
                    {
                        bestellingen[0] = "Tafel " + b.TafelID.ToString();
                        bestellingen[1] = b.BestellingID.ToString();
                        bestellingen[2] = b.statusBar.ToString();

                        itm = new ListViewItem(bestellingen);
                        lv_BarOverzicht.Items.Add(itm);
                    }
                }
            }
            else if (panelName == "BarBestelling")
            {
                hideAllPanels();
                pnl_Base.Show();
                pnl_MenuBalkBarOverzicht.Show();
                pnl_BestellingBar.Show();

                // Label tafelnummer laten zien
                string geselecteerdeTafel = "";
                string tafelStatus = "";

                for (int i = 0; i < lv_BarOverzicht.Items.Count; i++)
                {
                    if (lv_BarOverzicht.Items[i].Checked)
                    {
                        geselecteerdeTafel = lv_BarOverzicht.Items[i].Text;
                        tafelStatus = lv_BarOverzicht.Items[i].SubItems[2].Text;
                    }
                }

                lbl_TafelBar.Text = geselecteerdeTafel;
                lbl_TafelNrBar.Text = "";

                lbl_StatusBar.Text = tafelStatus;

                // Listview
                int geselecteerdeBestelling = GetGeselecteerdeBestellingBar();

                List<DrankLijstItem> drankList = drankLijstItemService.GetDrankLijstItems(geselecteerdeBestelling);

                // clear the listview before filling it again
                lv_BarBestelling.Clear();

                lv_BarBestelling.View = View.Details;
                lv_BarBestelling.GridLines = true;
                lv_BarBestelling.FullRowSelect = true;
                lv_BarBestelling.CheckBoxes = true;

                // Aanmaken van kolommen
                lv_BarBestelling.Columns.Add("BestellingID", 80);
                lv_BarBestelling.Columns.Add("Drankje", 218);
                lv_BarBestelling.Columns.Add("Aantal", 60);
                lv_BarBestelling.Columns.Add("Tijd", 60);
                lv_BarBestelling.Columns.Add("Status", 120);
                lv_BarBestelling.Columns.Add("DrankID", 0);

                string[] drankjes = new string[6];
                ListViewItem itm;

                foreach (SomerenModel.DrankLijstItem d in drankList)
                {
                    if (d.status != Status.Opslag)
                    {
                        drankjes[0] = d.bestellingID.ToString();
                        drankjes[1] = d.drankNaam;
                        drankjes[2] = d.aantal.ToString();
                        drankjes[3] = d.tijd.ToString("HH:mm");
                        drankjes[4] = d.status.ToString();
                        drankjes[5] = d.drankID.ToString();

                        itm = new ListViewItem(drankjes);

                        if (d.status == Status.KlaarVoorServeren)
                        {
                            itm.BackColor = Color.Green;
                        }
                        else if (d.status == Status.Geserveerd)
                        {
                            itm.BackColor = Color.LightBlue;
                        }

                        lv_BarBestelling.Items.Add(itm);
                    }
            
                }

            }
            else if (panelName == "KeukenBestelling")
            {
                hideAllPanels();
                pnl_Base.Show();
                pnl_MenuBalkKeukenOverzicht.Show();
                pnl_BestellingKeuken.Show();

                // Label tafelnummer laten zien
                string geselecteerdeTafel = "";
                string tafelStatus = "";

                for (int i = 0; i < lv_KeukenOverzicht.Items.Count; i++)
                {
                    if (lv_KeukenOverzicht.Items[i].Checked)
                    {
                        geselecteerdeTafel = lv_KeukenOverzicht.Items[i].Text;
                        tafelStatus = lv_KeukenOverzicht.Items[i].SubItems[2].Text;
                    }
                }

                lbl_Tafel.Text = geselecteerdeTafel;
                lbl_TafelNr.Text = "";

                lbl_StatusKeuken.Text = tafelStatus;

                // Listview
                int geselecteerdeBestelling = GetGeselecteerdeBestellingKeuken();

                List<GerechtlijstItem> gerechtList = gerechtlijstItemService.GetGerechtlijstItems(geselecteerdeBestelling);

                // clear the listview before filling it again
                lv_BestellingenKeuken.Clear();

                lv_BestellingenKeuken.View = View.Details;
                lv_BestellingenKeuken.GridLines = true;
                lv_BestellingenKeuken.FullRowSelect = true;
                lv_BestellingenKeuken.CheckBoxes = true;

                // Aanmaken van kolommen
                lv_BestellingenKeuken.Columns.Add("BestellingID", 80);
                lv_BestellingenKeuken.Columns.Add("Gerecht", 218);
                lv_BestellingenKeuken.Columns.Add("Aantal", 60);
                lv_BestellingenKeuken.Columns.Add("Tijd", 60);
                lv_BestellingenKeuken.Columns.Add("Status", 120);
                lv_BestellingenKeuken.Columns.Add("GerechtID", 0);

                string[] gerechten = new string[6];
                ListViewItem itm;

                foreach (SomerenModel.GerechtlijstItem g in gerechtList)
                {
                    if (g.status != Status.Opslag)
                    {
                        gerechten[0] = g.BestellingID.ToString();
                        gerechten[1] = g.GerechtNaam;
                        gerechten[2] = g.Aantal.ToString();
                        gerechten[3] = g.Tijd.ToString("HH:mm");
                        gerechten[4] = g.status.ToString();
                        gerechten[5] = g.GerechtID.ToString();

                        itm = new ListViewItem(gerechten);

                        if (g.status == Status.KlaarVoorServeren)
                        {
                            itm.BackColor = Color.Green;
                        }
                        else if (g.status == Status.Geserveerd)
                        {
                            itm.BackColor = Color.LightBlue;
                        }

                        lv_BestellingenKeuken.Items.Add(itm);
                    }
            
                }


            }
            else if (panelName == "Afrekenen")
            {
                hideAllPanels();
                pnl_Base.Show();
                pnl_MenuBalkRekening.Show();
                pnl_AfrekenOverzicht.Show();
                gb_Afgerekend.Hide();
                gb_AfrekenPopUp.Hide();

                // combobox betaalmethode
                cmb_BetaalMethode.Items.Clear();

                cmb_BetaalMethode.Items.Add(BetaalMethode.Pin);
                cmb_BetaalMethode.Items.Add(BetaalMethode.Contant);
                cmb_BetaalMethode.Items.Add(BetaalMethode.CreditCard);

                cmb_BetaalMethode.SelectedIndex = 0;

                txt_Fooi.Clear();

                lbl_TafelNrInvoer.Text = tafelnummer.ToString();
               
                List<GerechtlijstItem> gerechtList = gerechtlijstItemService.GerechtenBestellingVanTafel(tafelnummer);
                List<DrankLijstItem> drankList = drankLijstItemService.GetDrankjesBestellingVanTafel(tafelnummer);
                
                double btwPrijs = 0;

                foreach (SomerenModel.GerechtlijstItem g in gerechtList)
                {
                    btwPrijs += (g.Prijs * 0.09 * g.Aantal);
                }
                
                foreach (SomerenModel.DrankLijstItem d in drankList)
                {
                    if (d.alcoholisch == Alcholisch.Ja)
                    {
                        btwPrijs += (d.Prijs * 0.21 * d.aantal);
                    }
                    else
                    {
                        btwPrijs += (d.Prijs * 0.09 * d.aantal);
                    }
                }

                lbl_EindBedragInvoer.Text = totaalPrijs.ToString("0.00");
                lbl_TotaalBedrag.Text = "€" + totaalPrijs.ToString("0.00");
                lbl_BTWBedrag.Text = btwPrijs.ToString("0.00");
               
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            showPanel("KeukenOverzicht");
        }

        private void btn_Financien_Click(object sender, EventArgs e)
        {
            showPanel("Dag");
        }

        private void btn_TafelOverzicht_Click(object sender, EventArgs e)
        {
            showPanel("LunchBestelling");
        }

        private void btn_LogIn_Click(object sender, EventArgs e)
        {
            List<Personeel> personeelList = personeelService.GetPersoneel();

            foreach (Personeel item in personeelList)
            {
                if (txt_LogIn.Text == item.PersoneelID.ToString())
                {
                    naamIngelogde = item.Naam;
                    showPanel("Overzicht"); 
                    loggedIn = true;
                    break;
                }

            }

            if (loggedIn == false)
            {
                        string caption = "Error";
                        string message = "Verkeerde toegangscode";
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        DialogResult result;

                        // Displays the MessageBox.
                        result = MessageBox.Show(message, caption, buttons);
                        if (result == System.Windows.Forms.DialogResult.OK)
                        {
                            showPanel("LogIn");
                        }
            }





        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            showPanel("GedestilleerdeDranken");
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            showPanel("Wijn");
        }

        private void button26_Click(object sender, EventArgs e)
        {
            showPanel("Bier");
        }

        private void btn_Home_Click(object sender, EventArgs e)
        {
            showPanel("Overzicht");
        }

        private void btn_Voorraad_Click(object sender, EventArgs e)
        {
            showPanel("Voorraad");
        }

        private void btn_Tafels_Click(object sender, EventArgs e)
        {
            showPanel("Tafels");
        }

        private void btn_Drinken_Click(object sender, EventArgs e)
        {
            showPanel("Frisdrank");
        }

        private void btn_Diner_Click(object sender, EventArgs e)
        {
            showPanel("DinerBestelling");
        }

        private void btn_Lunch_Click(object sender, EventArgs e)
        {
            showPanel("LunchBestelling");
        }

        private void btn_FrisdrankKoffieThee_Click(object sender, EventArgs e)
        {
            showPanel("KoffieThee");
        }

        private void btn_BierFrisdrank_Click(object sender, EventArgs e)
        {
            showPanel("Frisdrank");
        }

        private void btn_BierBier_Click(object sender, EventArgs e)
        {
            showPanel("Bier");
        }

        private void btn_BierWijn_Click(object sender, EventArgs e)
        {
            showPanel("Wijn");
        }

        private void btn_BierGedestilleerde_Click(object sender, EventArgs e)
        {
            showPanel("GedestilleerdeDranken");
        }

        private void btn_BierKoffieThee_Click(object sender, EventArgs e)
        {
            showPanel("KoffieThee");
        }

        private void btn_WijnFrisdrank_Click(object sender, EventArgs e)
        {
            showPanel("Frisdrank");
        }

        private void btn_WijnBier_Click(object sender, EventArgs e)
        {
            showPanel("Bier");
        }

        private void btn_WijnWijn_Click(object sender, EventArgs e)
        {
            showPanel("Wijn");
        }

        private void btn_WijnGedestileerde_Click(object sender, EventArgs e)
        {
            showPanel("GedestilleerdeDranken");
        }

        private void btn_WijnKoffieThee_Click(object sender, EventArgs e)
        {
            showPanel("KoffieThee");
        }

        private void btn_GedestilleerdeFrisdrank_Click(object sender, EventArgs e)
        {
            showPanel("Frisdrank");
        }

        private void btn_GedestilleerdeBier_Click(object sender, EventArgs e)
        {
            showPanel("Bier");
        }

        private void btn_GedestilleerdeWijn_Click(object sender, EventArgs e)
        {
            showPanel("Wijn");
        }

        private void btn_GedestilleerdeGedestilleerde_Click(object sender, EventArgs e)
        {
            showPanel("GedestilleerdeDranken");
        }

        private void btn_GedestilleerdeKoffieThee_Click(object sender, EventArgs e)
        {
            showPanel("KoffieThee");
        }

        private void btn_KoffieTheeFrisdrank_Click(object sender, EventArgs e)
        {
            showPanel("Frisdrank");
        }

        private void btn_KoffieTheeBier_Click(object sender, EventArgs e)
        {
            showPanel("Bier");
        }

        private void btn_KoffieTheeWijn_Click(object sender, EventArgs e)
        {
            showPanel("Wijn");
        }

        private void btn_KoffieTheeGedestilleerde_Click(object sender, EventArgs e)
        {
            showPanel("GedestilleerdeDranken");
        }

        private void btn_KoffieTheeKoffieThee_Click(object sender, EventArgs e)
        {
            showPanel("KoffieThee");
        }

        private void btn_Lunch2_Click(object sender, EventArgs e)
        {
            showPanel("LunchBestelling");
        }

        private void btn_Bestelling_Click(object sender, EventArgs e)
        {
            showPanel("BestellingsOverzicht");
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            showPanel("BestellingVersturen");
        }

        private void btn_BestellingVersturenJa_Click(object sender, EventArgs e)
        {
            List<GerechtlijstItem> gerechtBestellingsOverzichtList = GetGerechtItemLijst();
            List<DrankLijstItem> drankBestellingsOverzichtList = GetDrankItemLijst();

            foreach (GerechtlijstItem item in gerechtBestellingsOverzichtList)
            {
                gerechtlijstItemService.UpdateGerechtItem(Status.Besteld, tafelService.GetHuidigeBestelling(tafelnummer), gerechtService.GetGerechtID(item.GerechtNaam));
            }
            foreach (DrankLijstItem item in drankBestellingsOverzichtList)
            {
                drankLijstItemService.UpdateDrankItem(Status.Besteld, tafelService.GetHuidigeBestelling(tafelnummer), drankService.GetDrankID(item.drankNaam));
            }
            showPanel("Tafels");
        }

        private void btn_BestellingVersturenOK_Click(object sender, EventArgs e)
        {
            showPanel("Tafels");
        }

        private void btn_BestellingVersturenNee_Click(object sender, EventArgs e)
        {
            showPanel("BestellingsOverzicht");
        }

        private void btn_Dag_Click(object sender, EventArgs e)
        {
            showPanel("Dag");
        }

        private void btn_Week_Click(object sender, EventArgs e)
        {
            showPanel("Week");
        }

        private void btn_Maand_Click(object sender, EventArgs e)
        {
            showPanel("Maand");
        }

        private void btn_DatumKiezen_Click(object sender, EventArgs e)
        {
            showPanel("DatumKiezen");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            showPanel("Tafels");
        }

        private void btn_BestellingOpnemen_Click(object sender, EventArgs e)
        {
            showPanel("LunchBestelling");
        }

        private void btn_reserveringenRes_Click(object sender, EventArgs e)
        {
            showPanel("Reserveringen");
        }

        private void btn_Reserveringen_Click(object sender, EventArgs e)
        {
            showPanel("Reserveringen");
        }

        private void btn_TafelOverzichtRes_Click(object sender, EventArgs e)
        {
            showPanel("Tafels");
        }



        // Bestellingen Keuken
        private void btn_KeukenOverzicht_Click(object sender, EventArgs e)
        {
            showPanel("KeukenOverzicht");
        }
        private void btn_ShowBestellingKeuken_Click(object sender, EventArgs e)
        {
            if (checkGeselecteerdeBestellingKeuken())
            {
                showPanel("KeukenBestelling");
            }
        }
        private bool checkGeselecteerdeBestellingKeuken()
        {
            int count = 0;

            for (int i = 0; i < lv_KeukenOverzicht.Items.Count; i++)
            {
                if (lv_KeukenOverzicht.Items[i].Checked)
                {
                    count++;

                    if (count > 1)
                    {
                        MessageBox.Show("Selecteer maar 1 bestelling!");
                        return false;
                    }
                }
            }

            if (count == 0)
            {
                MessageBox.Show("Selecteer een bestelling om hem te kunnen zien");
                return false;
            }

            return true;
        }
        private void VeranderStatusBestellingKeuken(StatusBestelling status, int geselecteerdeBestelling)
        {
            bestellingService.UpdateBestellingKeuken(status, geselecteerdeBestelling);
        }
        private int GetGeselecteerdeBestellingKeuken()
        {
            int geselecteerdeBestelling = 0;

            for (int i = 0; i < lv_KeukenOverzicht.Items.Count; i++)
            {
                if (lv_KeukenOverzicht.Items[i].Checked)
                {
                    geselecteerdeBestelling = int.Parse(lv_KeukenOverzicht.Items[i].SubItems[1].Text);
                }
            }

            return geselecteerdeBestelling;
        }
        private void btn_RefreshKeukenOverzicht_Click(object sender, EventArgs e)
        {
            showPanel("KeukenOverzicht");
        }
        private void btn_ServerenKeuken_Click(object sender, EventArgs e)
        {
            VeranderStatusGerechten(Status.KlaarVoorServeren);
            showPanel("KeukenBestelling");
        }
        private void VeranderStatusGerechten(Status status)
        {
            for (int i = 0; i < lv_BestellingenKeuken.Items.Count; i++)
            {
                if (lv_BestellingenKeuken.Items[i].Checked)
                {
                    //update status
                    int geselecteerdeBestelling = GetGeselecteerdeBestellingKeuken();
                    int geselecteerdGerecht = int.Parse(lv_BestellingenKeuken.Items[i].SubItems[5].Text);

                    gerechtlijstItemService.UpdateGerechtItem(status, geselecteerdeBestelling, geselecteerdGerecht);
                }
            }
        }
        private void btn_AfgerondKeuken_Click(object sender, EventArgs e)
        {
            VeranderStatusGerechten(Status.Geserveerd);
            int bestelling = 0;
            showPanel("KeukenBestelling");

            if (CheckAllesGeserveerdKeuken(ref bestelling))
            {
                VeranderStatusBestellingKeuken(StatusBestelling.Afgerond, bestelling);
            }

        }
        private bool CheckAllesGeserveerdKeuken(ref int bestelling)
        {
            int count = 0;

            for (int i = 0; i < lv_BestellingenKeuken.Items.Count; i++)
            {
                if (lv_BestellingenKeuken.Items[i].SubItems[4].Text == "Geserveerd")
                {
                    count++;
                }

                bestelling = int.Parse(lv_BestellingenKeuken.Items[i].SubItems[0].Text);
            }

            if (count == lv_BestellingenKeuken.Items.Count)
            {
                return true;
            }

            return false;
        }


        // Bestelingen Bar
        private void btn_BarOverzicht_Click(object sender, EventArgs e)
        {
            showPanel("BarOverzicht");
        }
        private void btn_Bar_Click(object sender, EventArgs e)
        {
            showPanel("BarOverzicht");
        }
        private void btn_ShowBestellingBar_Click(object sender, EventArgs e)
        {
            if (CheckGeselecteerdeBestellingBar())
            {
                showPanel("BarBestelling");
            }          
        }
        private bool CheckGeselecteerdeBestellingBar()
        {
            int count = 0;

            for (int i = 0; i < lv_BarOverzicht.Items.Count; i++)
            {
                if (lv_BarOverzicht.Items[i].Checked)
                {
                    count++;

                    if (count > 1)
                    {
                        MessageBox.Show("Selecteer maar 1 bestelling!");
                        return false;
                    }
                }
            }

            if (count == 0)
            {
                MessageBox.Show("Selecteer een bestelling om hem te kunnen zien");
                return false;
            }

            return true;
        }
        private void VeranderStatusBestellingBar(StatusBestelling status, int geselecteerdeBestelling)
        {
            bestellingService.UpdateBestellingBar(status, geselecteerdeBestelling);
        }
        private int GetGeselecteerdeBestellingBar()
        {
            int geselecteerdeBestelling = 0;

            for (int i = 0; i < lv_BarOverzicht.Items.Count; i++)
            {
                if (lv_BarOverzicht.Items[i].Checked)
                {
                    geselecteerdeBestelling = int.Parse(lv_BarOverzicht.Items[i].SubItems[1].Text);
                }
            }

            return geselecteerdeBestelling;
        }
        private void btn_RefreshBarOverzicht_Click(object sender, EventArgs e)
        {
            showPanel("BarOverzicht");
        }
        private void btn_ServerenBar_Click(object sender, EventArgs e)
        {
            VeranderStatusDrankjes(Status.KlaarVoorServeren);
            showPanel("BarBestelling");
        }
        private void VeranderStatusDrankjes(Status status)
        {
            for (int i = 0; i < lv_BarBestelling.Items.Count; i++)
            {
                if (lv_BarBestelling.Items[i].Checked)
                {
                    //update status
                    int geselecteerdeBestelling = GetGeselecteerdeBestellingBar();
                    int geselecteerdDrankje = int.Parse(lv_BarBestelling.Items[i].SubItems[5].Text);

                    drankLijstItemService.UpdateDrankItem(status, geselecteerdeBestelling, geselecteerdDrankje);
                }
            }
        }
        private void btn_AfgerondBar_Click(object sender, EventArgs e)
        {
            VeranderStatusDrankjes(Status.Geserveerd);
            int bestelling = 0;
            showPanel("BarBestelling");

            if (CheckAllesGeserveerdBar(ref bestelling))
            {
                VeranderStatusBestellingBar(StatusBestelling.Afgerond, bestelling);
            }
        }
        private bool CheckAllesGeserveerdBar(ref int bestelling)
        {
            int count = 0;

            for (int i = 0; i < lv_BarBestelling.Items.Count; i++)
            {
                if (lv_BarBestelling.Items[i].SubItems[4].Text == "Geserveerd")
                {
                    count++;
                }

                bestelling = int.Parse(lv_BarBestelling.Items[i].SubItems[0].Text);
            }

            if (count == lv_BarBestelling.Items.Count)
            {
                return true;
            }

            return false;
        }


        // Voorraad
        private void btn_DrankVoorraad_Click(object sender, EventArgs e)
        {
            gb_GerechtToevoegen.Hide();
            gb_DrankToevoegen.Show();
            vulDrankVoorraad();
        }
        private void vulDrankVoorraad()
        {
            List<Drankje> drankList = drankService.GetDrankjes();

            // clear the listview before filling it again
            lv_Voorraad.Clear();

            lv_Voorraad.View = View.Details;
            lv_Voorraad.GridLines = true;
            lv_Voorraad.FullRowSelect = true;

            // Aanmaken van kolommen
            lv_Voorraad.Columns.Add("ID", 30);
            lv_Voorraad.Columns.Add("Naam", 160);
            lv_Voorraad.Columns.Add("Voorraad", 50);

            string[] drankjes = new string[3];
            ListViewItem itm;

            foreach (SomerenModel.Drankje d in drankList)
            {
                drankjes[0] = d.drankID.ToString();
                drankjes[1] = d.drankNaam;
                drankjes[2] = d.voorraad.ToString();

                itm = new ListViewItem(drankjes);
                lv_Voorraad.Items.Add(itm);


            }
        }
        private void btn_Gerechtvoorraad_Click(object sender, EventArgs e)
        {
            gb_GerechtToevoegen.Show();
            gb_DrankToevoegen.Hide();

            vulGerechtVoorraad();


        }
        private void vulGerechtVoorraad()
        {
            List<Gerecht> gerechtList = gerechtService.GetGerechten();

            // clear the listview before filling it again
            lv_Voorraad.Clear();

            lv_Voorraad.View = View.Details;
            lv_Voorraad.GridLines = true;
            lv_Voorraad.FullRowSelect = true;

            // Aanmaken van kolommen
            lv_Voorraad.Columns.Add("ID", 30);
            lv_Voorraad.Columns.Add("Naam", 160);
            lv_Voorraad.Columns.Add("Voorraad", 50);

            string[] drankjes = new string[3];
            ListViewItem itm;

            foreach (SomerenModel.Gerecht g in gerechtList)
            {
                drankjes[0] = g.gerechtID.ToString();
                drankjes[1] = g.gerechtNaam;
                drankjes[2] = g.voorraad.ToString();

                itm = new ListViewItem(drankjes);
                lv_Voorraad.Items.Add(itm);
            }
        }
        private void btn_VoegToeDrank_Click(object sender, EventArgs e)
        {
            if (txt_DrankNaam.Text == "" || txt_HoeveelheidDrank.Text == "" || txt_Alcoholisch.Text == "" || txt_PrijsDrank.Text == "")
            {
                MessageBox.Show("Vul alle velden in alstublieft.");
                return;
            }

            drankService.UpdateDrankje(txt_DrankNaam.Text, txt_PrijsDrank.Text, txt_Alcoholisch.Text, txt_HoeveelheidDrank.Text);

            txt_Alcoholisch.Clear();
            txt_HoeveelheidDrank.Clear();
            txt_DrankNaam.Clear();
            txt_PrijsDrank.Clear();

            vulDrankVoorraad();
        }
        private void btn_VoegToeGerecht_Click(object sender, EventArgs e)
        {

            if (txt_NaamGerecht.Text == "" || txt_HoeveelheidGerecht.Text == "" || txt_SoortGerecht.Text == "" || txt_PrijsGerecht.Text == "" || txt_TypeGerecht.Text == "")
            {
                MessageBox.Show("Vul alle velden in alstublieft.");
                return;
            }

            gerechtService.UpdateGerecht(txt_NaamGerecht.Text, txt_PrijsGerecht.Text, txt_SoortGerecht.Text, txt_TypeGerecht.Text, txt_HoeveelheidGerecht.Text);

            txt_TypeGerecht.Clear();
            txt_HoeveelheidGerecht.Clear();
            txt_NaamGerecht.Clear();
            txt_PrijsGerecht.Clear();
            txt_SoortGerecht.Clear();


            vulGerechtVoorraad();
        }       
        private void btn_LogUit_Click(object sender, EventArgs e)
        {
            showPanel("LogIn");
        }



        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetItemList();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            CB_Aantal.Text = "1";
            if (CB_Items.Text != "")
            {
                CB_Aantal.Show();
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (CB_Items.Text != "")
            {
                btn_VoegToeBestelling.Enabled = true;
            }

        }
        private void btn_MinKalfstartaar_Click(object sender, EventArgs e)
        {

        }

        private void CB_LunchDiner_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetItemList();
        }

        private void CB_SoortGerecht_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetItemList();
        }



        //tafelbuttons
        private void btn_Tafel1_Click(object sender, EventArgs e)
        {
            tafelnummer = 1;
            showPanel("RekeningOverzicht");
        }
        private void btn_Tafel2_Click(object sender, EventArgs e)
        {
            tafelnummer = 2;
            showPanel("RekeningOverzicht");
        }
        private void btn_Tafel3_Click(object sender, EventArgs e)
        {
            tafelnummer = 3;
            showPanel("RekeningOverzicht");
        }
        private void btn_Tafel4_Click(object sender, EventArgs e)
        {
            tafelnummer = 4;
            showPanel("RekeningOverzicht");
        }
        private void btn_Tafel5_Click(object sender, EventArgs e)
        {
            tafelnummer = 5;
            showPanel("RekeningOverzicht");
        }
        private void btn_Tafel6_Click(object sender, EventArgs e)
        {
            tafelnummer = 6;
            showPanel("RekeningOverzicht");
        }
        private void btn_Tafel7_Click(object sender, EventArgs e)
        {
            tafelnummer = 7;
            showPanel("RekeningOverzicht");
        }
        private void btn_Tafel8_Click(object sender, EventArgs e)
        {
            tafelnummer = 8;
            showPanel("RekeningOverzicht");
        }
        private void btn_Tafel9_Click(object sender, EventArgs e)
        {
            tafelnummer = 9;
            showPanel("RekeningOverzicht");
        }
        private void btn_Tafel10_Click(object sender, EventArgs e)
        {
            tafelnummer = 10;
            showPanel("RekeningOverzicht");
        }


        // Restaurant overzicht (buttons van kleur veranderen)
        private void CheckStatusGerechten(List<GerechtlijstItem> gerechtlijst)
        {
            foreach (GerechtlijstItem g in gerechtlijst)
            {
                if (g.TafelID == 1)
                {
                    VeranderButtonKleurGerecht(g, btn_Tafel1);
                }
                else if (g.TafelID == 2)
                {
                    VeranderButtonKleurGerecht(g, btn_Tafel2);
                }
                else if (g.TafelID == 3)
                {
                    VeranderButtonKleurGerecht(g, btn_Tafel3);
                }
                else if (g.TafelID == 4)
                {
                    VeranderButtonKleurGerecht(g, btn_Tafel4);
                }
                else if (g.TafelID == 5)
                {
                    VeranderButtonKleurGerecht(g, btn_Tafel5);
                }
                else if (g.TafelID == 6)
                {
                    VeranderButtonKleurGerecht(g, btn_Tafel6);
                }
                else if (g.TafelID == 7)
                {
                    VeranderButtonKleurGerecht(g, btn_Tafel7);
                }
                else if (g.TafelID == 8)
                {
                    VeranderButtonKleurGerecht(g, btn_Tafel8);
                }
                else if (g.TafelID == 9)
                {
                    VeranderButtonKleurGerecht(g, btn_Tafel9);
                }
                else if (g.TafelID == 10)
                {
                    VeranderButtonKleurGerecht(g, btn_Tafel10);
                }
            }
        }
        private void VeranderButtonKleurGerecht(GerechtlijstItem g, Button button)
        {
            if (g.status == Status.Besteld && button.BackColor != Color.Green)
            {
                //daarna prio
                button.BackColor = Color.Yellow;
            }
            else if (g.status == Status.KlaarVoorServeren)
            {
                //grootste prioriteit 
                button.BackColor = Color.Green;
            }
            else if (g.status == Status.Geserveerd && button.BackColor != Color.Green && button.BackColor != Color.Yellow)
            {
                button.BackColor = Color.SkyBlue;
            }
        }
        private void CheckStatusDrankjes(List<DrankLijstItem> dranklijst)
        {
            foreach (DrankLijstItem d in dranklijst)
            {
                if (d.TafelID == 1)
                {
                    VeranderButtonKleurDrankje(d, btn_Tafel1);
                }
                else if (d.TafelID == 2)
                {
                    VeranderButtonKleurDrankje(d, btn_Tafel2);
                }
                else if (d.TafelID == 3)
                {
                    VeranderButtonKleurDrankje(d, btn_Tafel3);
                }
                else if (d.TafelID == 4)
                {
                    VeranderButtonKleurDrankje(d, btn_Tafel4);
                }
                else if (d.TafelID == 5)
                {
                    VeranderButtonKleurDrankje(d, btn_Tafel5);
                }
                else if (d.TafelID == 6)
                {
                    VeranderButtonKleurDrankje(d, btn_Tafel6);
                }
                else if (d.TafelID == 7)
                {
                    VeranderButtonKleurDrankje(d, btn_Tafel7);
                }
                else if (d.TafelID == 8)
                {
                    VeranderButtonKleurDrankje(d, btn_Tafel8);
                }
                else if (d.TafelID == 9)
                {
                    VeranderButtonKleurDrankje(d, btn_Tafel9);
                }
                else if (d.TafelID == 10)
                {
                    VeranderButtonKleurDrankje(d, btn_Tafel10);
                }
            }
        }
        private void VeranderButtonKleurDrankje(DrankLijstItem d, Button button)
        {
            if (d.status == Status.Besteld && button.BackColor != Color.Green)
            {
                //daarna prio
                button.BackColor = Color.Yellow;
            }
            else if (d.status == Status.KlaarVoorServeren)
            {
                //grootste prioriteit 
                button.BackColor = Color.Green;
            }
            else if (d.status == Status.Geserveerd && button.BackColor != Color.Green && button.BackColor != Color.Yellow)
            {
                button.BackColor = Color.SkyBlue;
            }
        }

        // Afrekenen
        private void btn_VoegToeFooi_Click(object sender, EventArgs e)
        {
            double fooi = double.Parse(txt_Fooi.Text);
            totaalPrijs += fooi;

            lbl_EindBedragInvoer.Text = totaalPrijs.ToString("0.00");
        }
        private void btn_AfrekenBetalen_Click(object sender, EventArgs e)
        {
            gb_AfrekenPopUp.Show();
        }
        private void btn_AfrekenAnnuleren_Click(object sender, EventArgs e)
        {
            showPanel("RekeningOverzicht");
        }
        private void btn_AfrekenNee_Click(object sender, EventArgs e)
        {
            gb_AfrekenPopUp.Hide();
        }
        private void btnAfrekenJa_Click(object sender, EventArgs e)
        {
            gb_AfrekenPopUp.Hide();
            gb_Afgerekend.Show();

            AfrondenBestelling();
        }
        private void AfrondenBestelling()
        {
            if (txt_Fooi.Text == "")
            {
                txt_Fooi.Text = (0.0).ToString();
            }

            int bestelling = tafelService.GetHuidigeBestelling(tafelnummer);

            rekeningService.InsertRekening(double.Parse(txt_Fooi.Text), txt_Commentaar.Text, (BetaalMethode)cmb_BetaalMethode.SelectedItem, bestelling, totaalPrijs);

            VeranderStatusBestellingBar(StatusBestelling.Betaald, bestelling);
            VeranderStatusBestellingKeuken(StatusBestelling.Betaald, bestelling);

            tafelService.UpdateBestellingIDTafel(0, tafelnummer);
        }
        private void btn_BetalingVoltooid_Click(object sender, EventArgs e)
        {
            showPanel("Overzicht");
        }
        private void btn_Afrekenen_Click(object sender, EventArgs e)
        {
            showPanel("Afrekenen");
        }




        private void CB_SoortGerechtLunch_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetItemList();
        }

        private void CB_SoortDrankje_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetItemList();
        }

        private void btn_VoegToeBestelling_Click(object sender, EventArgs e)
        {

            List<DrankLijstItem> drankListItemOpslag = new List<DrankLijstItem>();
            // Button alleen mogen inklikken als alle velden ingevuld zijn
            if (CB_EtenDrinken.Text == "Drinken")
            {
                drankLijstItemService.AddDrankLijstItem(drankService.GetDrankID(CB_Items.Text), tafelService.GetHuidigeBestelling(tafelnummer), int.Parse(CB_Aantal.Text));
            }
            else if (CB_EtenDrinken.Text == "Eten")
            {
                gerechtlijstItemService.AddGerechtLijstItem(gerechtService.GetGerechtID(CB_Items.Text), tafelService.GetHuidigeBestelling(tafelnummer), int.Parse(CB_Aantal.Text));
            }



            string message = "Item is toegevoegd";
            string caption = "Item toegevoegd";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;

            // Displays the MessageBox.
            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.OK)
            {

                showPanel("LunchBestelling");
            }


        }

        private void lbl_KiesItem_Click(object sender, EventArgs e)
        {

        }

        private void lbl_TijdHeader_Click(object sender, EventArgs e)
        {

        }

        private void lbl_NaamMedewerker_Click(object sender, EventArgs e)
        {

        }

        private void btn_MinBestelItem_Click(object sender, EventArgs e)
        {
            List<DrankLijstItem> dranklijst = GetDrankItemLijst();
            List<GerechtlijstItem> gerechtLijst = GetGerechtItemLijst();




            int geselecteerdeID = 0;
            string etenDrinken;

            for (int i = 0; i < lv_BestellingsOverzicht.Items.Count; i++)
            {
                if (lv_BestellingsOverzicht.Items[i].Checked)
                {
                    geselecteerdeID = int.Parse(lv_BestellingsOverzicht.Items[i].SubItems[1].Text);
                }
            }
            for (int i = 0; i < lv_BestellingsOverzicht.Items.Count; i++)
            {
                if (lv_BestellingsOverzicht.Items[i].Checked)
                {
                    etenDrinken = lv_BestellingsOverzicht.Items[i].SubItems[1].Text.ToString();
                }
            }

            if (true)
            {
                foreach (var item in dranklijst)
                {
                    if (item.status == Status.Opslag)
                    {
                        drankLijstItemService.DeleteDrankLijstItem(geselecteerdeID, tafelService.GetHuidigeBestelling(tafelnummer), item.aantal - 1);
                    }
                }
            }
            else if (true)
            {
                foreach (var item in gerechtLijst)
                {
                    if (item.status == Status.Opslag)
                    {
                        gerechtlijstItemService.DeleteGerechtLijstItem(geselecteerdeID, tafelService.GetHuidigeBestelling(tafelnummer), item.Aantal - 1);
                    }
                }
            }
            

 
        }

        private void lv_BestellingsOverzicht_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
