using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BezierSurface
{
    public class Triangle
    {
        public Vertex V1 { get; set; }
        public Vertex V2 { get; set; }
        public Vertex V3 { get; set; }
        
        public Triangle(Vertex v1, Vertex v2, Vertex v3)
        {
            V1 = v1;
            V2 = v2;
            V3 = v3;
        }

        public void CalculateRotation(Matrix4x4 rotationMatrix)
        {
            V1.CalculateRotation(rotationMatrix);
            V2.CalculateRotation(rotationMatrix);
            V3.CalculateRotation(rotationMatrix);
        }
    }
}
