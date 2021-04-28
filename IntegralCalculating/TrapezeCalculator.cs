using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegralCalculating
{
    public class TrapezeCalculator : ICalculator
    {
        object monitor = new object();
        public double Calculate(double a, double b, long n, Func<double, double> f)
        {
            double h = (b - a) / n;

            double sum = 0;
            for (int i = 1; i < n; i++)
            {
                sum += f(a + h * i);
            }

            sum += (f(a) + f(b)) / 2;

            return sum * h;
        }
        public double CalculateParallel(double a, double b, long n, Func<double, double> f)
        {
            double h = (b - a) / n;
            double sum = 0;
            double[] vs = new double[n];
            Parallel.For(1, n, (i) => {
                vs[i] =  (f(a + h * i)); 
            });
            //Array.Sort(vs);
            //Array.Sort(vs);
            sum = (f(a) + f(b)) / 2 + vs.Sum();
            return sum * h;
        }
    }
}
