using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ3
{
    //Корбун Т.И.
    /*
     Переделать программу Пример использования коллекций для решения следующих задач:
     а) Подсчитать количество студентов учащихся на 5 и 6 курсах; + 
     б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся (*частотный массив); +
     в) отсортировать список по возрасту студента; +
     г) *отсортировать список по курсу и возрасту студента;  +
     */

    class Student
    {
        public string lastName;
        public string firstName;
        public string university;
        public string faculty;
        public int course;
        public string department;
        public int group;
        public string city;
        public int age;
        
        public Student(string firstName, string lastName, string university, string faculty, string department, int course, int age, int group, string city)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.university = university;
            this.faculty = faculty;
            this.department = department;
            this.course = course;
            this.age = age;
            this.group = group;
            this.city = city;
        }
    }

    class Program
    {
        static int MyDelegat(Student st1, Student st2)
        {

            return String.Compare(st1.firstName, st2.firstName);
        }

        static int SortByAge(Student st1, Student st2)
        {

            return st1.age >= st2.age ? 1 : -1;
        }

        static int SortByAgeAndCourse(Student st1, Student st2)
        {
            if(st1.course >= st2.course)
            {
                return 1;
            } else if(st1.course == st2.course)
            {
                return st1.age >= st2.age ? 1 : -1;
            } else
            {
                return -1;
            }
        }

        static void Main(string[] args)
        {
            int bakalavr = 0;
            int magistr = 0;
            int fiveAndSix = 0;
            Dictionary<int, int> coursesAge = new Dictionary<int, int>();
            List<Student> list = new List<Student>();
            DateTime dt = DateTime.Now;
            StreamReader sr = new StreamReader("students.csv");
            while (!sr.EndOfStream)
            {
                try
                {
                    string[] s = sr.ReadLine().Split(';');
                    // Добавляем в список новый экземпляр класса Student
                    Student student = new Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[6]), int.Parse(s[5]), int.Parse(s[7]), s[8]);
                    list.Add(student);
                    // Одновременно подсчитываем количество бакалавров и магистров
                    if (student.course < 5) bakalavr++;
                    else
                    {
                        magistr++;
                        if(student.course == 5 || student.course == 6)
                        {
                            fiveAndSix++;
                        }
                    }
                    if(student.age >= 18 && student.age <= 20)
                    {
                        if (coursesAge.ContainsKey(student.course))
                        {
                            coursesAge[student.course]++;
                        }
                        else
                        {
                            coursesAge.Add(student.course, 1);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Ошибка!ESC - прекратить выполнение программы");
                    // Выход из Main
                    if (Console.ReadKey().Key == ConsoleKey.Escape) return;
                }
            }
            sr.Close();
            list.Sort(new Comparison<Student>(MyDelegat));
            Console.WriteLine("Всего студентов: " + list.Count);
            Console.WriteLine("Магистров: {0}", magistr);
            Console.WriteLine("Бакалавров: {0}", bakalavr);
            Console.WriteLine("Учащихся на 5 или 6 курсе: {0}", fiveAndSix);
            Console.WriteLine("Cколько студентов в возрасте от 18 до 20 лет на каком курсе учатся:");
            foreach(KeyValuePair<int, int> pair in coursesAge)
            {
                Console.WriteLine("Курс: {0}, кол-во: {1}", pair.Key, pair.Value);
            }
            list.Sort(new Comparison<Student>(SortByAge));
            Console.WriteLine("\nОтсортированно по возрасту:");
            foreach (Student student in list)
            {
                Console.WriteLine("{0} {1} {2} {3}", student.firstName, student.lastName, student.age, student.course);
            }
            list.Sort(new Comparison<Student>(SortByAgeAndCourse));
            Console.WriteLine("\nОтсортированно по возрасту и курсу (курс в приоритете):");
            foreach (Student student in list)
            {
                Console.WriteLine("{0} {1} {2} {3}", student.firstName, student.lastName, student.age, student.course);
            }
            Console.WriteLine(DateTime.Now - dt);
            Console.ReadKey();
        }
    }
}
