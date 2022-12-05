using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VapesteHomeDashboard
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, EventArgs e)
        {

            string server = "sql.freedb.tech", database = "freedb_MVC_Proj", username = "freedb_Vapers", password = "ncxW8Ct2nF?9QzG";
            string constring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";";

            MySqlConnection conn = new MySqlConnection(constring);
            string query = "Select * From tbl_teller Where email='" + txtBox1.Text + "'And password='" + txtBox2.Text + "'";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader;

            try
            {

                conn.Open();
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        MessageBox.Show("Succes");
                        this.Hide();
                        Dashboard db = new Dashboard();
                        db.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Either your Username or Password are Incorrect, Please type it again.");
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (showhidePass.Checked)
            {
                txtBox2.UseSystemPasswordChar = true;
            }
            else
            {
                txtBox2.UseSystemPasswordChar = false;
            }
        }
    }
}
