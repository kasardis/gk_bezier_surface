using System.Drawing.Imaging;
using System.Numerics;

namespace BezierSurface
{
    public partial class Form1 : Form
    {
        public List<BezierSurface> Scene = new List<BezierSurface>();
        string scene_filename = "scene.txt";
        bool rotating = false;
        PointF lastMousePosition = new PointF();
        int movingCpIndex = -1;
        LightSource lightSource { get; set; }
        System.Windows.Forms.Timer lightTimer { get; set; }
        int colorSelectedIndex = 0;

        public Form1()
        {
            InitializeComponent();
            pictureBox1.MouseWheel += pictureBox1_MouseWheel;

            ReadFromFile(scene_filename);

            Vector3 lightStart = new Vector3(-200, -200, 500);
            List<Vector3> lightControlPoints = new List<Vector3>()
            {
                lightStart,
                new Vector3(-150,  200, 500),
                new Vector3(   0,  300, 500),
                new Vector3( 200,  200, 500),
                new Vector3( 200, -200, 500),
                new Vector3(   0, -250, 500),
                lightStart
            };
            lightSource = new LightSource(lightControlPoints);

            lightTimer = new System.Windows.Forms.Timer();
            lightTimer.Interval = 32; // 30 fps?
            lightTimer.Tick += (e, sender) =>
            {
                lightSource.Update();
                pictureBox1.Invalidate();
            };
            lightTimer.Start();

            pictureBox1.Invalidate();
        }

        public bool ReadFromFile(string filename)
        {
            if (!File.Exists(filename))
            {
                MessageBox.Show($"Nie znaleziono pliku: {filename}", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                string[] lines = File.ReadAllLines(filename);
                for (int i = 0; i < lines.Length / BezierSurface.NumberOfPoints; i++)
                {
                    List<Vector3> cp = new List<Vector3>();
                    for (int j = 0; j < BezierSurface.NumberOfPoints; j++)
                    {
                        string currentLine = lines[i * BezierSurface.NumberOfPoints + j];
                        string[] tokens = currentLine.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                        if (tokens.Length < 3)
                        {
                            MessageBox.Show($"B³¹d w linii {i * BezierSurface.NumberOfPoints + j} w pliku {filename} - za ma³o liczb w linii");
                            return false;
                        }
                        float x = float.Parse(tokens[0], System.Globalization.CultureInfo.InvariantCulture);
                        float y = float.Parse(tokens[1], System.Globalization.CultureInfo.InvariantCulture);
                        float z = float.Parse(tokens[2], System.Globalization.CultureInfo.InvariantCulture);
                        cp.Add(new Vector3(x, y, z));
                    }
                    var surf = new BezierSurface(cp);
                    surf.CalculateTriangleMesh();
                    Scene.Add(surf);
                }
                return true;
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var help = new HelpForm();
            help.ShowDialog();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            using Bitmap frameBuffer = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            float[,] zBuffer = new float[pictureBox1.Width, pictureBox1.Height];
            for (int i = 0; i < pictureBox1.Width; i++)
            {
                for (int j = 0; j < pictureBox1.Height; j++)
                {
                    zBuffer[i, j] = float.NegativeInfinity;
                }
            }

            foreach (var item in Scene)
            {
                item.CalculateRotatedPoints();
                item.FillTriangles(frameBuffer, zBuffer, lightSource);
            }
            g.DrawImage(frameBuffer, 0, 0);


            g.TranslateTransform(pictureBox1.Width / 2, pictureBox1.Height / 2);
            g.ScaleTransform(1, -1);

            foreach (var item in Scene)
            {
                item.CalculateRotatedPoints();
                item.Draw(g);
            }
            lightSource.Draw(g);
        }

        private void triangulationTrackBar_Scroll(object sender, EventArgs e)
        {
            BezierSurface.TriangulationSteps = triangulationTrackBar.Value;
            foreach (var item in Scene)
            {
                item.CalculateTriangleMesh();
            }
            pictureBox1.Invalidate();
        }

        private void bezierCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            BezierSurface.DrawBezierPolygons = bezierCheckBox.Checked;
            pictureBox1.Invalidate();
        }

        private void triangleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            BezierSurface.DrawTriangleMesh = triangleCheckBox.Checked;
            pictureBox1.Invalidate();
        }

        private void filledCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            BezierSurface.DrawFilledTriangles = filledCheckBox.Checked;
            pictureBox1.Invalidate();
        }

