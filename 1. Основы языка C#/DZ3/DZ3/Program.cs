using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ1
{
    //Корбун Татьяна Ивановна

    /*а) Дописать структуру Complex, добавив метод вычитания комплексных чисел. Продемонстрировать работу структуры.
      б) Дописать класс Complex, добавив методы вычитания и произведения чисел. Проверить работу класса.
      в) Добавить диалог с использованием switch демонстрирующий работу класса.
    */

    struct Complex
    {
        double real;
        double imaginary;

        public Complex(double real, double imaginary)
        {
            this.real = real;
            this.imaginary = imaginary;
        }

        public static Complex operator +(Complex complex1, Complex complex2)
        {
            return new Complex(complex1.real + complex2.real, complex1.imaginary + complex2.imaginary);
        }

        public static Complex operator -(Complex complex1, Complex complex2)
        {
            return new Complex(complex1.real - complex2.real, complex1.imaginary - complex2.imaginary);
        }

        public static Complex operator *(Complex complex1, Complex complex2)
        {
            return new Complex(complex1.real * complex2.real - complex1.imaginary * complex2.imaginary,
                               complex1.real * complex2.imaginary + complex2.real * complex1.imaginary);
        }

        public string ToString()
        {
            return "" + real + " + i * " + imaginary; 
        }

        public void SetReal(double real)
        {
            this.real = real;
        }

        public void SetImaginary(double imaginary)
        {
            this.imaginary = imaginary;
        }

        public double GetReal()
        {
            return real;
        }

        public double GetImaginary()
        {
            return imaginary;
        }
    }

    class Program
    {
        public static Complex AddComplex(Complex complex1)
        {
            Complex complex2 = new Complex(0, 0);
            string input;
            double tmp;
            Console.Write("x: ");
            input = Console.ReadLine();
            if(double.TryParse(input, out tmp))
            {
                complex2.SetReal(tmp);
            }
            else
            {
                Console.WriteLine("Введено некоррекное значение. Можно вводить только числа! Действие было отменено.");
                return complex1;
            }
            Console.Write("y: ");
            input = Console.ReadLine();
            if (double.TryParse(input, out tmp))
            {
                complex2.SetImaginary(tmp);
            }
            else
            {
                Console.WriteLine("Введено некоррекное значение. Можно вводить только числа! Действие было отменено.");
                return complex1;
            }

            return complex1 + complex2;
        }

        public static Complex SubComplex(Complex complex1)
        {
            Complex complex2 = new Complex(0, 0);
            string input;
            double tmp;
            Console.Write("x: ");
            input = Console.ReadLine();
            if (double.TryParse(input, out tmp))
            {
                complex2.SetReal(tmp);
            }
            else
            {
                Console.WriteLine("Введено некоррекное значение. Можно вводить только числа! Действие было отменено.");
                return complex1;
            }
            Console.Write("y: ");
            input = Console.ReadLine();
            if (double.TryParse(input, out tmp))
            {
                complex2.SetImaginary(tmp);
            }
            else
            {
                Console.WriteLine("Введено некоррекное значение. Можно вводить только числа! Действие было отменено.");
                return complex1;
            }

            return complex1 - complex2;
        }

        public static Complex MultComplex(Complex complex1)
        {
            Complex complex2 = new Complex(0, 0);
            string input;
            double tmp;
            Console.Write("x: ");
            input = Console.ReadLine();
            if (double.TryParse(input, out tmp))
            {
                complex2.SetReal(tmp);
            }
            else
            {
                Console.WriteLine("Введено некоррекное значение. Можно вводить только числа! Действие было отменено.");
                return complex1;
            }
            Console.Write("y: ");
            input = Console.ReadLine();
            if (double.TryParse(input, out tmp))
            {
                complex2.SetImaginary(tmp);
            }
            else
            {
                Console.WriteLine("Введено некоррекное значение. Можно вводить только числа! Действие было отменено.");
                return complex1;
            }

            return complex1 * complex2;
        }

        static void Main(string[] args)
        {
            string input;
            bool done = false;
            Complex complex = new Complex(0, 0);
            do
            {
                Console.WriteLine("Текущее комплексное число: {0}\nДоступные действия:\n" +
                    "1) Сложить\n" +
                    "2) Вычесть\n" +
                    "3) Перемножить\n", complex.ToString());

                input = Console.ReadLine();
                switch (input)
                {
                    case "1": complex = AddComplex(complex); break;
                    case "2": complex = SubComplex(complex); break;
                    case "3": complex = MultComplex(complex); break;
                    default: done = true; break;
                }

            } while (!done);
            Console.WriteLine("Сеанс окончен! Для выхода нажмите любую кнопку.");
            Console.ReadKey();
        }
    }
}
