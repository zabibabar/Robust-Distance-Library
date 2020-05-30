using System;
using System.Collections.Generic;
using System.Text;

namespace Robust_Distance_Library
{
    public class Polygon
    {
        public List<PVector> Points { get; set; }

        public Polygon(List<PVector> points)
        {
            Points = points;
        }

        public Polygon()
        {
        }

        public void AddPoint(PVector p)
        {
            Points.Add(p);
        }

        public bool PointInsidePolygon(PVector p)
        {
            int intersectionCount = 0;
            int N = Points.Count;
            Edge pEdge = new Edge(p, new PVector(float.MaxValue, float.MaxValue));
            for (int i = 0; i < N; i++)
            {
                Edge edge = new Edge(Points[i], Points[(i + 1)% N]);
                if (pEdge.IntersectionTest(edge)) intersectionCount++;
            }
            if (intersectionCount % 2 == 1) return true;
            return false;
        }
        
    }
}
