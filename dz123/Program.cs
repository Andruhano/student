using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace student
{
    public enum Specialization
    {
        ComputerScience,
        Mathematics,
        Physics,
        Engineering,
        Other
    }

    public class Student: IComparable<Student>, ICloneable
    {
        private string lastName;
        private string firstName;
        private string middleName;
        private DateTime birthDate;
        private string homeAddress;
        private string phoneNumber;
        public List<int> homeworkGrades;
        public List<int> courseworkGrades;
        public List<int> examGrades;

        public Student()
        {
            lastName = "Неизвестно";
            firstName = "Неизвестно";
            middleName = "Неизвестно";
            birthDate = DateTime.MinValue;
            homeAddress = "Неизвестно";
            phoneNumber = "Неизвестно";
            homeworkGrades = new List<int>();
            courseworkGrades = new List<int>();
            examGrades = new List<int>();
        }

        public Student(string lastName, string firstName, string middleName,
        DateTime birthDate, string homeAddress, string phoneNumber)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.middleName = middleName;
            this.birthDate = birthDate;
            this.homeAddress = homeAddress;
            this.phoneNumber = phoneNumber;
            this.homeworkGrades = new List<int>();
            this.courseworkGrades = new List<int>();
            this.examGrades = new List<int>();
        }

        public string GetLastName()
        {
            return lastName;
        }

        public void SetLastName(string lastName)
        {
            this.lastName = lastName;
        }

        public string GetFirstName()
        {
            return firstName;
        }

        public void SetFirstName(string firstName)
        {
            this.firstName = firstName;
        }

        public string GetMiddleName()
        {
            return middleName;
        }

        public void SetMiddleName(string middleName)
        {
            this.middleName = middleName;
        }

        public DateTime GetBirthDate()
        {
            return birthDate;
        }

        public void SetBirthDate(DateTime birthDate)
        {
            this.birthDate = birthDate;
        }

        public string GetHomeAddress()
        {
            return homeAddress;
        }

        public void SetHomeAddress(string homeAddress)
        {
            this.homeAddress = homeAddress;
        }

        public string GetPhoneNumber()
        {
            return phoneNumber;
        }

        public void SetPhoneNumber(string phoneNumber)
        {
            this.phoneNumber = phoneNumber;
        }

        public List<int> GetHomeworkGrades()
        {
            return homeworkGrades;
        }

        public void SetHomeworkGrades(List<int> grades)
        {
            this.homeworkGrades = grades;
        }

        public List<int> GetCourseworkGrades()
        {
            return courseworkGrades;
        }

        public void SetCourseworkGrades(List<int> grades)
        {
            this.courseworkGrades = grades;
        }

        public List<int> GetExamGrades()
        {
            return examGrades;
        }

        public void SetExamGrades(List<int> grades)
        {
            this.examGrades = grades;
        }

        public int CompareTo(Student other)
        {
            if (other == null) return 1;
            return this.GetAverageExamGrade().CompareTo(other.GetAverageExamGrade());
        }

        public object Clone()
        {
            return new Student(lastName, firstName, middleName, birthDate, homeAddress, phoneNumber)
            {
                homeworkGrades = new List<int>(this.homeworkGrades),
                courseworkGrades = new List<int>(this.courseworkGrades),
                examGrades = new List<int>(this.examGrades)
            };
        }

        public double GetAverageExamGrade()
        {
            return examGrades.Count > 0 ? examGrades.Average() : 0;
        }

        public static bool operator ==(Student s1, Student s2)
        {
            if (ReferenceEquals(s1, null) && ReferenceEquals(s2, null)) return true;
            if (ReferenceEquals(s1, null) || ReferenceEquals(s2, null)) return false;

            return s1.lastName == s2.lastName &&
                   s1.firstName == s2.firstName &&
                   s1.middleName == s2.middleName &&
                   s1.birthDate == s2.birthDate;
        }

        public static bool operator !=(Student s1, Student s2)
        {
            return !(s1 == s2);
        }
        public static bool operator >(Student s1, Student s2)
        {
            return s1.GetAverageExamGrade() > s2.GetAverageExamGrade();
        }
        public static bool operator <(Student s1, Student s2)
        {
            return s1.GetAverageExamGrade() < s2.GetAverageExamGrade();
        }
        public static bool operator true(Student s)
        {
            return s.GetAverageExamGrade() >= 4.0;
        }
        public static bool operator false(Student s)
        {
            return s.GetAverageExamGrade() < 4.0;
        }

        public override bool Equals(object obj)
        {
            return this == obj as Student;
        }

        public class CompareByLastName : IComparer<Student>
        {
            public int Compare(Student x, Student y)
            {
                return string.Compare(x.lastName, y.lastName);
            }
        }

        public class CompareByAverageExamGrade : IComparer<Student>
        {
            public int Compare(Student x, Student y)
            {
                return x.GetAverageExamGrade().CompareTo(y.GetAverageExamGrade());
            }
        }

        public void ShowStudentInfo()
        {
            Console.WriteLine("Фамилия: " + lastName);
            Console.WriteLine("Имя: " + firstName);
            Console.WriteLine("Отчество: " + middleName);
            Console.WriteLine("Дата рождения: " + birthDate);
            Console.WriteLine("Домашний адрес: " + homeAddress);
            Console.WriteLine("Телефон: " + phoneNumber);

            Console.WriteLine("Оценки за домашние задания: " + string.Join((", "), homeworkGrades));
            Console.WriteLine("Оценки за курсовые работы: " + string.Join((", "), courseworkGrades));
            Console.WriteLine("Оценки за экзамены: " + string.Join((", "), examGrades));
        }
    }

    public class Group : IComparable<Group>, ICloneable, IEnumerable<Student>
    {
        private List<Student> students;
        private string groupName;
        private Specialization specialization;
        private int courseNumber;

        public Group()
        {
            students = new List<Student>();
            groupName = "Без названия";
            specialization = Specialization.Other;
            courseNumber = 1;
        }

        public int CompareTo(Group other)
        {
            if (other == null) return 1;
            return this.groupName.CompareTo(other.groupName);
        }
        public object Clone()
        {
            Group clonedGroup = new Group
            {
                groupName = this.groupName,
                specialization = this.specialization,
                courseNumber = this.courseNumber,
                students = new List<Student>(this.students.Select(student => (Student)student.Clone()))
            };
            return clonedGroup;
        }

        public IEnumerator<Student> GetEnumerator()
        {
            return students.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Group(Group otherGroup)
        {
            groupName = otherGroup.groupName;
            specialization = otherGroup.specialization;
            courseNumber = otherGroup.courseNumber;
            students = new List<Student>(otherGroup.students.Select(s => new Student
            (
                s.GetLastName(),
                s.GetFirstName(),
                s.GetMiddleName(),
                s.GetBirthDate(),
                s.GetHomeAddress(),
                s.GetPhoneNumber())
            {
                homeworkGrades = new List<int>(s.GetHomeworkGrades()),
                courseworkGrades = new List<int>(s.GetCourseworkGrades()),
                examGrades = new List<int>(s.GetExamGrades())
            }));
        }

        public void AddStudent(Student student)
        {
            students.Add(student);
        }
        public static bool operator ==(Group g1, Group g2)
        {
            if (ReferenceEquals(g1, null) && ReferenceEquals(g2, null)) return true;
            if (ReferenceEquals(g1, null) || ReferenceEquals(g2, null)) return false;

            return g1.groupName == g2.groupName &&
                   g1.specialization == g2.specialization &&
                   g1.courseNumber == g2.courseNumber;
        }
        public static bool operator !=(Group g1, Group g2)
        {
            return !(g1 == g2);
        }
        public override bool Equals(object obj)
        {
            return this == obj as Group;
        }
        public void EditGroup(string groupName, Specialization specialization, int courseNumber)
        {
            this.groupName = groupName;
            this.specialization = specialization;
            this.courseNumber = courseNumber;
        }
        public void TransferStudentToGroup(Student student, Group newGroup)
        {
            if (students.Contains(student))
            {
                students.Remove(student);
                newGroup.AddStudent(student);
            }
        }
        public void ExpelFailedStudents()
        {
            students.RemoveAll(student => student.GetExamGrades().Average() < 4.0);
        }
        public void ExpelWorstStudent()
        {
            if (students.Count > 0)
            {
                
                Student worstStudent = students
                    .Where(s => s.examGrades.Count > 0) 
                    .OrderBy(s => s.GetAverageExamGrade())
                    .FirstOrDefault();

                if (worstStudent != null)
                {
                    students.Remove(worstStudent);
                }
            }
        }

        public void ShowGroupInfo()
        {
            Console.WriteLine($"Группа: {groupName}, Специализация: {specialization}, Курс: {courseNumber}");
            Console.WriteLine("Список студентов:");

            var sortedStudents = students.OrderBy(s => s.GetLastName()).ThenBy(s => s.GetFirstName()).ToList();

            for (int i = 0; i < sortedStudents.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {sortedStudents[i].GetLastName()} {sortedStudents[i].GetFirstName()}");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            Group group = new Group();

            Student student1 = new Student("Загоруйко", "Алексей", "Дмитриевич", new DateTime(2000, 1, 1), "Адрес 1", "+380111111111");
            student1.SetExamGrades(new List<int> { 5, 4, 3 });

            Student student2 = new Student("Михайленко", "Андрей", "Андреевич", new DateTime(2008, 4, 8), "Адрес 2", "+380222222222");
            student2.SetExamGrades(new List<int> { 8, 7, 9 });

            group.AddStudent(student1);
            group.AddStudent(student2);

            foreach (var student in group)
            {
                Console.WriteLine($"Студент: {student.GetLastName()}, Средняя оценка: {student.GetAverageExamGrade()}");
            }

            List<Student> students = new List<Student>
            {
                student1,
                student2
            };

            Console.WriteLine("\nСортировка по фамилии:");
            students.Sort(new Student.CompareByLastName());
            foreach (var student in students)
            {
                Console.WriteLine(student.GetLastName());
            }

            Console.WriteLine("\nСортировка по средней оценке:");
            students.Sort(new Student.CompareByAverageExamGrade());
            foreach (var student in students)
            {
                Console.WriteLine($"{student.GetLastName()} - Средняя оценка: {student.GetAverageExamGrade()}");
            }

            group.ExpelWorstStudent();
            Console.WriteLine("\nГруппа после отчисления худшего студента:");
            group.ShowGroupInfo();
        }
    }
} 