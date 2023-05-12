using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace GeometrieComputationala1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //problema1(e);
            //problema2(e);
            //problema3(e);
        }

        private void problema1(PaintEventArgs e)
        {
            //Se dă o mulțime de puncte în plan.
            //Să se determine dreptunghiul de arie minimă care să conțină toate punctele date în interior.
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Black, 1);
            Random rnd = new Random();
            int n = rnd.Next(30, 50);
            int x_min = this.ClientSize.Width;
            int y_min = this.ClientSize.Height;
            int x_max = 0, y_max = 0;
            int x, y;

            for (int i = 0; i < n; i++)
            {
                x = rnd.Next(10, this.ClientSize.Width - 15);
                y = rnd.Next(10, this.ClientSize.Height - 15);
                g.DrawEllipse(p, x, y, 5, 5);
                if (x_min > x) { x_min = x; }
                else if (x_max < x) { x_max = x; }
                if (y_min > y) { y_min = y; }
                else if (y_max < y) { y_max = y; };
            }
            g.DrawRectangle(p, x_min, y_min, x_max - x_min + 2, y_max - y_min + 2);

        }

        private void problema2(PaintEventArgs e)
        {
            //Se dau două mulțimi de puncte în plan.
            //Pentru fiecare punct din prima mulțime să se găsească cel mai apropiat punct din cea de a doua mulțime.
            Graphics g = e.Graphics;
            Random rnd = new Random();
            Pen p1 = new Pen(Color.Black, 3);
            Pen p2 = new Pen(Color.DarkRed, 3);
            int n1 = rnd.Next(30, 40);
            int n2 = rnd.Next(50, 100);
            PointF[] points1 = new PointF[n1];
            PointF[] points2 = new PointF[n2];
            for (int i = 0; i < n1; i++)
            {
                points1[i].X = rnd.Next(15, this.ClientSize.Width - 15);
                points1[i].Y = rnd.Next(15, this.ClientSize.Height - 15);
                g.DrawEllipse(p1, points1[i].X, points1[i].Y, 10, 10);
            }
            for (int i = 0; i < n2; i++)
            {
                points2[i].X = rnd.Next(15, this.ClientSize.Width - 15);
                points2[i].Y = rnd.Next(15, this.ClientSize.Height - 15);
                g.DrawEllipse(p2, points2[i].X, points2[i].Y, 10, 10);
            }
            float d = int.MinValue;
            float x = 0; float y = 0;
            for (int i = 0; i < n1; i++)
            {
                float d_min = int.MaxValue;
                for (int j = 0; j < n2; j++)
                {
                    d = (float)Math.Sqrt(Math.Pow(points1[i].X - points2[j].X, 2) + Math.Pow(points1[i].Y - points2[j].Y, 2));
                    if (d < d_min)
                    {
                        d_min = d;
                        x = points2[j].X;
                        y = points2[j].Y;
                    }

                }
                g.DrawLine(p2, points1[i].X + 3, points1[i].Y + 3, x + 3, y + 3);
            }
        }

        private void problema3(PaintEventArgs e)
        {
            //Se dau n puncte în plan.Pentru un punct dat q să se determine cercul cu 
            //centrul în q și de rază maximă care să nu conțină niciun punct din mulțimea dată.
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Black, 3);
            Pen p1 = new Pen(Color.Blue, 3);
            Random rnd = new Random();
            int n = rnd.Next(30, 100);
            int x = rnd.Next(100, 500);
            int y = rnd.Next(100, 500);
            Point q = new Point(x, y);
            g.DrawEllipse(p1, x, y, 3, 3);
            PointF[] points = new PointF[n];
            float d_min = int.MaxValue;
            float d = 0;
            for (int i = 0; i < n; i++)
            {
                points[i].X = rnd.Next(15, this.ClientSize.Width - 15);
                points[i].Y = rnd.Next(15, this.ClientSize.Height - 15);
                g.DrawEllipse(p, points[i].X, points[i].Y, 5, 5);
                d = (float)Math.Sqrt(Math.Pow(points[i].X - x, 2) + Math.Pow(points[i].Y - y, 2));
                if (d < d_min)
                {
                    d_min = d;
                }
            }
            d_min -= 1;
            g.DrawEllipse(p, x - d_min, y - d_min, 2 * d_min, 2 * d_min);
        }
    }
}
