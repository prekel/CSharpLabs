using System;
using System.Linq;
using System.Text;

using CSharpLabs.Lab02.Core;

namespace CSharpLabs.Lab02.Console
{
    internal static class Program
    {
        private static ArrayVar11 Arr { get; set; } = null!;

        private static void Main(string[] args)
        {
            System.Console.InputEncoding = Encoding.UTF8;
            System.Console.OutputEncoding = Encoding.UTF8;

            if (args.Length != 0)
            {
                System.Console.WriteLine(new ArrayVar11(args.Select(Double.Parse)).SumFromFirstZeroToLastZero());
                return;
            }

            while (true)
            {
                try
                {
                    System.Console.WriteLine("Введите элементы через пробел");

                    var line = System.Console.ReadLine();

                    Arr = new ArrayVar11(line!
                        .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                        .Select(Double.Parse)
                    );
                    break;
                }
                catch (Exception e)
                {
                    System.Console.Error.WriteLine(e);
                }
            }

            if (!Arr.IsHasAtLeastTwoZeroes())
            {
                System.Console.WriteLine("Нет двух нулей");
                Environment.Exit(1);
            }

            System.Console.WriteLine($"Сумма между нулевыми элементами: {Arr.SumFromFirstZeroToLastZeroLinq()}");
        }
    }
}
