namespace CSharpLabs.Lab01.Core.InverseHyperbolicCotangent
{
    public class AvxDiv : Abstract
    {
        public override double Calculate(double x, double eps, int maxN) => throw new System.NotImplementedException();

        public override int N { get; protected set; }
        public override TaylorSeriesStatus Status { get; protected set; }
    }
}
