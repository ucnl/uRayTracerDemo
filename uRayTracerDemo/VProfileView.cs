using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UCNLPhysics;
using System.Globalization;
using uRayTracerDemo.uRays;

namespace uRayTracerDemo
{
    public partial class VProfileView : UserControl
    {
        #region Properties

        RectangleF graphBorder;
        public int tsTicks { get; private set; }

        public int ZTicks { get; private set; }
        public double ZStep { get; private set; }
                      
        #region Axis

        int axisTickSize = 4;

        Color axisColor;
        Pen axisPen;

        public Color AxisColor
        {
            get { return axisColor; }
            set
            {
                axisColor = value;
                axisPen = new Pen(axisColor, 1.0f);
            }
        }

        #endregion

        #region Axis labels

        public Font AxisLblFont { get; set; }
        Color axisLblColor;
        Brush axisLblBrush;        

        public Color AxisLblColor
        {
            get { return axisLblColor; }
            set
            {
                axisLblColor = value;
                axisLblBrush = new SolidBrush(axisLblColor);
            }
        }

        #endregion

        #region Caption

        public Font CaptionFont { get; set; }
        Color captionColor;
        Brush captionBrush;

        public string Caption { get; set; }

        public Color CaptionColor
        {
            get { return captionColor; }
            set
            {
                captionColor = value;
                captionBrush = new SolidBrush(captionColor);
            }
        }

        #endregion

        #region Graphs items

        Color tempColor;
        Color styColor;
        Color velColor;

        Brush tempBrush;
        Brush styBrush;
        Brush velBrush;

        Pen tPen;
        Pen sPen;
        Pen vPen;

        float graphPenWidth = 2.0f;

        public float GraphPenWidth
        {
            get { return graphPenWidth; }
            set
            {
                tPen = new Pen(tempColor, graphPenWidth);
                sPen = new Pen(styColor, graphPenWidth);
                vPen = new Pen(velColor, graphPenWidth);
            }
        }

        public Color TempGraphColor
        {
            get { return tempColor; }
            set
            {
                tempColor = value;
                tPen = new Pen(tempColor, graphPenWidth);
                tempBrush = new SolidBrush(tempColor);
            }
        }

        public Color StyGraphColor
        {
            get { return styColor; }
            set
            {
                styColor = value;
                sPen = new Pen(styColor, graphPenWidth);
                styBrush = new SolidBrush(styColor);
            }
        }

        public Color VelGraphColor
        {
            get { return velColor; }
            set
            {
                velColor = value;
                vPen = new Pen(velColor, graphPenWidth);
                velBrush = new SolidBrush(velColor);
            }
        }

        #endregion
        
        TSProfilePoint[] tsp;
        float[] sVelocity;

        public double Tmax { get; private set; }
        public double Tmin { get; private set; }
        public double Smax { get; private set; }
        public double Smin { get; private set; }
        public double Zmax { get; private set; }
        public double Zmin { get; private set; }

        public double VMax { get; private set; }
        public double VMin { get; private set; }

        float tRange;
        float sRange;
        float vRange;
        float zRange;
        float tStep;
        float sStep;
        float vStep;

        #endregion

        #region Constructor

        public VProfileView()
        {
            InitializeComponent();

            if (AxisLblFont == null)
                AxisLblFont = this.Font;

            AxisColor = Color.Gainsboro;

            if (CaptionFont == null)
                CaptionFont = this.Font;

            CaptionColor = Color.LightGray;

            tsTicks = 7;

            Caption = DemoProfiles.AltanticS20.Description;
            SetProfile(DemoProfiles.AltanticS20.Profile);
            
        }

        #endregion

        #region Methods

