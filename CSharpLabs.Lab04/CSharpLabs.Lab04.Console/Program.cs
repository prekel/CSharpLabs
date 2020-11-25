using System;
using System.Text;

using CSharpLabs.Lab04.Core;

Console.OutputEncoding = Encoding.UTF8;

StudentCollection collection1 = new("Коллекция 1");
StudentCollection collection2 = new("Коллекция 2");

Journal journal = new();

collection1.OnStudentCountChanged += (_, eventArgs) => journal.StudentCountChanged(eventArgs);
collection1.OnStudentReferenceChanged += (_, eventArgs) => journal.StudentReferenceChanged(eventArgs);
collection2.OnStudentCountChanged += (_, eventArgs) => journal.StudentCountChanged(eventArgs);
collection2.OnStudentReferenceChanged += (_, eventArgs) => journal.StudentReferenceChanged(eventArgs);

collection1.AddDefaults();
collection2.AddDefaults();

collection1.Remove(5);
collection2.Remove(4);
collection1.Remove(3);
collection2.Remove(2);
collection1.Remove(1);

collection1[0] = collection1[0] with { Name = "Новое имя" };

collection1.SortViaOrderBy(student => student.Name);
collection2.SortViaOrderBy(student => student.Group);

journal.SortByType();

Console.WriteLine(journal);
