using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;

namespace WebApplicationApi.BL
{
    internal class CubicBezierFittingCalculator
    {
        private List<Point> data;

        public CubicBezierFittingCalculator(List<Point> data)
        {
            this.data = data;
        }

        private double t(int i)
        {
            return (double)(i - 1) / (data.Count - 1);
            // double s = 0.0, d = 0.0;
            //
            // for (int j = 1; j < data.Count; j++)
            // {
            //     if (j < i)
            //     {
            //         s += (data[j] - data[j - 1]).Length;
            //     }
            //     d += (data[j] - data[j - 1]).Length;
            // }
            // return s / d;
        }

        public void Calc(ref Point p1, ref Point p2)
        {
           
            double n = data.Count;
            Vector p0 = (Vector)data.First();
            Vector p3 = (Vector)data.Last();

            double a1 = 0.0, a2 = 0.0, a12 = 0.0;
            Vector c1 = new Vector(0.0, 0.0), c2 = new Vector(0.0, 0.0);
            for (int i = 1; i <= n; i++)
            {
                double ti = t(i), qi = 1 - ti;
                double ti2 = ti * ti, qi2 = qi * qi;
                double ti3 = ti * ti2, qi3 = qi * qi2;
                double ti4 = ti * ti3, qi4 = qi * qi3;
                a1 += ti2 * qi4;
                a2 += ti4 * qi2;
                a12 += ti3 * qi3;

                Vector pi = (Vector)data[i - 1];
                Vector m = pi - qi3 * p0 - ti3 * p3;
                c1 += ti * qi2 * m;
                c2 += ti2 * qi * m;
            }
            a1 *= 9.0;
            a2 *= 9.0;
            a12 *= 9.0;
            c1 *= 3.0;
            c2 *= 3.0;

            double d = a1 * a2 - a12 * a12;
            p1 = (Point)((a2 * c1 - a12 * c2) / d);
            p2 = (Point)((a1 * c2 - a12 * c1) / d);
        }
    }
}