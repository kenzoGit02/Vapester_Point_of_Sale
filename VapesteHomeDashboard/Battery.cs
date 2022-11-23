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
    public partial class Battery : Form
    {
        public Battery()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dashboard form = new Dashboard();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           Mod form = new Mod();
            form.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
           Pod form = new Pod();
            form.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Ejuice form = new Ejuice();
            form.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
           Atomizer form = new Atomizer();
            form.Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {
          Battery form = new Battery();
            form.Show();
        }

        private void button18_Click(object sender, EventArgs e)
        {

            Others form = new Others();
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            About form = new About();
            form.Show();
        }
    }
}
