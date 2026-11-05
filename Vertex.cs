using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BezierSurface
{
    public class Vertex
    {
        public Vector3 P { get; set; }
        public Vector3 Pu { get; set; }
        public Vector3 Pv { get; set; }
        public Vector3 Normal { get; set; }

        public Vector3 PRotated { get; set; }
        public Vector3 PuRotated { get; set; }
        public Vector3 PvRotated { get; set; }
        public Vector3 NormalRotated { get; set; }

        public float U { get; set; }
        public float V { get; set; }

        public void CalculateRotation(Matrix4x4 rotationMatrix)
        {
            PRotated = Vector3.Transform(P, rotationMatrix);
            PuRotated = Vector3.Normalize(Vector3.TransformNormal(Pu, rotationMatrix));
            PvRotated = Vector3.Normalize(Vector3.TransformNormal(Pv, rotationMatrix));
            NormalRotated = Vector3.Normalize(Vector3.TransformNormal(Normal, rotationMatrix)); 
        }
    }
}
