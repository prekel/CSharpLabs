using System;
using System.Linq;

using NUnit.Framework;

namespace CSharpLabs.Lab02.Core.Tests
{
    public class ArrayVar11Tests
    {
        [Test]
        public void TestParamsCtor()
        {
            var c = new ArrayVar11(1, 2, 0, 1, 2, 3, 4, 0, 1, 2, 3);

            Assert.That(c.Count, Is.EqualTo(11));

            Assert.That(c.SumFromFirstZeroToLastZero(), Is.EqualTo(10));
            Assert.That(c.SumFromFirstZeroToLastZeroLinq(), Is.EqualTo(10));
        }

        [Test]
        public void TestParamsCtorSumOneZeroThrows()
        {
            var c = new ArrayVar11(1, 2, 0, 1, 2, 3, 4, 1, 1, 2, 3);

            Assert.That(c.Count, Is.EqualTo(11));

            Assert.That(c.SumFromFirstZeroToLastZero, Throws.Exception);
            Assert.That(c.SumFromFirstZeroToLastZeroLinq, Throws.Exception);
        }

        [Test]
        public void TestParamsCtorSumNoneZeroesThrows()
        {
            var c = new ArrayVar11(1, 2, 1, 1, 2, 3, 4, 1, 1, 2, 3);

            Assert.That(c.Count, Is.EqualTo(11));

            Assert.That(c.SumFromFirstZeroToLastZero, Throws.Exception);
            Assert.That(c.SumFromFirstZeroToLastZeroLinq, Throws.Exception);
        }

        [Test]
        public void TestParamsCtorSumThreeZeroes()
        {
            var c = new ArrayVar11(1, 0, 1, 1, 2, 0, 4, 1, 0, 2, 3);

            Assert.That(c.Count, Is.EqualTo(11));

            Assert.That(c.SumFromFirstZeroToLastZero(), Is.EqualTo(9));
            Assert.That(c.SumFromFirstZeroToLastZeroLinq(), Is.EqualTo(9));
        }

        [Test]
        public void TestExpCtorE1()
        {
            var c = new ArrayVar11(1, 12);

            Assert.That(c.Array.Sum(), Is.EqualTo(Math.E).Within(1e-3));
        }

        [Test]
        public void TestExpCtorE2()
        {
            var c = new ArrayVar11(2, 12);

            Assert.That(c.Array.Sum(), Is.EqualTo(Math.Exp(2)).Within(1e-3));
        }

        [Test]
        public void TestParamsCtorEqToArray()
        {
            var c = new ArrayVar11(2, 12, 12, 12);

            Assert.That(c.Array, Is.EqualTo(new[] {2d, 12, 12, 12}));
        }

        [Test]
        public void TestIEnumerableCtor()
        {
            var c = new ArrayVar11(
                Enumerable.Range(0, 5)
                    .Prepend(10)
                    .Append(0)
                    .Append(11)
                    .Select(u => (double) u)
            );

            Assert.That(c.Array, Is.EqualTo(new[] {10d, 0, 1, 2, 3, 4, 0, 11}));
            Assert.That(c.SumFromFirstZeroToLastZero(), Is.EqualTo(10).Within(1e-10));
        }
    }
}
