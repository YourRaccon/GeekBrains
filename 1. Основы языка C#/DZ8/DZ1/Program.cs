using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DZ1
{
    //Корбун Т.И.
    /*
     С помощью рефлексии выведите все свойства структуры DateTime
     */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(String.Join<PropertyInfo>("\n", typeof(DateTime).GetProperties()));
            Console.ReadKey();
        }
    }
}
