namespace CityGroundline
{
    partial class SimulatorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlCanvas = new System.Windows.Forms.Panel();
            this.btnClearFunction = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCreateRH = new System.Windows.Forms.Button();
            this.btnCreatePS = new System.Windows.Forms.Button();
            this.btnCreateRoad = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.btnCreateHPL = new System.Windows.Forms.Button();
            this.btnCreateFS = new System.Windows.Forms.Button();
            this.btnCreateNP = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnlCanvas
            // 
            this.pnlCanvas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlCanvas.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pnlCanvas.Location = new System.Drawing.Point(21, 12);
            this.pnlCanvas.Name = "pnlCanvas";
            this.pnlCanvas.Size = new System.Drawing.Size(1151, 551);
            this.pnlCanvas.TabIndex = 0;
            this.pnlCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCanvas_Paint);
            this.pnlCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlCanvas_MouseDown);
            this.pnlCanvas.MouseLeave += new System.EventHandler(this.pnlCanvas_MouseLeave);
            this.pnlCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlCanvas_MouseMove);
            // 
            // btnClearFunction
            // 
            this.btnClearFunction.Location = new System.Drawing.Point(33, 618);
            this.btnClearFunction.Name = "btnClearFunction";
            this.btnClearFunction.Size = new System.Drawing.Size(75, 23);
            this.btnClearFunction.TabIndex = 1;
            this.btnClearFunction.Text = "Clear Function";
            this.btnClearFunction.UseVisualStyleBackColor = true;
            this.btnClearFunction.Click += new System.EventHandler(this.btnClearFunction_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 592);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 654);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "label2";
            // 
            // btnCreateRH
            // 
            this.btnCreateRH.BackgroundImage = global::CityGroundline.Properties.Resources.house_icon;
            this.btnCreateRH.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCreateRH.FlatAppearance.BorderSize = 5;
            this.btnCreateRH.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.btnCreateRH.Location = new System.Drawing.Point(124, 569);
            this.btnCreateRH.Name = "btnCreateRH";
            this.btnCreateRH.Size = new System.Drawing.Size(72, 72);
            this.btnCreateRH.TabIndex = 5;
            this.btnCreateRH.UseVisualStyleBackColor = true;
            this.btnCreateRH.Click += new System.EventHandler(this.btnCreateRH_Click);
            // 
            // btnCreatePS
            // 
            this.btnCreatePS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCreatePS.FlatAppearance.BorderSize = 5;
            this.btnCreatePS.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.btnCreatePS.Image = global::CityGroundline.Properties.Resources.police;
            this.btnCreatePS.Location = new System.Drawing.Point(202, 569);
            this.btnCreatePS.Name = "btnCreatePS";
            this.btnCreatePS.Size = new System.Drawing.Size(72, 72);
            this.btnCreatePS.TabIndex = 6;
            this.btnCreatePS.UseVisualStyleBackColor = true;
            this.btnCreatePS.Click += new System.EventHandler(this.btnCreatePS_Click);
            // 
            // btnCreateRoad
            // 
            this.btnCreateRoad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCreateRoad.FlatAppearance.BorderSize = 5;
            this.btnCreateRoad.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.btnCreateRoad.Location = new System.Drawing.Point(282, 569);
            this.btnCreateRoad.Name = "btnCreateRoad";
            this.btnCreateRoad.Size = new System.Drawing.Size(72, 72);
            this.btnCreateRoad.TabIndex = 7;
            this.btnCreateRoad.Text = "Road";
            this.btnCreateRoad.UseVisualStyleBackColor = true;
            this.btnCreateRoad.Click += new System.EventHandler(this.btnCreateRoad_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 566);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "label3";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(600, 569);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 72);
            this.button1.TabIndex = 13;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(758, 569);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(72, 72);
            this.button2.TabIndex = 14;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(931, 574);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "label8";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(931, 601);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "label9";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(931, 628);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "label10";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(678, 569);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(72, 72);
            this.button3.TabIndex = 18;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(836, 569);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(72, 72);
            this.button4.TabIndex = 19;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(931, 654);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "label11";
            // 
            // btnCreateHPL
            // 
            this.btnCreateHPL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCreateHPL.FlatAppearance.BorderSize = 5;
            this.btnCreateHPL.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.btnCreateHPL.Image = global::CityGroundline.Properties.Resources.hospital;
            this.btnCreateHPL.Location = new System.Drawing.Point(362, 569);
            this.btnCreateHPL.Name = "btnCreateHPL";
            this.btnCreateHPL.Size = new System.Drawing.Size(72, 72);
            this.btnCreateHPL.TabIndex = 21;
            this.btnCreateHPL.UseVisualStyleBackColor = true;
            this.btnCreateHPL.Click += new System.EventHandler(this.btnCreateHPL_Click);
            // 
            // btnCreateFS
            // 
            this.btnCreateFS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCreateFS.FlatAppearance.BorderSize = 5;
            this.btnCreateFS.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.btnCreateFS.Image = global::CityGroundline.Properties.Resources.fire_station;
            this.btnCreateFS.Location = new System.Drawing.Point(440, 569);
            this.btnCreateFS.Name = "btnCreateFS";
            this.btnCreateFS.Size = new System.Drawing.Size(72, 72);
            this.btnCreateFS.TabIndex = 22;
            this.btnCreateFS.UseVisualStyleBackColor = true;
            this.btnCreateFS.Click += new System.EventHandler(this.btnCreateFS_Click);
            // 
            // btnCreateNP
            // 
            this.btnCreateNP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCreateNP.FlatAppearance.BorderSize = 5;
            this.btnCreateNP.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.btnCreateNP.Image = global::CityGroundline.Properties.Resources.nuclear_plant;
            this.btnCreateNP.Location = new System.Drawing.Point(520, 569);
            this.btnCreateNP.Name = "btnCreateNP";
            this.btnCreateNP.Size = new System.Drawing.Size(72, 72);
            this.btnCreateNP.TabIndex = 23;
            this.btnCreateNP.UseVisualStyleBackColor = true;
            this.btnCreateNP.Click += new System.EventHandler(this.btnCreateNP_Click);
            // 
            // SimulatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1194, 672);
            this.Controls.Add(this.btnCreateNP);
            this.Controls.Add(this.btnCreateFS);
            this.Controls.Add(this.btnCreateHPL);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCreateRoad);
            this.Controls.Add(this.btnCreatePS);
            this.Controls.Add(this.btnCreateRH);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClearFunction);
            this.Controls.Add(this.pnlCanvas);
            this.Name = "SimulatorForm";
            this.Text = "SimulatorForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlCanvas;
        private System.Windows.Forms.Button btnClearFunction;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCreateRH;
        private System.Windows.Forms.Button btnCreatePS;
        private System.Windows.Forms.Button btnCreateRoad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnCreateHPL;
        private System.Windows.Forms.Button btnCreateFS;
        private System.Windows.Forms.Button btnCreateNP;
    }
}

