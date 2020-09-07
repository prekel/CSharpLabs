namespace CSharpLabs.Lab01.Core
{
    public interface ITaylorSeries
    {
        public bool IsInDomain(double x);

        public double ReferenceFunction(double x);

        public double Calculate(double x, double eps, int maxN);
        
        public int N { get; }
        
        public TaylorSeriesStatus Status { get; }
    }
}
