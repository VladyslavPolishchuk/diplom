using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLib
{
    internal static class Metric
    {
        public static double Evklid(List<double> x, List<double>y)
        {
            if (x.Count != y.Count)
                throw new InvalidOperationException("Length of x array is not equel to length of y array");
            double res = 0;
            for (int i = 0; i < x.Count; i++)
            {
                res += Math.Pow(x[i] - y[i], 2);
            }
            return Math.Sqrt(res);
        }
    }
}
