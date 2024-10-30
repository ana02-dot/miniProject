using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Algorithms
{
    class LinearReg
    {
        
        public static (double slope, double intercept) LinearRegression(double[] x, double[] y)
        {
            double xMean = x.Average();
            double yMean = y.Average();

            double numerator = x.Zip(y, (xi, yi) => (xi - xMean) * (yi - yMean)).Sum();
            double denominator = x.Sum(xi => Math.Pow(xi - xMean, 2));

            double slope = numerator / denominator;
            double intercept = yMean - slope * xMean;

            return (slope, intercept);
        }
    }
}
