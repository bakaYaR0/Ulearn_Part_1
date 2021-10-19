using System;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace RefactorMe
{
    class Drawer
    {
        static float x, y;
        static Graphics graphics;

        public static void Initialize(Graphics newGraphics)
        {
            graphics = newGraphics;
            graphics.SmoothingMode = SmoothingMode.None;
            graphics.Clear(Color.Black);
        }

        public static void SetPosition(float x0, float y0)
        {x = x0; y = y0;}

        public static void MakeIt(Pen pen, double length, double angle)
        {
            //Делает шаг длиной length в направлении angle и рисует пройденную траекторию
            var x1 = (float)(x + length * Math.Cos(angle));
            var y1 = (float)(y + length * Math.Sin(angle));
            graphics.DrawLine(pen, x, y, x1, y1);
            x = x1;
            y = y1;
        }

        public static void Change(double length, double angle)
        {
            x = (float)(x + length * Math.Cos(angle)); 
            y = (float)(y + length * Math.Sin(angle));
        }
    }

    public class ImpossibleSquare
    {
        const double Degrees0 = 0;
        const double Degrees45 = Math.PI / 4;
        const double Degrees90 = Math.PI / 2;
        const double Degrees135 = 3 * Math.PI / 4;
        const double Degrees180 = Math.PI;
        const double Degrees225 = 5 * Math.PI / 4;
        const double Degrees270 = 3 * Math.PI / 2;
        const double Degrees315 = 7 * Math.PI / 4;
        const double Degrees360 = 2 * Math.PI;


        public static void Draw(int width, int height, double rotationAngle, Graphics graphics)
        {
            // ugolPovorota пока не используется, но будет использоваться в будущем
            Drawer.Initialize(graphics);

            var size = Math.Min(width, height);

            var diagonal_length = Math.Sqrt(2) * (size * 0.375f + size * 0.04f) / 2;
            var x0 = (float)(diagonal_length * Math.Cos(Degrees225)) + width / 2f;
            var y0 = (float)(diagonal_length * Math.Sin(Degrees225)) + height / 2f;

            Drawer.SetPosition(x0, y0);

            //Рисуем 1-ую сторону
            DrawSide1(size);

            //Рисуем 2-ую сторону
            DrawSide2(size);

            //Рисуем 3-ю сторону
            DrawSide3(size);

            //Рисуем 4-ую сторону
            DrawSide4(size);
        }

        public static void DrawSide1(double size)
        {
            Drawer.MakeIt(Pens.Yellow, size * 0.375f, 0);
            Drawer.MakeIt(Pens.Yellow, size * 0.04f * Math.Sqrt(2), Degrees45);
            Drawer.MakeIt(Pens.Yellow, size * 0.375f, Degrees180);
            Drawer.MakeIt(Pens.Yellow, size * 0.375f - size * 0.04f, Degrees90);

            Drawer.Change(size * 0.04f, -Math.PI);
            Drawer.Change(size * 0.04f * Math.Sqrt(2), Degrees135);
        }

        public static void DrawSide2(double size)
        {
            Drawer.MakeIt(Pens.Yellow, size * 0.375f, -Degrees90);
            Drawer.MakeIt(Pens.Yellow, size * 0.04f * Math.Sqrt(2), -Degrees45);
            Drawer.MakeIt(Pens.Yellow, size * 0.375f, Degrees90);
            Drawer.MakeIt(Pens.Yellow, size * 0.375f - size * 0.04f, Degrees0);

            Drawer.Change(size * 0.04f, -Degrees270);
            Drawer.Change(size * 0.04f * Math.Sqrt(2), Degrees45);
        }

        public static void DrawSide3(double size)
        {
            Drawer.MakeIt(Pens.Yellow, size * 0.375f, Degrees180);
            Drawer.MakeIt(Pens.Yellow, size * 0.04f * Math.Sqrt(2), Degrees225);
            Drawer.MakeIt(Pens.Yellow, size * 0.375f, Degrees360);
            Drawer.MakeIt(Pens.Yellow, size * 0.375f - size * 0.04f, Degrees270);

            Drawer.Change(size * 0.04f, Degrees0);
            Drawer.Change(size * 0.04f * Math.Sqrt(2), Degrees315);
        }

        public static void DrawSide4(double size)
        {
            Drawer.MakeIt(Pens.Yellow, size * 0.375f, Math.PI / 2);
            Drawer.MakeIt(Pens.Yellow, size * 0.04f * Math.Sqrt(2), Degrees135);
            Drawer.MakeIt(Pens.Yellow, size * 0.375f, Degrees270);
            Drawer.MakeIt(Pens.Yellow, size * 0.375f - size * 0.04f, Degrees180);

            Drawer.Change(size * 0.04f, -Degrees90);
            Drawer.Change(size * 0.04f * Math.Sqrt(2), Degrees225);
        }
    }
}
