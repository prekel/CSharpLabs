using System;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

namespace CSharpLabs.Lab03.Core.Tests
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
            var s = new Student(new Tuple<string, string, int[]>("Максимов Т.А.", "КИ18-16б", new[] {3, 4, 5, 3, 3}));

            var list = new List<Student> {s};

            Assert.That(list.Count, Is.EqualTo(1));
            Assert.That(list.First(), Is.EqualTo(s));

            var sorted = list.OrderBy(st => st.Name).ToList();

            Assert.That(sorted, Is.Not.Empty);
        }
    }
}
