using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ1
{
    class Program
    {
        static void Main(string[] args)
        {
            string tmp = "";
            double height, weigh;
            int age;

            Console.Write("Your first name: ");
            string firstName = Console.ReadLine();

            Console.Write("\nYour surname: ");
            string surname = Console.ReadLine();

            Console.Write("\nYour age: ");
            tmp = Console.ReadLine();
            if(!int.TryParse(tmp, out age) || age < 0)
            {
                Console.Write("\nWrong age. Age must be a number greater than zero.\n");
                return;
            }

            Console.Write("\nYour height: ");
            tmp = Console.ReadLine();
            if (!double.TryParse(tmp, out height) || height < 0)
            {
                Console.Write("\nWrong height. Height must be a number greater than zero. If you want to write a fractional number, use only ','.\n");
                return;
            }

            Console.Write("\nYour weigh: ");
            tmp = Console.ReadLine();
            if (!double.TryParse(tmp, out weigh) || weigh < 0)
            {
                Console.Write("\nWrong weigh. Weigh must be a number greater than zero. If you want to write a fractional number, use only ','.\n");
                return;
            }

            Console.Write("\na) " + firstName + " " + surname + ", age: " + age + ", height: " + height + ", weigh: " + weigh);
            Console.Write("\nb) {0} {1}, age: {2}, height: {3:F1}, weigh: {4:F1}", firstName, surname, age, height, weigh);
            Console.Write("\nc) {0:C1} {1:C1}, age: {2:C1}, height: {3:C1}, weigh: {4:C1}", firstName, surname, age, height, weigh);
            Console.Write("\nНадеюсь я правильно поняла задание с долларом ^^'\n");
            Console.WriteLine("Внезапно второе задание. Ваш индекс массы тела:");
            Console.WriteLine("{0:F5}", weigh / (height * height));
        }
    }
}
