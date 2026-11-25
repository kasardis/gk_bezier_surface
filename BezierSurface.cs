using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BezierSurface
{
    public class BezierSurface
    {
        public List<Vector3> ControlPoints { get; set; }
        public List<Vector3> RotatedControlPoints { get; set; }
        public TriangleMesh TriangleMesh { get; set; } = new TriangleMesh();
        private static Quaternion currentRotation = Quaternion.Identity;
        public static Matrix4x4 RotationMatrix => Matrix4x4.CreateFromQuaternion(currentRotation);

        public static int TriangulationSteps = 10;
        public static bool DrawBezierPolygons = true;
        public static bool DrawTriangleMesh = true;
        public static bool DrawFilledTriangles = true;
        public static bool DrawNormalMap = false;
        public static bool DrawHeightMap = false;
        public const int NumberOfPoints = 16;
        public static int HeightMapK = 2;

        public Color FillColor { get; set; } = Color.MediumPurple;
        public Bitmap? FillImage { get; set; } = null;
        public int FillImageWidth;
        public int FillImageHeight;
        public Color[,]? FillImageCache { get; set; }
        public Bitmap? NormalMapImage { get; set; } = null;
        public Color[,]? NormalMapImageCache { get; set; }
        public int NormalMapWidth;
        public int NormalMapHeight;
        public ColorMode SurfaceColorMode { get; set; } = ColorMode.Solid;
        public enum ColorMode
        {
            Solid,
            Image
        }

        public float KDiffuse { get; set; } = 0.7f;
        public float KSpecular { get; set; } = 0.3f;
        public int Mirror { get; set; } = 32;

        public BezierSurface(List<Vector3> controlPoints)
        {
            if (controlPoints.Count != NumberOfPoints)
            {
                throw new Exception("Invalid number of points in BezierSurface constructor");
            }
            ControlPoints = controlPoints;
            RotatedControlPoints = controlPoints;
        }

        public void Draw(Graphics g)
        {
            if (DrawBezierPolygons)
            {
                int rows = (int)Math.Sqrt(NumberOfPoints);
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < rows - 1; j++)
                    {
                        Vector3 cp1 = RotatedControlPoints[rows * i + j];
                        Vector3 cp2 = RotatedControlPoints[rows * i + j + 1];
                        g.DrawLine(Pens.DarkGray, cp1.X, cp1.Y, cp2.X, cp2.Y);

                        cp1 = RotatedControlPoints[rows * j + i];
                        cp2 = RotatedControlPoints[rows * (j + 1) + i];
                        g.DrawLine(Pens.DarkGray, cp1.X, cp1.Y, cp2.X, cp2.Y);
                    }
                }
            }
            if (DrawTriangleMesh)
            {
                foreach (var triangle in TriangleMesh.Triangles)
                {
                    g.DrawLine(Pens.Magenta, triangle.V1.PRotated.X, triangle.V1.PRotated.Y, triangle.V2.PRotated.X, triangle.V2.PRotated.Y);
                    g.DrawLine(Pens.Magenta, triangle.V2.PRotated.X, triangle.V2.PRotated.Y, triangle.V3.PRotated.X, triangle.V3.PRotated.Y);
                    g.DrawLine(Pens.Magenta, triangle.V3.PRotated.X, triangle.V3.PRotated.Y, triangle.V1.PRotated.X, triangle.V1.PRotated.Y);
                }
            }
        }

        public static void RotateScene(float alpha, float beta, float gamma)
        {
            Quaternion rotX = Quaternion.CreateFromAxisAngle(Vector3.UnitX, alpha);
            Quaternion rotY = Quaternion.CreateFromAxisAngle(Vector3.UnitY, beta);
            Quaternion rotZ = Quaternion.CreateFromAxisAngle(Vector3.UnitZ, gamma);
            Quaternion deltaRotation = rotY * rotX * rotZ;
            currentRotation = deltaRotation * currentRotation;
            currentRotation = Quaternion.Normalize(currentRotation);
        }

        public void CalculateRotatedPoints()
        {
            RotatedControlPoints = new List<Vector3>();
            foreach (var controlPoint in ControlPoints)
            {
                RotatedControlPoints.Add(Vector3.Transform(controlPoint, RotationMatrix));
            }
            foreach (var triangle in TriangleMesh.Triangles)
            {
                triangle.CalculateRotation(RotationMatrix);
            }
        }

        private Vertex EvaluateVertex(float u, float v)
        {
            Vector3 p = Vector3.Zero;
            Vector3 pu = Vector3.Zero;
            Vector3 pv = Vector3.Zero;

            float[] bU = { B0(u), B1(u), B2(u), B3(u) };
            float[] bV = { B0(v), B1(v), B2(v), B3(v) };

            float[] dbU = { dB0(u), dB1(u), dB2(u), dB3(u) };
            float[] dbV = { dB0(v), dB1(v), dB2(v), dB3(v) };

            int rows = (int)Math.Sqrt(NumberOfPoints);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    Vector3 cp = ControlPoints[i * rows + j];
                    p += cp * bU[i] * bV[j];
                    pu += cp * dbU[i] * bV[j];
                    pv += cp * bU[i] * dbV[j];
                }
            }

            Vector3 n = Vector3.Cross(pu, pv);
            if (n.LengthSquared() > 0)
            {
                n = Vector3.Normalize(n);
            }
            else
            {
                n = new Vector3(0, 0, 1);
            }

            return new Vertex
            {
                P = p,
                Pu = pu.LengthSquared() > 0 ? Vector3.Normalize(pu) : new Vector3(1, 0, 0),
                Pv = pv.LengthSquared() > 0 ? Vector3.Normalize(pv) : new Vector3(0, 1, 0),
                Normal = n,
                U = u,
                V = v
            };
        }

        // wielomiany bernsteina
        private float B0(float t) => (1 - t) * (1 - t) * (1 - t);
        private float B1(float t) => 3f * t * (1 - t) * (1 - t);
        private float B2(float t) => 3f * t * t * (1 - t);
        private float B3(float t) => t * t * t;

        // pochodne bernsteina
        private float dB0(float t) => -3f * (1 - t) * (1 - t);
        private float dB1(float t) => 3f * (1 - t) * (1 - t) - 6f * t * (1 - t);
        private float dB2(float t) => 6f * t * (1 - t) - 3f * t * t;
        private float dB3(float t) => 3f * t * t;

        public void CalculateTriangleMesh()
        {
            TriangleMesh.Triangles.Clear();
            Vertex[,] grid = new Vertex[TriangulationSteps + 1, TriangulationSteps + 1];
            for (int i = 0; i < TriangulationSteps + 1; i++)
            {
                float u = (float)i / TriangulationSteps;
                for (int j = 0; j < TriangulationSteps + 1; j++)
                {
                    float v = (float)j / TriangulationSteps;
                    grid[i, j] = EvaluateVertex(u, v);
                }
            }

            for (int i = 0; i < TriangulationSteps; i++)
            {
                for (int j = 0; j < TriangulationSteps; j++)
                {
                    Vertex v00 = grid[i, j];
                    Vertex v10 = grid[i + 1, j];
                    Vertex v01 = grid[i, j + 1];
                    Vertex v11 = grid[i + 1, j + 1];

                    TriangleMesh.Triangles.Add(new Triangle(v00, v10, v01));
                    TriangleMesh.Triangles.Add(new Triangle(v10, v11, v01));
                }
            }
        }

        // parallel
        public void FillTriangles(Bitmap frameBuffer, float[,] zBuffer, LightSource lightSource)
        {
            if (!DrawFilledTriangles) return;

            int width = frameBuffer.Width;
            int height = frameBuffer.Height;
            Vector3 V = new Vector3(0, 0, 1);
            List<Vector3> movedLights = [];
            foreach(var pos in lightSource.Positions)
            {
                Vector3 moved = new Vector3(pos.X + width / 2, -pos.Y + height / 2, pos.Z);
                movedLights.Add(moved);
            }

            Rectangle rect = new Rectangle(0, 0, width, height);
            BitmapData bmpData = frameBuffer.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            unsafe
            {
                byte* scan0 = (byte*)bmpData.Scan0;
                int stride = bmpData.Stride;

                Parallel.ForEach(TriangleMesh.Triangles, triangle =>
                //foreach (var triangle in TriangleMesh.Triangles)
                {
                    Vertex v1 = TransformCoordinates(triangle.V1, width, height);
                    Vertex v2 = TransformCoordinates(triangle.V2, width, height);
                    Vertex v3 = TransformCoordinates(triangle.V3, width, height);

                    Vertex[] verts = new[] { v1, v2, v3 };
                    Array.Sort(verts, (a, b) => a.PRotated.Y.CompareTo(b.PRotated.Y));

                    Vertex top = verts[0];
                    Vertex mid = verts[1];
                    Vertex bot = verts[2];

                    int yStart = (int)top.PRotated.Y;
                    int yMid = (int)mid.PRotated.Y;
                    int yEnd = (int)bot.PRotated.Y;

                    int yMin = Math.Clamp(yStart, 0, height - 1);
                    int yMax = Math.Clamp(yEnd, 0, height - 1);

                    int helperX = (int)(top.PRotated.X + ((yMid - yStart) / (float)(yEnd - yStart)) * (bot.PRotated.X - top.PRotated.X));

                    float denom = (v2.PRotated.Y - v3.PRotated.Y) * (v1.PRotated.X - v3.PRotated.X) + (v3.PRotated.X - v2.PRotated.X) * (v1.PRotated.Y - v3.PRotated.Y);

                    for (int y = yMin; y <= yMax; y++)
                    {
                        int rawMinX, rawMaxX;
                        if (y <= yMid)
                        {
                            if (mid.PRotated.X < helperX)
                            {
                                rawMinX = (int)(top.PRotated.X + (y - yStart) * (mid.PRotated.X - top.PRotated.X) / (yMid - yStart));
                                rawMaxX = (int)(top.PRotated.X + (y - yStart) * (helperX - top.PRotated.X) / (yMid - yStart));
                            }
                            else
                            {
                                rawMaxX = (int)(top.PRotated.X + (y - yStart) * (mid.PRotated.X - top.PRotated.X) / (yMid - yStart));
                                rawMinX = (int)(top.PRotated.X + (y - yStart) * (helperX - top.PRotated.X) / (yMid - yStart));
                            }
                        }
                        else
                        {
                            if (mid.PRotated.X < helperX)
                            {
                                rawMinX = (int)(bot.PRotated.X + (y - yEnd) * (bot.PRotated.X - mid.PRotated.X) / (yEnd - yMid));
                                rawMaxX = (int)(bot.PRotated.X + (y - yEnd) * (bot.PRotated.X - helperX) / (yEnd - yMid));
                            }
                            else
                            {
                                rawMaxX = (int)(bot.PRotated.X + (y - yEnd) * (bot.PRotated.X - mid.PRotated.X) / (yEnd - yMid));
                                rawMinX = (int)(bot.PRotated.X + (y - yEnd) * (bot.PRotated.X - helperX) / (yEnd - yMid));
                            }
                        }

                        int minX = Math.Max(0, Math.Min(width - 1, Math.Min(rawMinX, rawMaxX)));
                        int maxX = Math.Max(0, Math.Min(width - 1, Math.Max(rawMinX, rawMaxX)));

                        byte* row = scan0 + (y * stride);

                        for (int x = minX; x <= maxX; x++)
                        {
                            float l1 = ((v2.PRotated.Y - v3.PRotated.Y) * (x - v3.PRotated.X) + (v3.PRotated.X - v2.PRotated.X) * (y - v3.PRotated.Y)) / denom;
                            float l2 = ((v3.PRotated.Y - v1.PRotated.Y) * (x - v3.PRotated.X) + (v1.PRotated.X - v3.PRotated.X) * (y - v3.PRotated.Y)) / denom;
                            float l3 = 1.0f - l1 - l2;

                            float interpolatedZ = l1 * v1.PRotated.Z + l2 * v2.PRotated.Z + l3 * v3.PRotated.Z;

                            bool updatedZBuffer = false;
                            lock (zBuffer)
                            {
                                if (interpolatedZ >= zBuffer[x, y])
                                {
                                    zBuffer[x, y] = interpolatedZ;
                                    updatedZBuffer = true;
                                }
                            }

                            if (updatedZBuffer)
                            {

                                float u = l1 * v1.U + l2 * v2.U + l3 * v3.U;
                                float v = l1 * v1.V + l2 * v2.V + l3 * v3.V;

                                Vector3 N_surface = Vector3.Normalize(v1.NormalRotated * l1 + v2.NormalRotated * l2 + v3.NormalRotated * l3);
                                Vector3 Pu_interp = Vector3.Normalize(v1.PuRotated * l1 + v2.PuRotated * l2 + v3.PuRotated * l3);
                                Vector3 Pv_interp = Vector3.Normalize(v1.PvRotated * l1 + v2.PvRotated * l2 + v3.PvRotated * l3);

                                Vector3 N = N_surface;
                                if (DrawNormalMap && NormalMapImage != null && NormalMapImageCache != null)
                                {
                                    int mapX = Math.Clamp((int)(u * (NormalMapWidth - 1)), 0, NormalMapWidth - 1);
                                    int mapY = Math.Clamp((int)(v * (NormalMapHeight - 1)), 0, NormalMapHeight - 1);
                                    Color nc = NormalMapImageCache[mapX, mapY];

                                    float nx = (nc.R / 255f) * 2f - 1f;
                                    float ny = (nc.G / 255f) * 2f - 1f;
                                    float nz = (nc.B / 255f) * 2f - 1f;

                                    N = Vector3.Normalize(nx * Pu_interp + ny * Pv_interp + nz * N_surface);
                                } else if(DrawHeightMap && NormalMapImage != null && NormalMapImageCache != null)
                                {
                                    int mapX = Math.Clamp((int)(u * (NormalMapWidth - 1)), 0, NormalMapWidth - 1);
                                    int mapY = Math.Clamp((int)(v * (NormalMapHeight - 1)), 0, NormalMapHeight - 1);
                                    int uleft = Math.Clamp((int)(u * (NormalMapWidth - 1))-1, 0, NormalMapWidth - 1);
                                    int uright = Math.Clamp((int)(u * (NormalMapWidth - 1))+1, 0, NormalMapWidth - 1);
                                    int vleft = Math.Clamp((int)(v * (NormalMapHeight - 1)) - 1, 0, NormalMapHeight - 1);
                                    int vright = Math.Clamp((int)(v * (NormalMapHeight - 1)) + 1, 0, NormalMapHeight - 1);
                                    float Hu = (NormalMapImageCache[uright, mapY].R - NormalMapImageCache[uleft, mapY].R) / 2;
                                    float Hv = (NormalMapImageCache[mapX, vright].R - NormalMapImageCache[mapX, vleft].R) / 2;
                                    Vector3 D = HeightMapK * (Hu * Vector3.Cross(N, Pv_interp) - Hv * Vector3.Cross(N, Pu_interp));
                                    N = Vector3.Normalize(N + D);
                                }

                                Vector3 IO;
                                if (SurfaceColorMode == ColorMode.Image && FillImage != null && FillImageCache != null)
                                {
                                    int texX = Math.Clamp((int)(u * (FillImageWidth - 1)), 0, FillImageWidth - 1);
                                    int texY = Math.Clamp((int)(v * (FillImageHeight - 1)), 0, FillImageHeight - 1);
                                    Color c = FillImageCache[texX, texY];
                                    IO = new Vector3(c.R / 255f, c.G / 255f, c.B / 255f);
                                }
                                else
                                {
                                    IO = new Vector3(FillColor.R / 255f, FillColor.G / 255f, FillColor.B / 255f);
                                }
                                Vector3 IL = new Vector3(lightSource.Color.R / 255f, lightSource.Color.G / 255f, lightSource.Color.B / 255f);

                                if (Vector3.Dot(N, V) < 0)
                                {
                                    N = -N;
                                }

                                Vector3 pixelPos = new Vector3(x, y, interpolatedZ);
                                Vector3 I = Vector3.Zero;
                                if (lightSource.CurrentLightType == LightSource.LightType.Directional)
                                {
                                    Vector3 L = new Vector3(0, 0, 1);
                                    Vector3 R = Vector3.Normalize(2f * Vector3.Dot(N, L) * N - L);
                                    float cosVR = Math.Max(0f, V.X * R.X + V.Y * R.Y + V.Z * R.Z);
                                    float cosNL = Math.Max(0f, N.X * L.X + N.Y * L.Y + N.Z * L.Z);
                                    I = KDiffuse * IL * IO * cosNL + KSpecular * IL * IO * (float)Math.Pow(cosVR, Mirror);
                                } else if(lightSource.CurrentLightType == LightSource.LightType.Reflector)
                                {
                                    foreach (var movedLightPosition in movedLights)
                                    {
                                        Vector3 L = Vector3.Normalize(movedLightPosition - pixelPos);
                                        Vector3 R = Vector3.Normalize(2f * Vector3.Dot(N, L) * N - L);
                                        float cosVR = Math.Max(0f, V.X * R.X + V.Y * R.Y + V.Z * R.Z);
                                        float cosNL = Math.Max(0f, N.X * L.X + N.Y * L.Y + N.Z * L.Z);
                                        float cosRef = Vector3.Dot(Vector3.Normalize(movedLightPosition), L);
                                        if(cosRef < 0)
                                        {
                                            cosRef = -cosRef;
                                        }
                                        I += (float)Math.Pow(cosRef, lightSource.ReflectorM) * (KDiffuse * IL * IO * cosNL + KSpecular * IL * IO * (float)Math.Pow(cosVR, Mirror));
                                    }
                                } else if(lightSource.CurrentLightType == LightSource.LightType.Point)
                                {
                                    foreach (var movedLightPosition in movedLights)
                                    {
                                        Vector3 L = Vector3.Normalize(movedLightPosition - pixelPos);
                                        Vector3 R = Vector3.Normalize(2f * Vector3.Dot(N, L) * N - L);
                                        float cosVR = Math.Max(0f, V.X * R.X + V.Y * R.Y + V.Z * R.Z);
                                        float cosNL = Math.Max(0f, N.X * L.X + N.Y * L.Y + N.Z * L.Z);
                                        I += KDiffuse * IL * IO * cosNL + KSpecular * IL * IO * (float)Math.Pow(cosVR, Mirror);
                                    }
                                }

                                int red = (int)Math.Clamp(I.X * 255f, 0, 255);
                                int green = (int)Math.Clamp(I.Y * 255f, 0, 255);
                                int blue = (int)Math.Clamp(I.Z * 255f, 0, 255);

                                int idx = x * 4;
                                row[idx + 0] = (byte)blue;
                                row[idx + 1] = (byte)green;
                                row[idx + 2] = (byte)red;
                                row[idx + 3] = 255;
                            }
                        }
                    }
                });
            }

            frameBuffer.UnlockBits(bmpData);
        }
        

        private Vertex TransformCoordinates(Vertex v, int screenWidth, int screenHeight)
        {
            return new Vertex
            {
                PRotated = new Vector3(
                    v.PRotated.X + (screenWidth / 2f),
                    -v.PRotated.Y + (screenHeight / 2f),
                    v.PRotated.Z
                ),
                NormalRotated = v.NormalRotated,
                U = v.U,
                V = v.V,
                PuRotated = v.PuRotated,
                PvRotated = v.PvRotated
            };
        }
    }
}
