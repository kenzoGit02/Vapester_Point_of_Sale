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
    public partial class Mod : Form
    {
        public static Mod instance;
        public Mod()
        {
            InitializeComponent();
            instance = this;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Dashboard form = new Dashboard();
            form.Show();
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Mod_Load(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dashboard form = new Dashboard();
            form.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Ejuice form = new Ejuice();
            form.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
          Pod form = new Pod();
            form.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Atomizer form = new Atomizer();
            form.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Battery form = new Battery();
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