        public void SetProfile(TSProfilePoint[] profile)
        {
            tsp = new TSProfilePoint[profile.Length];
            sVelocity = new float[profile.Length];
            Array.Copy(profile, tsp, profile.Length);

            Zmin = 0;
            Zmax = tsp[tsp.Length - 1].Z;

            zRange = Convert.ToSingle(Zmax);

            double p = PHX.PHX_ATM_PRESSURE_MBAR;
            double tmax = tsp[0].T;
            double tmin = tmax;
            double smax = tsp[0].S;
            double smin = smax;
            double vmin = PHX.Speed_of_sound_UNESCO_calc(tmax, p, smax);
            double vmax = vmin;
            double v;
            sVelocity[0] = Convert.ToSingle(vmax);

            for (int i = 1; i < tsp.Length; i++)
            {
                if (tsp[i].T > tmax)
                    tmax = tsp[i].T;

                if (tsp[i].T < tmin)
                    tmin = tsp[i].T;

                if (tsp[i].S > smax)
                    smax = tsp[i].S;

                if (tsp[i].S < smin)
                    smin = tsp[i].S;

                p = PHX.Pressure_by_depth_calc(tsp[i].Z, PHX.PHX_ATM_PRESSURE_MBAR, PHX.PHX_FWTR_DENSITY_KGM3, PHX.PHX_GRAVITY_ACC_MPS2);
                v = PHX.Speed_of_sound_UNESCO_calc(tsp[i].T, p, tsp[i].S);

                sVelocity[i] = Convert.ToSingle(v);

                if (v < vmin)
                    vmin = v;

                if (v > vmax)
                    vmax = v;
            }

            Tmax = tmax;
            Tmin = tmin;
            Smax = smax;
            Smin = smin;
            VMin = vmin;
            VMax = vmax;

            tRange = Convert.ToSingle(Math.Abs(Tmax - Tmin));
            sRange = Convert.ToSingle(Math.Abs(Smax - Smin));
            vRange = Convert.ToSingle(Math.Abs(VMax - VMin));
            
            tStep = tRange / tsTicks;
            sStep = sRange / tsTicks;
            vStep = vRange / tsTicks;

            if (tsp.Length <= 30)
                ZTicks = tsp.Length;
            else
            {
                ZTicks = 10;
            }

            ZStep = Utils.FitAxisStepByRange(Zmax - Zmin);

            ProfileChangedEvent.Rise(this, new EventArgs());
        }

        public TSProfilePoint[] GetProfile()
        {
            TSProfilePoint[] result = new TSProfilePoint[tsp.Length];
            Array.Copy(tsp, result, tsp.Length);
            return result;
        }       

        #endregion

        #region Handlers

