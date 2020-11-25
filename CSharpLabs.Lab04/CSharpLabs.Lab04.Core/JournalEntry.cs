using System;

namespace CSharpLabs.Lab04.Core
{
    public record JournalEntry(string CollectionName, DateTimeOffset Time, string Type, string Data)
    {
        public override string ToString() =>
            $"CollectionName: {CollectionName}, Время: {Time}, Тип: {Type}, Data: {Data}";
    }
}
