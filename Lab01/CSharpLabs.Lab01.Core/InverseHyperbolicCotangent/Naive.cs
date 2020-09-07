using System;
using System.Linq;

namespace CSharpLabs.Lab01.Core.InverseHyperbolicCotangent
{
    public class Naive : Abstract
    {
        public override double Calculate(double x, double eps, int maxN)
        {
            if (!IsInDomain(x))
            {
                Status |= TaylorSeriesStatus.NotInDomain;
            }

            var sum = 0d;
            foreach (var n in Enumerable.Range(0, maxN))
            {
                var curr = CurrentStep(x, n);
                sum += curr;
                if (!(Math.Abs(curr) < eps))
                {
                    continue;
                }

                Status |= TaylorSeriesStatus.Success;
                N = n;
                return sum;
            }

            Status |= TaylorSeriesStatus.TooManyIterations;
            N = maxN;
            return sum;
        }

        public override int N { get; protected set; }
        public override TaylorSeriesStatus Status { get; protected set; } = TaylorSeriesStatus.None;
    }
}
