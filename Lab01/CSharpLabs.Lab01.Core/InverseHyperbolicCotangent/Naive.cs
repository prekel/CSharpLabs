using System;
using System.Linq;

namespace CSharpLabs.Lab01.Core.InverseHyperbolicCotangent
{
    public class Naive : Abstract
    {
        protected override double CalculateImpl(double x, double eps, int maxN)
        {
            var sum = 0d;
            for (N = 0; N < maxN; N++)
            {
                var curr = CurrentStep(x, N);
                sum += curr;
                if (Math.Abs(curr) < eps)
                {
                    break;
                }
            }

            if (N >= maxN)
            {
                Status |= TaylorSeriesStatus.TooManyIterations;
            }
            else
            {
                Status |= TaylorSeriesStatus.Success;
            }
            return sum;
        }
    }
}
