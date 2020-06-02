using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;
using SomerenModel;

namespace SomerenDAL
{
    public class Brein_DAO : Base
    {

        public bool Db_Get_All_Gebruikers()
        {
            string query = "SELECT DrankID, Dranknaam, [Prijs] FROM [Drankje]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private bool ReadTables(DataTable dataTable)
        {



            SqlParameter uPassword = new SqlParameter("@Password", SqlDbType.VarChar);


            uPassword.Value = txtPassword.Text;


            myCommand.Parameters.Add(uPassword);





            if (myReader.Read() == true)
            {
                MessageBox.Show("You have logged in successfully " + txtUserName.Text);
                //Hide the login form
                this.Hide();
            }

            return false;
    }
}
