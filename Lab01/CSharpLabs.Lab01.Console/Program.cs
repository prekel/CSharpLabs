using CSharpLabs.Lab01.Core.InverseHyperbolicCotangent;

namespace CSharpLabs.Lab01.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            System.Console.WriteLine("Hello World!");

            System.Console.WriteLine("x      | f(x)       | sigma(x)     | n ");

            var avxdiv = new AvxDiv();
            var tc = Abstract.ReferenceFunction(1.2);
            var ac = avxdiv.Calculate(1.2, 0.0002, 1000);

            //var c = new InverseHyperbolicCotangent();

            for (var i = 1.01; i < 10; i += 0.01)
            {
                //System.Console.WriteLine($"{i:N10} | {InverseHyperbolicCotangent.TrueFunc(i):N10} | {c.Calculate(i, 0.00001, 100000):N10}| {c.CalculateFunclional(i, 0.00001):N10}");
            }
        }
    }
}
