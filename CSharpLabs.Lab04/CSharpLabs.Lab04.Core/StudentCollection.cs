using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CSharpLabs.Lab04.Core
{
    public class StudentCollection : IEnumerable<Student>
    {
        private List<Student> List = new List<Student>();

        public string CollectionName { get; }

        public StudentCollection(string collectionName)
        {
            CollectionName = collectionName;
        }

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

            OnStudentCountChanged?.Invoke(this, new StudentListHandlerEventArgs(CollectionName, "Удаление", List[j]));
            List.RemoveAt(j);
            return true;
        }

        public Student this[int j]
        {
            get => List[j];
            set
            {
                OnStudentReferenceChanged?.Invoke(this,
                    new StudentListHandlerEventArgs(CollectionName, "Замена", value));
                List[j] = value;
            }
        }

        public void AddDefaults()
        {
            var s1 = new Student("Тимофеев М.А.", "КИ18-16б", new[] {1, 2, 3, 4, 5});
            OnStudentReferenceChanged?.Invoke(this, new StudentListHandlerEventArgs(CollectionName, "Добавление", s1));
            List.Add(s1);
            var s2 = new Student("Тимофеев М.П.", "КИ18-17б", new[] {2, 2, 3, 4, 5});
            OnStudentReferenceChanged?.Invoke(this, new StudentListHandlerEventArgs(CollectionName, "Добавление", s2));
            List.Add(s2);
            var s3 = new Student("Максимов М.П.", "КИ18-15б", new[] {3, 2, 3, 4, 5});
            OnStudentReferenceChanged?.Invoke(this, new StudentListHandlerEventArgs(CollectionName, "Добавление", s3));
            List.Add(s3);
            var s4 = new Student("Максимов Т.П.", "КИ18-165б", new[] {4, 2, 3, 4, 5});
            OnStudentReferenceChanged?.Invoke(this, new StudentListHandlerEventArgs(CollectionName, "Добавление", s4));
            List.Add(s4);
            var s5 = new Student("Максимов Т.А.", "КИ18-165б", new[] {5, 2, 3, 4, 5});
            OnStudentReferenceChanged?.Invoke(this, new StudentListHandlerEventArgs(CollectionName, "Добавление", s5));
            List.Add(s5);
        }

        public void AddStudent(params Student[] students)
        {
            foreach (var i in students)
            {
                OnStudentReferenceChanged?.Invoke(this,
                    new StudentListHandlerEventArgs(CollectionName, "Добавление", i));
                List.Add(i);
            }
        }

        public void SortViaOrderBy<T>(Func<Student, T> f)
        {
            List = List.OrderBy(f).ToList();
        }

        public delegate void StudentListHandler(object source, StudentListHandlerEventArgs args);

        public record StudentListHandlerEventArgs(string CollectionName, string Type, Student Element);

        public event StudentListHandler OnStudentCountChanged;
        public event StudentListHandler OnStudentReferenceChanged;

        public IEnumerator<Student> GetEnumerator() => throw new NotImplementedException();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
