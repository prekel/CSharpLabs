using System;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace CSharpLabs.Lab01.Core.InverseHyperbolicCotangent
{
    public class AvxDiv : Abstract
    {
        protected override unsafe double CalculateImpl(double x, double eps, int maxN)
        {
            if (!Avx.IsSupported)
            {
                Status |= TaylorSeriesStatus.NotSupported;
                return Double.NaN;
            }

            const int vectorSize = 256 / 8 / sizeof(double);

            var value8 = 8.0;
            var v8888 = Avx.BroadcastScalarToVector256(&value8);

            var xPow8 = Avx.BroadcastScalarToVector256(&x);
            xPow8 = Avx.Multiply(xPow8, xPow8);
            xPow8 = Avx.Multiply(xPow8, xPow8);
            xPow8 = Avx.Multiply(xPow8, xPow8);

            var upSa = stackalloc double[vectorSize];
            var xDiv2iPlus1 = 1 / x;
            for (var i = 0; i < vectorSize; i++)
            {
                upSa[i] = xDiv2iPlus1;
                xDiv2iPlus1 /= x * x;
            }

            var up = Avx.LoadVector256(upSa);

            var downSa = stackalloc double[vectorSize] {1, 3, 5, 7};
            var down = Avx.LoadVector256(downSa);

            var sum = Vector256<double>.Zero;

            for (N = 0; N < maxN; N += vectorSize)
            {
                var div = Avx.Divide(up, down);
                sum = Avx.Add(sum, div);
                var last = div.GetElement(vectorSize - 1);
                if (Math.Abs(last) < eps)
                {
                    break;
                }

                up = Avx.Divide(up, xPow8);
                down = Avx.Add(down, v8888);
            }


            var resultSa = stackalloc double[vectorSize];
            Avx.Store(resultSa, sum);

            if (N >= maxN)
            {
                Status |= TaylorSeriesStatus.TooManyIterations;
            }
            else
            {
                Status |= TaylorSeriesStatus.Success;
            }

            return resultSa[0] + resultSa[1] + resultSa[2] + resultSa[3];
        }
    }
}
