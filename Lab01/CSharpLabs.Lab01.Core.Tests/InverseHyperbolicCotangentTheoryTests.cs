using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using CSharpLabs.Lab01.Core.InverseHyperbolicCotangent;

using NUnit.Framework;

namespace CSharpLabs.Lab01.Core.Tests
{
    [TestFixture(typeof(ArcothAvx))]
    [TestFixture(typeof(ArcothLinq))]
    [TestFixture(typeof(ArcothNaive))]
    [TestFixture(typeof(ArcothOptimized))]
    public class InverseHyperbolicCotangentTheoryTests<T>
        where T : AbstractArcoth, new()
    {
        private T Calc { get; } = new T();

        [DatapointSource]
        public IEnumerable<double> Values => new List<double>
        {
            1.1, 1.01, 1.001, 1.23, 1.26, 1.05, 1.0001, 2, 3, 4, 5, 6, 7, 8, -1.1, -1.01, -1.001, -1.23, -1.26,
            -1.05, -1.0001, -2, -3, -4, -5, -6, -7, -8, 1.2345678, -1.2345678, 1 + Eps, -1 - Eps
        };

        private static Random Random => new Random();

        [DatapointSource]
        public static IEnumerable<double> Random500ValuesFrom1To7 { get; } = Enumerable.Range(0, 1000)
            .Select(x => (Random.NextDouble() * 7 + 1 + Eps) * (Random.Next(0, 1) * 2 - 1))
            .ToList();

        public const double Eps = 1e-4;

        [Theory]
        public void Test1(double x)
        {
            var res = Calc.Calculate(x, Eps / 10000, 100000);

            if (Calc.Status == TaylorSeriesStatus.NotSupported)
            {
                Assert.Ignore();
            }

            Assert.That(Calc.Status, Is.EqualTo(TaylorSeriesStatus.Success));
            Assert.That(res, Is.EqualTo(AbstractArcoth.ReferenceFunction(x)).Within(Eps));
        }
    }
}
