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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btn1_Click(object sender, EventArgs e)
        {
           
            if (txtBox1.Text == "" && txtBox2.Text == "")
            {
                MessageBox.Show("Enter your Username and Password");
                txtBox1.Focus();
            }
            else if (txtBox1.Text != "" && txtBox2.Text == "")
            {
                MessageBox.Show("Enter your Password");
                txtBox2.Focus();
            }
            else if (txtBox1.Text == "" && txtBox2.Text != "")
            {
                MessageBox.Show("Enter your Username");
            }
            else if(txtBox1.Text == "hello" && txtBox2.Text == "hello")
            {
                Dashboard f1 = new Dashboard();
                f1.Show();
                this.Hide();
                 
            }

        }
    }
}
