using System;
using System.Collections.Generic;
using System.Text;

namespace Robust_Distance_Library
{
    public class DistanceCalculator
    {
        public static double DistanceFromPointToPoint(PVector p1, PVector p2)
        {
            PVector v1 = new PVector(p1.X, p1.Y);
            PVector v2 = new PVector(p2.X, p2.Y);

            return PVector.Dist(v1, v2);
        }

        public static double DistanceFromPointToEdge(PVector p, Edge e)
        {
            double edgeDist2 = e.DistanceSquared();
            if (edgeDist2 == 0)
            {
                return DistanceFromPointToPoint(p, e.EndPoint1);
            }

            double t = ((p.X - e.EndPoint1.X) * (e.EndPoint2.X - e.EndPoint1.X) + (p.Y - e.EndPoint1.Y) * (e.EndPoint2.Y - e.EndPoint1.Y)) / edgeDist2;
            t = Math.Max(0, Math.Min(1, t));

            double x = e.EndPoint1.X + t * (e.EndPoint2.X - e.EndPoint1.X);
            double y = e.EndPoint1.Y + t * (e.EndPoint2.Y - e.EndPoint1.Y);

            double dx = x - p.X;
            double dy = y - p.Y;

            double dist = Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));
            return dist;
        }

        public static double DistanceFromPointToPolygon(PVector p, Polygon poly)
        {
            if (poly.Points.Count == 0) return 0;
            if (poly.PointInsidePolygon(p)) return 0;
            if (poly.Points.Count == 1) return DistanceFromPointToPoint(p, poly.Points[0]);

            double minDist = double.MaxValue;
            int N = poly.Points.Count;

            for (int i = 0; i < N; i++)
            {
                Edge e = new Edge(poly.Points[i], poly.Points[(i + 1) % N]);
                double dist = DistanceFromPointToEdge(p, e);
                if (dist < minDist) minDist = dist;
            }

            return minDist;
        }

        public static double DistanceFromEdgeToEdge(Edge e1, Edge e2)
        {

            if (e1.IntersectionTest(e2)) return 0;

            double distA = DistanceFromPointToEdge(e1.EndPoint1, e2);
            double distB = DistanceFromPointToEdge(e1.EndPoint2, e2);
            double distC = DistanceFromPointToEdge(e2.EndPoint1, e1);
            double distD = DistanceFromPointToEdge(e2.EndPoint2, e1);

            double[] dists = { distA, distB, distC, distD };

            double minDist = distA;

            foreach(double elem in dists){
                if (elem < minDist) minDist = elem;
            }

            return minDist;
        }

        public static double DistanceFromEdgeToPolygon(Edge e, Polygon poly)
        {
            if (poly.Points.Count == 0) return 0;
            if (poly.PointInsidePolygon(e.EndPoint1) && poly.PointInsidePolygon(e.EndPoint2)) return 0;
            if (poly.Points.Count == 1) return DistanceFromPointToEdge(poly.Points[0], e);

            double minDist = double.MaxValue; ;

            int N = poly.Points.Count;
            for (int i = 0; i < N; i++)
            {
                Edge e1 = new Edge(poly.Points[i], poly.Points[(i + 1) % N]);
                double dist = DistanceFromEdgeToEdge(e1, e);
                if (dist < minDist) minDist = dist;
            }

            return minDist;
        }

        public static double DistanceFromPolygonToPolygon(Polygon p1, Polygon p2)
        {

            if (p1.Points.Count == 0 || p2.Points.Count == 0) return 0;

            if (p1.Points.Count == 1)
            {
                return DistanceFromPointToPolygon(p1.Points[0], p2);
            }

            if (p2.Points.Count == 1)
            { 
                return DistanceFromPointToPolygon(p2.Points[0], p1);
            }

            double minDist = double.MaxValue;

            int N1 = p1.Points.Count;

            for (int i = 0; i < N1; i++)
            {
                Edge e1 = new Edge(p1.Points[i], p1.Points[(i + 1) % N1]);
                double dist = DistanceFromEdgeToPolygon(e1, p2);
                if (dist < minDist) minDist = dist;
            }

            return minDist;
        }

        public static double DistanceFromPolygonList(List<Polygon> polygons)
        {

            if (polygons.Count < 2) return 0;

            double minDist = double.MaxValue;
            int N = polygons.Count;

            for (int i = 0; i < N; i++)
            {
                for (int j = i + 1; j < N; j++)
                {
                    double dist = DistanceFromPolygonToPolygon(polygons[i], polygons[j]);
                    if (dist < minDist) minDist = dist;
                }
            }
            return minDist;
        }
    }
}
