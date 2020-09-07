namespace CSharpLabs.Lab01.Core
{
    public interface ITaylorSeries
    {
        public int N { get; }

        public TaylorSeriesStatus Status { get; }
        public bool IsInDomain(double x);

        public double ReferenceFunction(double x);

        public double Calculate(double x, double eps, int maxN);
    }
}
