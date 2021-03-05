using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uRayTracerDemo.uRays
{
    public struct RayPoint
    {
        #region Properties

        public double X_m;
        public double Z_m;
        public double E;

        #endregion

        #region Constructor

        public RayPoint(double x, double z, double e)
        {
            X_m = x;
            Z_m = z;
            E = e;
        }

        #endregion
    }
}
