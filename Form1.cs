using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace Mandelbrot
{
    public partial class Form1 : Form
    {
        double size = 400;
        double xmove = -100;
        double ymove = 0;
        public Form1()
        {
            InitializeComponent();
        }
        Graphics graphics;
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            graphics = CreateGraphics();
        }
        private Complex Function (Complex z, Complex c)
        {
            return z * z + c;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 1; i < ClientSize.Width; i++)
            {
                for (int j = 1; j < ClientSize.Height; j++)
                {
                    DrawPoint(new Point(i, j));
                }
            }
        }

        private void DrawPoint(Point e)
        {
            Complex point = new Complex((e.X - ClientSize.Width / 2 + xmove) / size, (e.Y - ClientSize.Height / 2 + ymove) / size);
            Complex firstpoint = point;
            for (int i = 0;i < 20;i++)
            {
                point = Function(point, firstpoint);
            }
            if (point.Magnitude < 10) graphics.DrawLine(Pens.Black, e.X, e.Y, e.X + 0.1f, e.Y);
        }
    }
}
