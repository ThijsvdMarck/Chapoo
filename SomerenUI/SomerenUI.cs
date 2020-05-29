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
            showPanel("Dashboard");
        }

        private void showPanel(string panelName)
        {

            if(panelName == "Dashboard")
            {

                // hide all other panels
                pnl_Students.Hide();

                // show dashboard
                pnl_Dashboard.Show();
                img_Dashboard.Show();
            }
            else if(panelName == "Students")
            {
                // hide all other panels
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();

                // show students
                pnl_Students.Show();

                

                // fill the students listview within the students panel with a list of students
                SomerenLogic.DrankLijstItem_Service test = new SomerenLogic.DrankLijstItem_Service();
                List<DrankLijstItem> drankLijstItem = test.GetDrankLijstItems();

                // clear the listview before filling it again
                listViewStudents.Clear();

                listViewStudents.View = View.Details;
                listViewStudents.GridLines = true;
                listViewStudents.FullRowSelect = true;

                // Aanmaken van kolommen
                listViewStudents.Columns.Add("DrankID", 50);
                listViewStudents.Columns.Add("BestellingID", 50);
                listViewStudents.Columns.Add("Status", 100);
                listViewStudents.Columns.Add("Aantal", 100);

                string[] drankLijstItems = new string[4];
                ListViewItem itm;

                foreach (SomerenModel.DrankLijstItem d in drankLijstItems)
                {
                    drankLijstItems[0] = d.drankID.ToString();
                    drankLijstItems[1] = d.bestellingID.ToString();
                    drankLijstItems[2] = d.status.ToString();
                    drankLijstItems[3] = d.aantal.ToString();

                    itm = new ListViewItem(drankLijstItems);
                    listViewStudents.Items.Add(itm);
                }

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
    }
}
