using System;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace CSharpLabs.Lab01.Core.InverseHyperbolicCotangent
{
    public class ArcothAvx : AbstractArcoth
    {
        protected override unsafe double CalculateImpl(double x, double stepThreshold, int maxN)
        {
            if (!Avx.IsSupported)
            {
                Status = TaylorSeriesStatus.NotSupported;
                return Double.NaN;
            }

            const int vectorSize = 256 / 8 / sizeof(double);

            // v8888 <- (8, 8, 8, 8)
            var value8 = 8.0;
            var v8888 = Avx.BroadcastScalarToVector256(&value8);

            // xPow8 <- (x^8, x^8, x^8, x^8)
            var xPow8 = Avx.BroadcastScalarToVector256(&x);
            xPow8 = Avx.Multiply(xPow8, xPow8);
            xPow8 = Avx.Multiply(xPow8, xPow8);
            xPow8 = Avx.Multiply(xPow8, xPow8);

            // up <- (x^(-1), x^(-3), x^(-5), x^(-7))
            var upSa = stackalloc double[vectorSize];
            var xDiv2iPlus1 = 1 / x;
            for (var i = 0; i < vectorSize; i++)
            {
                upSa[i] = xDiv2iPlus1;
                xDiv2iPlus1 /= x * x;
            }
            var up = Avx.LoadVector256(upSa);

            // down <- (1, 3, 5, 7)
            var downSa = stackalloc double[vectorSize] {1, 3, 5, 7};
            var down = Avx.LoadVector256(downSa);

            // sum <- (0, 0, 0, 0)
            var sum = Vector256<double>.Zero;

            N = 0;
            while (N < maxN)
            {
                // div <- up / down
                var div = Avx.Divide(up, down);
                // sum <- sum + div
                sum = Avx.Add(sum, div);
                // div = (x1, x2, x3, last)
                var last = div.GetElement(vectorSize - 1);
                N += vectorSize;
                if (Math.Abs(last) < stepThreshold)
                {
                    break;
                }

                // up <- up / (x^8, x^8, x^8, x^8)
                up = Avx.Divide(up, xPow8);
                // down <- down + (8, 8, 8, 8)
                down = Avx.Add(down, v8888);
            }

            var resultSa = stackalloc double[vectorSize];
            Avx.Store(resultSa, sum);

            Status = N >= maxN ? TaylorSeriesStatus.TooManyIterations : TaylorSeriesStatus.Success;

            return resultSa[0] + resultSa[1] + resultSa[2] + resultSa[3];
        }
    }
}
