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
                SomerenLogic.Tafel_Service tafelService = new SomerenLogic.Tafel_Service();
                List<Tafel> tafelList = tafelService.GetTafels();

                // clear the listview before filling it again
                listViewStudents.Clear();

                listViewStudents.View = View.Details;
                listViewStudents.GridLines = true;
                listViewStudents.FullRowSelect = true;

                // Aanmaken van kolommen
                listViewStudents.Columns.Add("Tafel ID", 100);
                listViewStudents.Columns.Add("Gereserveerd", 100);

                string[] tafels = new string[2];
                ListViewItem itm;

                foreach (SomerenModel.Tafel t in tafelList)
                {
                    tafels[0] = t.tafelID.ToString();
                    tafels[1] = t.gereserveerd.ToString();

                    itm = new ListViewItem(tafels);
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
