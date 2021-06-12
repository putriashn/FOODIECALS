using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FOODIECALS
{
    public partial class CashForm : Form
    {
        public CashForm(string value)
        {
            InitializeComponent();
            //textBox1.Text = value;
            this.Value = value;
        }

        public string Value { get; set; }
        public void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double total = double.Parse(textBox1.Text);
            double bayar = double.Parse(textBox2.Text);

            if (bayar<total)
            {
                MessageBox.Show("Maaf uang anda tidak cukup");
            }
            else
            {
                var kembalian = bayar - total;
                textBox3.Text = kembalian.ToString();
                MessageBox.Show("Transaksi berhasil");
                Close();
            }
        }

        private void CashForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = Value;
        }
    }
}
