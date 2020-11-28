using System;
using System.Collections.Generic;

namespace CSharpLabs.Lab05.Core
{
    public record Car(string Manufacturer, int ServiceId, double[] Prices)
    {
        public override string ToString() =>
            $"Car {{ Manufacturer = {Manufacturer}, ServiceId = {ServiceId}, Prices = [{String.Join("; ", Prices)}] }}";
    }
}
