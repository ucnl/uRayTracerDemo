using System;
using System.Collections.Generic;

namespace uRayTracerDemo.uRays
{
    public class Ray : IReadOnlyList<RayPoint>
    {
        #region Properties

        List<RayPoint> rayPoints;

        public double Theta0_rad { get; private set; }
        public double Theta_rad { get; private set; }
        public double Z0_m { get; private set; }
        public double Path_m { get; private set; }
        public double ZMax_m { get; private set; }

        double prevTheta_deg_valid;

        Func<double, double> getSoundSpeed;

        public static double EtaSurface = 0.3;
        public static double EtaBottom = 0.1;

        public double XMax_m
        {
            get
            {
                return rayPoints[rayPoints.Count - 1].X_m;
            }
        }

        double cPrev;
        double c;

        #endregion

        #region Constructor

        public Ray(double z0_m, double zMax_m, double theta0_deg, Func<double, double> soundSpeedVsZ)
        {
            if (soundSpeedVsZ == null)
                throw new ArgumentNullException("soundSpeedVsZ");

            getSoundSpeed = soundSpeedVsZ;

            Z0_m = z0_m;
            ZMax_m = zMax_m;
            Theta0_rad = theta0_deg * Math.PI / 180;

            if ((Theta0_rad >= 0) && (Theta0_rad < 0.002))
                Theta0_rad = 0.002;
            else if ((Theta0_rad <= 0) && (Theta0_rad > -0.002))
                Theta0_rad = -0.002;

            Theta_rad = Theta0_rad;
            prevTheta_deg_valid = Theta_rad;
            Path_m = 0;
            rayPoints = new List<RayPoint>();

            cPrev = getSoundSpeed(z0_m);

            rayPoints.Add(new RayPoint(0, Z0_m, 1));
        }

        #endregion

        #region Methods

        public RayPoint Step(double dZ)
        {
            double z = rayPoints[rayPoints.Count - 1].Z_m;
            double x = rayPoints[rayPoints.Count - 1].X_m;
            double e = rayPoints[rayPoints.Count - 1].E;

            double theta_sign = Theta_rad > 0 ? 1 : -1;
            z += (dZ * theta_sign);

            if (z > ZMax_m)
            {
                if (z >= ZMax_m)
                {
                    Theta_rad = -Theta_rad;
                    theta_sign = -theta_sign;
                    z = ZMax_m * 2 - z;
                    e *= EtaBottom;
                    // bottom reflection
                }
            }
            else
            {
                if (z <= 0)
                {
                    Theta_rad = -Theta_rad;
                    theta_sign = -theta_sign;
                    z = -z;
                    e *= EtaSurface;
                    // surface reflection
                }
            }
            
            double rsn = dZ / Math.Abs(Math.Sin(Theta_rad));            
            double drn = Math.Sqrt(rsn * rsn - dZ * dZ);
            Path_m += rsn;
            x += drn;

            c = getSoundSpeed(z);
                        
            double cosTheta = Math.Cos(Theta_rad);
            double recipSinTheta = 1.0 / Math.Sin(Theta_rad);
            double cncp = cosTheta * c / cPrev;

            if ((Math.Abs(cncp) <= 1) && (!double.IsInfinity(recipSinTheta)))
            {
                prevTheta_deg_valid = Theta_rad;
                Theta_rad = theta_sign * Math.Acos(cncp);
            }
            else
            {
                Theta_rad = -prevTheta_deg_valid;
            }
           
            cPrev = c;

            RayPoint newPoint = new RayPoint(x, z, e);
            rayPoints.Add(newPoint);

            return newPoint;
        }

        #endregion

        #region IReadOnlyList

        public RayPoint this[int index]
        {
            get { return rayPoints[index]; }
        }

        public int Count
        {
            get { return rayPoints.Count; }
        }

        public IEnumerator<RayPoint> GetEnumerator()
        {
            return rayPoints.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return rayPoints.GetEnumerator();
        }

        #endregion
    }
}
