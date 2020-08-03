using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ7
{
    //Корбун Татьяна Ивановна

    /*a) Разработать рекурсивный метод, который выводит на экран числа от a до b(a<b).
      б) *Разработать рекурсивный метод, который считает сумму чисел от a до b.*/

    class Program
    {
        //а
        public static void PrintNumbers(int a, int b)
        {
            if (a > b)
            {
                return;
            }
            else
            {
                Console.WriteLine(a);
                a++;
                PrintNumbers(a, b);
            }
        }

        //б
        public static int GetNumbersSum(int a, int b)
        {
            if (a == b)
            {
                return b;
            }
            else
            {
                return a + GetNumbersSum(a + 1, b);
            }
        }

        //тест методов
        static void Main(string[] args)
        {
            Console.WriteLine("Вывод чисел от 1 до 10:");
            PrintNumbers(1, 10);
            int sum = GetNumbersSum(1, 10);
            Console.WriteLine("Сумма чисел от 1 до 10: {0}", sum);
            Console.ReadKey();
        }
    }
}
