using System;
using System.Linq;

namespace CSharpLabs.Lab01.Core
{
    public class InverseHyperbolicTangentMtOne
    {
        public static bool IsInDomain(double x) => Math.Abs(x) > 1;

        private static double CurrentStep(double x, double n) => 1 / ((2 * n + 1) * Math.Pow(x, 2 * n + 1));

        public double CalculateFunclional(double x, int maxN) =>
            Enumerable.Range(0, maxN)
                .Select(n => CurrentStep(x, n))
                .Sum();

        public double Calculate(double x, double eps, int maxN)
        {
            var sum = 0d;
            foreach (var n in Enumerable.Range(0, maxN))
            {
                var curr = CurrentStep(x, n);
                sum += curr;
                if (curr < eps)
                {
                    return sum;
                }
            }
            throw new TaylorSeriesException("Too many iterations", sum);
        }
    }
}
