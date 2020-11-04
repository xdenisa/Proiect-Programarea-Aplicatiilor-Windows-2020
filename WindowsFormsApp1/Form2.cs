using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    
    public partial class Form2 : Form
    {
        Form1 b;
        string utilizator;
        Portofoliu p;
        public Form2(string u,Portofoliu po)
        {
            utilizator = u;
            p = po;
            InitializeComponent();
            this.Text = "Bun venit " + utilizator;
           
        }
      

        private void button1_Click(object sender, EventArgs e)
        {
            b = new Form1(p);
            this.Hide();
            b.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 x = new Form6(p,utilizator);
            this.Hide();
            x.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form7 y = new Form7(p,utilizator);
            y.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {
          
        }

        public void PrintPv(object sender, PrintPageEventArgs e)
        {
            Graphics gr = e.Graphics;
            Color color = Color.AliceBlue;
            Pen pen = new Pen(color, 5);

            double[] vect = new double[p.Actiuni.Count()];

            int j = 0;
            foreach (Actiune c in p.Actiuni)
            {
                vect[j] = c.Valoare;
                j++;
            }

            Point start_line = new Point();
            start_line.X = 0;
            start_line.Y = 0;

            Point end_line = new Point();
            end_line.X = 0;
            end_line.Y = 0;

            int height = this.Height;



            int nrElem = vect.Length;
            if (nrElem == 0)
                return;

            double inaltime = this.Height / nrElem / 5;
            double distanta = (this.Height - nrElem * inaltime) / (nrElem + 1);
            double vMax = vect.Max();

            start_line.X = 0+ 50;
            start_line.Y = 0+ 50;

            Brush br = new SolidBrush(color);
            double distanta2 = 30;

            
            string total = "Total actiuni: ";
          
            gr.DrawString((total.ToUpper() + p.Actiuni.Count.ToString()), DefaultFont, br, new Point(this.Width / 4, start_line.Y));

            int i = 1;
            int width = 700;
            Font f = new Font(FontFamily.GenericSansSerif, 10f, FontStyle.Regular);
            foreach (Actiune c in p.Actiuni)
            {
                gr.DrawString(( c.Titlu.ToUpper()), f, br, new Point(start_line.X, (int)(i * (start_line.Y + distanta2 + 20))));
                string lval = "Valoare: "; 
                SizeF sizeV = new SizeF();
                sizeV = e.Graphics.MeasureString(lval, f);
                gr.DrawString(lval,f, br, new Point(start_line.X + 30, (int)((i * (start_line.Y + distanta2 + 40)) - (2 * 10 * (i - 1)))));
                Rectangle rec = new Rectangle((int)(start_line.X + 30 + sizeV.Width), (int)((i * (start_line.Y + distanta2 + 40)) - (2 * 10 * (i - 1))), (int)((vect[i - 1] / vMax * width) - 100), (int)sizeV.Height);
                gr.FillRectangle(br, rec);
                gr.DrawString(("      "+c.Valoare.ToString() + " $"), f, br, new Point((int)(start_line.X + 75 + rec.Width), (int)((i * (start_line.Y + distanta2 + 40)) - (2 * 10 * (i - 1)))));
                gr.DrawString(("Detinator: " + "  " + c.Detinator), f, br, new Point(start_line.X + 30, (int)((i * (start_line.Y + distanta2 + 60)) - (4 * 10 * (i - 1)))));
                gr.DrawString(("Dividende: " + "  " + c.Dividende), f, br, new Point(start_line.X + 30, (int)((i * (start_line.Y + distanta2 + 80)) - (6 * 10 * (i - 1)))));
              
               
                i++;
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += new PrintPageEventHandler(PrintPv);
                PrintPreviewDialog dlg = new PrintPreviewDialog();
                dlg.PrintPreviewControl.ForeColor = Color.Black;
                dlg.Document = pd;
                dlg.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Portofoliul este gol.");
            }

           
        }
    }
}
