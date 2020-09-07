using System;
using System.Linq;

namespace CSharpLabs.Lab01.Core.InverseHyperbolicCotangent
{
    public class Linq : Abstract
    {
        protected override double CalculateImpl(double x, double eps, int maxN)
        {
            Status = TaylorSeriesStatus.Success;
            return Enumerable.Range(0, maxN)
                .Select(n => CurrentStep(x, n))
                .TakeWhile(fx => Math.Abs(fx) > eps)
                .Sum();
        }
    }
}
