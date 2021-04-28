using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegralCalculating
{
    interface ICalculator
    {
        double Calculate(double a, double b, long n, Func<double, double> f);
        double CalculateParallel(double a, double b, long n, Func<double, double> f);
    }
}
