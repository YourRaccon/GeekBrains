using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DZ1
{
    //Корбун Т.И.
    /*
     Создать программу, которая будет проверять корректность ввода логина. 
     Корректным логином будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита или цифры, 
     при этом цифра не может быть первой:
     а) без использования регулярных выражений;
     б) **с использованием регулярных выражений.
     */

    class Program
    {
        public static bool CheckLogin(string login)
        {
            if(login.Length >= 2 && login.Length <= 10 && !int.TryParse(login.Substring(0,1), out int tmp))
            {
                foreach(char ch in login){
                    if(!((ch >= '0' && ch <= '9') || (ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z')))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        public static bool CheckLoginWithRegex(string login)
        {
            Regex regex = new Regex("^[a-zA-Z][a-zA-Z0-9]{1,9}$");
            return regex.IsMatch(login);
        }

        static void Main(string[] args)
        {
            Console.Write("Введите логин: ");
            string login = Console.ReadLine();

            Console.WriteLine("а) Проверка без регулярок: {0}", CheckLogin(login));
            Console.WriteLine("б) Проверка с регулярками: {0}", CheckLoginWithRegex(login));
            Console.ReadKey();
        }
    }
}
