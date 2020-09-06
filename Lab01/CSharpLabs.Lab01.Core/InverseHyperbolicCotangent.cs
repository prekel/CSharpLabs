using System;
using System.Linq;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace CSharpLabs.Lab01.Core
{
    public class InverseHyperbolicCotangent
    {
        public static bool IsInDomain(double x) => Math.Abs(x) > 1;

        public static double TrueFunc(double x) => Math.Log((x + 1) / (x - 1)) / 2;

        private static double CurrentStep(double x, double n) => 1 / ((2 * n + 1) * Math.Pow(x, 2 * n + 1));

        public double CalculateFunclional(double x, double eps) =>
            Enumerable.Range(0, Int32.MaxValue)
                .Select(n => CurrentStep(x, n))
                .TakeWhile(fx => Math.Abs(fx) > eps)
                .Sum();

        public double Calculate(double x, double eps, int maxN)
        {
            var sum = 0d;
            foreach (var n in Enumerable.Range(0, maxN))
            {
                var curr = CurrentStep(x, n);
                sum += curr;
                if (!(Math.Abs(curr) < eps))
                {
                    continue;
                }

                if (!IsInDomain(x))
                {
                    throw new TaylorSeriesException("Not in domain", sum);
                }

                return sum;
            }

            if (!IsInDomain(x))
            {
                throw new TaylorSeriesException("Not in domain and too many iterations", sum);
            }

            throw new TaylorSeriesException("Too many iterations", sum);
        }
    }
}
