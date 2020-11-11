using System;
using System.Threading;

using CSharpLabs.Lab01.Core.InverseHyperbolicCotangent;

namespace CSharpLabs.Lab06.Core.InverseHyperbolicCotangent
{
    public class ArcothMultithread : AbstractArcoth
    {
        protected int ThreadsCount { get; }
        
        public ArcothMultithread(int threads)
        {
            ThreadsCount = threads;
        }

        private class ThreadStartOptions
        {
            protected internal double X { get; }
            protected internal double StepThreshold { get; }
            protected internal double MaxN { get; }
            protected internal Func<int, int> FIndex { get; }
        }
        
        protected override double CalculateImpl(double x, double stepThreshold, int maxN)
        {
            //var threads = new Thread();

            throw new NotImplementedException();
        }

        private double CalculateSteps(double x, double stepThreshold, int maxN, Func<int, int> fIndex)
        {
            throw new NotImplementedException();
        }
    }
}
    