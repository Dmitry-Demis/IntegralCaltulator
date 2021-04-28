using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegralCalculating
{
    public class RectangleCalculator : ICalculator
    {
        object monitor = new object();
        public double Calculate(double a, double b, long n, Func<double, double> f)
        {
            if (n<=0)
            {
                throw new ArgumentException();
            }
            double h = (b - a) / n;
            a += h * 0.5;
            double sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += f(a + h * i);
            }
            return sum * h;
        }

        public double CalculateParallel(double a, double b, long n, Func<double, double> f)
        {
            if (n <= 0)
            {
                throw new ArgumentException();
            }
            double h = (b - a) / n;
            a += h * 0.5;

           var bag = new ConcurrentBag<double>();

            // Паралелльное вычисление
            Parallel.For(1, n, (i) =>
            {
                bag.Add(f(a + h * i));
            });
            var total = bag.Sum();
            return total * h;

        }
    }
}
