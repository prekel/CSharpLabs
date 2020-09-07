using System;
using System.Linq;

namespace CSharpLabs.Lab01.Core.InverseHyperbolicCotangent
{
    public class ArcothNaive : AbstractArcoth
    {
        protected override double CalculateImpl(double x, double stepThreshold, int maxN)
        {
            var sum = 0d;
            N = 0;
            while (N < maxN)
            {
                var curr = CurrentStep(x, N);
                sum += curr;
                N++;
                if (Math.Abs(curr) < stepThreshold)
                {
                    break;
                }
            }

            Status = N >= maxN ? TaylorSeriesStatus.TooManyIterations : TaylorSeriesStatus.Success;

            return sum;
        }
    }
}
