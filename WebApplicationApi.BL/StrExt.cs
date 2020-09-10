using System.Collections.Generic;

namespace System
{
    public static class StrExt
    {
        public static double GetDouble(this string s)
        {
            double.TryParse(s, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double d);
            return d;
        }

        public static double[][] GeVectors(this string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return null;
            }
            var res = new List<double[]>();
            var pairTab = s.Split(';');
            for (var i = 0; i < pairTab.Length; i += 2)
            {
                if (i + 1 <= pairTab.Length - 1)
                    res.Add(new double[] { pairTab[i].GetDouble(), pairTab[i + 1].GetDouble() });
            }
            return res.ToArray();
        }

        public static double[] GeDoubleTable(this string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return null;
            }
            var res = new List<double>();
            var pairTab = s.Split(';');
            for (var i = 0; i < pairTab.Length; i++)
            {
                res.Add(pairTab[i].GetDouble());
            }
            return res.ToArray();
        }

        public static string DaubleTableToString(this double[] d)
        {
            var sb = new Text.StringBuilder();
            foreach (var r in d)
            {
                sb.AppendFormat("El: {0}", r);
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}