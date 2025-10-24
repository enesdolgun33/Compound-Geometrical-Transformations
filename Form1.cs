namespace BG_KS_1
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.ResizeRedraw = true;
            this.BackColor = Color.White;
            this.Text = "BG Kýsa Sýnav 1 - Geometrik Dönüþümler";
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            
            PointF A = new PointF(-3, 3);
            PointF B = new PointF(-5, 3);
            PointF C = new PointF(-3, 1);
            PointF P1 = new PointF(7, 1);
            PointF P2 = new PointF(1, 8);

            PointF[] originalTriangle = { A, B, C };

            
            float angle1 = -44.0f;
            Matrix transform1 = CreateRotationMatrix(P1.X, P1.Y, angle1);

            float angle2 = 20.0f;
            Matrix transform2 = CreateRotationMatrix(P2.X, P2.Y, angle2);

            Matrix finalMatrix = transform1.Clone();
            finalMatrix.Multiply(transform2, MatrixOrder.Append);

            PointF[] transformedTriangle = (PointF[])originalTriangle.Clone();
            finalMatrix.TransformPoints(transformedTriangle);

            float scale = 20.0f;
            g.TranslateTransform(this.ClientSize.Width / 2.0f, this.ClientSize.Height / 2.0f);
            g.ScaleTransform(scale, -scale);

            DrawAxes(g, this.ClientSize, scale);

            using (Pen originalPen = new Pen(Color.Blue, 0.15f))
            using (Pen transformedPen = new Pen(Color.Red, 0.15f))
            {
                g.DrawPolygon(originalPen, originalTriangle);
                g.DrawPolygon(transformedPen, transformedTriangle);
            }

            DrawPoint(g, A, "A", Brushes.Blue, Brushes.Black); 
            DrawPoint(g, B, "B", Brushes.Blue, Brushes.Black); 
            DrawPoint(g, C, "C", Brushes.Blue, Brushes.Black); 

            DrawPoint(g, transformedTriangle[0], "A'", Brushes.Red, Brushes.Black);
            DrawPoint(g, transformedTriangle[1], "B'", Brushes.Red, Brushes.Black);
            DrawPoint(g, transformedTriangle[2], "C'", Brushes.Red, Brushes.Black);

            DrawPoint(g, P1, "P1", Brushes.Green, Brushes.Black);
            DrawPoint(g, P2, "P2", Brushes.DarkOrange, Brushes.Black);
        }


        private Matrix CreateRotationMatrix(float centerX, float centerY, float angleDegrees)
        {
            Matrix matrix = new Matrix();
            matrix.Translate(-centerX, -centerY, MatrixOrder.Append);
            matrix.Rotate(angleDegrees, MatrixOrder.Append);
            matrix.Translate(centerX, centerY, MatrixOrder.Append);
            return matrix;
        }

        private void DrawAxes(Graphics g, Size clientSize, float scale)
        {
            float logicalWidth = (clientSize.Width / 2.0f) / scale;
            float logicalHeight = (clientSize.Height / 2.0f) / scale;

            Pen axisPen = new Pen(Color.Black, 0.2f);
            axisPen.EndCap = LineCap.ArrowAnchor;

            g.DrawLine(axisPen, -logicalWidth, 0, logicalWidth, 0);
            g.DrawLine(axisPen, 0, -logicalHeight, 0, logicalHeight);

            float originSize = 0.2f;
            g.FillEllipse(Brushes.Black, -originSize / 2, -originSize / 2, originSize, originSize);

            g.ScaleTransform(1, -1);
            using (Font font = new Font("Arial", 0.7f, FontStyle.Bold))
            {
                g.DrawString("X", font, Brushes.Black, logicalWidth - 1.0f, 0.2f);
                g.DrawString("Y", font, Brushes.Black, 0.2f, -logicalHeight + 1.0f);
                g.DrawString("0", font, Brushes.Black, -1f, 0.2f);
            }
            g.ScaleTransform(1, -1);
        }

        private void DrawPoint(Graphics g, PointF p, string label, Brush pointBrush, Brush labelBrush)
        {
            float pointSize = 0.4f;
            g.FillEllipse(pointBrush, p.X - pointSize / 2, p.Y - pointSize / 2, pointSize, pointSize);

            g.ScaleTransform(1, -1);
            using (Font font = new Font("Arial", 0.6f))
            {
                g.DrawString(label, font, labelBrush, p.X + 0.3f, -p.Y - 0.3f);
            }
            g.ScaleTransform(1, -1);
        }
    }
}
