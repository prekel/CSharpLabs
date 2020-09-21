using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpLabs.Lab02.Core
{
    public class ArrayVar11
    {
        public ArrayVar11(double x, int n)
        {
            Array = new double[n];
            var up = 1d;
            var down = 1d;
            for (var i = 0; i < n; i++)
            {
                Array[i] = up / down;
                up *= x;
                down *= i + 1;
            }
        }

        public ArrayVar11(IEnumerable<double> elements) => Array = elements.ToArray();

        public ArrayVar11(params double[] elements)
        {
            Array = new double[elements.Length];
            elements.CopyTo(Array, 0);
        }

        public double[] Array { get; }

        public int Count => Array.Length;

        public bool IsHasAtLeastTwoZeroes() => Array.Count(p => p == 0) >= 2;

        public double SumFromFirstZeroToLastZeroLinq() =>
            !IsHasAtLeastTwoZeroes()
                ? throw new ApplicationException("Нет двух нулевых элементов")
                : Array.SkipWhile(p => p != 0)
                    .Reverse()
                    .SkipWhile(p => p != 0)
                    .Sum();

        public double SumFromFirstZeroToLastZero()
        {
            if (!IsHasAtLeastTwoZeroes())
            {
                throw new ApplicationException("Нет двух нулевых элементов");
            }

            var s = 0d;
            for (var i = System.Array.IndexOf(Array, 0);
                i < System.Array.LastIndexOf(Array, 0);
                i++)
            {
                s += Array[i];
            }

            return s;
        }
    }
}
