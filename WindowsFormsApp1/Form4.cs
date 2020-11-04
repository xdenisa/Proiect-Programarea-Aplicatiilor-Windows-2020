using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {
        Portofoliu p;
     
        public Form4(Portofoliu p)
        {
            this.p = p;

            InitializeComponent();

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            float[] x = new float[p.Actiuni.Count()];
            for (int i = 0; i < p.Actiuni.Count(); i++)
                x[i] = p.Actiuni[i].Valoare;

           
             grafic1.valori = x;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var printDialog = new PrintPreviewDialog())
            {
                printDialog.Document = new DocumentGr(grafic1);

                printDialog.Document.DefaultPageSettings.Landscape = true;
                printDialog.ShowDialog(this);
            }


        }

        private void save(Control c, string denumire)
        {
            Bitmap img = new Bitmap(c.Width, c.Height);
            c.DrawToBitmap(img, new Rectangle(c.ClientRectangle.X,
                c.ClientRectangle.Y, c.ClientRectangle.Width,
                c.ClientRectangle.Height));
            img.Save(denumire);
            img.Dispose();
        }
        private void salvareGraficToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save(grafic1, "Grafic.bmp");
            MessageBox.Show("Salvat cu succes!");
        }

        //private void panel1_Paint(object sender, PaintEventArgs e)
        //{
          
        //}

        
        
    }
}