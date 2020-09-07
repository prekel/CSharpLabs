using BenchmarkDotNet.Running;

namespace CSharpLabs.Lab01.Core.Benchmark
{
    internal static class Program
    {
        public static void Main(string[] args) =>
            BenchmarkSwitcher.FromTypes(new[] {typeof(InverseHyperbolicCotangentBenchmark)}).Run(args);
    }
}
