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
 
        private void SomerenUI_Load(object sender, EventArgs e)
        {
            showPanel("LogIn");
        }
        private void hideAllPanels()
        {
            // Hide all panels niet header
            pnl_LogIn.Hide();
            pnl_Base.Hide();
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
            showPanel("Base");
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
    }
}
