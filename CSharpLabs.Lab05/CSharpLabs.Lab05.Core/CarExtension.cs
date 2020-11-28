using System;
using System.Linq;

namespace CSharpLabs.Lab05.Core
{
    public static class CarExtension
    {
        public static double AveragePrice(this Car car) => Math.Round(car.Prices.Average() * 100) / 100;
    }
}
