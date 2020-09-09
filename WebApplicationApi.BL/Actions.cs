using System;
using System.Text;

namespace WebApplicationApi.BL
{
    public class Actions : IActions
    {
        public string Addition(string arg1, string arg2)
        {
            return (arg1.GetDouble() + arg2.GetDouble()).ToString();
        }

        public string Division(string arg1, string arg2)
        {
            if (arg2.GetDouble() == 0) return "0";
            return (arg1.GetDouble() / arg2.GetDouble()).ToString();
        }

        public string Multiplication(string arg1, string arg2)
        {
            return (arg1.GetDouble() * arg2.GetDouble()).ToString();
        }

        public string Subtraction(string arg1, string arg2)
        {
            return (arg1.GetDouble() - arg2.GetDouble()).ToString();
        }

        public string CurveApproximation(string arg1, string arg2)
        {
            double[] xdata = arg1.GeDoubleTable();
            double[] ydata = arg2.GeDoubleTable();

            double[] p = MathNet.Numerics.Fit.Polynomial(xdata, ydata, 3); // polynomial of order 3
                         
            return StrExt.DaubleTableToString(p);
        }

        public string CurveInterpolation(string arg1, string arg2)
        {
            throw new NotImplementedException();
        }
    }
}