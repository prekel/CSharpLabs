using BenchmarkDotNet.Running;

namespace CSharpLabs.Lab06.Core.Benchmark
{
    internal static class Program
    {
        public static void Main(string[] args) =>
            BenchmarkRunner.Run<InverseHyperbolicCotangentBenchmark>();
    }
}
