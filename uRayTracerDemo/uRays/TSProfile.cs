using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UCNLPhysics;

namespace uRayTracerDemo.uRays
{
    public class TSProfile
    {
        public string Description;
        public double LatitudeDeg;
        public double LongitudeDeg;
        public TSProfilePoint[] Profile;

        public static char[] csep = new char[] { ',' };

        public TSProfile(string description, double latDeg, double lonDeg, IEnumerable<TSProfilePoint> pPoints)
        {
            LatitudeDeg = latDeg;
            LongitudeDeg = lonDeg;
            Description = description;

            List<TSProfilePoint> list = new List<TSProfilePoint>();
            foreach (var pPoint in pPoints)
                list.Add(pPoint);

            Profile = list.ToArray();
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0} ({1:F02}°, {2:F02}°)", Description, LatitudeDeg, LongitudeDeg);
        }

        public static TSProfile LoadFromFile(string fileName)
        {
            var lines = File.ReadAllLines(fileName);

            bool isVars = false;
            double lat = 0;
            double lon = 0;
            double t = 0;
            double s = 0;
            double z = 0;
            double lt = 0, ln = 0;
            string description = string.Empty;

            List<TSProfilePoint> points = new List<TSProfilePoint>();

            foreach (var line in lines)
            {
                if (!line.StartsWith("#-------"))
                {
                    if (isVars)
                    {
                        var splits = line.Split(csep);
                        if ((double.TryParse(splits[1], System.Globalization.NumberStyles.Any, CultureInfo.InvariantCulture, out z)) &&
                            (double.TryParse(splits[4], System.Globalization.NumberStyles.Any, CultureInfo.InvariantCulture, out t)) &&
                            (double.TryParse(splits[7], System.Globalization.NumberStyles.Any, CultureInfo.InvariantCulture, out s)))
                        {
                            points.Add(new TSProfilePoint(z, t, s));
                        }
                    }
                    else
                    {
                        if (line.StartsWith("Prof-Flag"))
                            isVars = true;
                        else
                        {
                            var splits = line.Split(",".ToCharArray());
                            if (line.StartsWith("Latitude"))
                            {
                                if (double.TryParse(splits[2], System.Globalization.NumberStyles.Any, CultureInfo.InvariantCulture, out lt))
                                    lat = lt;
                            }
                            else if (line.StartsWith("Longitude"))
                            {
                                if (double.TryParse(splits[2], System.Globalization.NumberStyles.Any, CultureInfo.InvariantCulture, out ln))
                                    lon = ln;
                            }
                            else if (line.StartsWith("NODC Cruise ID"))
                            {
                                description = splits[2].Trim();
                            }
                        }
                    }
                }
            }

            return new TSProfile(description, lat, lon, points);
        }
    }

    public static class DemoProfiles
    {
        public static TSProfile ArcticN89 = new TSProfile(
            "Arctic",
            89,
            0,
            new TSProfilePoint[]
            {
                new TSProfilePoint(  0, -1.8, 32.8 ),
                new TSProfilePoint(100, -1.1, 34.25 ),
                new TSProfilePoint(200,  1.1, 34.8 ),
                new TSProfilePoint(300,  1.3, 34.9 ),
                new TSProfilePoint(400,  1.1, 34.9 ),
                new TSProfilePoint(500, 0.75, 34.9 ),
                new TSProfilePoint(600,  0.4, 34.9 ),
                new TSProfilePoint(700,  0.2, 34.9 ),
                new TSProfilePoint(800, -0.1, 34.9 )
            });

        public static TSProfile PacificN39 = new TSProfile(
            "Northern Pacific",
            39,
            0,
            new TSProfilePoint[]
            {
                new TSProfilePoint(    0, 12.0, 33.8 ),
                new TSProfilePoint(  500, 7.0, 34.0  ),
                new TSProfilePoint( 1000, 3.0, 34.25 ),
                new TSProfilePoint( 1500, 2.5, 34.5  ),
                new TSProfilePoint( 2000, 2.0, 34.6  ),
                new TSProfilePoint( 2500, 1.9, 34.65 ),
                new TSProfilePoint( 3000, 1.8, 34.65 ),
                new TSProfilePoint( 3500, 1.8, 34.66 ),
                new TSProfilePoint( 4000, 1.8, 34.67 ),
                new TSProfilePoint( 4500, 1.8, 34.67 ),
                new TSProfilePoint( 5000, 1.8, 34.67 ),
                new TSProfilePoint( 5500, 1.9, 34.67 ),
                new TSProfilePoint( 6000, 1.9, 34.67 )
            });

        public static TSProfile AltanticS20 = new TSProfile(
            "Southern Atlantic",
            -20,
            153,
            new TSProfilePoint[]
            {
                new TSProfilePoint(0, 25.6, 37.2),
                new TSProfilePoint(200,	20.0, 36.2),
                new TSProfilePoint(400, 11.5, 35.0),
                new TSProfilePoint(600, 6.5, 34.4),
                new TSProfilePoint(800,	4.0, 34.4),
                new TSProfilePoint(1000, 3.0, 34.4),
                new TSProfilePoint(1200, 3.0, 34.7),
                new TSProfilePoint(1400, 3.0, 34.8),
                new TSProfilePoint(1600, 2.9, 34.9),
                new TSProfilePoint(1800, 2.8, 34.9),
                new TSProfilePoint(2000, 2.8, 34.9),
                new TSProfilePoint(2200, 2.7, 34.9),
                new TSProfilePoint(2400, 2.5, 34.9),
                new TSProfilePoint(2600, 2.4, 34.9),
                new TSProfilePoint(2800, 2.3, 34.9),
                new TSProfilePoint(3000, 2.2, 34.9),
                new TSProfilePoint(3200, 2.1, 34.8),
                new TSProfilePoint(3400, 2.1, 34.7),
                new TSProfilePoint(3600, 2.1, 34.7),
                new TSProfilePoint(3800, 2.0, 34.7),
                new TSProfilePoint(4000, 1.9, 34.7),
                new TSProfilePoint(4200, 1.8, 34.7),
                new TSProfilePoint(4400, 1.7, 34.7),
                new TSProfilePoint(4600, 1.6, 34.7),
                new TSProfilePoint(4800, 1.5, 34.7),
                new TSProfilePoint(5000, 1.3, 34.7),
                new TSProfilePoint(5200, 1.2, 34.7),
                new TSProfilePoint(5400, 1.1, 34.7),
                new TSProfilePoint(5600, 1.1, 34.7)
            });
    }
}
