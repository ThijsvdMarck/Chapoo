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
    public partial class SomerenUI : Form
    {

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
            MenuBalkBestelling_pnl.Hide();
            MenuBalkTafels_pnl.Hide();

        }
        private void SomerenUI_Load(object sender, EventArgs e)
        {
            showPanel("LogIn");
        }
        

        private void showPanel(string panelName)
        {

            if(panelName == "LogIn")
            {
                hideAllPanels();
                pnl_LogIn.Show();
            }
            else if(panelName == "Students")
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
            else if(panelName == "Base"){
                hideAllPanels();
                pnl_Base.Show();
            }           
            else if (panelName == "BestellingsOverzicht")
            {
                hideAllPanels();
                pnl_Base.Show();
                MenuBalkBestelling_pnl.Show();
                pnl_BestellingsOverzicht.Show();
            }
            else if (panelName == "BestellingVersturen")
            {
                hideAllPanels();
                pnl_BestellingVersturen.Show();
            }
            else if (panelName == "BestellingVerstuurd")
            {
                hideAllPanels();
                pnl_BestellingVerstuurd.Show();
            }
            else if (panelName == "Bier")
            {
                hideAllPanels();
                pnl_Bier.Show();
            }
            else if (panelName == "DinerBestelling")
            {
                hideAllPanels();
                pnl_DinerBestelling.Show();
            }
            else if (panelName == "Frisdrank")
            {
                hideAllPanels();
                pnl_Frisdrank.Show();
            }
            else if (panelName == "GedestilleerdeDranken")
            {
                hideAllPanels();
                pnl_GedestilleerdeDranken.Show();
            }
            else if (panelName == "KoffieThee")
            {
                hideAllPanels();
                pnl_KoffieThee.Show();
            }
            else if (panelName == "LunchBestelling")
            {
                hideAllPanels();
                pnl_Base.Show();
                MenuBalkBestelling_pnl.Show();
                pnl_LunchBestelling.Show();
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
            else if (panelName == "TafelOverzicht")
            {
                hideAllPanels();
                pnl_TafelOverzicht.Show();
            }
            else if (panelName == "TafelOverzicht")
            {
                hideAllPanels();
                pnl_TafelOverzicht.Show();
            }
            else if (panelName == "Tafels")
            {
                hideAllPanels();
                pnl_Base.Show();
                pnl_TafelOverzicht.Show();
            }
            else if (panelName == "Voorraad")
            {
                hideAllPanels();
                pnl_Base.Show();
                pnl_Voorraad.Show();
            }
            else if (panelName == "Wijn")
            {
                hideAllPanels();
                pnl_Wijn.Show();
            }
            else if (panelName == "MenuBalkBestelling_pnl")
            {
                hideAllPanels();
                MenuBalkBestelling_pnl.Show();
            }
            else if (panelName == "MenuBalkTafels")
            {
                hideAllPanels();
                MenuBalkTafels_pnl.Show();
            }
             
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
           //
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dashboardToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            showPanel("Dashboard");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void img_Dashboard_Click(object sender, EventArgs e)
        {
            MessageBox.Show("What happens in Someren, stays in Someren!");
        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Students");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btn_Financien_Click(object sender, EventArgs e)
        {

        }

        private void btn_TafelOverzicht_Click(object sender, EventArgs e)
        {

        }

        private void btn_LogIn_Click(object sender, EventArgs e)
        {
            showPanel("Overzicht");
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void btn_MinSteakTartaar_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void lbl_LinguiniPaddestoelen_Click(object sender, EventArgs e)
        {

        }

        private void lbl_Hoofdgerechten_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }

        private void button26_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_2(object sender, EventArgs e)
        {

        }

        private void lbl_PrijsCocaCola_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_3(object sender, EventArgs e)
        {

        }

        private void lbl_PrijsKalfstartaar_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_4(object sender, EventArgs e)
        {

        }

        private void label44_Click(object sender, EventArgs e)
        {

        }

        private void label41_Click(object sender, EventArgs e)
        {

        }

        private void label39_Click(object sender, EventArgs e)
        {

        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {

        }

        private void label38_Click(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {

        }

        private void label40_Click(object sender, EventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e)
        {

        }

        private void button24_Click(object sender, EventArgs e)
        {

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

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void txt_Opmerkingen_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Tafel1_Click(object sender, EventArgs e)
        {
            showPanel("LunchBestelling");
        }
    }
}
