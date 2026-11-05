using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BezierSurface
{
    public class TriangleMesh
    {
        public List<Triangle> Triangles { get; set; } = new List<Triangle>();
        public void AddTriangle(Triangle triangle)
        {
            Triangles.Add(triangle);
        }
    }
}
