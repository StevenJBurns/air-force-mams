using System;
using System.Collections.Generic;

namespace MAMS
    {
    public class RoutePoint : System.ICloneable
        {
        private double x, y;
        
        public double X
            {
            get { return x; }
            set { x = value; }
            }

        public double Y
            {
            get { return y;}
            set { y = value;}
            }

        public RoutePoint()
            {
            x = 0.0;
            y = 0.0;
            }

        public RoutePoint(double newX, double newY)
            {
            x = newX;
            y = newY;
            }

        public object Clone()
            {
            return new RoutePoint(y, x);
            }

        }
    
    public class RouteLine : System.ICloneable
        {
        private RoutePoint p1, p2;
        private double a, b, c;

        public RoutePoint Point1
            {
            get { return p1;}
            set { p1 = value;}
            }

        public RoutePoint Point2
            {
            get { return p2;}
            set { p2 = value;}
            }
        
        public RouteLine()
            {
            }

        public RouteLine(RoutePoint P1, RoutePoint P2)
            {
            p1 = (RoutePoint)P1.Clone();
            p2 = (RoutePoint)P2.Clone();
            DefineRouteLine();
            }

        public object Clone()
            {
            return new RouteLine(p1, p2);
            }

        private void DefineRouteLine()
            {
            a = p2.Y - p1.Y;
            b = p1.X - p2.X;
            c = (a * p1.X) + (b * p1.Y);
            }

        public RoutePoint GetIntersectPoint(RouteLine line, bool LinesCross)
            {
            try
                {
                double D = (line.a * b) - (line.b * a);
                RoutePoint Intersect = new RoutePoint(((line.c * b) - (line.b * c)) / D, ((line.a * c) - (line.c * a)) / D);
                LinesCross = true;
                return Intersect;
                }
            catch
                {
                LinesCross = false;
                return new RoutePoint();
                }
            }

        public bool OnLine(RoutePoint point)
            {
            return System.Math.Abs((a * point.X) + (b * point.Y) - c) < 0.000000001;
            }

        public bool OnSegment(RoutePoint point)
            {
            if (!OnLine(point))
                {return false;}

            return  (System.Math.Min(p1.X, p2.X) <= point.X) &&
                    (System.Math.Max(p1.X, p2.X) >= point.X) && 
                    (System.Math.Min(p1.Y, p2.Y) <= point.Y) &&
                    (System.Math.Max(p1.Y, p2.Y) >= point.Y);
            }

        }

    public class Polygon //: System.ICloneable
        {
        private List<RoutePoint> PolygonPoints;

        public Polygon()
            {
            //PolygonPoints = new List<RoutePoint>(
            }

        public Polygon(List<RoutePoint> points)
            {
            PolygonPoints = points;
            }

        public bool IsSimplePolygon()
            {
            for (int i = 0; ; i++)
                {



                }

            }


        }
    
    }