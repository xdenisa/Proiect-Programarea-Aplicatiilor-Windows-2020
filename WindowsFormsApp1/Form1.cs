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
    public partial class Form1 : Form
    {
        Form2 a;
        Portofoliu p;
        bool ascunde;
        public Form1()
        {
            p = new Portofoliu();
            InitializeComponent();
            
           
        }

        public Form1(Portofoliu p)
        {
            this.p = p;
            InitializeComponent();
            

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string utilizator = textBox1.Text;
            a = new Form2(utilizator,p);
            this.Hide();
            a.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 c = new Form3(p);
            c.ShowDialog();
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 d = new Form4(p);
            d.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form5 f = new Form5(p);
            f.ShowDialog();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string var = textBox2.Text;
            string var2 = "";
            for(int i=0;i<var.Length;i++)
            {
                var2 += "*";
            }
            if (ascunde == true)
                textBox2.Text = var2;
            else
                textBox2.Text = var;
        }

        private void Form1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ascunde = true;
            pictureBox2.Visible = true;
            pictureBox1.Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ascunde = false;
            textBox2.Clear();
            pictureBox1.Visible = true;
            pictureBox2.Visible = false;


        }
    }
}
