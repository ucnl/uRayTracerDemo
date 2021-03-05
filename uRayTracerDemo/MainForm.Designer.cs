namespace uRayTracerDemo
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainToolStrip = new System.Windows.Forms.ToolStrip();
            this.profileBtn = new System.Windows.Forms.ToolStripDropDownButton();
            this.demoProfilesBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.demoProfileNorthernPacificBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.demoProfileSouthernAtlanticBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.demoProfileArcticBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.loadProfileBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.wwwBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.runSimulationBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.parametersGroup = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pathMaxEdit = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.etaSurfaceEdit = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.etaBottomEdit = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.xMaxEdit = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.zTxEdit = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.dZEdit = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.raysNumEdit = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.beamAngleEdit = new System.Windows.Forms.NumericUpDown();
            this.traceView = new uRayTracerDemo.TraceView();
            this.vProfileView = new uRayTracerDemo.VProfileView();
            this.mainToolStrip.SuspendLayout();
            this.parametersGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pathMaxEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.etaSurfaceEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.etaBottomEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xMaxEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zTxEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dZEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.raysNumEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beamAngleEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // mainToolStrip
            // 
            this.mainToolStrip.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profileBtn,
            this.wwwBtn,
            this.toolStripSeparator1,
            this.runSimulationBtn,
            this.toolStripSeparator2});
            this.mainToolStrip.Location = new System.Drawing.Point(0, 0);
            this.mainToolStrip.Name = "mainToolStrip";
            this.mainToolStrip.Size = new System.Drawing.Size(1119, 35);
            this.mainToolStrip.TabIndex = 0;
            this.mainToolStrip.Text = "toolStrip1";
            // 
            // profileBtn
            // 
            this.profileBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.profileBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.demoProfilesBtn,
            this.loadProfileBtn});
            this.profileBtn.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.profileBtn.Image = ((System.Drawing.Image)(resources.GetObject("profileBtn.Image")));
            this.profileBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.profileBtn.Name = "profileBtn";
            this.profileBtn.Size = new System.Drawing.Size(117, 32);
            this.profileBtn.Text = "PROFILE...";
            // 
            // demoProfilesBtn
            // 
            this.demoProfilesBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.demoProfileNorthernPacificBtn,
            this.demoProfileSouthernAtlanticBtn,
            this.demoProfileArcticBtn});
            this.demoProfilesBtn.Name = "demoProfilesBtn";
            this.demoProfilesBtn.Size = new System.Drawing.Size(253, 32);
            this.demoProfilesBtn.Text = "DEMO PROFILES...";
            // 
            // demoProfileNorthernPacificBtn
            // 
            this.demoProfileNorthernPacificBtn.Name = "demoProfileNorthernPacificBtn";
            this.demoProfileNorthernPacificBtn.Size = new System.Drawing.Size(355, 32);
            this.demoProfileNorthernPacificBtn.Text = "NORTHERN PACIFIC (N39°)";
            this.demoProfileNorthernPacificBtn.Click += new System.EventHandler(this.demoProfileNorthernPacificBtn_Click);
            // 
            // demoProfileSouthernAtlanticBtn
            // 
            this.demoProfileSouthernAtlanticBtn.Name = "demoProfileSouthernAtlanticBtn";
            this.demoProfileSouthernAtlanticBtn.Size = new System.Drawing.Size(355, 32);
            this.demoProfileSouthernAtlanticBtn.Text = "SOUTHERN ATLANTIC (S20°)";
            this.demoProfileSouthernAtlanticBtn.Click += new System.EventHandler(this.demoProfileSouthernAtlanticBtn_Click);
            // 
            // demoProfileArcticBtn
            // 
            this.demoProfileArcticBtn.Name = "demoProfileArcticBtn";
            this.demoProfileArcticBtn.Size = new System.Drawing.Size(355, 32);
            this.demoProfileArcticBtn.Text = "ARCTIC (N89°)";
            this.demoProfileArcticBtn.Click += new System.EventHandler(this.demoProfileArcticBtn_Click);
            // 
            // loadProfileBtn
            // 
            this.loadProfileBtn.Name = "loadProfileBtn";
            this.loadProfileBtn.Size = new System.Drawing.Size(253, 32);
            this.loadProfileBtn.Text = "LOAD...";
            this.loadProfileBtn.Click += new System.EventHandler(this.loadProfileBtn_Click);
            // 
            // wwwBtn
            // 
            this.wwwBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.wwwBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.wwwBtn.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.wwwBtn.Image = ((System.Drawing.Image)(resources.GetObject("wwwBtn.Image")));
            this.wwwBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.wwwBtn.Name = "wwwBtn";
            this.wwwBtn.Size = new System.Drawing.Size(290, 32);
            this.wwwBtn.Text = "VISIT PROJECT GITHUB PAGE";
            this.wwwBtn.Click += new System.EventHandler(this.wwwBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 35);
            // 
            // runSimulationBtn
            // 
            this.runSimulationBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.runSimulationBtn.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.runSimulationBtn.Image = ((System.Drawing.Image)(resources.GetObject("runSimulationBtn.Image")));
            this.runSimulationBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.runSimulationBtn.Name = "runSimulationBtn";
            this.runSimulationBtn.Size = new System.Drawing.Size(187, 32);
            this.runSimulationBtn.Text = "RUN SIMULATION";
            this.runSimulationBtn.Click += new System.EventHandler(this.runSimulationBtn_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 35);
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 579);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1119, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            // 
            // parametersGroup
            // 
            this.parametersGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.parametersGroup.Controls.Add(this.label8);
            this.parametersGroup.Controls.Add(this.pathMaxEdit);
            this.parametersGroup.Controls.Add(this.label7);
            this.parametersGroup.Controls.Add(this.etaSurfaceEdit);
            this.parametersGroup.Controls.Add(this.label6);
            this.parametersGroup.Controls.Add(this.etaBottomEdit);
            this.parametersGroup.Controls.Add(this.label5);
            this.parametersGroup.Controls.Add(this.xMaxEdit);
            this.parametersGroup.Controls.Add(this.label4);
            this.parametersGroup.Controls.Add(this.zTxEdit);
            this.parametersGroup.Controls.Add(this.label3);
            this.parametersGroup.Controls.Add(this.dZEdit);
            this.parametersGroup.Controls.Add(this.label2);
            this.parametersGroup.Controls.Add(this.raysNumEdit);
            this.parametersGroup.Controls.Add(this.label1);
            this.parametersGroup.Controls.Add(this.beamAngleEdit);
            this.parametersGroup.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.parametersGroup.Location = new System.Drawing.Point(12, 38);
            this.parametersGroup.Name = "parametersGroup";
            this.parametersGroup.Size = new System.Drawing.Size(1095, 83);
            this.parametersGroup.TabIndex = 5;
            this.parametersGroup.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(636, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 23);
            this.label8.TabIndex = 15;
            this.label8.Text = "Path max, m";
            // 
            // pathMaxEdit
            // 
            this.pathMaxEdit.Location = new System.Drawing.Point(636, 47);
            this.pathMaxEdit.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.pathMaxEdit.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.pathMaxEdit.Name = "pathMaxEdit";
            this.pathMaxEdit.Size = new System.Drawing.Size(120, 30);
            this.pathMaxEdit.TabIndex = 14;
            this.pathMaxEdit.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(888, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 23);
            this.label7.TabIndex = 13;
            this.label7.Text = "η surface";
            // 
            // etaSurfaceEdit
            // 
            this.etaSurfaceEdit.DecimalPlaces = 2;
            this.etaSurfaceEdit.Location = new System.Drawing.Point(888, 47);
            this.etaSurfaceEdit.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.etaSurfaceEdit.Name = "etaSurfaceEdit";
            this.etaSurfaceEdit.Size = new System.Drawing.Size(120, 30);
            this.etaSurfaceEdit.TabIndex = 12;
            this.etaSurfaceEdit.Value = new decimal(new int[] {
            3,
            0,
            0,
            65536});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(762, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 23);
            this.label6.TabIndex = 11;
            this.label6.Text = "η bottom";
            // 
            // etaBottomEdit
            // 
            this.etaBottomEdit.DecimalPlaces = 2;
            this.etaBottomEdit.Location = new System.Drawing.Point(762, 47);
            this.etaBottomEdit.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.etaBottomEdit.Name = "etaBottomEdit";
            this.etaBottomEdit.Size = new System.Drawing.Size(120, 30);
            this.etaBottomEdit.TabIndex = 10;
            this.etaBottomEdit.Value = new decimal(new int[] {
            3,
            0,
            0,
            65536});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(510, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 23);
            this.label5.TabIndex = 9;
            this.label5.Text = "X max, m";
            // 
            // xMaxEdit
            // 
            this.xMaxEdit.Location = new System.Drawing.Point(510, 47);
            this.xMaxEdit.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.xMaxEdit.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.xMaxEdit.Name = "xMaxEdit";
            this.xMaxEdit.Size = new System.Drawing.Size(120, 30);
            this.xMaxEdit.TabIndex = 8;
            this.xMaxEdit.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(384, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 23);
            this.label4.TabIndex = 7;
            this.label4.Text = "Z Tx, m";
            // 
            // zTxEdit
            // 
            this.zTxEdit.DecimalPlaces = 1;
            this.zTxEdit.Location = new System.Drawing.Point(384, 47);
            this.zTxEdit.Name = "zTxEdit";
            this.zTxEdit.Size = new System.Drawing.Size(120, 30);
            this.zTxEdit.TabIndex = 6;
            this.zTxEdit.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(258, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "𝛿Z, m";
            // 
            // dZEdit
            // 
            this.dZEdit.DecimalPlaces = 1;
            this.dZEdit.Location = new System.Drawing.Point(258, 47);
            this.dZEdit.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.dZEdit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.dZEdit.Name = "dZEdit";
            this.dZEdit.Size = new System.Drawing.Size(120, 30);
            this.dZEdit.TabIndex = 4;
            this.dZEdit.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(132, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Rays number";
            // 
            // raysNumEdit
            // 
            this.raysNumEdit.Location = new System.Drawing.Point(132, 47);
            this.raysNumEdit.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.raysNumEdit.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.raysNumEdit.Name = "raysNumEdit";
            this.raysNumEdit.Size = new System.Drawing.Size(120, 30);
            this.raysNumEdit.TabIndex = 2;
            this.raysNumEdit.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Beam angle, °";
            // 
            // beamAngleEdit
            // 
            this.beamAngleEdit.Location = new System.Drawing.Point(6, 47);
            this.beamAngleEdit.Maximum = new decimal(new int[] {
            170,
            0,
            0,
            0});
            this.beamAngleEdit.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.beamAngleEdit.Name = "beamAngleEdit";
            this.beamAngleEdit.Size = new System.Drawing.Size(120, 30);
            this.beamAngleEdit.TabIndex = 0;
            this.beamAngleEdit.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // traceView
            // 
            this.traceView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.traceView.AxisColor = System.Drawing.Color.Gainsboro;
            this.traceView.AxisLblColor = System.Drawing.Color.LightGray;
            this.traceView.AxisLblFont = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.traceView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(20)))), ((int)(((byte)(30)))));
            this.traceView.Caption = "Ray tracing";
            this.traceView.CaptionColor = System.Drawing.Color.LightGray;
            this.traceView.CaptionFont = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.traceView.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.traceView.GraphPenWidth = 1F;
            this.traceView.Location = new System.Drawing.Point(400, 128);
            this.traceView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.traceView.Name = "traceView";
            this.traceView.Padding = new System.Windows.Forms.Padding(5);
            this.traceView.RayGraphColor = System.Drawing.Color.Aqua;
            this.traceView.Size = new System.Drawing.Size(707, 447);
            this.traceView.TabIndex = 4;
            this.traceView.Xmax = 8000D;
            this.traceView.Xmin = 0D;
            this.traceView.Zmax = 5600D;
            this.traceView.Zmin = 0D;
            // 
            // vProfileView
            // 
            this.vProfileView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.vProfileView.AxisColor = System.Drawing.Color.Gainsboro;
            this.vProfileView.AxisLblColor = System.Drawing.Color.LightGray;
            this.vProfileView.AxisLblFont = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.vProfileView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(20)))), ((int)(((byte)(30)))));
            this.vProfileView.Caption = "Southern Atlantic";
            this.vProfileView.CaptionColor = System.Drawing.Color.LightGray;
            this.vProfileView.CaptionFont = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.vProfileView.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.vProfileView.GraphPenWidth = 2F;
            this.vProfileView.Location = new System.Drawing.Point(12, 128);
            this.vProfileView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.vProfileView.Name = "vProfileView";
            this.vProfileView.Padding = new System.Windows.Forms.Padding(5);
            this.vProfileView.Size = new System.Drawing.Size(389, 447);
            this.vProfileView.StyGraphColor = System.Drawing.Color.SlateGray;
            this.vProfileView.TabIndex = 3;
            this.vProfileView.TempGraphColor = System.Drawing.Color.Lime;
            this.vProfileView.VelGraphColor = System.Drawing.Color.Aqua;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 601);
            this.Controls.Add(this.parametersGroup);
            this.Controls.Add(this.traceView);
            this.Controls.Add(this.vProfileView);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.mainToolStrip);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.Text = "uRayTracerDemo";
            this.mainToolStrip.ResumeLayout(false);
            this.mainToolStrip.PerformLayout();
            this.parametersGroup.ResumeLayout(false);
            this.parametersGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pathMaxEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.etaSurfaceEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.etaBottomEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xMaxEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zTxEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dZEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.raysNumEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beamAngleEdit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip mainToolStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private VProfileView vProfileView;
        private TraceView traceView;
        private System.Windows.Forms.ToolStripDropDownButton profileBtn;
        private System.Windows.Forms.ToolStripMenuItem demoProfilesBtn;
        private System.Windows.Forms.ToolStripMenuItem demoProfileNorthernPacificBtn;
        private System.Windows.Forms.ToolStripMenuItem demoProfileSouthernAtlanticBtn;
        private System.Windows.Forms.ToolStripMenuItem demoProfileArcticBtn;
        private System.Windows.Forms.ToolStripMenuItem loadProfileBtn;
        private System.Windows.Forms.ToolStripButton wwwBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton runSimulationBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.GroupBox parametersGroup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown beamAngleEdit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown dZEdit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown raysNumEdit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown zTxEdit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown etaSurfaceEdit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown etaBottomEdit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown xMaxEdit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown pathMaxEdit;
    }
}

