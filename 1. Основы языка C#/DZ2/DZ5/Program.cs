using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ5
{
    //Корбун Татьяна Ивановна

    /*а) Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс массы и сообщает, 
         нужно ли человеку похудеть, набрать вес или всё в норме.
      б) *Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.*/

    class Program
    {
        public static double GetBodyMassIndex(double mass, double height)
        {
            return mass / (height * height) * 10000;
        }

        public static int CheckBodyMassIndex(double bodyMassIndex, double mass, double height)
        {
            if(bodyMassIndex < 18.5)
            {
                double needMass = 18.5 / 10000 * height * height;
                return (int)Math.Round(needMass - mass);
            }
            else if(bodyMassIndex >= 25)
            {
                double needMass = 25.0 / 10000 * height * height;
                return (int)Math.Round(needMass - mass);
            }
            else
            {
                return 0;
            }
        }

        static void Main(string[] args)
        {
            string tmp = "";
            double height, mass;

            Console.Write("Ваш рост: ");
            tmp = Console.ReadLine();
            if (!double.TryParse(tmp, out height) || height < 0)
            {
                Console.Write("\nРост должен быть задан числом, большим нуля. Если Вы хотите ввести дробное число, используйте только ','.\n");
                Console.ReadKey();
                return;
            }

            Console.Write("Ваш вес: ");
            tmp = Console.ReadLine();
            if (!double.TryParse(tmp, out mass) || mass < 0)
            {
                Console.Write("\nВес должен быть задан числом, большим нуля. Если Вы хотите ввести дробное число, используйте только ','.\n");
                Console.ReadKey();
                return;
            }

            double bodyMassIndex = GetBodyMassIndex(mass, height);
            Console.WriteLine("\nИндекс массы тела: {0:F5}", bodyMassIndex);

            int delta = CheckBodyMassIndex(bodyMassIndex, mass, height);
            if(delta > 0)
            {
                Console.WriteLine("Ваш вес ниже нормы! Вам нужно набрать как минимум {0} кг.", delta);
            }
            else if(delta < 0)
            {
                Console.WriteLine("Ваш вес выше нормы! Вам нужно сбросить как минимум {0} кг.", Math.Abs(delta));
            }
            else
            {
                Console.WriteLine("Ваш вес в пределах нормы!");
            }

            Console.ReadKey();
        }
    }
}
