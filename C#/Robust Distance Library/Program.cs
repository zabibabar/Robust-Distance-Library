using System;
using System.Collections.Generic;

namespace Robust_Distance_Library
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            PVector v3 = new PVector(10, 3);
            PVector v2 = new PVector(7, 6);
            PVector v1 = new PVector(4, 3);
            PVector v0 = new PVector(0, 0);

            Edge e1 = new Edge(v3, v2);
            Edge e2 = new Edge(v0, v1);


            List<PVector> arr = new List<PVector> { v2, v3 };
            List<PVector> arr1 = new List<PVector> { v0, v1 };
            List<PVector> arr2 = new List<PVector> { v1, v2, v3 };

            Polygon poly = new Polygon(arr);
            Polygon poly1 = new Polygon(arr1);
            Polygon poly2 = new Polygon(arr2);

            List<Polygon> polys = new List<Polygon> { poly, poly1 };

            Console.WriteLine(DistanceCalculator.DistanceFromPolygonList(polys));
            Console.WriteLine(DistanceCalculator.DistanceFromEdgeToEdge(e1, e2));
            Console.WriteLine(DistanceCalculator.DistanceFromPointToEdge(v0, e1));
            Console.WriteLine(DistanceCalculator.DistanceFromPointToPoint(v1, v3));
            Console.WriteLine(DistanceCalculator.DistanceFromPointToPolygon(v1, poly2));
            Console.WriteLine(DistanceCalculator.DistanceFromEdgeToPolygon(e2, poly2));


        }
    }
}
