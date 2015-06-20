using System;

namespace Lab1
{
    public class Triangle
    {
        private double _c;
        private double _a;
        private double _b;

        public void SetSides(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new FormatException("Length of side should be greater than 0");
            }
            CheckSides(a, b, c);
            CheckSides(b, a, c);
            CheckSides(c, a, b);
            this._a = a;
            this._b = b;
            this._c = c;
        }

        public double Area()
        {
            var p = (_a + _b + _c) / 2;

            return Math.Sqrt(p * (p - _a) * (p - _b) * (p - _c));
        }

        private static void CheckSides(double a, double b, double c)
        {
            if (a >= b + c)
            {
                throw new ArgumentException("Triangle does not exist: one side is greater than or equal to the sum of the other two");
            }
        }
    }
}
