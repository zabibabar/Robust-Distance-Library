using System;
using System.Collections.Generic;
using System.Text;

namespace Robust_Distance_Library
{
    public class Edge
    {
        public PVector EndPoint1 { get; set; }
        public PVector EndPoint2 { get; set; }

        public Edge(PVector endPoint1, PVector endPoint2)
        {
            EndPoint1 = endPoint1;
            EndPoint2 = endPoint2;
        }

        public double DistanceSquared()
        {
            return Math.Pow(EndPoint1.X - EndPoint2.X, 2) + Math.Pow(EndPoint1.Y - EndPoint2.Y, 2);
        }
        public bool IntersectionTest(Edge other)
        {
            PVector v1 = PVector.Subtract(other.EndPoint1, EndPoint1);
            PVector v2 = PVector.Subtract(EndPoint2, EndPoint1);
            PVector v3 = PVector.Subtract(other.EndPoint2, EndPoint1);

            double z1 = v1.Cross(v2);
            double z2 = v2.Cross(v3);

            if ((z1 * z2) < 0) return false;

            PVector v4 = PVector.Subtract(EndPoint1, other.EndPoint1);
            PVector v5 = PVector.Subtract(other.EndPoint2, other.EndPoint1);
            PVector v6 = PVector.Subtract(EndPoint2, other.EndPoint1);

            double z3 = v4.Cross(v5);
            double z4 = v5.Cross(v6);

            if ((z3 * z4 < 0)) return false;

            return true;
        }
        
    }
}
