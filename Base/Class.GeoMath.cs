using System;
using System.Collections.Generic;
using System.Text;

namespace MAMS
    {
    class GeoMath
        {
        const double WGS84_E2 = 0.006694379990197;
        const double WGS84_E4 = WGS84_E2 * WGS84_E2;
        const double WGS84_E6 = WGS84_E4 * WGS84_E2;
        const double MajorAxis = 6378137.0;
        const double MinorAxis = 6356752.314245;

        const double OriginLongitude = 3.0 / 180 * Math.PI;
        const double OriginLatitude = 0.0;

        const double FalseEasting = 500000;
        const double FalseNorthingN = 0.0;
        const double FalseNorthingS = 10000000;
        const double ScaleFactor = 0.9996;


        public void DMStoUTM(double latitude, double longitude, out double easting, out double northing, out int zone)
            {
            int zone_int = (int)(longitude / 6.0);

            if (longitude < 0)
                zone_int--;

            longitude -= (double)zone_int * 6.0;

            zone = zone_int + 31;
            longitude *= Math.PI / 180.0;
            latitude *= Math.PI / 180.0;

            double M = MajorAxis * m_calc(latitude);
            double OriginM = MajorAxis * m_calc(OriginLatitude);
            double A = (longitude - OriginLatitude) * Math.Cos(latitude);
            double A2 = A * A;
            double E2 = WGS84_E2 / (1 - WGS84_E2);
            double C = E2 * Math.Pow(Math.Cos(latitude), 2);
            double T = Math.Tan(latitude);
            T *= T;

            double v = MajorAxis / Math.Sqrt(1 - WGS84_E2 * Math.Pow(Math.Sin(latitude), 2));

            northing = ScaleFactor * (M - OriginM + v * Math.Tan(latitude) * (A2 / 2 + (5 - T + 9 * C + 4 * C * C) * A2 * A2 / 24 + (61 - 58 * T + T * T + 600 * C - 330 * E2) * A2 * A2 * A2 / 720));

            if (latitude < 0)
                northing += FalseNorthingS;

            easting = FalseEasting + ScaleFactor * v * (A + (1 - T + C) * A2 * A / 6 + (5 - 18 * T + T * T + 72 * C - 58 * E2) * A2 * A2 * A / 120);
            }

        private double m_calc(double lat)
            {
            return  (1 - WGS84_E2/4 - 3 * WGS84_E4 /64 - 5 * WGS84_E6/256) * lat - (3 * WGS84_E2/8 + 3 * WGS84_E4 /32 + 45 * WGS84_E6/1024) *Math.Sin(2*lat) + (15 * WGS84_E4/256 + 45 * WGS84_E6/1024) * Math.Sin(4*lat) - (35 * WGS84_E6/3072) * Math.Sin(6 * lat);

            }


        }
    }
