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
    public partial class DebitForm : Form
    {
        public DebitForm(string value)
        {
            InitializeComponent();
            this.Value = value;
        }
        public string Value { get; set; }
        private void DebitForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = Value;
        }

        private void lbltotalbgt_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double total = double.Parse(textBox1.Text);
            double fee = 0.025;
            string card = comboBox1.SelectedItem.ToString();
            if (card == "Others")
            {
                var charge = fee * total;
                var totalbanget = charge + total;
                lbltotalbgt.Text = "Rp " + totalbanget.ToString() + ",00" ;
            }
            else
            {
                lbltotalbgt.Text = "Rp " + textBox1.Text + ",00" ;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Transaksi berhasil");
            Close();
        }
    }
}
