using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Просто посмотри код. Думаю это не стоит демонстрации в консоли.");
            int a = 1;
            int b = 2;

            //С тремя переменными
            int tmp = a;
            a = b;
            b = tmp;

            //С двумя переменными
            a += b;
            b = a - b;
            a -= b;
        }
    }
}
