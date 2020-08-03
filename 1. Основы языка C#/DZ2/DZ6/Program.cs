using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ6
{
    //Корбун Татьяна Ивановна

    /*Написать программу подсчета количества «хороших» чисел в диапазоне от 1 до 1 000 000 000. 
     «Хорошим» называется число, которое делится на сумму своих цифр. 
     Реализовать подсчёт времени выполнения программы, используя структуру DateTime.*/

    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            int sum = 1;
            DateTime startTime = DateTime.Now;
            for (int num = 1; num <= 1_000_000_000; num++)
            {
                if (num % sum == 0) counter++;
                sum++;
                int tmp = num;
                while(tmp % 10 == 9)
                {
                    sum -= 9;
                    tmp /= 10;
                }
            }
            DateTime endTime = DateTime.Now;
            Console.WriteLine("Количество \"хороших\" чисел: {0}\nВремя расчета заняло {1} сек.", counter, (endTime - startTime).Seconds);
            Console.ReadKey();
        }
    }
}
