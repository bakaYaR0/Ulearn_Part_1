using System;

namespace DistanceTask
{
	public static class DistanceTask
	{
		// Расстояние от точки (x, y) до отрезка с координатами (ax, ay), (bx, by)
		public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
		{
            // Сохраним разности для упрощения
            double A = x - ax;
            double B = x - bx;
            double C = y - ay;
            double D = y - by;
            double E = ax - bx;
            double F = ay - by;
            double G = bx - ax;
            double H = by - ay;

            if (ax == bx && ay == by)
                return Math.Sqrt(A * A + C * C);
            else if ((A * G + C * H) < 0 || (B * E + D * F) < 0)
                return Math.Min(Math.Sqrt(A * A + C * C), Math.Sqrt(B * B + D * D));
            else
               return Math.Abs(G * C - H * A) / Math.Sqrt(G * G + H * H);
        }
    }
}