using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using UCNLPhysics;
using uRayTracerDemo.uRays;

namespace uRayTracerDemo
{
    public partial class MainForm : Form
    {
        #region Properties

        Simulator simulator;

        double beamAngle
        {
            get { return Convert.ToDouble(beamAngleEdit.Value); }
            set { UIUtils.TrySetNEditValue(beamAngleEdit, value); }
        }

        int raysNum
        {
            get { return Convert.ToInt32(raysNumEdit.Value); }
            set { UIUtils.TrySetNEditValue(raysNumEdit, value); }
        }

        double dZ
        {
            get { return Convert.ToDouble(dZEdit.Value); }
            set { UIUtils.TrySetNEditValue(dZEdit, value); }
        }

        double ZTx
        {
            get { return Convert.ToDouble(zTxEdit.Value); }
            set { UIUtils.TrySetNEditValue(zTxEdit, value); }
        }

        double XMax
        {
            get { return Convert.ToDouble(xMaxEdit.Value); }
            set { UIUtils.TrySetNEditValue(xMaxEdit, value); }
        }

        double PathMax
        {
            get { return Convert.ToDouble(pathMaxEdit.Value); }
            set { UIUtils.TrySetNEditValue(pathMaxEdit, value); }
        }

        double etaBottom
        {
            get { return Convert.ToDouble(etaBottomEdit.Value); }
            set
            {
                UIUtils.TrySetNEditValue(etaBottomEdit, value);
            }
        }

        double etaSurface
        {
            get { return Convert.ToDouble(etaSurfaceEdit.Value); }
            set
            {
                UIUtils.TrySetNEditValue(etaSurfaceEdit, value);
            }
        }

        #endregion

        #region Constructor

        public MainForm()
        {
            InitializeComponent();

            simulator = new Simulator();
            ApplyProfile(DemoProfiles.PacificN39);
        }

        #endregion        

        #region Methods

        private void ApplyProfile(TSProfile tsProfile)
        {
            vProfileView.Caption = tsProfile.Description;
            vProfileView.SetProfile(tsProfile.Profile);
            vProfileView.Invalidate();

            simulator.ApplyProfile(tsProfile.Profile, dZ);

            zTxEdit.Maximum = Convert.ToDecimal(tsProfile.Profile[tsProfile.Profile.Length - 1].Z);

            traceView.ClearRays();
            traceView.Invalidate();            
        }

        #endregion

        #region Handlers

        #region UI

        #region mainToolStrip

        #region PROFILE

        private void demoProfileNorthernPacificBtn_Click(object sender, System.EventArgs e)
        {
            ApplyProfile(DemoProfiles.PacificN39);
        }

        private void demoProfileSouthernAtlanticBtn_Click(object sender, System.EventArgs e)
        {
            ApplyProfile(DemoProfiles.AltanticS20);            
        }

        private void demoProfileArcticBtn_Click(object sender, System.EventArgs e)
        {
            ApplyProfile(DemoProfiles.ArcticN89);
        }

        private void loadProfileBtn_Click(object sender, System.EventArgs e)
        {
            using (OpenFileDialog oDialog = new OpenFileDialog())
            {
                oDialog.Title = "Select a CSV-file containing TS-profile...";
                oDialog.Filter = "CSV (*.csv)|*.csv";

                if (oDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        var tsProfile = TSProfile.LoadFromFile(oDialog.FileName);

                        this.Text = string.Format("{0} - [{1}]({2})", Application.ProductName, tsProfile.Description, Path.GetFileName(oDialog.FileName));

                        ApplyProfile(tsProfile);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        #endregion

        private void runSimulationBtn_Click(object sender, System.EventArgs e)
        {
            parametersGroup.Enabled = false;

            Ray.EtaBottom = etaBottom;
            Ray.EtaSurface = etaSurface;

            simulator.Simulate(beamAngle, raysNum, ZTx, dZ, XMax, PathMax);

            parametersGroup.Enabled = true;

            traceView.Zmin = 0;
            traceView.Zmax = simulator.ProfileZMax_m;
            traceView.Xmin = 0;
            traceView.Xmax = simulator.ProfileXMax_m;

            traceView.ClearRays();

            foreach (var ray in simulator)
            {
                traceView.SetRay(ray);
            }

            traceView.Invalidate();
        }

        private void wwwBtn_Click(object sender, System.EventArgs e)
        {
            try
            {
                Process.Start("https://github.com/ucnl/uRayTracerDemo/");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion        

        private void profileBtn_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #endregion
    }
}
