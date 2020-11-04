using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class UC_PAW : UserControl
    {

        public int sens;
     
        public UC_PAW()
        {
           
            InitializeComponent();
        }

        private void UC_PAW_Load(object sender, EventArgs e)
        {
            sens = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }
      
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            Random r = new Random();
            Point x = new Point(pictureBox1.Location.X, pictureBox1.Location.Y);
            x.X = x.X + r.Next(1,20)*sens;
            x.Y = x.Y + r.Next(1,20)*sens;
            pictureBox1.Location = x;
            if (pictureBox1.Location.X >=this.Right)
                sens = -1;
            if (pictureBox1.Location.X <= this.Left)
                sens = 1;
            if (pictureBox1.Location.Y >= this.Height)
                sens = -1;
            if (pictureBox1.Location.Y <= 0)
              sens = 1;

        }

        //private void label1_Click(object sender, EventArgs e)
        //{

        //}

        //private void textBox1_KeyDown(object sender, KeyEventArgs e)
        //{

        //}

    }
}
