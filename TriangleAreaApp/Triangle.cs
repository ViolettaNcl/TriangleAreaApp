using System;

namespace TriangleAreaApp
{
    public class Triangle
    {
        public static double CalculateArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0 || a + b <= c || a + c <= b || b + c <= a)
                throw new ArgumentException("Invalid triangle sides");

            double s = (a + b + c) / 2;
            return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        }

        public static double CalculateArea((double, double) p1, (double, double) p2, (double, double) p3)
        {
            return Math.Abs((p1.Item1 * (p2.Item2 - p3.Item2) +
                             p2.Item1 * (p3.Item2 - p1.Item2) +
                             p3.Item1 * (p1.Item2 - p2.Item2)) / 2.0);
        }
    }
}
