using System;
using System.Collections.Generic;

namespace CSharpLabs.Lab04.Core
{
    public record Student(string Name, string Group, IEnumerable<int> Marks)
    {
        public override string ToString() =>
            $"Student: Name: {Name}; Group: {Group}; Marks: {String.Join(", ", Marks)}";
    }
}
