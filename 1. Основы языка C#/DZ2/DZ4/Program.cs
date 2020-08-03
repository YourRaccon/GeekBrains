using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ4
{
    //Корбун Татьяна Ивановна

    /*Реализовать метод проверки логина и пароля. 
    На вход метода подается логин и пароль. 
    На выходе истина, если прошел авторизацию, и ложь, если не прошел (Логин: root, Password: GeekBrains). 
    Используя метод проверки логина и пароля, написать программу: пользователь вводит логин и пароль, 
    программа пропускает его дальше или не пропускает. 
    С помощью цикла do while ограничить ввод пароля тремя попытками.*/

    class Program
    {
        private static string login = "root";
        private static string password = "GeekBrains";

        public static bool CheckLogin(string login, string password)
        {
            if(Program.login.Equals(login) && Program.password.Equals(password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void Main(string[] args)
        {
            string login, password;
            int tries = 3;
            do
            {
                Console.Write("Попыток авторизации: {0}.\nВведите логин: ", tries);
                login = Console.ReadLine();
                Console.Write("Введите пароль: ");
                password = Console.ReadLine();
                if(CheckLogin(login, password))
                {
                    break;
                }
            } while (--tries > 0);
            if (tries > 0)
            {
                Console.WriteLine("Вы успешно авторизовались!");
            }
            else
            {
                Console.WriteLine("У Вас закончились попытки!");
            }
            Console.ReadKey();
        }
    }
}
