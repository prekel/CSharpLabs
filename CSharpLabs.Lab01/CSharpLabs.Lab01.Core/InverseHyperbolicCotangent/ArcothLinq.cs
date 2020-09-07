using System;
using System.Linq;

namespace CSharpLabs.Lab01.Core.InverseHyperbolicCotangent
{
    public class ArcothLinq : AbstractArcoth
    {
        protected override double CalculateImpl(double x, double stepThreshold, int maxN)
        {
            Status = TaylorSeriesStatus.Success;
            return Enumerable.Range(0, maxN)
                .Select(n => CurrentStep(x, n))
                .TakeWhile(fx => Math.Abs(fx) > stepThreshold)
                .Sum();
        }
    }
}
