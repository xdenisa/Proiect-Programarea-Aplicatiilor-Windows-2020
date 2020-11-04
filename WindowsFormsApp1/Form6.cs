using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form6 : Form
    {
        public Portofoliu p;
        string utilizator;
        public Form6(Portofoliu p,string utilizator)
        {
            this.p = p;
            this.utilizator = utilizator;
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Actiune a = new Actiune(textBox1.Text, textBox2.Text, float.Parse(textBox3.Text), float.Parse(textBox4.Text));
                p.adaugaActiune(a);
                MessageBox.Show("Actiune adaugata in portofoliu.");
                //textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                errorProvider1.Clear();
            }
            catch
            {
               
              //  MessageBox.Show("Datele introduse nu sunt valide");

                 if (textBox1.Text == "")
                        errorProvider1.SetError(textBox1, "Introduceti titlu!");
                   if (textBox2.Text == "")
                       errorProvider1.SetError(textBox2, "Introduceti detinator!");
                  if (textBox3.Text == "")
                        errorProvider1.SetError(textBox3, "Introduceti valoare!");
                   if (textBox4.Text == "")
                        errorProvider1.SetError(textBox4, "Introduceti dividende!");
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form2 b = new Form2(utilizator,p);
            this.Hide();
            b.ShowDialog();
            this.Close();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
        }
    }
}
