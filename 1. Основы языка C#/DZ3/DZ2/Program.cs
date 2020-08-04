using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ2
{
    //Корбун Татьяна Ивановна

    /*а)  С клавиатуры вводятся числа, пока не будет введён 0 (каждое число в новой строке). 
          Требуется подсчитать сумму всех нечётных положительных чисел. Сами числа и сумму вывести на экран, 
          используя tryParse.*/

    class Program
    {
        static void Main(string[] args)
        {
            string numbers = "";
            string input;
            int sum = 0;
            int tmp;
            do
            {
                input = Console.ReadLine();
                if(int.TryParse(input, out tmp))
                {
                    if(tmp > 0 && tmp % 2 != 0)
                    {
                        sum += tmp;
                        numbers += tmp + ", ";
                    }
                }
            } while (!input.Equals("0"));
            numbers = numbers.Remove(numbers.Length - 2, 2);
            Console.WriteLine("Были введены следующие пложительные нечетные числа:\n[{0}]\nИх сумма: {1}", numbers, sum);
            Console.ReadKey();
        }
    }
}
