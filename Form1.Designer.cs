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
            heightMapCheckbox = new CheckBox();
            panel4 = new Panel();
            reflectorLightRadioButton = new RadioButton();
            radioButton5 = new RadioButton();
            directionalLightRadioButton = new RadioButton();
            pointLightRadioButton = new RadioButton();
            panel3 = new Panel();
            radioButton4 = new RadioButton();
            radioButton3 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            label8 = new Label();
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
            label9 = new Label();
            trackBar1 = new TrackBar();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)lightzTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)mTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ksTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)kdTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)triangulationTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
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
            panel1.Controls.Add(trackBar1);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(heightMapCheckbox);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(label8);
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
            // heightMapCheckbox
            // 
            heightMapCheckbox.AutoSize = true;
            heightMapCheckbox.Location = new Point(21, 657);
            heightMapCheckbox.Name = "heightMapCheckbox";
            heightMapCheckbox.Size = new Size(310, 24);
            heightMapCheckbox.TabIndex = 31;
            heightMapCheckbox.Text = "Mapa wysokości (załaduj mapę normalną)";
            heightMapCheckbox.UseVisualStyleBackColor = true;
            heightMapCheckbox.CheckedChanged += heightMapCheckbox_CheckedChanged;
            // 
            // panel4
            // 
            panel4.Controls.Add(reflectorLightRadioButton);
            panel4.Controls.Add(radioButton5);
            panel4.Controls.Add(directionalLightRadioButton);
            panel4.Controls.Add(pointLightRadioButton);
            panel4.Location = new Point(18, 618);
            panel4.Name = "panel4";
            panel4.Size = new Size(309, 31);
            panel4.TabIndex = 30;
            // 
            // reflectorLightRadioButton
            // 
            reflectorLightRadioButton.AutoSize = true;
            reflectorLightRadioButton.Location = new Point(211, 3);
            reflectorLightRadioButton.Name = "reflectorLightRadioButton";
            reflectorLightRadioButton.Size = new Size(86, 24);
            reflectorLightRadioButton.TabIndex = 21;
            reflectorLightRadioButton.Text = "reflektor";
            reflectorLightRadioButton.UseVisualStyleBackColor = true;
            reflectorLightRadioButton.CheckedChanged += reflectorLightRadioButton_CheckedChanged;
            // 
            // radioButton5
            // 
            radioButton5.AutoSize = true;
            radioButton5.Location = new Point(102, 3);
            radioButton5.Name = "radioButton5";
            radioButton5.Size = new Size(105, 24);
            radioButton5.TabIndex = 20;
            radioButton5.Text = "kierunkowe";
            radioButton5.UseVisualStyleBackColor = true;
            radioButton5.CheckedChanged += radioButton5_CheckedChanged;
            // 
            // directionalLightRadioButton
            // 
            directionalLightRadioButton.AutoSize = true;
            directionalLightRadioButton.Location = new Point(104, 3);
            directionalLightRadioButton.Name = "directionalLightRadioButton";
            directionalLightRadioButton.Size = new Size(105, 24);
            directionalLightRadioButton.TabIndex = 19;
            directionalLightRadioButton.Text = "kierunkowe";
            directionalLightRadioButton.UseVisualStyleBackColor = true;
            // 
            // pointLightRadioButton
            // 
            pointLightRadioButton.AutoSize = true;
            pointLightRadioButton.Checked = true;
            pointLightRadioButton.Location = new Point(3, 3);
            pointLightRadioButton.Name = "pointLightRadioButton";
            pointLightRadioButton.Size = new Size(95, 24);
            pointLightRadioButton.TabIndex = 18;
            pointLightRadioButton.TabStop = true;
            pointLightRadioButton.Text = "punktowe";
            pointLightRadioButton.UseVisualStyleBackColor = true;
            pointLightRadioButton.CheckedChanged += pointLightRadioButton_CheckedChanged;
            // 
            // panel3
            // 
            panel3.Controls.Add(radioButton4);
            panel3.Controls.Add(radioButton3);
            panel3.Controls.Add(radioButton2);
            panel3.Controls.Add(radioButton1);
            panel3.Location = new Point(129, 578);
            panel3.Name = "panel3";
            panel3.Size = new Size(215, 34);
            panel3.TabIndex = 29;
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Location = new Point(135, 7);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(38, 24);
            radioButton4.TabIndex = 5;
            radioButton4.Text = "4";
            radioButton4.UseVisualStyleBackColor = true;
            radioButton4.CheckedChanged += radioButton4_CheckedChanged;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(91, 7);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(38, 24);
            radioButton3.TabIndex = 4;
            radioButton3.Text = "3";
            radioButton3.UseVisualStyleBackColor = true;
            radioButton3.CheckedChanged += radioButton3_CheckedChanged;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(47, 7);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(38, 24);
            radioButton2.TabIndex = 3;
            radioButton2.Text = "2";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.Location = new Point(3, 7);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(38, 24);
            radioButton1.TabIndex = 2;
            radioButton1.TabStop = true;
            radioButton1.Text = "1";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(18, 589);
            label8.Name = "label8";
            label8.Size = new Size(101, 20);
            label8.TabIndex = 28;
            label8.Text = "Liczba świateł";
            // 
            // panel2
            // 
            panel2.Controls.Add(indexOneRadioButton);
            panel2.Controls.Add(indexZeroRadioButton);
            panel2.Location = new Point(218, 426);
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
            label6.Location = new Point(133, 431);
            label6.Name = "label6";
            label6.Size = new Size(76, 20);
            label6.TabIndex = 26;
            label6.Text = "Id obiektu";
            // 
            // drawControlPointsCheckBox
            // 
            drawControlPointsCheckBox.AutoSize = true;
            drawControlPointsCheckBox.Location = new Point(18, 394);
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
            drawTrajectoryCheckBox.Location = new Point(18, 363);
            drawTrajectoryCheckBox.Name = "drawTrajectoryCheckBox";
            drawTrajectoryCheckBox.Size = new Size(191, 24);
            drawTrajectoryCheckBox.TabIndex = 23;
            drawTrajectoryCheckBox.Text = "Pokaż trajektorię światła";
            drawTrajectoryCheckBox.UseVisualStyleBackColor = true;
            drawTrajectoryCheckBox.CheckedChanged += drawTrajectoryCheckBox_CheckedChanged;
            // 
            // lightColorButton
            // 
            lightColorButton.Location = new Point(24, 287);
            lightColorButton.Name = "lightColorButton";
            lightColorButton.Size = new Size(313, 30);
            lightColorButton.TabIndex = 22;
            lightColorButton.Text = "Wybierz kolor światła";
            lightColorButton.UseVisualStyleBackColor = true;
            lightColorButton.Click += lightColorButton_Click;
            // 
            // normalMapButton
            // 
            normalMapButton.Location = new Point(239, 542);
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
            normalMapCheckBox.Location = new Point(18, 546);
            normalMapCheckBox.Name = "normalMapCheckBox";
            normalMapCheckBox.Size = new Size(219, 24);
            normalMapCheckBox.TabIndex = 20;
            normalMapCheckBox.Text = "Mapa wektorów normalnych";
            normalMapCheckBox.UseVisualStyleBackColor = true;
            normalMapCheckBox.CheckedChanged += normalMapCheckBox_CheckedChanged;
            // 
            // textureButton
            // 
            textureButton.Location = new Point(158, 502);
            textureButton.Name = "textureButton";
            textureButton.Size = new Size(148, 30);
            textureButton.TabIndex = 19;
            textureButton.Text = "Załaduj teksturę";
            textureButton.UseVisualStyleBackColor = true;
            textureButton.Click += fillTextureButton_Click;
            // 
            // colorButton
            // 
            colorButton.Location = new Point(158, 461);
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
            textureRadioButton.Location = new Point(18, 502);
            textureRadioButton.Name = "textureRadioButton";
            textureRadioButton.Size = new Size(82, 24);
            textureRadioButton.TabIndex = 17;
            textureRadioButton.Text = "tekstura";
            textureRadioButton.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(18, 431);
            label7.Name = "label7";
            label7.Size = new Size(102, 20);
            label7.TabIndex = 16;
            label7.Text = "Kolor obiektu:";
            // 
            // colorRadioButton
            // 
            colorRadioButton.AutoSize = true;
            colorRadioButton.Checked = true;
            colorRadioButton.Location = new Point(18, 464);
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
            label5.Location = new Point(18, 331);
            label5.Name = "label5";
            label5.Size = new Size(136, 20);
            label5.TabIndex = 13;
            label5.Text = "Płaszczyzna światła";
            // 
            // lightzTrackBar
            // 
            lightzTrackBar.Location = new Point(150, 331);
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
            animationButton.Location = new Point(24, 251);
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
            label4.Location = new Point(20, 210);
            label4.Name = "label4";
            label4.Size = new Size(116, 20);
            label4.TabIndex = 10;
            label4.Text = "Współczynnik m";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 180);
            label3.Name = "label3";
            label3.Size = new Size(96, 20);
            label3.TabIndex = 9;
            label3.Text = "Wsp. ks * 100";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 147);
            label2.Name = "label2";
            label2.Size = new Size(99, 20);
            label2.TabIndex = 8;
            label2.Text = "Wsp. kd * 100";
            // 
            // mTrackBar
            // 
            mTrackBar.Location = new Point(150, 212);
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
            ksTrackBar.Location = new Point(150, 178);
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
            kdTrackBar.Location = new Point(150, 147);
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
            filledCheckBox.Location = new Point(24, 111);
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
            triangleCheckBox.Location = new Point(24, 81);
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
            bezierCheckBox.Location = new Point(24, 51);
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
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(20, 691);
            label9.Name = "label9";
            label9.Size = new Size(127, 20);
            label9.TabIndex = 32;
            label9.Text = "k mapy wysokości";
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(153, 687);
            trackBar1.Maximum = 4;
            trackBar1.Minimum = 1;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(187, 56);
            trackBar1.TabIndex = 33;
            trackBar1.TickStyle = TickStyle.None;
            trackBar1.Value = 2;
            trackBar1.Scroll += trackBar1_Scroll;
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
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)lightzTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)mTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)ksTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)kdTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)triangulationTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
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
        private Label label8;
        private Panel panel3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private RadioButton radioButton4;
        private RadioButton radioButton3;
        private Panel panel4;
        private RadioButton pointLightRadioButton;
        private RadioButton reflectorLightRadioButton;
        private RadioButton radioButton5;
        private RadioButton directionalLightRadioButton;
        private CheckBox heightMapCheckbox;
        private Label label9;
        private TrackBar trackBar1;
    }
}
