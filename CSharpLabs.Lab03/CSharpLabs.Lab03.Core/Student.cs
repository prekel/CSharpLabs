using System;
using System.Linq;

namespace CSharpLabs.Lab03.Core
{
    public struct Student : IComparable<Student>
    {
        public string Name { get; set; }
        public string Group { get; set; }

        public int[] Marks { get; set; }

        public Student(Tuple<string, string, int[]> data)
        {
            (Name, Group, Marks) = data;
        }

        public int CompareTo(Student other) =>
            String.Compare(Name, other.Name, StringComparison.OrdinalIgnoreCase) != 0
                ? String.Compare(Name, other.Name, StringComparison.OrdinalIgnoreCase)
                : String.Compare(Group, other.Group, StringComparison.OrdinalIgnoreCase);

        public double AverageScore() => Marks.Average();

        public override string ToString() =>
            $"Student: Name: {Name}; Group: {Group}; Marks: {String.Join(", ", Marks)}; AverageScore: {AverageScore()}";
    }
}
