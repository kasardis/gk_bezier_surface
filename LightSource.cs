using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BezierSurface
{
    public class LightSource
    {
        public Vector3 Position { get; set; }
        public List<Vector3> ControlPoints { get; set; }
        public Color Color { get; set; } = Color.White;
        public float T { get; set; } = 0f;
        public float Speed { get; set; } = 0.002f;
        private int Radius = 15;
        private int cpRadius = 8;
        public bool DrawControlPoints = false;
        public bool DrawTrajectory = false;

        public LightSource(List<Vector3> controlPoints)
        {
            ControlPoints = controlPoints;
            Position = EvaluatePosition(T);
        }

        public void Update()
        {
            T += Speed;
            if (T > 1f) T = 0f;
            Position = EvaluatePosition(T);
        }

        public Vector3 EvaluatePosition(float t)
        {
            if (ControlPoints.Count < 2) return Vector3.Zero;
            int n = ControlPoints.Count - 1; 
            Vector3 p = Vector3.Zero;

            for (int i = 0; i <= n; i++)
            {
                float b = Bernstein(n, i, t);
                p += ControlPoints[i] * b;
            }

            return p;
        }

        public void Draw(Graphics g)
        {
            if (DrawControlPoints)
            {
                using Pen dashedPen = new Pen(Color.LightGray, 1);
                dashedPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                dashedPen.DashPattern = new float[] { 10, 6 };
                for (int i = 0; i < ControlPoints.Count-1; i++)
                {
                    g.DrawLine(dashedPen, ControlPoints[i].X, ControlPoints[i].Y, ControlPoints[i+1].X, ControlPoints[i+1].Y);
                }
                for(int i = 0; i < ControlPoints.Count-1; i++)
                {
                    g.FillEllipse(Brushes.Navy, ControlPoints[i].X - cpRadius / 2, ControlPoints[i].Y - cpRadius / 2, cpRadius, cpRadius);
                }
            }

            if (DrawTrajectory)
            {
                int steps = 100;
                List<PointF> curvePoints = new List<PointF>();
                for (int i = 0; i <= steps; i++)
                {
                    float t = (float)i / steps;
                    Vector3 pos = EvaluatePosition(t);
                    curvePoints.Add(new PointF(pos.X, pos.Y));
                }
                if (curvePoints.Count > 1)
                {
                    g.DrawLines(Pens.Navy, curvePoints.ToArray());
                }
            }

            using SolidBrush sunBrush = new SolidBrush(Color);
            g.FillEllipse(sunBrush, Position.X - Radius / 2, Position.Y - Radius / 2, Radius, Radius);
            g.DrawEllipse(Pens.Gray, Position.X - Radius / 2, Position.Y - Radius / 2, Radius, Radius);
        }

        public int HitTest(PointF pos)
        {
            if (!DrawControlPoints) return -1;
            for(int i = 0; i < ControlPoints.Count-1; i++)
            {
                if((pos.X - ControlPoints[i].X) * (pos.X - ControlPoints[i].X) + (pos.Y - ControlPoints[i].Y) * (pos.Y - ControlPoints[i].Y) <= cpRadius * cpRadius)
                {
                    return i;
                }
            }
            return -1;
        }

        private float Bernstein(int n, int i, float t)
        {
            return BinomialCoefficient(n, i) * (float)Math.Pow(t, i) * (float)Math.Pow(1 - t, n - i);
        }

        private long BinomialCoefficient(int n, int k)
        {
            if (k < 0 || k > n) return 0;
            if (k == 0 || k == n) return 1;
            long c = 1;
            for (int i = 1; i <= k; i++)
            {
                c = c * (n - (k - i)) / i;
            }
            return c;
        }
    }
}
