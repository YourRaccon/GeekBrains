using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DZ4
{
    //Корбун Т.И.
    /*
     *Задача ЕГЭ.
      На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней школы. 
      В первой строке сообщается количество учеников N, которое не меньше 10, но не превосходит 100, 
      каждая из следующих N строк имеет следующий формат:
      <Фамилия> <Имя> <оценки>,
      где <Фамилия> — строка, состоящая не более чем из 20 символов, 
      <Имя> — строка, состоящая не более чем из 15 символов, 
      <оценки> — через пробел три целых числа, соответствующие оценкам по пятибалльной системе. 
      <Фамилия> и <Имя>, а также <Имя> и <оценки> разделены одним пробелом. Пример входной строки:
      Иванов Петр 4 5 3
      Требуется написать как можно более эффективную программу, 
      которая будет выводить на экран фамилии и имена трёх худших по среднему баллу учеников. 
      Если среди остальных есть ученики, набравшие тот же средний балл, что и один из трёх худших, 
      следует вывести и их фамилии и имена.
     */

    class Student
    {
        public string firstName { get; }
        public string name { get; }

        public double averageScore { get; }

        public Student(string firstName, string name, double averageScore) 
        {
            if(firstName.Length > 20 || name.Length > 15 || averageScore > 5 || averageScore < 1)
            {
                throw new ArgumentException();
            }
            this.firstName = firstName;
            this.name = name;
            this.averageScore = averageScore;
        }

        public Student(string firstName, string name, int s1, int s2, int s3) : this(firstName, name, (s1 + s2 + s3) / 3.0)
        {
            if (s1 > 5 || s1 < 1 || s2 > 5 || s2 < 1 || s3 > 5 || s3 < 1)
            {
                throw new ArgumentException();
            }
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Student> worstStudents = new List<Student>();
            double notSoBad = 0;

            FileStream file = new FileStream("data.txt", FileMode.Open);
            StreamReader reader = new StreamReader(file);
            int studentCount;
            if (int.TryParse(reader.ReadLine(), out studentCount) && studentCount >= 10 && studentCount <= 100)
            {
                Regex regex = new Regex(@"^(?<firstName>\w+)\s+(?<name>\w+)\s+(?<s1>\d)\s+(?<s2>\d)\s+(?<s3>\d)$");
                int counter = 0;
                while (!reader.EndOfStream && counter++ < studentCount)
                {
                    string line = reader.ReadLine();
                    if (regex.IsMatch(line))
                    {
                        GroupCollection groups = regex.Match(line).Groups;
                        string firstName = groups["firstName"].Value;
                        string name = groups["name"].Value;
                        int s1 = int.Parse(groups["s1"].Value);
                        int s2 = int.Parse(groups["s2"].Value);
                        int s3 = int.Parse(groups["s3"].Value);
                        try
                        {
                            Student student = new Student(firstName, name, s1, s2, s3);
                            if (worstStudents.Count < 3)
                            {
                                worstStudents.Add(student);
                                if(notSoBad < student.averageScore)
                                {
                                    notSoBad = student.averageScore;
                                }
                            }
                            else
                            {
                                if (student.averageScore < notSoBad)
                                {
                                    double newNotSoBad = student.averageScore;
                                    List<Student> newWorstStudents = new List<Student>(worstStudents);
                                    foreach(Student s in worstStudents)
                                    {
                                        if(s.averageScore == notSoBad)
                                        {
                                            newWorstStudents.Remove(s);
                                        }
                                        else if(s.averageScore > newNotSoBad)
                                        {
                                            newNotSoBad = s.averageScore;
                                        }
                                    }
                                    if (newWorstStudents.Count >= 2)
                                    {
                                        worstStudents = newWorstStudents;
                                        notSoBad = newNotSoBad;
                                    }
                                    worstStudents.Add(student);
                                }
                                else if (student.averageScore == notSoBad)
                                {
                                    worstStudents.Add(student);
                                }
                            }
                        }
                        catch(ArgumentException e)
                        {
                            Console.WriteLine("Ваш {0} студент кривой! Он пропускается.", counter);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ваш {0} студент кривой! Он пропускается.", counter);
                    }
                }
                Console.WriteLine("Доска позора:");
                foreach(Student student in worstStudents)
                {
                    Console.WriteLine("{0} {1} (Средний балл: {2:F2})", student.firstName, student.name, student.averageScore);
                }
            }
            else
            {
                Console.WriteLine("Ошибочно задано количество студентов");
            }
            file.Close();
            reader.Close();

            Console.ReadKey();
        }
    }
}
