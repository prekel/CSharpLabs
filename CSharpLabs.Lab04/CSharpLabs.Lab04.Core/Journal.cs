using System;
using System.Collections.Generic;

namespace CSharpLabs.Lab04.Core
{
    public class Journal
    {
        private readonly List<JournalEntry> List = new();

        public void StudentCountChanged(StudentCollection.StudentListHandlerEventArgs eventArgs)
        {
            List.Add(new JournalEntry(eventArgs.CollectionName, DateTimeOffset.Now, eventArgs.Type,
                eventArgs.Element.ToString()));
        }

        public void StudentReferenceChanged(StudentCollection.StudentListHandlerEventArgs eventArgs)
        {
            List.Add(new JournalEntry(eventArgs.CollectionName, DateTimeOffset.Now, eventArgs.Type,
                eventArgs.Element.ToString()));
        }

        public override string ToString() => String.Join(";\n", List);

        public void SortByType()
        {
            List.Sort((e1, e2) => String.Compare(e1.Type, e2.Type, StringComparison.Ordinal));
        }
    }
}
