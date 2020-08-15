using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ3
{
    //Корбун Т.И.
    /*
     *Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой.
      Например:
      badc являются перестановкой abcd. 
     */

    class Program
    {
        public static bool HasSameChars(string str1, string str2)
        {
            if(str1.Length != str2.Length)
            {
                return false;
            }
            foreach(char ch in str1)
            {
                if(str2.IndexOf(ch) == -1)
                {
                    return false;
                }
                else
                {
                    str2 = str2.Remove(str2.IndexOf(ch), 1);
                }
            }
            return true;
        }

        static void Main(string[] args)
        {
            Console.Write("Введите первую строку: ");
            string str1 = Console.ReadLine();
            Console.Write("Введите вторую строку: ");
            string str2 = Console.ReadLine();

            Console.WriteLine(HasSameChars(str1, str2));
            Console.ReadKey();
        }
    }
}
