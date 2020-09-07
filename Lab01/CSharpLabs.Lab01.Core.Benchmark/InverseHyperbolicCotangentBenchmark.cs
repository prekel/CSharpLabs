using System.Collections.Generic;

using BenchmarkDotNet.Attributes;

using CSharpLabs.Lab01.Core.InverseHyperbolicCotangent;

namespace CSharpLabs.Lab01.Core.Benchmark
{
    public class InverseHyperbolicCotangentBenchmark
    {
        [ParamsSource(nameof(Calcs))]
        public Abstract Calc;

        public IEnumerable<Abstract> Calcs =>
            new List<Abstract> {new Linq(), new Naive(), new AvxDiv()};

        [Benchmark]
        public void Benchmark1()
        {
            Calc.Calculate(1.1, 1e-8, 1000);
        }

        [Benchmark]
        public void Benchmark2()
        {
            Calc.Calculate(1.01, 1e-6, 1000);
        }

        [Benchmark]
        public void Benchmark3()
        {
            Calc.Calculate(1.5, 1e-6, 1000);
        }

        [Benchmark]
        public void Benchmark4()
        {
            Calc.Calculate(5, 1e-6, 1000);
        }

        [Benchmark]
        public void Benchmark5()
        {
            Calc.Calculate(2, 1e-6, 1000);
        }
    }
}
