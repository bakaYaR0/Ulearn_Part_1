using System;

namespace Rectangles
{
	public static class RectanglesTask
	{
		// Пересекаются ли два прямоугольника (пересечение только по границе также считается пересечением)
		public static bool AreIntersected(Rectangle r1, Rectangle r2)
		{
			int r1Right = r1.Left + r1.Width;
			int r2Right = r2.Left + r2.Width;
			int r1Bottom = r1.Top + r1.Height;
			int r2Bottom = r2.Top + r2.Height;
			// так можно обратиться к координатам левого верхнего угла первого прямоугольника: r1.Left, r1.Top

			// Если один из прямоугольников целиком слева
			if (r2Right < r1.Left || r1Right < r2.Left )
			{ 
				return false;
			}

			// Если один из прямоугольников целиком сверху
			if (r2Bottom < r1.Top || r1Bottom < r2.Top)
			{
				return false;
			}
			return true;
		}

		// Площадь пересечения прямоугольников
		public static int IntersectionSquare(Rectangle r1, Rectangle r2)
		{
			if (AreIntersected(r1, r2))
            {
				int r1Right = r1.Left + r1.Width;
				int r2Right = r2.Left + r2.Width;
				int r1Bottom = r1.Top + r1.Height;
				int r2Bottom = r2.Top + r2.Height;

				int dx = Math.Min(r1Right, r2Right) - Math.Max(r1.Left, r2.Left);
				int dy = Math.Min(r1Bottom, r2Bottom) - Math.Max(r1.Top, r2.Top);

				return dx * dy;
			}
			else 
				return 0;		
		}

		// Если один из прямоугольников целиком находится внутри другого — вернуть номер (с нуля) внутреннего.
		// Иначе вернуть -1
		// Если прямоугольники совпадают, можно вернуть номер любого из них.
		public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
		{
			int r1Right = r1.Left + r1.Width;
			int r2Right = r2.Left + r2.Width;
			int r1Bottom = r1.Top + r1.Height;
			int r2Bottom = r2.Top + r2.Height;

			if (r1.Top >= r2.Top && r1Bottom <= r2Bottom && r1Right <= r2Right && r1.Left >= r2.Left)
				return 0;
			else if (r1.Top <= r2.Top && r1Bottom >= r2Bottom && r1Right >= r2Right && r1.Left <= r2.Left)
				return 1;
			else
				return -1;
		}
	}
}