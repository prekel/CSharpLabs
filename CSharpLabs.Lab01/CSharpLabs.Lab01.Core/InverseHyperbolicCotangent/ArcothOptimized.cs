using System;

namespace CSharpLabs.Lab01.Core.InverseHyperbolicCotangent
{
    public class ArcothOptimized : AbstractArcoth
    {
        protected override double CalculateImpl(double x, double stepThreshold, int maxN)
        {
            var sum = 0d;
            N = 0;

            var up = 1 / x;
            var down = 1;
            var xx = x * x;

            while (N < maxN)
            {
                var curr = up / down;
                sum += curr;
                N++;
                if (Math.Abs(curr) < stepThreshold)
                {
                    break;
                }

                up /= xx;
                down += 2;
            }

            Status = N >= maxN ? TaylorSeriesStatus.TooManyIterations : TaylorSeriesStatus.Success;

            return sum;
        }
    }
}
