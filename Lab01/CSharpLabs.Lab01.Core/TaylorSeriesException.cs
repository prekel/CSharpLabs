using System;

namespace CSharpLabs.Lab01.Core
{
    public class TaylorSeriesException : ArithmeticException
    {
        public double Result { get; }

        public TaylorSeriesException(string message, double result) : base(message)
        {
            Result = result;
        }
    }
}
