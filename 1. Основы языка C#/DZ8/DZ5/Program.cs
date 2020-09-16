using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace DZ5
{
    //
    /*
     **Написать программу-преобразователь из CSV в XML-файл с информацией о студентах (6 урок).
    */

    public class Student
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

        public Student() { }

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
        static void Main(string[] args)
        {
            List<Student> list = new List<Student>();
            StreamReader sr = new StreamReader("students.csv");
            while (!sr.EndOfStream)
            {
                try
                {
                    string[] s = sr.ReadLine().Split(';');
                    Student student = new Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[6]), int.Parse(s[5]), int.Parse(s[7]), s[8]);
                    list.Add(student);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Ошибка!ESC - прекратить выполнение программы");
                    // Выход из Main
                    if (Console.ReadKey().Key == ConsoleKey.Escape) break;
                }
            }
            sr.Close();

            SaveStudentsAsXmlFormat(list, "students.xml");
        }

        static void SaveStudentsAsXmlFormat(List<Student> obj, string fileName)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Student>));
            Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            xmlFormat.Serialize(fStream, obj);
            fStream.Close();
        }

        static List<Student> LoadStudentsFromXmlFormat(string fileName)
        {
            List<Student> obj = new List<Student>();
            XmlSerializer xmlFormat = new XmlSerializer(typeof(Student));
            Stream fStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            obj = (xmlFormat.Deserialize(fStream) as List<Student>);
            fStream.Close();
            return obj;
        }
    }
}
