using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student
{
    public class Student
    {
        private string lastName;
        private string firstName;
        private string middleName;
        private DateTime birthDate;
        private string homeAddress;
        private string phoneNumber;
        private List<int> homeworkGrades;
        private List<int> courseworkGrades;
        private List<int> examGrades;

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
    internal class Program
    {
        static void Main(string[] args)
        {
            Student Alex = new Student(
            lastName: "Загоруйко",
            firstName: "Александр",
            middleName: "Дмитриевич",
            birthDate: new DateTime(2000, 01, 01),
            homeAddress: "г. Одесса, ул. -, кв. -",
            phoneNumber: "+380123456789");

            Alex.SetHomeworkGrades(new List<int> { 9, 8, 10 });
            Alex.SetCourseworkGrades(new List<int> { 7, 8 });
            Alex.SetExamGrades(new List<int> { 10, 9 });

            Alex.ShowStudentInfo();
        }
    }
}
