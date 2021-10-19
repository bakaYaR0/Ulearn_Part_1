using System;

namespace AngryBirds
{
	public static class AngryBirdsTask
	{
		public static double FindSightAngle(double v, double distance)
		{
			double g = 9.8;

			return Math.Asin((distance * g / Math.Pow(v, 2))) / 2;
		}
	}
}
