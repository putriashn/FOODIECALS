using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FOODIECALS
{
    public partial class OrderForm : Form
    {
        public TextBox tb1;
        public OrderForm()
        {
            InitializeComponent();
            fillcombobox();
            tb1 = txttotal;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        public void fillcombobox()
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-DJH161QP;Initial Catalog=comboboxnew;Integrated Security=True");
            string sql = "select * from comboboxnew";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader myreader; 
                try
            {
                con.Open();
                myreader = cmd.ExecuteReader();
                while(myreader.Read())
                {
                    string smenu = myreader.GetString(1);
                    comboBox1.Items.Add(smenu);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-DJH161QP;Initial Catalog=comboboxnew;Integrated Security=True");
            con.Open();
            string q = "select calories, harga from comboboxnew where menu = '" + comboBox1.SelectedItem + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtharga.Text = dr[1].ToString();
                lblcal.Text = dr[0].ToString();
            }
           con.Close();

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtsubttl_TextChanged(object sender, EventArgs e)
        {
            
        }

        public void button1_Click(object sender, EventArgs e)
        {
            double jumlah = double.Parse(txtqty.Text);
            double harga = double.Parse(txtharga.Text);
            var total = harga * jumlah;
            txttotal.Text = total.ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string payment = comboBox2.SelectedItem.ToString();
            if (payment == "Cash")
            {
                CashForm form3 = new CashForm(txttotal.Text);
                form3.Show();
            }
            else if (payment == "Debit")
            {
                DebitForm form4 = new DebitForm(txttotal.Text);
                form4.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
