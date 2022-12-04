using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
        private void Form1_Load(object sender, EventArgs e)
        {
            sidebarTimer.Start();
            getData();
        }
        private void getData() {
            string server = "sql.freedb.tech", database = "freedb_MVC_Proj", username = "freedb_Vapers", pass = "ncxW8Ct2nF?9QzG";
            string constring = "SERVER=" + server + ";DATABASE=" + database + ";UID=" + username + ";PASSWORD=" + pass + ";";
            MySqlConnection conn = new MySqlConnection(constring);
            try
            {
                List<GetProdDetails> details = new List<GetProdDetails>();
                string query = "SELECT * FROM tbl_product";
                MySqlCommand select = new MySqlCommand(query, conn);
                conn.Open();
                MySqlDataReader dr = select.ExecuteReader();
                while (dr.Read())
                {
                    details.Add(new GetProdDetails
                    {
                        prod_Id = Convert.ToInt32(dr["prod_Id"]),
                        prod_Name = Convert.ToString(dr["prod_Name"]),
                        prod_Stock = Convert.ToInt32(dr["prod_Stock"]),
                        prod_Type = Convert.ToString(dr["prod_Type"]),
                        prod_Variant = Convert.ToString(dr["prod_Variant"]),
                        prod_Price = Convert.ToInt32(dr["prod_Price"])
                    });
                }
                cboxProductNo.DisplayMember = "prod_Id";
                cboxProductNo.DataSource = details;

                cboxProductName.DataSource = details;
                cboxProductName.DisplayMember = "prod_Name";


                cboxPrice.DisplayMember = "prod_Price";
                cboxPrice.DataSource = details;

                cboxInStock.DisplayMember = "prod_Stock";
                cboxInStock.DataSource = details;
                conn.Close();
            }
            catch
            {
                conn.Close();
            }
        }
        private void reset() {
            lblTotalPrice.Text = "";
            listView1.Items.Clear();
            txtQuantity.Clear();
            btnCancel.Enabled = false;
            btnRemove.Enabled = false;
            txtMoneyPaid.Clear();
            txtMoneyPaid.Enabled = false;
        }
        private void receipt() {
            int prodNameCol = 1;
            int quantityCol = 2;
            int priceCol = 3;
            foreach (ListViewItem items in listView1.Items) 
            {
                ListViewItem list = new ListViewItem(items.SubItems[prodNameCol].Text);
                list.SubItems.Add(items.SubItems[quantityCol].Text);
                list.SubItems.Add(items.SubItems[priceCol].Text);
                int result = Convert.ToInt32(items.SubItems[quantityCol].Text) * Convert.ToInt32(items.SubItems[priceCol].Text);
                list.SubItems.Add(result.ToString());
                listView2.Items.Add(list);
            }
            lbl_rcpt_DateOfPurchase.Text = DateTime.Now.ToString("MM/dd/yyyy hh:mmtt");
            lbl_rcpt_TotalPrice.Text = lblTotalPrice.Text;
            lbl_rcpt_MoneyRecieved.Text = txtMoneyPaid.Text;
            lbl_rcpt_Change.Text = txtChange.Text;
        }
        //int _totalPrice = 0;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtQuantity.Text))
            {
                MessageBox.Show("Quantity missing value");
                return;
            }
                
            ListViewItem item = new ListViewItem(cboxProductNo.Text);
            item.SubItems.Add(cboxProductName.Text);
            item.SubItems.Add(txtQuantity.Text);
            item.SubItems.Add(cboxPrice.Text);

            listView1.Items.Add(item);

            txtQuantity.Clear();
            cboxProductNo.Focus();

            int quantityCol = 2;
            int priceCol = 3;
            int _totalPrice = 0;

            foreach (ListViewItem items in listView1.Items)
            {
                int quantity = Convert.ToInt32(items.SubItems[quantityCol].Text);
                _totalPrice += Convert.ToInt32(items.SubItems[priceCol].Text) * quantity;
            }
            lblTotalPrice.Text = _totalPrice.ToString();
            txtMoneyPaid.Enabled = true;
            btnCancel.Enabled = true;
            btnRemove.Enabled = true;
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.Items.Count > 0) {
                    listView1.Items.Remove(listView1.SelectedItems[0]);
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show("Please click an Entry first");
            }
            

            int quantityCol = 2;
            int priceCol = 3;
            int _totalPrice = 0;
            foreach (ListViewItem items in listView1.Items)
            {
                int quantity = Convert.ToInt32(items.SubItems[quantityCol].Text);
                _totalPrice += Convert.ToInt32(items.SubItems[priceCol].Text) * quantity;
            }
            lblTotalPrice.Text = _totalPrice.ToString();
            if (Convert.ToInt32(lblTotalPrice.Text) <= 0 || listView1.Items.Count <= 0)
            {
                txtMoneyPaid.Clear();
                txtMoneyPaid.Enabled = false;
                btnCheckout.Enabled = false;
                btnCancel.Enabled = false;
                btnRemove.Enabled = false;
            }
                
        }
        private void btnCheckout_Click(object sender, EventArgs e)
        {
            int idCol = 0;
            int quantityCol = 2;
            
            string server = "sql.freedb.tech", database = "freedb_MVC_Proj", username = "freedb_Vapers", pass = "ncxW8Ct2nF?9QzG";
            string constring = "SERVER=" + server + ";DATABASE=" + database + ";UID=" + username + ";PASSWORD=" + pass + ";";
            MySqlConnection conn = new MySqlConnection(constring);

            try
            {
                conn.Open();
                
                
                foreach (ListViewItem item in listView1.Items)
                {
                    string id = item.SubItems[idCol].Text;
                    string quantity = item.SubItems[quantityCol].Text;

                    string updateProduct = "UPDATE tbl_product SET prod_Stock = prod_Stock - " + quantity + " WHERE prod_ID = " + id + "";
                    string transactionLog = "INSERT INTO tbl_order_history(quantity,price,prod_ID,date) VALUES(" + quantity + "," + lblTotalPrice.Text + "," + id + ",CURDATE())";


                    MySqlCommand update = new MySqlCommand(updateProduct, conn);
                    if (update.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Product Quantity decreased");
                    }
                    else
                    {
                        MessageBox.Show("Update Query Failed");
                    }

                    MySqlCommand log = new MySqlCommand(transactionLog, conn);
                    if (log.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Logging Succesfull");
                    }
                    else
                    {
                        MessageBox.Show("Logging Failed");
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
            receipt();
            reset();
            getData();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            reset();
        }
        private void cboxProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cboxProductName.SelectedIndex;
            cboxProductNo.SelectedIndex = index;
            cboxPrice.SelectedIndex = index;
            cboxInStock.SelectedIndex = index;
        }
        private void txtMoneyPaid_KeyPress(object sender, KeyPressEventArgs e)
        {
            //To not accept keypress other than Numbers and backspace
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }
        private void txtMoneyPaid_TextChanged(object sender, EventArgs e)
        {
            int result = 0;
            if (txtMoneyPaid.Text != "" && Convert.ToInt32(txtMoneyPaid.Text) >= Convert.ToInt32(lblTotalPrice.Text))//checks if there is an input and the input is greater than total price
            {
                result = Convert.ToInt32(txtMoneyPaid.Text) - Convert.ToInt32(lblTotalPrice.Text);
                btnCheckout.Enabled = true;
            }
            else
            {
                txtChange.Clear();
                btnCheckout.Enabled = false;
            }
            txtChange.Text = result.ToString();//output the change

        }
        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);//only accepts keypress numbers and backspace
        }
        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString();
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }
        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void sidebar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Mod form = new Mod();
            //form.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
         


        }

        private void button1_Click(object sender, EventArgs e)
        {
            //int a = Convert.ToInt32(txtProduct.Text);
            //int b = Convert.ToInt32(txtQuantity.Text);
           

            //txtPrice.Text = Convert.ToString(a + b);
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            //int a = Convert.ToInt32(txtProduct.Text);
            //int b = Convert.ToInt32(txtQuantity.Text);

            //int d = Convert.ToInt32(txtMoneyPaid.Text);
            //int j = Convert.ToInt32(txtPrice.Text);
            //textBox5.Text = Convert.ToString( d - j );
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

        

        private void button16_Click(object sender, EventArgs e)
        {
            //Ejuice form = new Ejuice();
            //form.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            //Atomizer form = new Atomizer();
            //form.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            //Mod form = new Mod();
            //form.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            //Pod form = new Pod();
            //form.Show();
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
            //Battery form = new Battery();
            //form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
            //Others form = new Others();
            //form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //About form = new About();
            //form.Show();
        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        

        private void dsadsa_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //comboBox2.SelectedIndexChanged[]

            //int index = cboxProductNo.SelectedIndex;
            //cboxProductName.SelectedIndex = index;
            //cboxPrice.SelectedIndex = index;
            //cboxInStock.SelectedIndex = index;
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        

        private void button1_Click_1(object sender, EventArgs e)
        {
        }

        

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //int index = comboBox1.SelectedIndex;
            //comboBox2.SelectedIndex = index;
            //comboBox3.SelectedIndex = index;
            //comboBox4.SelectedIndex = index;
        }

        

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

            //if (textBox1.Text != "")
            //{
            //    int a = 10;
            //    int b = int.Parse(textBox1.Text);
            //    textBox2.Text = (a * b).ToString();
            //}
            //else 
            //{
            //    textBox2.Clear();
            //}
                
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsLetter(e.KeyChar)|| e.KeyChar == '\b')
            //{
            //    e.Handled = true;
            //}
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
    }
}