        private PointF GetMathCoordinates(Point mousePt)
        {
            float mathX = mousePt.X - (pictureBox1.Width / 2f);
            float mathY = -(mousePt.Y - (pictureBox1.Height / 2f));
            return new PointF(mathX, mathY);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            PointF mathPt = GetMathCoordinates(e.Location);
            movingCpIndex = lightSource.HitTest(mathPt);
            if (movingCpIndex == -1)
            {
                rotating = true;
                lastMousePosition = e.Location;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (movingCpIndex != -1)
            {
                PointF mathPt = GetMathCoordinates(e.Location);
                Vector3 newCp = new Vector3(mathPt.X, mathPt.Y, lightSource.ControlPoints[movingCpIndex].Z);
                lightSource.ControlPoints[movingCpIndex] = newCp;
                if (movingCpIndex == 0)
                {
                    lightSource.ControlPoints[lightSource.ControlPoints.Count - 1] = newCp;
                }
                lightSource.Positions.Clear();
                for (int i = 0; i < lightSource.NumLights; i++)
                {
                    float t = lightSource.T + (float)i / (float)lightSource.NumLights;
                    if (t > 1) t -= 1;
                    lightSource.Positions.Add(lightSource.EvaluatePosition(t));
                }
            }
            else
            {
                if (!rotating) return;

                float deltaX = e.X - lastMousePosition.X;
                float deltaY = e.Y - lastMousePosition.Y;
                lastMousePosition = e.Location;

                float sensitivity = 0.005f;

                float beta = deltaX * sensitivity;
                float alpha = -deltaY * sensitivity;

                BezierSurface.RotateScene(alpha, beta, 0f);
            }

            pictureBox1.Invalidate();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            movingCpIndex = -1;
            rotating = false;
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Focus();
        }

        private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            float scrollSensitivity = 0.05f;
            float gamma = (e.Delta / 120f) * scrollSensitivity;
            BezierSurface.RotateScene(0f, 0f, gamma);
            pictureBox1.Invalidate();
        }

