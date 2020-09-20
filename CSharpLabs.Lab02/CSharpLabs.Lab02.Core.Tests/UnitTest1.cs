using System;
using System.Linq;

using NUnit.Framework;

namespace CSharpLabs.Lab02.Core.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var c = new Class1(1, 2, 0, 1, 2, 3, 4, 0, 1, 2, 3);

            Assert.That(c.Count, Is.EqualTo(11));

            Assert.That(c.SumFromFirstZeroToLastZero(), Is.EqualTo(10));
            Assert.That(c.SumFromFirstZeroToLastZeroLinq(), Is.EqualTo(10));
        }

        [Test]
        public void Test2()
        {
            var c = new Class1(1, 2, 0, 1, 2, 3, 4, 1, 1, 2, 3);

            Assert.That(c.Count, Is.EqualTo(11));

            Assert.That(c.SumFromFirstZeroToLastZero, Throws.Exception);
            Assert.That(c.SumFromFirstZeroToLastZeroLinq, Throws.Exception);
        }

        [Test]
        public void Test3()
        {
            var c = new Class1(1, 2, 1, 1, 2, 3, 4, 1, 1, 2, 3);

            Assert.That(c.Count, Is.EqualTo(11));

            Assert.That(c.SumFromFirstZeroToLastZero, Throws.Exception);
            Assert.That(c.SumFromFirstZeroToLastZeroLinq, Throws.Exception);
        }

        [Test]
        public void Test4()
        {
            var c = new Class1(1, 0, 1, 1, 2, 0, 4, 1, 0, 2, 3);

            Assert.That(c.Count, Is.EqualTo(11));

            Assert.That(c.SumFromFirstZeroToLastZero(), Is.EqualTo(9));
            Assert.That(c.SumFromFirstZeroToLastZeroLinq(), Is.EqualTo(9));
        }

        [Test]
        public void Test5()
        {
            var c = new Class1(1, 12);
            
            Assert.That(c.Array.Sum(), Is.EqualTo(Math.E).Within(1e-3));
        }

        [Test]
        public void Test6()
        {
            var c = new Class1(2, 12);
            
            Assert.That(c.Array.Sum(), Is.EqualTo(Math.Exp(2)).Within(1e-3));
        }
    }
}
