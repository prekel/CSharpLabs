using System.Collections.Generic;

using BenchmarkDotNet.Attributes;

using CSharpLabs.Lab01.Core.InverseHyperbolicCotangent;

namespace CSharpLabs.Lab06.Core.Benchmark
{
    public class InverseHyperbolicCotangentBenchmark
    {
        [ParamsSource(nameof(Calcs))]
        public AbstractArcoth Calc = null!;

        public IEnumerable<AbstractArcoth> Calcs =>
            new List<AbstractArcoth> {new ArcothAvx(), new ArcothLinq(), new ArcothNaive(), new ArcothOptimized()};

        [Benchmark]
        public double Benchmark1() => Calc.Calculate(1.1, 1e-8, 1000);

        [Benchmark]
        public double Benchmark2() => Calc.Calculate(1.01, 1e-6, 1000);
    }
}
