using System;
using System.Linq;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace CSharpLabs.Lab01.Core.InverseHyperbolicCotangent
{
    public abstract class Abstract : ITaylorSeries
    {
        public bool IsInDomain(double x) => Math.Abs(x) > 1;
        public double ReferenceFunction(double x) => Math.Log((x + 1) / (x - 1)) / 2;

        protected static double CurrentStep(double x, double n) => 1 / ((2 * n + 1) * Math.Pow(x, 2 * n + 1));

        public abstract double Calculate(double x, double eps, int maxN);
        
        public abstract int N { get; protected set; }
        
        public abstract TaylorSeriesStatus Status { get; protected set; }
    }
}
