using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using uRayTracerDemo.uRays;

namespace uRayTracerDemo
{
    public partial class TraceView : UserControl
    {
        #region Properties

        RectangleF graphBorder;
        public int tsTicks { get; private set; }
        int vTickPeriod = 1;

        public int ZTicks { get; private set; }
        public double ZStep { get; private set; }

        public double Xmax { get; set; }
        public double Xmin { get; set; }
        public double Zmax { get; set; }
        public double Zmin { get; set; }

        List<List<RayPoint>> rays;

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

        Color rayColor;
        Brush rayBrush;
        Pen rayPen;

        float graphPenWidth = 1.0f;

        public float GraphPenWidth
        {
            get { return graphPenWidth; }
            set
            {
                rayPen = new Pen(rayColor, graphPenWidth);
            }
        }

        public Color RayGraphColor
        {
            get { return rayColor; }
            set
            {
                rayColor = value;
                rayPen = new Pen(rayColor, graphPenWidth);
                rayBrush = new SolidBrush(rayColor);
            }
        }

        #endregion        

        float xStep;

        #endregion

        #region Constructor

        public TraceView()
        {
            InitializeComponent();

            if (AxisLblFont == null)
                AxisLblFont = this.Font;

            AxisColor = Color.Gainsboro;

            if (CaptionFont == null)
                CaptionFont = this.Font;

            CaptionColor = Color.LightGray;

            tsTicks = 7;

            Zmax = 5600;
            Zmin = 0;
            Xmax = 8000;
            Xmin = 0;
            ZStep = 1000;
            xStep = 1000;

            rays = new List<List<RayPoint>>();
        }

        #endregion

        #region Methods

        public void ClearRays()
        {
            rays.Clear();
        }

        public void SetRay(IEnumerable<RayPoint> ray)
        {
            List<RayPoint> rayPoints = new List<RayPoint>();
            foreach (var rayPoint in ray)
            {
                rayPoints.Add(rayPoint);
            }

            rays.Add(rayPoints);
        }

        #endregion

        #region Handlers

        private void TraceView_Paint(object sender, PaintEventArgs e)
        {
            if (!e.ClipRectangle.IsEmpty)
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                var captionSize = e.Graphics.MeasureString(Caption, CaptionFont);
                var axisLblMaxSize = e.Graphics.MeasureString(Zmax.ToString(), AxisLblFont);

                float graphBorderLeft = axisLblMaxSize.Width + axisTickSize + axisLblMaxSize.Height;
                float graphBorderTop = captionSize.Height + axisLblMaxSize.Height + axisTickSize;

                graphBorder = new RectangleF(graphBorderLeft, graphBorderTop,
                    this.Width - this.Padding.Left - this.Padding.Right - graphBorderLeft - axisLblMaxSize.Width,
                    this.Height - this.Padding.Top - this.Padding.Bottom - graphBorderTop - axisLblMaxSize.Height);

                float zscale = graphBorder.Height / Convert.ToSingle(Math.Abs(Zmax - Zmin));
                float xscale = graphBorder.Width / Convert.ToSingle(Math.Abs(Xmax - Xmin));


                #region Draw rays

                float x, z;
                foreach (var ray in rays)
                {
                    //float x_prev = graphBorder.Left + Convert.ToSingle(ray[0].X_m * xscale);
                    //float z_prev = graphBorder.Top + Convert.ToSingle(ray[0].Z_m * xscale);

                    foreach (var rayPoint in ray)
                    {
                        if (!double.IsNaN(rayPoint.X_m))
                        {
                            x = graphBorder.Left + Convert.ToSingle(rayPoint.X_m * xscale);
                            z = graphBorder.Top + Convert.ToSingle(rayPoint.Z_m * zscale);
                            rayPen.Color = Color.FromArgb(Convert.ToInt32(rayPoint.E * 127), rayColor);

                            //e.Graphics.DrawLine(rayPen, x_prev, z_prev, x, z);
                            //x_prev = x;
                            //z_prev = z;

                            e.Graphics.DrawRectangle(rayPen, x - 1, z - 1, 2, 2);
                        }
                    }
                }

                #endregion
                
                e.Graphics.DrawRectangle(axisPen, graphBorder.Left, graphBorder.Top, graphBorder.Width, graphBorder.Height);

                e.Graphics.DrawString(Caption, CaptionFont, captionBrush,
                    graphBorder.Left + graphBorder.Width / 2 - captionSize.Width / 2,
                    graphBorder.Top - captionSize.Height - axisLblMaxSize.Height);

                float z1;
                x = graphBorder.Left;

                string lbl = "Z, m";
                var lblSize = e.Graphics.MeasureString(lbl, AxisLblFont);
                e.Graphics.TranslateTransform(
                    graphBorder.Left - axisTickSize - axisLblMaxSize.Width - lblSize.Height,
                    graphBorder.Top + graphBorder.Height / 2 - lblSize.Width / 2);
                e.Graphics.RotateTransform(-90);
                e.Graphics.DrawString(lbl, AxisLblFont, axisLblBrush, 0, 0);
                e.Graphics.RotateTransform(90);
                e.Graphics.TranslateTransform(
                    graphBorder.Left - axisTickSize - axisLblMaxSize.Width - lblSize.Height,
                    -(graphBorder.Top + graphBorder.Height / 2 - lblSize.Width / 2));


                float zStep = Convert.ToSingle(Utils.FitAxisStepByRange(Zmax - Zmin));
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


                xStep = Convert.ToSingle(Utils.FitAxisStepByRange(Xmax - Xmin));
                for (int i = 0; i < tsTicks; i++)
                {
                    x = graphBorder.Left + i * xStep * xscale;

                    lbl = string.Format(CultureInfo.InvariantCulture, "{0:F01}", Xmin + i * xStep);
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
                
                lbl = "x, m";
                lblSize = e.Graphics.MeasureString(lbl, AxisLblFont);
                e.Graphics.DrawString(lbl, AxisLblFont, axisLblBrush,
                    graphBorder.Right + this.Padding.Right,
                    graphBorder.Bottom - lblSize.Height);

            }
        }

        private void TraceView_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        #endregion
    }
}
