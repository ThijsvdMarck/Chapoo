using SomerenLogic;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SomerenUI
{
    // Friet is lekker
    public partial class SomerenUI : Form
    {
        SomerenLogic.Drankje_Service drankService = new SomerenLogic.Drankje_Service();
        SomerenLogic.Gerecht_Service gerechtService = new SomerenLogic.Gerecht_Service();
        SomerenLogic.Bestelling_Service bestellingService = new SomerenLogic.Bestelling_Service();
        SomerenLogic.GerechtlijstItem_Service gerechtlijstItemService = new SomerenLogic.GerechtlijstItem_Service();
        SomerenLogic.DrankLijstItem_Service drankLijstService = new SomerenLogic.DrankLijstItem_Service();



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

        }
        private void GetGerechtList()
        {
            comboBox3.Items.Clear();
            comboBox3.Hide();
            comboBox3.Text = "";

            List<Gerecht> gerechtList = gerechtService.GetGerechten();
            List<Drankje> drankList = drankService.GetDrankjes();

            List<Gerecht> voorgerechtLunchGerechtList = new List<Gerecht>();
            List<Gerecht> hoofdgerechtLunchGerechtList = new List<Gerecht>();
            List<Gerecht> nagerechtLunchGerechtList = new List<Gerecht>();


            List<Gerecht> voorgerechtDinerGerechtList = new List<Gerecht>();
            List<Gerecht> tussengerechtDinerGerechtList = new List<Gerecht>();
            List<Gerecht> hoofdgerechtDinerGerechtList = new List<Gerecht>();
            List<Gerecht> nagerechtDinerGerechtList = new List<Gerecht>();

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

            if (CB_EtenDrinken.Text == "Drinken")
            {
                CB_LunchDiner.Hide();
                CB_SoortGerecht.Hide();
                comboBox3.Show();
                foreach (SomerenModel.Drankje d in drankList) { comboBox3.Items.Add(d.drankNaam.ToString()); }
            }
            else if (CB_EtenDrinken.Text == "Eten")
            {
                CB_LunchDiner.Show();
                if (CB_LunchDiner.Text == "Lunch")
                {
                    
                    CB_SoortGerecht.Show();

                    CB_SoortGerecht.Items.Add("Voorgerecht");
                    CB_SoortGerecht.Items.Add("Hoofdgerecht");
                    CB_SoortGerecht.Items.Add("Nagerecht");

                    
                    if (CB_SoortGerecht.Text == "Voorgerecht")
                    {
                        comboBox3.Show();
                        foreach (SomerenModel.Gerecht d in voorgerechtLunchGerechtList) { comboBox3.Items.Add(d.gerechtNaam.ToString()); }
                        CB_SoortGerecht.SelectedIndex = 0;

                    }
                    else if (CB_SoortGerecht.Text == "Hoofdgerecht")
                    {
                        comboBox3.Show();
                        CB_SoortGerecht.SelectedIndex = 1;
                        foreach (SomerenModel.Gerecht d in hoofdgerechtLunchGerechtList) { comboBox3.Items.Add(d.gerechtNaam.ToString()); }
                    }
                    else if (CB_SoortGerecht.Text == "Voorgerecht")
                    {
                        comboBox3.Show();
                        CB_SoortGerecht.SelectedIndex = 2;
                        foreach (SomerenModel.Gerecht d in nagerechtLunchGerechtList) { comboBox3.Items.Add(d.gerechtNaam.ToString()); }
                    }
                }
                else if(CB_LunchDiner.Text == "Diner")
                {
                    CB_SoortGerecht.Show();

                    CB_SoortGerecht.Items.Add("Voorgerecht");
                    CB_SoortGerecht.Items.Add("Tussengerecht");
                    CB_SoortGerecht.Items.Add("Hoofdgerecht");
                    CB_SoortGerecht.Items.Add("Nagerecht");

                    if (CB_SoortGerecht.Text == "Voorgerecht")
                    {
                        comboBox3.Show();
                        foreach (SomerenModel.Gerecht d in voorgerechtDinerGerechtList) { comboBox3.Items.Add(d.gerechtNaam.ToString()); }
                    }
                    else if (CB_SoortGerecht.Text == "Tussengerecht")
                    {
                        comboBox3.Show();
                        foreach (SomerenModel.Gerecht d in hoofdgerechtDinerGerechtList) { comboBox3.Items.Add(d.gerechtNaam.ToString()); }
                    }
                    else if (CB_SoortGerecht.Text == "Hoofdgerecht")
                    {
                        comboBox3.Show();
                        foreach (SomerenModel.Gerecht d in hoofdgerechtDinerGerechtList) { comboBox3.Items.Add(d.gerechtNaam.ToString()); }
                    }
                    else if (CB_SoortGerecht.Text == "Nagerecht")
                    {
                        comboBox3.Show();
                        foreach (SomerenModel.Gerecht d in nagerechtDinerGerechtList) { comboBox3.Items.Add(d.gerechtNaam.ToString()); }
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
        private void SomerenUI_Load(object sender, EventArgs e)
        {
            showPanel("LogIn");
        }


        private void showPanel(string panelName)
        {

            if (panelName == "LogIn")
            {
                hideAllPanels();
                pnl_LogIn.Show();
            }
            else if (panelName == "Students")
            {
                /*
                   // hide all other panels
                   pnl_Dashboard.Hide();
                   img_Dashboard.Hide();

                   // show students
                   pnl_Students.Show();



                   // fill the students listview within the students panel with a list of students
                   SomerenLogic.DrankLijstItem_Service test = new SomerenLogic.DrankLijstItem_Service();
                   List<DrankLijstItem> drankLijstItem  = test.GetDrankLijstItems();

                   // clear the listview before filling it again
                   listViewStudents.Clear();

                   listViewStudents.View = View.Details;
                   listViewStudents.GridLines = true;
                   listViewStudents.FullRowSelect = true;

                   // Aanmaken van kolommen
                   listViewStudents.Columns.Add("DrankNaam", 70);
                   listViewStudents.Columns.Add("BestellingID", 70);
                   listViewStudents.Columns.Add("Status", 100);
                   listViewStudents.Columns.Add("Aantal", 100);

                   string[] drankLijstItems = new string[4];
                   ListViewItem itm;

                   foreach (SomerenModel.DrankLijstItem d in drankLijstItem )
                   {
                       drankLijstItems[0] = d.drankNaam;
                       drankLijstItems[1] = d.bestellingID.ToString();
                       drankLijstItems[2] = d.status.ToString();
                       drankLijstItems[3] = d.aantal.ToString();

                       itm = new ListViewItem(drankLijstItems);
                       listViewStudents.Items.Add(itm);
                   }
                */
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

                comboBox3.Items.Clear();
                CB_LunchDiner.Items.Clear();
                CB_EtenDrinken.Items.Clear();
                CB_SoortGerecht.Items.Clear();


                CB_LunchDiner.Items.Add(DagType.Lunch.ToString());
                CB_LunchDiner.Items.Add(DagType.Diner.ToString());

                CB_EtenDrinken.Items.Add("Drinken");
                CB_EtenDrinken.Items.Add("Eten");

                CB_LunchDiner.Hide();
                CB_SoortGerecht.Hide();
                comboBox3.Hide();
                comboBox4.Hide();
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
                lv_KeukenOverzicht.Columns.Add("Status", 100);

                string[] bestellingen = new string[3];
                ListViewItem itm;

                foreach (SomerenModel.Bestelling b in bestellingList)
                {
                    bestellingen[0] = "Tafel " + b.TafelID.ToString();
                    bestellingen[1] = b.BestellingID.ToString();
                    bestellingen[2] = b.status.ToString();

                    itm = new ListViewItem(bestellingen);
                    lv_KeukenOverzicht.Items.Add(itm);
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
                lv_BarOverzicht.Columns.Add("Status", 100);

                string[] bestellingen = new string[3];
                ListViewItem itm;

                foreach (SomerenModel.Bestelling b in bestellingList)
                {
                    bestellingen[0] = "Tafel " + b.TafelID.ToString();
                    bestellingen[1] = b.BestellingID.ToString();
                    bestellingen[2] = b.status.ToString();

                    itm = new ListViewItem(bestellingen);
                    lv_BarOverzicht.Items.Add(itm);
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

                lbl_Tafel.Text = geselecteerdeTafel;
                lbl_TafelNr.Text = "";

                lbl_StatusBar.Text = tafelStatus;

                // Listview
                int geselecteerdeBestelling = GetGeselecteerdeBestellingBar();

                List<DrankLijstItem> drankList = drankLijstService.GetDrankLijstItems(geselecteerdeBestelling);

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
                    drankjes[0] = d.bestellingID.ToString();
                    drankjes[1] = d.drankNaam;
                    drankjes[2] = d.aantal.ToString();
                    drankjes[3] = d.tijd.ToString("HH:mm");
                    drankjes[4] = d.status.ToString();
                    drankjes[5] = d.drankID.ToString();

                    itm = new ListViewItem(drankjes);

                    if (d.status == Status.KlaarVoorServeren)
                    {
                        itm.BackColor = Color.MistyRose;
                    }
                    else if (d.status == Status.Geserveerd)
                    {
                        itm.BackColor = Color.Pink;
                    }

                    lv_BarBestelling.Items.Add(itm);
            
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
                    gerechten[0] = g.BestellingID.ToString();
                    gerechten[1] = g.GerechtNaam;
                    gerechten[2] = g.Aantal.ToString();
                    gerechten[3] = g.Tijd.ToString("HH:mm");
                    gerechten[4] = g.status.ToString();
                    gerechten[5] = g.GerechtID.ToString();

                    itm = new ListViewItem(gerechten);

                    if (g.status == Status.KlaarVoorServeren)
                    {
                        itm.BackColor = Color.MistyRose;
                    }     
                    else if (g.status == Status.Geserveerd)
                    {
                        itm.BackColor = Color.Pink;
                    }

                    lv_BestellingenKeuken.Items.Add(itm);
            
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
                
                //lbl_TafelNrInvoer.Text = geselecteerdeTafel;

                cmb_BetaalMethode.Items.Clear();

                cmb_BetaalMethode.Items.Add(BetaalMethode.Pin);
                cmb_BetaalMethode.Items.Add(BetaalMethode.Contant);
                cmb_BetaalMethode.Items.Add(BetaalMethode.CreditCard);

                cmb_BetaalMethode.SelectedIndex = 0;
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
            showPanel("Overzicht");
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

        private void btn_Tafel1_Click(object sender, EventArgs e)
        {
            //showPanel("RekeningOverzicht");
            //if (statusBestelling = )
            //{ 

            //}
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
            showPanel("BestellingVerstuurd");
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
        private void VeranderStatusBestelling(StatusBestelling status, int geselecteerdeBestelling)
        {
            bestellingService.UpdateBestelling(status, geselecteerdeBestelling);
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
        private int GetGeselecteerdGerecht()
        {
            int geselecteerdGerecht = 0;

            for (int i = 0; i < lv_BestellingenKeuken.Items.Count; i++)
            {
                if (lv_BestellingenKeuken.Items[i].Checked)
                {
                    geselecteerdGerecht = int.Parse(lv_BestellingenKeuken.Items[i].SubItems[5].Text);
                }
            }

            return geselecteerdGerecht;
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
                    int geselecteerdGerecht = GetGeselecteerdGerecht();

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
                VeranderStatusBestelling(StatusBestelling.Afgerond, bestelling);
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
        private int GetGeselecteerdDrankje()
        {
            int geselecteerdDrankje = 0;

            for (int i = 0; i < lv_BarBestelling.Items.Count; i++)
            {
                if (lv_BarBestelling.Items[i].Checked)
                {
                    geselecteerdDrankje = int.Parse(lv_BarBestelling.Items[i].SubItems[5].Text);
                }
            }

            return geselecteerdDrankje;
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
                    int geselecteerdDrankje = GetGeselecteerdDrankje();

                    drankLijstService.UpdateDrankItem(status, geselecteerdeBestelling, geselecteerdDrankje);
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
                VeranderStatusBestelling(StatusBestelling.Afgerond, bestelling);
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

            string query = "INSERT INTO drankje VALUES ('" + txt_DrankNaam.Text + "', " + txt_PrijsDrank.Text + ", '" + txt_Alcoholisch.Text + "', " + txt_HoeveelheidDrank.Text + ")";
            drankService.UpdateDrankje(query);

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

            string query = "INSERT INTO gerecht VALUES ('" + txt_NaamGerecht.Text + "', " + txt_PrijsGerecht.Text + ", '" + txt_SoortGerecht.Text + "', '" + txt_TypeGerecht.Text + "', " + txt_HoeveelheidGerecht.Text + ")";
            gerechtService.UpdateGerecht(query);

            txt_TypeGerecht.Clear();
            txt_HoeveelheidGerecht.Clear();
            txt_NaamGerecht.Clear();
            txt_PrijsGerecht.Clear();
            txt_SoortGerecht.Clear();


            vulGerechtVoorraad();
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
        }

        private void btn_BetalingVoltooid_Click(object sender, EventArgs e)
        {
            showPanel("Overzicht");
        }

        private void btn_Afrekenen_Click(object sender, EventArgs e)
        {
            showPanel("Afrekenen");
        }

        private void btn_LogUit_Click(object sender, EventArgs e)
        {
            showPanel("LogIn");
        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetGerechtList();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void btn_MinKalfstartaar_Click(object sender, EventArgs e)
        {

        }

        private void CB_LunchDiner_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetGerechtList();
        }


       

        private void CB_SoortGerecht_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetGerechtList();
        }

    }
}
