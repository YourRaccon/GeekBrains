using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ1
{
    //Корбун Т.И.
    /*
     Изменить программу вывода таблицы функции так, чтобы можно было передавать функции типа double (double, double). 
     Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x).
     */

    public delegate double Fun(double x);
    public delegate double Fun2(double x, double y);

    class Program
    {
        public static void Table(Fun F, double x, double b)
        {
            Console.WriteLine("----- X ----- Y -----");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(x));
                x += 1;
            }
            Console.WriteLine("---------------------");
        }

        public static void Table(Fun2 F, double x, double b, double a)
        {
            Console.WriteLine("----- X ----- Y -----");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(x,a));
                x += 1;
            }
            Console.WriteLine("---------------------");
        }

        public static double MyFunc(double x)
        {
            return x * x * x;
        }

        public static double MyFunc2(double x, double y)
        {
            return y * x * x;
        }

        public static double MySin(double x, double y)
        {
            return y * Math.Sin(x);
        }

        static void Main(string[] args)
        {
            Console.Write("a: ");
            double a;
            if (!double.TryParse(Console.ReadLine(), out a))
            {
                Console.WriteLine("Ошибка ввода. Необходимо задать целое число, либо число в виде десятичной дроби.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Таблица функции a*x^2:");
            Table(MyFunc2, -2, 2, a);

            Console.WriteLine("Таблица функции a*sin(x):");
            Table(MyFunc2, -2, 2, a);

            Console.ReadKey();
        }
    }
}
