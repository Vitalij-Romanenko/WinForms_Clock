using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp21
{
    public partial class Form1 : Form
    {
        Point centr;

        Graphics graphic;

        Pen pen;
        Matrix matrix1, matrix2, matrix3;

        int i;

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }


        public Form1()
        {
            InitializeComponent();
            i = 0;
            matrix1 = new Matrix();
            matrix2 = new Matrix();
            matrix3 = new Matrix();
            centr = new Point(160, 160);
            timer1.Start();
            Paint += Form1_Paint;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            graphic = e.Graphics;
            graphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            graphic.DrawEllipse(new Pen(Color.DarkBlue, 9), 10, 10, 300, 300);
            pen = new Pen(Color.DarkBlue, 9);
            pen.StartCap = System.Drawing.Drawing2D.LineCap.SquareAnchor;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;


            Matrix matrix = new Matrix();
            graphic.DrawLine(new Pen(Color.Brown, 2), 160, 10, 160, 25);
            for (int i = 0; i < 11; i++)
            {
                matrix.RotateAt(30, new PointF(160, 160));
                graphic.Transform = matrix;
                graphic.DrawLine(new Pen(Color.Brown, 2), 160, 10, 160, 25);
            }

            if (i == 0)
            {
                graphic.Transform = matrix1;
                matrix1.RotateAt(6 * DateTime.Now.Second, new PointF(160, 160));
                pen.Width = 5;
                graphic.DrawLine(pen, centr, new Point(160, 10));
                graphic.Transform = matrix2;
                matrix2.RotateAt(6 * DateTime.Now.Minute, new PointF(160, 160));
                pen.Width = 7;
                graphic.DrawLine(pen, centr, new Point(160, 25));
                graphic.Transform = matrix3;
                matrix3.RotateAt(30 * DateTime.Now.Hour, new PointF(160, 160));
                pen.Width = 9;
                graphic.DrawLine(pen, centr, new Point(160, 50));
            }
            else
            {
                graphic.Transform = matrix1;
                matrix1.RotateAt(6, new PointF(160, 160));

                Color[] c = { Color.Red, Color.Orange, Color.Green, Color.Gray, Color.DarkBlue, Color.Black, Color.Blue, Color.Brown, Color.Violet, Color.Tomato };
                pen.Color = c[i % 10];
                pen.Width = (i % 10) + 1;
                graphic.DrawLine(pen, centr, new Point(160, 10));
                graphic.Transform = matrix2;
                matrix2.RotateAt(0.1f, new PointF(160, 160));

                graphic.DrawLine(pen, centr, new Point(160, 25));
                graphic.Transform = matrix3;
                matrix2.RotateAt(0.008333333333f, new PointF(160, 160));

                graphic.DrawLine(pen, centr, new Point(160, 50));
                    
            }

            i++;
        }
    }
}
