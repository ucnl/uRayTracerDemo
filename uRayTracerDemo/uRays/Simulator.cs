using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCNLPhysics;

namespace uRayTracerDemo.uRays
{
    public struct VSSPPoint
    {
        public double Z;
        public double V;

        public VSSPPoint(double z, double v)
        {
            Z = z;
            V = v;
        }
    }

    public class Simulator : IReadOnlyList<Ray>
    {
        #region Properties

        List<Ray> rays;

        public double surfaceReflectionCoefficient
        {
            get { return Ray.EtaSurface; }
            set { Ray.EtaSurface = value; }
        }

        public double bottonReflectionCoefficient
        {
            get { return Ray.EtaBottom; }
            set { Ray.EtaBottom = value; }
        }

        List<VSSPPoint> vssp;
        Dictionary<double, double> vssp_lookup;

        double profileZMax_m = double.NaN;
        public double ProfileZMax_m { get { return profileZMax_m; } }

        public double ProfileXMax_m { get; private set; }

        #endregion

        #region Constructor

        public Simulator()
        {
            rays = new List<Ray>();            
        }

        #endregion

        #region Methods

        private void BuildVSSP(TSProfilePoint[] tsProfile, double dZ)
        {
            if (tsProfile.Length < 2)
            {
                throw new ArgumentOutOfRangeException("tsProfile has to contain at least two points");
            }

            double zmax = tsProfile[tsProfile.Length - 1].Z;
            profileZMax_m = zmax;

            double z1 = tsProfile[0].Z;
            double t1 = tsProfile[0].T;
            double s1 = tsProfile[0].S;
            double rho0 = PHX.Water_density_calc(t1, PHX.PHX_ATM_PRESSURE_MBAR, s1);
            double p1 = PHX.Pressure_by_depth_calc(z1, PHX.PHX_ATM_PRESSURE_MBAR, rho0, PHX.PHX_GRAVITY_ACC_MPS2);            

            int p_idx = 1;
            double z2 = tsProfile[p_idx].Z;
            double t2 = tsProfile[p_idx].T;
            double s2 = tsProfile[p_idx].S;
            double p2 = PHX.Pressure_by_depth_calc(z2, PHX.PHX_ATM_PRESSURE_MBAR, rho0, PHX.PHX_GRAVITY_ACC_MPS2);

            double t;
            double p;
            double s;

            double z = 0;

            double v = PHX.Speed_of_sound_UNESCO_calc(t1, p1, s1);

            vssp = new List<VSSPPoint>();

            vssp_lookup = new Dictionary<double, double>();

            while (z < zmax)
            {                
                if (z > z2)
                {
                    p1 = p2;
                    t1 = t2;
                    s1 = s2;
                    z1 = z2;
                    p_idx = p_idx + 1;

                    z2 = tsProfile[p_idx].Z;
                    t2 = tsProfile[p_idx].T;
                    s2 = tsProfile[p_idx].S;
                    p2 = PHX.Pressure_by_depth_calc(z2, PHX.PHX_ATM_PRESSURE_MBAR, rho0, PHX.PHX_GRAVITY_ACC_MPS2);
                }

                t = PHX.Linterp(z1, t1, z2, t2, z);
                p = PHX.Linterp(z1, p1, z2, p2, z);
                s = PHX.Linterp(z1, s1, z2, s2, z);
                v = PHX.Speed_of_sound_UNESCO_calc(t, p, s);
                vssp.Add(new VSSPPoint(z, v));

                z += 0.1;
            }

            vssp_lookup = new Dictionary<double, double>();
        }

        private double GetSoundSpeed(double z_m)
        {
            if (vssp_lookup.ContainsKey(z_m))
                return vssp_lookup[z_m];
            else
            {

                int nearest_idx = 0;
                double v = vssp[nearest_idx].V;
                double delta_z = Math.Abs(z_m - vssp[nearest_idx].Z);

                for (int i = 1; i < vssp.Count; i++)
                {
                    if (Math.Abs(z_m - vssp[i].Z) < delta_z)
                    {
                        nearest_idx = i;
                        delta_z = Math.Abs(z_m - vssp[i].Z);
                    }
                }

                vssp_lookup.Add(z_m, vssp[nearest_idx].V);
                return vssp[nearest_idx].V;
            }
        }

        public void ApplyProfile(TSProfilePoint[] tsProfile, double dZ)
        {
            BuildVSSP(tsProfile, dZ);
        }

        public void Simulate(double thetaRange_deg, int numRays, double Z0_m, double dZ, double maxX_m, double maxPath_m)
        {
            if ((thetaRange_deg <= 0) || (thetaRange_deg >= 180))
                throw new ArgumentOutOfRangeException("thetaRange_deg should be in a range from 0° to 180° (exclusively)");

            if ((numRays <= 0) || (numRays > 1024))
                throw new ArgumentOutOfRangeException("numRays should be in a range from 1 to 1024 (inclusively)");
            
            if (vssp.Count == 0)
                throw new ArgumentOutOfRangeException("TS-Profile is empty");            

            if ((Z0_m < 0) || (Z0_m > profileZMax_m))
                throw new ArgumentOutOfRangeException(string.Format("Z0_m should be in a range from 0 to {0:F03} m accodring to the specified profile", profileZMax_m));

            ProfileXMax_m = maxX_m;

            rays.Clear();
            double dTheta_deg = thetaRange_deg / numRays;

            double theta_deg = -thetaRange_deg / 2;
            for (int i = 0; i < numRays; i++)
            {
                rays.Add(new Ray(Z0_m, profileZMax_m, theta_deg, GetSoundSpeed));
                theta_deg += dTheta_deg;                
            }            

            bool finished = false;
            while (!finished)
            {
                finished = true;
                foreach (var ray in rays)
                {
                    if ((ray.XMax_m < maxX_m) && (ray.Path_m < maxPath_m))
                    {
                        ray.Step(dZ);
                        finished = false;
                    }                    
                }
            }
        }

        public void Serialize(string fileName)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var ray in rays)
            {
                //sb.AppendFormat(CultureInfo.InvariantCulture, "# Ray: Z0 = {0:F03} m, theta0 = {1:F03}°, Path = {2:F03} m\r\n", ray.Z0_m, ray.Theta0_deg, ray.Path_m);
                foreach (var rayPoint in ray)
                {
                    sb.AppendFormat(CultureInfo.InvariantCulture, "{0:F03},{1:F03},{2:F03}\r\n", rayPoint.X_m, rayPoint.Z_m, rayPoint.E);
                }
            }

            File.WriteAllText(fileName, sb.ToString());
        }

        #endregion

        #region IReadOnlyList

        public Ray this[int index]
        {
            get { return rays[index]; }
        }

        public int Count
        {
            get { return rays.Count; }
        }

        public IEnumerator<Ray> GetEnumerator()
        {
            return rays.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return rays.GetEnumerator();
        }

        #endregion
    }
}
