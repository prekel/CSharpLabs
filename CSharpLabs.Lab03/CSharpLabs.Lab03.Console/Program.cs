using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CSharpLabs.Lab03.Core;

static Student InputStudent()
{
    try
    {
        var name = Console.ReadLine();
        var group = Console.ReadLine();
        var marks = Console.ReadLine()?
            .Split(new[] {','}, StringSplitOptions.TrimEntries).Select(Int32.Parse)
            .ToArray();
        if (name == null || group == null || marks == null)
        {
            throw new NullReferenceException();
        }

        return new Student(new Tuple<string, string, int[]>(name, group, marks));
    }
    catch (Exception e)
    {
        throw new ApplicationException("Ошибка при считывании", e);
    }
}

Console.InputEncoding = Encoding.Unicode;
Console.OutputEncoding = Encoding.Unicode;
var list = new List<Student>();
for (var i = 0; i < 10; i++)
{
    list.Add(InputStudent());
}

var gt4 = list.Where(s => s.AverageScore() > 4).ToList();
Console.WriteLine(gt4.Any() ? String.Join("\n", gt4) : "Нет таких элементов");
