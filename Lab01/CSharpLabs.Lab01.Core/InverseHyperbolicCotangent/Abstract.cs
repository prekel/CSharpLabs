using System;

namespace CSharpLabs.Lab01.Core.InverseHyperbolicCotangent
{
    public abstract class Abstract : ITaylorSeries
    {
        public static bool IsInDomain(double x) => Math.Abs(x) > 1;

        bool ITaylorSeries.IsInDomain(double x) => IsInDomain(x);

        public static double ReferenceFunction(double x) => Math.Log((x + 1) / (x - 1)) / 2;
        double ITaylorSeries.ReferenceFunction(double x) => ReferenceFunction(x);

        public double Calculate(double x, double eps, int maxN)
        {
            N = -1;
            Status = TaylorSeriesStatus.None;
            if (IsInDomain(x))
            {
                return CalculateImpl(x, eps / 10, maxN);
            }

            Status |= TaylorSeriesStatus.NotInDomain;
            return Double.NaN;
        }

        public int N { get; protected set; }

        public TaylorSeriesStatus Status { get; protected set; } = TaylorSeriesStatus.None;

        protected static double CurrentStep(double x, double n) => 1 / ((2 * n + 1) * Math.Pow(x, 2 * n + 1));

        protected abstract double CalculateImpl(double x, double eps, int maxN);
    }
}
