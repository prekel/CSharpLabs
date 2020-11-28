using System;
using System.Linq;
using System.Text;

using CSharpLabs.Lab05.Core;

Console.OutputEncoding = Encoding.UTF8;
var random = new Random();

var services = Enumerable.Range(1, 10)
    .Select(id => new Service($"Сервис №{id}", id))
    .ToList();

var cars = new[] {"Volkswagen", "BMV", "Audi", "Mercedes-Benz", "Porsche", "Toyota", "Nissan", "Renault"}
    .Select(manufacturer => new Car(
            manufacturer,
            random.Next(1, services.Count + 1),
            Enumerable.Range(0, 5)
                .Select(_ => random.Next(1000000000) / 100.0)
                .ToArray()
        )
    ).ToList();
Console.WriteLine(String.Join("\n", services));
Console.WriteLine();

Console.WriteLine(String.Join("\n", cars));
Console.WriteLine();

var q1 = cars
    .Join(services, car => car.ServiceId, service => service.ServiceId,
        (car, service) => new {car, service})
    .OrderBy(carservice => carservice.car.Manufacturer)
    .ToList();
Console.WriteLine(String.Join("\n", q1));
Console.WriteLine();

var q2 = services
    .GroupJoin(cars, service => service.ServiceId, car => car.ServiceId,
        (service, carsInService) => new
            {Service = service, Cars = carsInService.OrderByDescending(car => car.AveragePrice())})
    .Select(serviceWithCars =>
        $"{serviceWithCars.Service} Cars = [{String.Join("; ", serviceWithCars.Cars.Select(car => $"{car.Manufacturer} {car.AveragePrice()}"))}]");
Console.WriteLine(String.Join("\n", q2));
Console.WriteLine();