using System;
using System.Linq;

namespace CSharpLabs.Lab03.Core
{
    public struct Student : IComparable<Student>
    {
        public string Name { get; }
        public string Group { get; }

        public int[] Marks { get; }

        public Student(Tuple<string, string, int[]> data)
        {
            (Name, Group, Marks) = data;
        }

        public int CompareTo(Student other) =>
            String.Compare(Name, other.Name, StringComparison.Ordinal) != 0
                ? String.Compare(Name, other.Name, StringComparison.Ordinal)
                : String.Compare(Group, other.Group, StringComparison.Ordinal);

        public double AverageScore() => Marks.Average();

        public override string ToString() =>
            $"Student: Name: {Name}; Group: {Group}; Marks: {String.Join(", ", Marks)}";
    }
}
