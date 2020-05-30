using System;
using System.Collections.Generic;
using System.Text;

namespace Robust_Distance_Library
{
    public class PVector
    {
        public double X { get; set; }
        public double Y { get; set; }

        public PVector(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double Dot(PVector v)
        {
            return (X * v.X + Y * v.Y);
        }

        public double Dist(PVector v)
        {
            double distSquared = Math.Pow(X - v.X, 2) + Math.Pow(Y - v.Y, 2);
            return Math.Sqrt(distSquared);
        }

        public PVector Add(PVector v)
        {
            return new PVector(X + v.X, Y + v.Y);
        }

        public PVector Subtract(PVector v)
        {
            return new PVector(X - v.X, Y - v.Y);
        }

        public double Cross(PVector v)
        {
            return X * v.Y - v.X * Y;
        }

        public static double Dist(PVector v1, PVector v2)
        {
            double distSquared = Math.Pow(v1.X - v2.X, 2) + Math.Pow(v1.Y - v2.Y, 2);
            return Math.Sqrt(distSquared);
        }

        public static double Dot(PVector v1, PVector v2)
        {
            return (v1.X * v2.X + v1.Y * v2.Y);
        }

        public static PVector Add(PVector v1, PVector v2)
        {
            return new PVector(v1.X + v2.X, v1.Y + v2.Y);
        }

        public static PVector Subtract(PVector v1, PVector v2)
        {
            return new PVector(v1.X - v2.X, v1.Y - v2.Y);
        }

        public static double Cross(PVector v1, PVector v2)
        {
            return v1.X * v2.Y - v2.X * v1.Y;
        }

    }
}