        private void VProfileView_Paint(object sender, PaintEventArgs e)
        {
            if (!e.ClipRectangle.IsEmpty)
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                var captionSize = e.Graphics.MeasureString(Caption, CaptionFont);
                var zaxisLblMaxSize = e.Graphics.MeasureString(Zmax.ToString(), AxisLblFont);

                float graphBorderLeft = zaxisLblMaxSize.Width + axisTickSize + zaxisLblMaxSize.Height;
                float graphBorderTop = captionSize.Height + zaxisLblMaxSize.Height + axisTickSize;

                string taxislbl = "t, °C";
                var taxislblSize = e.Graphics.MeasureString(taxislbl, AxisLblFont);
                string saxislbl = "s, PSU";
                var saxislblSize = e.Graphics.MeasureString(saxislbl, AxisLblFont);
                var axisLblMaxWidth = Math.Max(taxislblSize.Width, saxislblSize.Width);
                axisLblMaxWidth = Math.Max(axisLblMaxWidth, zaxisLblMaxSize.Width);

                graphBorder = new RectangleF(graphBorderLeft, graphBorderTop,
                    this.Width - this.Padding.Left - this.Padding.Right - graphBorderLeft - axisLblMaxWidth,
                    this.Height - this.Padding.Top - this.Padding.Bottom - graphBorderTop - zaxisLblMaxSize.Height);

                float zscale = graphBorder.Height / Convert.ToSingle(zRange);
                float tscale = graphBorder.Width / Convert.ToSingle(tRange);
                float sscale = graphBorder.Width / Convert.ToSingle(sRange);
                float vscale = graphBorder.Width / Convert.ToSingle(vRange);

                e.Graphics.DrawRectangle(axisPen, graphBorder.Left, graphBorder.Top, graphBorder.Width, graphBorder.Height);

                e.Graphics.DrawString(Caption, CaptionFont, captionBrush,
                    graphBorder.Left + graphBorder.Width / 2 - captionSize.Width / 2,
                    graphBorder.Top - captionSize.Height - zaxisLblMaxSize.Height);

                float z, z1;
                float x = graphBorder.Left;
                
                string lbl = "Z, m";
                var lblSize = e.Graphics.MeasureString(lbl, AxisLblFont);
                e.Graphics.TranslateTransform(
                    graphBorder.Left - axisTickSize - zaxisLblMaxSize.Width - lblSize.Height,
                    graphBorder.Top + graphBorder.Height / 2 - lblSize.Width / 2);
                e.Graphics.RotateTransform(-90);
                e.Graphics.DrawString(lbl, AxisLblFont, axisLblBrush, 0, 0);
                e.Graphics.RotateTransform(90);
                e.Graphics.TranslateTransform(
                    graphBorder.Left - axisTickSize - zaxisLblMaxSize.Width - lblSize.Height,
                    -(graphBorder.Top + graphBorder.Height / 2 - lblSize.Width / 2));

                
                float zStep = Convert.ToSingle(ZStep);
                z = zStep;
                float za;
                while (z <= Zmax - zStep / 2)
                {
                    za = graphBorder.Top + z * zscale;
                    e.Graphics.DrawLine(axisPen, x, za, x - axisTickSize, za);
                    lbl = string.Format(CultureInfo.InvariantCulture, "{0:F00}", z);
                    lblSize = e.Graphics.MeasureString(lbl, AxisLblFont);

                    e.Graphics.DrawString(lbl, AxisLblFont, axisLblBrush,
                        x - axisTickSize - lblSize.Width,
                        za - lblSize.Height / 2);

                    z += zStep;
                }

                lbl = string.Format(CultureInfo.InvariantCulture, "{0:F00}", Zmin);
                lblSize = e.Graphics.MeasureString(lbl, AxisLblFont);
                e.Graphics.DrawString(lbl, AxisLblFont, axisLblBrush,
                    x - axisTickSize - lblSize.Width,
                    graphBorder.Top - lblSize.Height / 2);

                lbl = string.Format(CultureInfo.InvariantCulture, "{0:F00}", Zmax);
                lblSize = e.Graphics.MeasureString(lbl, AxisLblFont);
                e.Graphics.DrawString(lbl, AxisLblFont, axisLblBrush,
                    x - axisTickSize - lblSize.Width,
                    graphBorder.Bottom - lblSize.Height / 2);

                for (int i = 0; i < tsp.Length; i++)
                {                    
                    z = graphBorder.Top + Convert.ToSingle(tsp[i].Z * zscale);                    

                    if (i < tsp.Length - 1)
                    {
                        z1 = graphBorder.Top + Convert.ToSingle(tsp[i + 1].Z * zscale);
                        e.Graphics.DrawLine(tPen,
                            graphBorder.Left + Convert.ToSingle(tsp[i].T - Tmin) * tscale, z,
                            graphBorder.Left + Convert.ToSingle(tsp[i + 1].T - Tmin) * tscale, z1);

                        e.Graphics.DrawLine(sPen,
                            graphBorder.Left + Convert.ToSingle(tsp[i].S - Smin) * sscale, z,
                            graphBorder.Left + Convert.ToSingle(tsp[i + 1].S - Smin) * sscale, z1);

                        e.Graphics.DrawLine(vPen,
                            graphBorder.Left + Convert.ToSingle(sVelocity[i] - VMin) * vscale, z,
                            graphBorder.Left + Convert.ToSingle(sVelocity[i + 1] - VMin) * vscale, z1);
                    }
                }                

                for (int i = 0; i < tsTicks; i++)
                {
                    x = graphBorder.Left + i * graphBorder.Width / tsTicks;

                    lbl = string.Format(CultureInfo.InvariantCulture, "{0:F01}", Tmin + i * tStep);
                    lblSize = e.Graphics.MeasureString(lbl, AxisLblFont);
                    e.Graphics.DrawString(lbl, AxisLblFont, axisLblBrush,
                        x - lblSize.Width / 2, graphBorder.Top - axisTickSize - lblSize.Height);

                    lbl = string.Format(CultureInfo.InvariantCulture, "{0:F01}", Smin + i * sStep);
                    lblSize = e.Graphics.MeasureString(lbl, AxisLblFont);
                    e.Graphics.DrawString(lbl, AxisLblFont, axisLblBrush,
                        x - lblSize.Width / 2, graphBorder.Bottom + axisTickSize);

                    e.Graphics.DrawLine(axisPen,
                        x, graphBorder.Top,
                        x, graphBorder.Top - axisTickSize);

                    e.Graphics.DrawLine(axisPen,
                        x, graphBorder.Bottom,
                        x, graphBorder.Bottom + axisTickSize);
                }

                e.Graphics.DrawString(taxislbl, AxisLblFont, tempBrush,
                    graphBorder.Right + this.Padding.Right,
                    graphBorder.Top - axisTickSize - taxislblSize.Height);

                e.Graphics.DrawString(saxislbl, AxisLblFont, styBrush,
                    graphBorder.Right + this.Padding.Right,
                    graphBorder.Bottom + axisTickSize);

            }
        }

        private void VProfileView_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        #endregion

        #region Events

        public EventHandler ProfileChangedEvent;

        #endregion
    }
}
