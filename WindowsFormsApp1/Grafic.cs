using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
   public class Grafic : Control
    {
        public float[] valori=new float[0];
        float tensiune = 0.3f;

        public Color color;
        Pen pen;
        Brush brush;

        public Grafic()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);

            color = Color.Blue;
            pen = new Pen(color, 2);
            brush = new SolidBrush(Color.LightSteelBlue);
          //  brush = new SolidBrush(Color.FromArgb(30, color.R, color.G, color.B));

            MouseMove += (s, e) => Invalidate();
        }

        public float[] Valori
        {
            get => valori;
            set
            {
                valori = value ?? new float[0];
                Invalidate();
            }
        }

        public float Tensiune
        {
            get => tensiune;
            set
            {
                tensiune = value;
                Invalidate();
            }
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            var dreptunghiGrafic = ClientRectangle;
            dreptunghiGrafic.Inflate(-10, -10);

            e.Graphics.FillRectangle(Brushes.White, dreptunghiGrafic);
            e.Graphics.DrawRectangle(Pens.Black, dreptunghiGrafic);

            if (valori.Length > 1)
            {
                DesenareGrafic(e.Graphics, dreptunghiGrafic, valori, brush, tensiune);
            }
        }

       public void DesenareGrafic(Graphics graphics, Rectangle dreptunghiGrafic, float[] valori, Brush brush, float tensiune = 0.3f)
        {
            const float pointRadius = 5;

            // 1. Calculare coordonate puncte pe baza valorilor și a dimensiunilor dreptunghiului
            float W = dreptunghiGrafic.Width;
            float H = dreptunghiGrafic.Height;

            var n = valori.Length;

            float w = W / (n - 1);
            float f = 0.8f * H / valori.Max();
            var puncte = new List<PointF>();
            for (int index = 0; index < n; index++)
            {
                puncte.Add(new PointF(
                    dreptunghiGrafic.X + index * w,
                    dreptunghiGrafic.Y + H - valori[index] * f));
            }

            // 2. Construirea căii și desenarea suprefeței de sub grafic
            var fillPath = new GraphicsPath();
            fillPath.AddLine(
                dreptunghiGrafic.X, dreptunghiGrafic.Y + H,
                dreptunghiGrafic.X, dreptunghiGrafic.Y + puncte.First().X);

            fillPath.AddCurve(puncte.ToArray(), tensiune);

            fillPath.AddLine(
                dreptunghiGrafic.X + W, dreptunghiGrafic.Y + puncte.Last().X,
                dreptunghiGrafic.X + W, dreptunghiGrafic.Y + H);

            graphics.FillPath(brush, fillPath);

            // 2. Desenarea liniei
            graphics.DrawCurve(pen, puncte.ToArray(), tensiune);

            // 3. Desenarea punctelor
            for (int index = 0; index < n; index++)
            {
                graphics.DrawEllipse(pen,
                    puncte[index].X - pointRadius,
                    puncte[index].Y - pointRadius,
                    pointRadius * 2,
                    pointRadius * 2
                );

                // Obținem coordonatele mouse-ului în coordonate client (față de controlul nostru, nu față de colțul ecranului)
                var mousePoint = PointToClient(Cursor.Position);

                // și calculăm distanța euclidiană
                var distanta = Math.Sqrt(
                    (puncte[index].X - mousePoint.X) * (puncte[index].X - mousePoint.X)
                    + (puncte[index].Y - mousePoint.Y) * (puncte[index].Y - mousePoint.Y));

                // Afișăm și valoarea ca text dacă mouse-ul este aproape de punctul curent 
                if (distanta < pointRadius * 3)
                {
                    graphics.FillEllipse(pen.Brush,
                        puncte[index].X - pointRadius,
                        puncte[index].Y - pointRadius,
                        pointRadius * 2,
                        pointRadius * 2
                    );
                    StringFormat stringFormat = new StringFormat();
                    stringFormat.Alignment = StringAlignment.Center;
                    stringFormat.LineAlignment = StringAlignment.Far;

                    graphics.DrawString(valori[index].ToString(), Font, Brushes.Black, puncte[index].X, puncte[index].Y - pointRadius, stringFormat);
                }
            }
        }
    }
}
