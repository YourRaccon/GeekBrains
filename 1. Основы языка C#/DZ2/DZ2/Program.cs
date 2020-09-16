using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ1
{
    class Program
    {
        //Корбун Татьяна Ивановна

        //Написать метод, возвращающий минимальное из трёх чисел.
        public static int GetMin(int a, int b, int c)
        {
            if(a <= b && a <= c)
            {
                return a;
            } else if(b <= c)
            {
                return b;
            } else
            {
                return c;
            }
        }

        //Написать метод подсчета количества цифр числа.
        public static int GetLength(int num)
        {
            num = Math.Abs(num);
            return ("" + num).Length;
        }

        //С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать сумму всех нечетных положительных чисел.
        static void Main(string[] args)
        {
            string input = "";
            int sum = 0, tmp = 0;
            Console.WriteLine("Вводите числа. Для завершения введите '0'");
            do
            {
                input = Console.ReadLine();
                if(int.TryParse(input, out tmp) && tmp > 0 && tmp % 2 != 0)
                {
                    sum += tmp;
                }
            } while (!input.Equals("0"));
            Console.WriteLine("Сумма введенных нечетных положительных чисел: {0}", sum);
            Console.ReadKey();
        }
    }
}
