using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ2
{
    //Корбун Т.И.
    /*
     Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата. 
     а) Сделать меню с различными функциями и представить пользователю выбор, для какой функции и на каком отрезке находить минимум. 
     Использовать массив (или список) делегатов, в котором хранятся различные функции.
     б) *Переделать функцию Load, чтобы она возвращала массив считанных значений. 
     Пусть она возвращает минимум через параметр (с использованием модификатора out). 
     */

    public delegate double Fun(double x);

    class Program
    {
        public static double F1(double x)
        {
            return x * x - 50 * x + 10;
        }

        public static double F2(double x)
        {
            return x + 1;
        }

        public static double F3(double x)
        {
            return x / 10 + 4;
        }

        public static double F4(double x)
        {
            return (x - 6) / x;
        }

        public static void SaveFunc(Fun F, string fileName, double a, double b, double h)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b)
            {
                bw.Write(F(x));
                x += h;
            }
            bw.Close();
            fs.Close();
        }

        public static double[] Load(string fileName, out double min)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            min = double.MaxValue;
            List<double> mas = new List<double>();
            double d;
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                // Считываем значение и переходим к следующему
                d = bw.ReadDouble();
                mas.Add(d);
                if (d < min) min = d;
            }
            bw.Close();
            fs.Close();
            return mas.ToArray();
        }

        public static void StartService(Fun F)
        {
            Console.Write("Укажите диапазон поиска минимума функции.\nЛевая граница: ");
            double a, b;
            if (!double.TryParse(Console.ReadLine(), out a))
            {
                Console.WriteLine("Некорректно задана граница диапазона. Необходимо задать целое число, либо число в виде десятичной дроби. Возврат в меню.");
                return;
            }
            Console.Write("Правая граница: ");
            if (!double.TryParse(Console.ReadLine(), out b))
            {
                Console.WriteLine("Некорректно задана граница диапазона. Необходимо задать целое число, либо число в виде десятичной дроби. Возврат в меню.");
                return;
            }
            if(a > b)
            {
                a = a + b;
                b = a - b;
                a = a - b;
            }
            SaveFunc(F, "data.bin", a, b, 0.5);
            double min;
            Load("data.bin", out min);
            Console.WriteLine("Минимум функции равен: {0}\n", min);
        }

        static void Main(string[] args)
        {
            List<Fun> functions = new List<Fun>();
            functions.Add(F1);
            functions.Add(F2);
            functions.Add(F3);
            functions.Add(F4);

            while (true)
            {
                Console.WriteLine("Программа нахождения минимума функции. Введите номер одной из предложенных ниже функций:\n" +
                    "1)x * x - 50 * x + 10" +
                    "\n2)x + 1" +
                    "\n3)x / 10 + 4" +
                    "\n4)(x - 6) / x");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1": 
                    case "2": 
                    case "3": 
                    case "4": StartService(functions[int.Parse(input) - 1]); break;
                    default: Console.WriteLine("Завершение работы программы"); Console.ReadKey(); return;
                }
            }
        }
    }
}
