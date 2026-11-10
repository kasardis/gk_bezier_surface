namespace BezierSurface
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            helpToolStripMenuItem = new ToolStripMenuItem();
            loadFileToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            panel2 = new Panel();
            indexOneRadioButton = new RadioButton();
            indexZeroRadioButton = new RadioButton();
            label6 = new Label();
            drawControlPointsCheckBox = new CheckBox();
            drawTrajectoryCheckBox = new CheckBox();
            lightColorButton = new Button();
            normalMapButton = new Button();
            normalMapCheckBox = new CheckBox();
            textureButton = new Button();
            colorButton = new Button();
            textureRadioButton = new RadioButton();
            label7 = new Label();
            colorRadioButton = new RadioButton();
            label5 = new Label();
            lightzTrackBar = new TrackBar();
            animationButton = new Button();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            mTrackBar = new TrackBar();
            ksTrackBar = new TrackBar();
            kdTrackBar = new TrackBar();
            filledCheckBox = new CheckBox();
            triangleCheckBox = new CheckBox();
            bezierCheckBox = new CheckBox();
            label1 = new Label();
            triangulationTrackBar = new TrackBar();
            pictureBox1 = new PictureBox();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)lightzTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)mTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ksTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)kdTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)triangulationTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { helpToolStripMenuItem, loadFileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1213, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(55, 24);
            helpToolStripMenuItem.Text = "Help";
            helpToolStripMenuItem.Click += helpToolStripMenuItem_Click;
            // 
            // loadFileToolStripMenuItem
            // 
            loadFileToolStripMenuItem.Name = "loadFileToolStripMenuItem";
            loadFileToolStripMenuItem.Size = new Size(102, 24);
            loadFileToolStripMenuItem.Text = "Wczytaj plik";
            loadFileToolStripMenuItem.Click += loadFileToolStripMenuItem_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(drawControlPointsCheckBox);
            panel1.Controls.Add(drawTrajectoryCheckBox);
            panel1.Controls.Add(lightColorButton);
            panel1.Controls.Add(normalMapButton);
            panel1.Controls.Add(normalMapCheckBox);
            panel1.Controls.Add(textureButton);
            panel1.Controls.Add(colorButton);
            panel1.Controls.Add(textureRadioButton);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(colorRadioButton);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(lightzTrackBar);
            panel1.Controls.Add(animationButton);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(mTrackBar);
            panel1.Controls.Add(ksTrackBar);
            panel1.Controls.Add(kdTrackBar);
            panel1.Controls.Add(filledCheckBox);
            panel1.Controls.Add(triangleCheckBox);
            panel1.Controls.Add(bezierCheckBox);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(triangulationTrackBar);
            panel1.Location = new Point(850, 36);
            panel1.Name = "panel1";
            panel1.Size = new Size(351, 728);
            panel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(indexOneRadioButton);
            panel2.Controls.Add(indexZeroRadioButton);
            panel2.Location = new Point(218, 479);
            panel2.Name = "panel2";
            panel2.Size = new Size(119, 29);
            panel2.TabIndex = 27;
            // 
            // indexOneRadioButton
            // 
            indexOneRadioButton.AutoSize = true;
            indexOneRadioButton.Location = new Point(50, 3);
            indexOneRadioButton.Name = "indexOneRadioButton";
            indexOneRadioButton.Size = new Size(38, 24);
            indexOneRadioButton.TabIndex = 1;
            indexOneRadioButton.Text = "1";
            indexOneRadioButton.UseVisualStyleBackColor = true;
            // 
            // indexZeroRadioButton
            // 
            indexZeroRadioButton.AutoSize = true;
            indexZeroRadioButton.Checked = true;
            indexZeroRadioButton.Location = new Point(6, 3);
            indexZeroRadioButton.Name = "indexZeroRadioButton";
            indexZeroRadioButton.Size = new Size(38, 24);
            indexZeroRadioButton.TabIndex = 0;
            indexZeroRadioButton.TabStop = true;
            indexZeroRadioButton.Text = "0";
            indexZeroRadioButton.UseVisualStyleBackColor = true;
            indexZeroRadioButton.CheckedChanged += indexZeroRadioButton_CheckedChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(133, 484);
            label6.Name = "label6";
            label6.Size = new Size(76, 20);
            label6.TabIndex = 26;
            label6.Text = "Id obiektu";
            // 
            // drawControlPointsCheckBox
            // 
            drawControlPointsCheckBox.AutoSize = true;
            drawControlPointsCheckBox.Location = new Point(18, 446);
            drawControlPointsCheckBox.Name = "drawControlPointsCheckBox";
            drawControlPointsCheckBox.Size = new Size(234, 24);
            drawControlPointsCheckBox.TabIndex = 24;
            drawControlPointsCheckBox.Text = "Pokaż punkty kontrolne światła";
            drawControlPointsCheckBox.UseVisualStyleBackColor = true;
            drawControlPointsCheckBox.CheckedChanged += drawControlPointsCheckBox_CheckedChanged;
            // 
            // drawTrajectoryCheckBox
            // 
            drawTrajectoryCheckBox.AutoSize = true;
            drawTrajectoryCheckBox.Location = new Point(18, 415);
            drawTrajectoryCheckBox.Name = "drawTrajectoryCheckBox";
            drawTrajectoryCheckBox.Size = new Size(191, 24);
            drawTrajectoryCheckBox.TabIndex = 23;
            drawTrajectoryCheckBox.Text = "Pokaż trajektorię światła";
            drawTrajectoryCheckBox.UseVisualStyleBackColor = true;
            drawTrajectoryCheckBox.CheckedChanged += drawTrajectoryCheckBox_CheckedChanged;
            // 
            // lightColorButton
            // 
            lightColorButton.Location = new Point(24, 334);
            lightColorButton.Name = "lightColorButton";
            lightColorButton.Size = new Size(313, 30);
            lightColorButton.TabIndex = 22;
            lightColorButton.Text = "Wybierz kolor światła";
            lightColorButton.UseVisualStyleBackColor = true;
            lightColorButton.Click += lightColorButton_Click;
            // 
            // normalMapButton
            // 
            normalMapButton.Location = new Point(239, 600);
            normalMapButton.Name = "normalMapButton";
            normalMapButton.Size = new Size(98, 30);
            normalMapButton.TabIndex = 21;
            normalMapButton.Text = "Załaduj";
            normalMapButton.UseVisualStyleBackColor = true;
            normalMapButton.Click += normalMapButton_Click;
            // 
            // normalMapCheckBox
            // 
            normalMapCheckBox.AutoSize = true;
            normalMapCheckBox.Location = new Point(18, 604);
            normalMapCheckBox.Name = "normalMapCheckBox";
            normalMapCheckBox.Size = new Size(219, 24);
            normalMapCheckBox.TabIndex = 20;
            normalMapCheckBox.Text = "Mapa wektorów normalnych";
            normalMapCheckBox.UseVisualStyleBackColor = true;
            normalMapCheckBox.CheckedChanged += normalMapCheckBox_CheckedChanged;
            // 
            // textureButton
            // 
            textureButton.Location = new Point(158, 553);
            textureButton.Name = "textureButton";
            textureButton.Size = new Size(148, 30);
            textureButton.TabIndex = 19;
            textureButton.Text = "Załaduj teksturę";
            textureButton.UseVisualStyleBackColor = true;
            textureButton.Click += fillTextureButton_Click;
            // 
            // colorButton
            // 
            colorButton.Location = new Point(158, 514);
            colorButton.Name = "colorButton";
            colorButton.Size = new Size(148, 30);
            colorButton.TabIndex = 18;
            colorButton.Text = "Wybierz kolor";
            colorButton.UseVisualStyleBackColor = true;
            colorButton.Click += colorButton_Click;
            // 
            // textureRadioButton
            // 
            textureRadioButton.AutoSize = true;
            textureRadioButton.Location = new Point(18, 553);
            textureRadioButton.Name = "textureRadioButton";
            textureRadioButton.Size = new Size(82, 24);
            textureRadioButton.TabIndex = 17;
            textureRadioButton.Text = "tekstura";
            textureRadioButton.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(18, 484);
            label7.Name = "label7";
            label7.Size = new Size(102, 20);
            label7.TabIndex = 16;
            label7.Text = "Kolor obiektu:";
            // 
            // colorRadioButton
            // 
            colorRadioButton.AutoSize = true;
            colorRadioButton.Checked = true;
            colorRadioButton.Location = new Point(18, 517);
            colorRadioButton.Name = "colorRadioButton";
            colorRadioButton.Size = new Size(126, 24);
            colorRadioButton.TabIndex = 15;
            colorRadioButton.TabStop = true;
            colorRadioButton.Text = "jednolity kolor";
            colorRadioButton.UseVisualStyleBackColor = true;
            colorRadioButton.CheckedChanged += colorRadioButton_CheckedChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(18, 383);
            label5.Name = "label5";
            label5.Size = new Size(136, 20);
            label5.TabIndex = 13;
            label5.Text = "Płaszczyzna światła";
            // 
            // lightzTrackBar
            // 
            lightzTrackBar.Location = new Point(150, 383);
            lightzTrackBar.Maximum = 1000;
            lightzTrackBar.Minimum = 500;
            lightzTrackBar.Name = "lightzTrackBar";
            lightzTrackBar.Size = new Size(187, 56);
            lightzTrackBar.TabIndex = 12;
            lightzTrackBar.TickStyle = TickStyle.None;
            lightzTrackBar.Value = 500;
            lightzTrackBar.Scroll += lightzTrackBar_Scroll;
            // 
            // animationButton
            // 
            animationButton.Location = new Point(24, 298);
            animationButton.Name = "animationButton";
            animationButton.Size = new Size(313, 30);
            animationButton.TabIndex = 11;
            animationButton.Text = "Zatrzymaj/Wznów animację światła";
            animationButton.UseVisualStyleBackColor = true;
            animationButton.Click += animationButton_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 255);
            label4.Name = "label4";
            label4.Size = new Size(116, 20);
            label4.TabIndex = 10;
            label4.Text = "Współczynnik m";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 211);
            label3.Name = "label3";
            label3.Size = new Size(96, 20);
            label3.TabIndex = 9;
            label3.Text = "Wsp. ks * 100";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 167);
            label2.Name = "label2";
            label2.Size = new Size(99, 20);
            label2.TabIndex = 8;
            label2.Text = "Wsp. kd * 100";
            // 
            // mTrackBar
            // 
            mTrackBar.Location = new Point(150, 255);
            mTrackBar.Maximum = 100;
            mTrackBar.Minimum = 1;
            mTrackBar.Name = "mTrackBar";
            mTrackBar.Size = new Size(187, 56);
            mTrackBar.TabIndex = 7;
            mTrackBar.TickStyle = TickStyle.None;
            mTrackBar.Value = 32;
            mTrackBar.Scroll += mTrackBar_Scroll;
            // 
            // ksTrackBar
            // 
            ksTrackBar.Location = new Point(150, 211);
            ksTrackBar.Maximum = 100;
            ksTrackBar.Name = "ksTrackBar";
            ksTrackBar.Size = new Size(187, 56);
            ksTrackBar.TabIndex = 6;
            ksTrackBar.TickStyle = TickStyle.None;
            ksTrackBar.Value = 30;
            ksTrackBar.Scroll += ksTrackBar_Scroll;
            // 
            // kdTrackBar
            // 
            kdTrackBar.Location = new Point(150, 167);
            kdTrackBar.Maximum = 100;
            kdTrackBar.Name = "kdTrackBar";
            kdTrackBar.Size = new Size(187, 56);
            kdTrackBar.TabIndex = 5;
            kdTrackBar.TickStyle = TickStyle.None;
            kdTrackBar.Value = 70;
            kdTrackBar.Scroll += kdTrackBar_Scroll;
            // 
            // filledCheckBox
            // 
            filledCheckBox.AutoSize = true;
            filledCheckBox.Checked = true;
            filledCheckBox.CheckState = CheckState.Checked;
            filledCheckBox.Location = new Point(24, 119);
            filledCheckBox.Name = "filledCheckBox";
            filledCheckBox.Size = new Size(164, 24);
            filledCheckBox.TabIndex = 4;
            filledCheckBox.Text = "Wypełnione trójkąty";
            filledCheckBox.UseVisualStyleBackColor = true;
            filledCheckBox.CheckedChanged += filledCheckBox_CheckedChanged;
            // 
            // triangleCheckBox
            // 
            triangleCheckBox.AutoSize = true;
            triangleCheckBox.Checked = true;
            triangleCheckBox.CheckState = CheckState.Checked;
            triangleCheckBox.Location = new Point(24, 89);
            triangleCheckBox.Name = "triangleCheckBox";
            triangleCheckBox.Size = new Size(138, 24);
            triangleCheckBox.TabIndex = 3;
            triangleCheckBox.Text = "Siatka trójkątów";
            triangleCheckBox.UseVisualStyleBackColor = true;
            triangleCheckBox.CheckedChanged += triangleCheckBox_CheckedChanged;
            // 
            // bezierCheckBox
            // 
            bezierCheckBox.AutoSize = true;
            bezierCheckBox.Checked = true;
            bezierCheckBox.CheckState = CheckState.Checked;
            bezierCheckBox.Location = new Point(24, 59);
            bezierCheckBox.Name = "bezierCheckBox";
            bezierCheckBox.Size = new Size(152, 24);
            bezierCheckBox.TabIndex = 2;
            bezierCheckBox.Text = "Wieloboki Beziera";
            bezierCheckBox.UseVisualStyleBackColor = true;
            bezierCheckBox.CheckedChanged += bezierCheckBox_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 18);
            label1.Name = "label1";
            label1.Size = new Size(121, 20);
            label1.TabIndex = 1;
            label1.Text = "Kroki triangulacji";
            // 
            // triangulationTrackBar
            // 
            triangulationTrackBar.Location = new Point(150, 18);
            triangulationTrackBar.Maximum = 40;
            triangulationTrackBar.Minimum = 2;
            triangulationTrackBar.Name = "triangulationTrackBar";
            triangulationTrackBar.Size = new Size(187, 56);
            triangulationTrackBar.TabIndex = 0;
            triangulationTrackBar.TickStyle = TickStyle.None;
            triangulationTrackBar.Value = 10;
            triangulationTrackBar.Scroll += triangulationTrackBar_Scroll;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 36);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(832, 728);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            pictureBox1.Paint += pictureBox1_Paint;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseEnter += pictureBox1_MouseEnter;
            pictureBox1.MouseMove += pictureBox1_MouseMove;
            pictureBox1.MouseUp += pictureBox1_MouseUp;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1213, 776);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "BezierSurface";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)lightzTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)mTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)ksTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)kdTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)triangulationTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem helpToolStripMenuItem;
        private Panel panel1;
        private PictureBox pictureBox1;
        private TrackBar triangulationTrackBar;
        private Label label1;
        private CheckBox filledCheckBox;
        private CheckBox triangleCheckBox;
        private CheckBox bezierCheckBox;
        private Label label4;
        private Label label3;
        private Label label2;
        private TrackBar mTrackBar;
        private TrackBar ksTrackBar;
        private TrackBar kdTrackBar;
        private Label label5;
        private TrackBar lightzTrackBar;
        private Button animationButton;
        private Button textureButton;
        private Button colorButton;
        private RadioButton textureRadioButton;
        private Label label7;
        private RadioButton colorRadioButton;
        private Button normalMapButton;
        private CheckBox normalMapCheckBox;
        private Button lightColorButton;
        private CheckBox drawTrajectoryCheckBox;
        private CheckBox drawControlPointsCheckBox;
        private ToolStripMenuItem loadFileToolStripMenuItem;
        private Label label6;
        private Panel panel2;
        private RadioButton indexOneRadioButton;
        private RadioButton indexZeroRadioButton;
    }
}