        private void lightColorButton_Click(object sender, EventArgs e)
        {
            using ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                lightSource.Color = colorDialog.Color;
            }
            pictureBox1.Invalidate();
        }

        private void drawTrajectoryCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            lightSource.DrawTrajectory = drawTrajectoryCheckBox.Checked;
            pictureBox1.Invalidate();
        }

        private void drawControlPointsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            lightSource.DrawControlPoints = drawControlPointsCheckBox.Checked;
            pictureBox1.Invalidate();
        }

        private void animationButton_Click(object sender, EventArgs e)
        {
            if (lightTimer.Enabled)
            {
                lightTimer.Stop();
            }
            else
            {
                lightTimer.Start();
            }
        }

        private void lightzTrackBar_Scroll(object sender, EventArgs e)
        {
            for (int i = 0; i < lightSource.ControlPoints.Count; i++)
            {
                var cp = lightSource.ControlPoints[i];
                lightSource.ControlPoints[i] = new Vector3(cp.X, cp.Y, lightzTrackBar.Value);
            }
            pictureBox1.Invalidate();
        }

        private void colorRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            /*
            foreach (var item in Scene)
            {
                if (colorRadioButton.Checked)
                {
                    item.SurfaceColorMode = BezierSurface.ColorMode.Solid;
                }
                else
                {
                    item.SurfaceColorMode = BezierSurface.ColorMode.Image;
                }
            }
            */
            if (colorRadioButton.Checked)
            {
                Scene[colorSelectedIndex].SurfaceColorMode = BezierSurface.ColorMode.Solid;
            }
            else
            {
                Scene[colorSelectedIndex].SurfaceColorMode = BezierSurface.ColorMode.Image;
            }
            pictureBox1.Invalidate();
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            using ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                /*
                foreach (var item in Scene)
                {
                    item.FillColor = colorDialog.Color;
                }
                */
                Scene[colorSelectedIndex].FillColor = colorDialog.Color;
            }
            pictureBox1.Invalidate();
        }

        private void fillTextureButton_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Obrazy|*.jpg;*.jpeg;*.png;*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var bitmap = new Bitmap(openFileDialog.FileName);
                /*
                foreach (var item in Scene)
                {
                    item.FillImage = bitmap;
                }
                */
                Scene[colorSelectedIndex].FillImage = bitmap;

                int fiWidth = bitmap.Width;
                int fiHeight = bitmap.Height;
                Color[,] fillImageCache = new Color[fiWidth, fiHeight];

                BitmapData fiData = bitmap.LockBits(new Rectangle(0, 0, fiWidth, fiHeight), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                unsafe
                {
                    byte* ptr = (byte*)fiData.Scan0;
                    for (int y = 0; y < fiHeight; y++)
                    {
                        byte* row = ptr + (y * fiData.Stride);
                        for (int x = 0; x < fiWidth; x++)
                        {
                            int idx = x * 4;
                            fillImageCache[x, y] = Color.FromArgb(row[idx + 3], row[idx + 2], row[idx + 1], row[idx + 0]);
                        }
                    }
                }
                bitmap.UnlockBits(fiData);
                Scene[colorSelectedIndex].FillImageCache = fillImageCache;
                Scene[colorSelectedIndex].FillImageWidth = fiWidth;
                Scene[colorSelectedIndex].FillImageHeight = fiHeight;
            }
            pictureBox1.Invalidate();
        }

        private void normalMapButton_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Obrazy|*.jpg;*.jpeg;*.png;*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var bitmap = new Bitmap(openFileDialog.FileName);
                /*
                foreach (var item in Scene)
                {
                    item.NormalMapImage = bitmap;
                }
                */
                Scene[colorSelectedIndex].NormalMapImage = bitmap;

                int nmWidth = bitmap.Width;
                int nmHeight = bitmap.Height;
                Color[,] normalMapCache = new Color[nmWidth, nmHeight];

                BitmapData nmData = bitmap.LockBits(new Rectangle(0, 0, nmWidth, nmHeight), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                unsafe
                {
                    byte* ptr = (byte*)nmData.Scan0;
                    for (int y = 0; y < nmHeight; y++)
                    {
                        byte* row = ptr + (y * nmData.Stride);
                        for (int x = 0; x < nmWidth; x++)
                        {
                            int idx = x * 4;
                            normalMapCache[x, y] = Color.FromArgb(row[idx + 3], row[idx + 2], row[idx + 1], row[idx + 0]);
                        }
                    }
                }
                bitmap.UnlockBits(nmData);
                Scene[colorSelectedIndex].NormalMapImageCache = normalMapCache;
                Scene[colorSelectedIndex].NormalMapWidth = nmWidth;
                Scene[colorSelectedIndex].NormalMapHeight = nmHeight;
            }
            pictureBox1.Invalidate();
        }

        private void normalMapCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            BezierSurface.DrawNormalMap = normalMapCheckBox.Checked;
            pictureBox1.Invalidate();
        }

        private void kdTrackBar_Scroll(object sender, EventArgs e)
        {
            foreach (var item in Scene)
            {
                item.KDiffuse = (float)kdTrackBar.Value / 100;
            }
            pictureBox1.Invalidate();
        }

        private void ksTrackBar_Scroll(object sender, EventArgs e)
        {
            foreach (var item in Scene)
            {
                item.KSpecular = (float)ksTrackBar.Value / 100;
            }
            pictureBox1.Invalidate();
        }

        private void mTrackBar_Scroll(object sender, EventArgs e)
        {
            foreach (var item in Scene)
            {
                item.Mirror = mTrackBar.Value;
            }
            pictureBox1.Invalidate();
        }

        private void loadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Pliki tekstowe|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var SceneCp = Scene;
                Scene = new List<BezierSurface>();
                if (!ReadFromFile(openFileDialog.FileName))
                {
                    Scene = SceneCp;
                }
                else
                {
                    foreach (var item in Scene)
                    {
                        item.KDiffuse = (float)kdTrackBar.Value / 100;
                        item.KSpecular = (float)ksTrackBar.Value / 100;
                        item.Mirror = mTrackBar.Value;
                        item.SurfaceColorMode = colorRadioButton.Checked ? BezierSurface.ColorMode.Solid : BezierSurface.ColorMode.Image;
                    }
                }
                pictureBox1.Invalidate();
            }
        }

        private void indexZeroRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (indexZeroRadioButton.Checked)
            {
                colorSelectedIndex = 0;
            }
            else
            {
                colorSelectedIndex = 1;
            }
            if (Scene[colorSelectedIndex].SurfaceColorMode == BezierSurface.ColorMode.Solid)
            {
                colorRadioButton.Checked = true;
            }
            else
            {
                textureRadioButton.Checked = true;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                lightSource.NumLights = 1;
                pictureBox1.Invalidate();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                lightSource.NumLights = 2;
                pictureBox1.Invalidate();
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                lightSource.NumLights = 3;
                pictureBox1.Invalidate();
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                lightSource.NumLights = 4;
                pictureBox1.Invalidate();
            }
        }

        private void pointLightRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (pointLightRadioButton.Checked)
            {
                lightSource.CurrentLightType = LightSource.LightType.Point;
                pictureBox1.Invalidate();
            }
        }

        // directional light, visual studio doesn't want to change the name
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                lightSource.CurrentLightType = LightSource.LightType.Directional;
                pictureBox1.Invalidate();
            }
        }

        private void reflectorLightRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (reflectorLightRadioButton.Checked)
            {
                lightSource.CurrentLightType = LightSource.LightType.Reflector;
                pictureBox1.Invalidate();
            }
        }

        private void heightMapCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            BezierSurface.DrawHeightMap = heightMapCheckbox.Checked;
            pictureBox1.Invalidate();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            BezierSurface.HeightMapK = trackBar1.Value;
            pictureBox1.Invalidate();
        }
    }
}
