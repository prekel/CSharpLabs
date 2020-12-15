using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CSharpLabs.Lab04.Core
{
    public class StudentCollection : IEnumerable<Student>
    {
        public delegate void StudentListHandler(object source, StudentListHandlerEventArgs args);

        private List<Student> List = new();

        private StudentListHandler onStudentCountChanged;

        private StudentListHandler onStudentReferenceChanged;

        public StudentCollection(string collectionName) => CollectionName = collectionName;

        public string CollectionName { get; }

        public Student this[int j]
        {
            get => List[j];
            set
            {
                onStudentReferenceChanged?.Invoke(this,
                    new StudentListHandlerEventArgs(CollectionName, "Замена", value));
                List[j] = value;
            }
        }

        public IEnumerator<Student> GetEnumerator() => throw new NotImplementedException();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public bool Add(int j, Student record)
        {
            if (List.Count <= j)
            {
                return false;
            }

            List.Insert(j, record);
            return true;
        }

        public bool Remove(int j)
        {
            if (List.Count <= j)
            {
                return false;
            }

            onStudentCountChanged?.Invoke(this, new StudentListHandlerEventArgs(CollectionName, "Удаление", List[j]));
            List.RemoveAt(j);
            return true;
        }

        public void AddDefaults()
        {
            var s1 = new Student("Тимофеев М.А.", "КИ18-16б", new[] {1, 2, 3, 4, 5});
            onStudentReferenceChanged?.Invoke(this, new StudentListHandlerEventArgs(CollectionName, "Добавление", s1));
            List.Add(s1);
            var s2 = new Student("Тимофеев М.П.", "КИ18-17б", new[] {2, 2, 3, 4, 5});
            onStudentReferenceChanged?.Invoke(this, new StudentListHandlerEventArgs(CollectionName, "Добавление", s2));
            List.Add(s2);
            var s3 = new Student("Максимов М.П.", "КИ18-15б", new[] {3, 2, 3, 4, 5});
            onStudentReferenceChanged?.Invoke(this, new StudentListHandlerEventArgs(CollectionName, "Добавление", s3));
            List.Add(s3);
            var s4 = new Student("Максимов Т.П.", "КИ18-165б", new[] {4, 2, 3, 4, 5});
            onStudentReferenceChanged?.Invoke(this, new StudentListHandlerEventArgs(CollectionName, "Добавление", s4));
            List.Add(s4);
            var s5 = new Student("Максимов Т.А.", "КИ18-165б", new[] {5, 2, 3, 4, 5});
            onStudentReferenceChanged?.Invoke(this, new StudentListHandlerEventArgs(CollectionName, "Добавление", s5));
            List.Add(s5);
        }

        public void AddStudent(params Student[] students)
        {
            foreach (var i in students)
            {
                onStudentReferenceChanged?.Invoke(this,
                    new StudentListHandlerEventArgs(CollectionName, "Добавление", i));
                List.Add(i);
            }
        }

        public void SortViaOrderBy<T>(Func<Student, T> f)
        {
            List = List.OrderBy(f).ToList();
        }

        public event StudentListHandler OnStudentCountChanged
        {
            add
            {
                onStudentCountChanged += value;
                Console.WriteLine($"{value.Method.Name} добавлен");
            }
            remove
            {
                onStudentCountChanged -= value;
                Console.WriteLine($"{value.Method.Name} удален");
            }
        }

        public event StudentListHandler OnStudentReferenceChanged
        {
            add
            {
                onStudentReferenceChanged += value;
                Console.WriteLine($"{value.Method.Name} добавлен");
            }
            remove
            {
                onStudentReferenceChanged -= value;
                Console.WriteLine($"{value.Method.Name} удален");
            }
        }

        public record StudentListHandlerEventArgs(string CollectionName, string Type, Student Element);
    }
}
