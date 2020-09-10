using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.Optimization;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplicationApi.BL;

namespace MathNet
{
    public static class MathNetExt
    {
        /// <summary>
        /// Non-linear least-squares fitting the points (x,y) to an arbitrary function y : x -> f(p, x),
        /// returning its best fitting parameter p.
        /// https://github.com/mathnet/mathnet-numerics/issues/597
        /// http://kb.en-mat.com/Curve%20Fitting_%20Linear%20Regression.pdf
        /// </summary>
        public static double Curve(double[] x, double[] y, Func<double, double, double> f, double initialGuess, double tolerance = 1e-8, int maxIterations = 1000)
        {
            return FindMinimum.OfScalarFunction(p => Distance.Euclidean(Generate.Map(x, t => f(p, t)), y), initialGuess, tolerance, maxIterations);
        }

        public static MinimizationResult Curve(double[] x, double[] y, Func<Vector<double>, double, double> f, double[] initialGuess, double tolerance = 1e-8, int maxIterations = 1000)
        {
            return OfFunction((p) => SquareEuclidean(Generate.Map(x, t => f(p, t)), y), Vector<double>.Build.DenseOfArray(initialGuess), tolerance, maxIterations);
        }

        public static MinimizationResult OfFunction(Func<Vector<double>, double> function, Vector<double> initialGuess, double tolerance = 1e-8, int maxIterations = 1000)
        {
            var objective = ObjectiveFunction.Value(v => function(v));
            var result = NelderMeadSimplex.Minimum(objective, initialGuess, tolerance, maxIterations);
            return result;
        }

        // calculate the residual sum of squares, RSS = Sum of (a[i] - b[i])^2
        private static double SquareEuclidean(double[] a, double[] b)
        {
            var A = Vector<double>.Build.DenseOfArray(a);
            var B = Vector<double>.Build.DenseOfArray(b);
            var norm = (A - B).L2Norm(); // or (A - B).DotProduct(A - B)
            return norm * norm;
        }

        public static string CurveInterpolation(this PointXy[] pointXy)
        {
            var listX = new List<double>();
            var listY = new List<double>();

            foreach (PointXy point in pointXy)
            {
                listX.Add(point.PointX);
                listY.Add(point.PointY);
            }

            var result = Interpolate.Linear(listX, listY);
            StringBuilder sb = new StringBuilder();
            for (var i = -9; i < 10; i++)
            {
                sb.AppendFormat("[X: {0} ; Y: {1}]", i, result.Interpolate(i));
                sb.AppendLine();
            }
            return sb.ToString()?.TrimEnd();
        }
    }
}