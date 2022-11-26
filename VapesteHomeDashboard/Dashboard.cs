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
    public partial class Dashboard : Form
    {
        public static Dashboard instance;
        public Dashboard()
        {
            InitializeComponent();
            instance = this;
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void sidebar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Mod form = new Mod();
            form.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
         


        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(txtProduct.Text);
            int b = Convert.ToInt32(txtQuantity.Text);
           

            txtPrice.Text = Convert.ToString(a + b);


        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(txtProduct.Text);
            int b = Convert.ToInt32(txtQuantity.Text);

            int d = Convert.ToInt32(textBox4.Text);
            int j = Convert.ToInt32(txtPrice.Text);
            textBox5.Text = Convert.ToString( d - j );
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
           
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel16_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel15_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel17_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label12_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

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

        private void button4_Click_1(object sender, EventArgs e)
        {

            Mod form = new Mod();
            form.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Pod form = new Pod();
            form.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
         Battery form = new Battery();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

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

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProduct.Text) || string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtQuantity.Text) || string.IsNullOrEmpty(txtPrice.Text))
                return;
            ListViewItem item = new ListViewItem(txtProduct.Text);
            item.SubItems.Add(txtName.Text);
            item.SubItems.Add(txtQuantity.Text);
            item.SubItems.Add(txtPrice.Text);
            listView1.Items.Add(item);

            txtProduct.Clear();
            txtName.Clear();
            txtQuantity.Clear();
            txtPrice.Clear();
            txtProduct.Focus();

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0)
                listView1.Items.Remove(listView1.SelectedItems[0]);
        }
    }
}
