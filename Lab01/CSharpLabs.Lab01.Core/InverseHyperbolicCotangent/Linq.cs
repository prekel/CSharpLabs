using System;
using System.Linq;

namespace CSharpLabs.Lab01.Core.InverseHyperbolicCotangent
{
    public class Linq : Abstract
    {
        public override double Calculate(double x, double eps, int maxN) =>
            Enumerable.Range(0, maxN)
                .Select(n => CurrentStep(x, n))
                .TakeWhile(fx => Math.Abs(fx) > eps)
                .Sum();

        public override int N { get; protected set; }

        public override TaylorSeriesStatus Status { get; protected set; } = TaylorSeriesStatus.Undefined;
    }
}
