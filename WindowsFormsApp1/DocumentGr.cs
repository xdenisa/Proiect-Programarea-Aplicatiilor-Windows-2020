using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Printing;

namespace WindowsFormsApp1
{
    class DocumentGr : PrintDocument
    {
        Grafic grafic;
        bool estePrimaPagina;
        int indexValoareCurenta;

        public DocumentGr(Grafic grafic)
        {
            this.grafic = grafic;
            estePrimaPagina = true;
            indexValoareCurenta = 0;
        }

        protected override void OnPrintPage(PrintPageEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            if (estePrimaPagina == true)
            {
                grafic.DesenareGrafic(e.Graphics, e.MarginBounds, grafic.Valori, Brushes.Transparent);

                e.HasMorePages = true;
                estePrimaPagina = false;
            }
            else
            {
                // afișăm 5 valori; dacă ajungem la sfârșitul listei oprim tipărirea
                for (int i = 0; i < 5; i++)
                {
                    if (indexValoareCurenta >= grafic.Valori.Length)
                    {
                        e.HasMorePages = false;
                        return;
                    }

                    e.Graphics.DrawString(grafic.Valori[indexValoareCurenta].ToString(),
                        grafic.Font, Brushes.Black, e.MarginBounds.X, e.MarginBounds.Y + i * 20);
                    indexValoareCurenta++;
                }
                e.HasMorePages = indexValoareCurenta < grafic.Valori.Length;
            }
            base.OnPrintPage(e);
        }
    }
}
