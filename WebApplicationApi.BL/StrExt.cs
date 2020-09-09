using System;
using System.Collections.Generic;
using System.Text;

namespace System
{
   public static class StrExt
    {
        public static double GetDouble(this string s)
        {
            double.TryParse(s, out double d);
            return d;
        }
    }
}
