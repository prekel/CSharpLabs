using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Text;

using CSharpLabs.Lab01.Core;
using CSharpLabs.Lab01.Core.InverseHyperbolicCotangent;

namespace CSharpLabs.Lab01.Console
{
    internal static class Program
    {
        private static double XStart { get; set; }
        private static double XEnd { get; set; }
        private static double XStep { get; set; }
        private static double Threeshold { get; set; }

        private static ITaylorSeries Calc { get; set; } = null!;

        private static void Inputs()
        {
            while (true)
            {
                try
                {
                    System.Console.Write("Введите Xнач: ");
                    XStart = Double.Parse(System.Console.ReadLine()!);
                    System.Console.Write("Введите Xкон: ");
                    XEnd = Double.Parse(System.Console.ReadLine()!);
                    System.Console.Write("Введите dx: ");
                    XStep = Double.Parse(System.Console.ReadLine()!);
                    System.Console.Write("Введите порог (в несколько раз меньше eps): ");
                    Threeshold = Double.Parse(System.Console.ReadLine()!);
                    break;
                }
                catch (Exception e)
                {
                    System.Console.Error.WriteLine($"Ошибка: {e.Message}\n");
                }
            }
        }

        private static void InputCalc()
        {
            while (true)
            {
                try
                {
                    var calcs = new List<Type>
                        {typeof(ArcothAvx), typeof(ArcothLinq), typeof(ArcothNaive), typeof(ArcothOptimized)};
                    var defaultCalc = typeof(ArcothOptimized);
                    if (Avx.IsSupported)
                    {
                        defaultCalc = typeof(ArcothAvx);
                    }

                    System.Console.WriteLine("Доступные вычислители:");
                    var i = 1;
                    foreach (var c in calcs)
                    {
                        System.Console.WriteLine($"{i++} {c.Name}");
                    }

                    System.Console.Write($"Введите номер вычислителя [{defaultCalc.Name}]: ");
                    var choosen = System.Console.ReadLine();
                    if (String.IsNullOrEmpty(choosen))
                    {
                        Calc = (Activator.CreateInstance(defaultCalc) as ITaylorSeries)!;
                    }
                    else
                    {
                        Calc = (Activator.CreateInstance(calcs[Int32.Parse(choosen) - 1]) as ITaylorSeries)!;
                    }

                    break;
                }
                catch (Exception e)
                {
                    System.Console.Error.WriteLine($"Ошибка: {e.Message}\n");
                }
            }
        }

        private static void Main(string[] args)
        {
            System.Console.InputEncoding = Encoding.UTF8;
            System.Console.OutputEncoding = Encoding.UTF8;

            System.Console.WriteLine("Вычисление обратного гиперболического котангенса");
            System.Console.WriteLine("(arcth aka arcoth aka Inverse Hyperbolic Cotangent)");
            System.Console.WriteLine("с помощью ряда Тейлора");
            System.Console.WriteLine();

            Inputs();
            InputCalc();

            System.Console.WriteLine();
            System.Console.WriteLine($" {"x",20} | {"f(x)",20} | {"Σ(x)",20} | {"n",10} | {"Status",20} ");
            for (var x = XStart; x < XEnd; x += XStep)
            {
                var res = Calc.Calculate(x, Threeshold);
                System.Console.WriteLine(
                    $" {$"{x:F10}",20} | {$"{Calc.ReferenceFunction(x):F10}",20} | {$"{res:F10}",20} | {Calc.N,10} | {Calc.Status,20}");
            }
        }
    }
}
