using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ3
{
    //Корбун Татьяна Ивановна

    /*Описать класс дробей — рациональных чисел, являющихся отношением двух целых чисел. Предусмотреть методы сложения, вычитания, умножения и деления дробей. Написать программу, демонстрирующую все разработанные элементы класса.
      *Добавить свойства типа int для доступа к числителю и знаменателю;
      *Добавить свойство типа double только на чтение, чтобы получить десятичную дробь числа;
      **Добавить проверку, чтобы знаменатель не равнялся 0. Выбрасывать исключение ArgumentException("Знаменатель не может быть равен 0");
      ***Добавить упрощение дробей.*/

    class Fraction
    {
        int top;
        int bottom;

        public Fraction(int top, int bottom)
        {
            this.top = top;
            if (bottom == 0)
            {
                throw new ArgumentException("Знаменатель не может быть равен 0");
            }
            this.bottom = bottom;
        }

        public Fraction(Fraction fraction)
        {
            this.top = fraction.top;
            this.bottom = fraction.bottom;
        }

        public Fraction(int top)
        {
            this.top = top;
            this.bottom = 1;
        }

        public Fraction()
        {
            this.top = 1;
            this.bottom = 1;
        }

        public static Fraction operator +(Fraction fraction1, Fraction fraction2)
        {
            return new Fraction(fraction1.top * fraction2.bottom + fraction2.top * fraction1.bottom, fraction1.bottom * fraction2.bottom).Simplify();
        }

        public static Fraction operator -(Fraction fraction1, Fraction fraction2)
        {
            return new Fraction(fraction1.top * fraction2.bottom - fraction2.top * fraction1.bottom, fraction1.bottom * fraction2.bottom).Simplify();
        }

        public static Fraction operator *(Fraction fraction1, Fraction fraction2)
        {
            return new Fraction(fraction1.top * fraction2.top, fraction1.bottom * fraction2.bottom).Simplify();
        }

        public static Fraction operator /(Fraction fraction1, Fraction fraction2)
        {
            return new Fraction(fraction1.top * fraction2.bottom, fraction1.bottom * fraction2.top).Simplify();
        }

        public double GetDecimal()
        {
            return (double)top / (double)bottom;
        }

        public Fraction Simplify()
        {
            int min = Math.Abs(top > bottom ? bottom : top);
            Fraction fraction = new Fraction(this);
            fraction.SetTop(Math.Abs(fraction.top));
            fraction.SetBottom(Math.Abs(fraction.bottom));
            for (int i = min; i > 1; i--)
            {
                if(fraction.top % i == 0 && fraction.bottom % i == 0)
                {
                    fraction.SetTop(fraction.top / i);
                    fraction.SetBottom(fraction.bottom / i);
                }
            }
            this.SetTop(this.top / Math.Abs(this.top) * fraction.top);
            this.SetBottom(this.bottom / Math.Abs(this.bottom) * fraction.bottom);
            return this;
        }

        public string ToString()
        {
            return "" + top + " / " + bottom;
        }

        public void SetTop(int top)
        {
            this.top = top;
        }

        public void SetBottom(int bottom)
        {
            if(bottom == 0)
            {
                throw new ArgumentException("Знаменатель не может быть равен 0");
            }
            this.bottom = bottom;
        }

        public int GetTop()
        {
            return top;
        }

        public int GetBottom()
        {
            return bottom;
        }
    }

    class Program
    {
        public static Fraction AddFraction(Fraction fraction1)
        {
            Fraction fraction2 = new Fraction();
            string input;
            int tmp;
            Console.Write("Числитель: ");
            input = Console.ReadLine();
            if (int.TryParse(input, out tmp))
            {
                fraction2.SetTop(tmp);
            }
            else
            {
                Console.WriteLine("Введено некоррекное значение. Можно вводить только числа! Действие было отменено.");
                return fraction1;
            }
            Console.Write("Знаменатель: ");
            input = Console.ReadLine();
            if (int.TryParse(input, out tmp))
            {
                fraction2.SetBottom(tmp);
            }
            else
            {
                Console.WriteLine("Введено некоррекное значение. Можно вводить только числа! Действие было отменено.");
                return fraction1;
            }

            return fraction1 + fraction2;
        }

        public static Fraction SubFraction(Fraction fraction1)
        {
            Fraction fraction2 = new Fraction();
            string input;
            int tmp;
            Console.Write("Числитель: ");
            input = Console.ReadLine();
            if (int.TryParse(input, out tmp))
            {
                fraction2.SetTop(tmp);
            }
            else
            {
                Console.WriteLine("Введено некоррекное значение. Можно вводить только числа! Действие было отменено.");
                return fraction1;
            }
            Console.Write("Знаменатель: ");
            input = Console.ReadLine();
            if (int.TryParse(input, out tmp))
            {
                fraction2.SetBottom(tmp);
            }
            else
            {
                Console.WriteLine("Введено некоррекное значение. Можно вводить только числа! Действие было отменено.");
                return fraction1;
            }

            return fraction1 - fraction2;
        }

        public static Fraction MultFraction(Fraction fraction1)
        {
            Fraction fraction2 = new Fraction();
            string input;
            int tmp;
            Console.Write("Числитель: ");
            input = Console.ReadLine();
            if (int.TryParse(input, out tmp))
            {
                fraction2.SetTop(tmp);
            }
            else
            {
                Console.WriteLine("Введено некоррекное значение. Можно вводить только числа! Действие было отменено.");
                return fraction1;
            }
            Console.Write("Знаменатель: ");
            input = Console.ReadLine();
            if (int.TryParse(input, out tmp))
            {
                fraction2.SetBottom(tmp);
            }
            else
            {
                Console.WriteLine("Введено некоррекное значение. Можно вводить только числа! Действие было отменено.");
                return fraction1;
            }

            return fraction1 * fraction2;
        }

        public static Fraction DivFraction(Fraction fraction1)
        {
            Fraction fraction2 = new Fraction();
            string input;
            int tmp;
            Console.Write("Числитель: ");
            input = Console.ReadLine();
            if (int.TryParse(input, out tmp))
            {
                fraction2.SetTop(tmp);
            }
            else
            {
                Console.WriteLine("Введено некоррекное значение. Можно вводить только числа! Действие было отменено.");
                return fraction1;
            }
            Console.Write("Знаменатель: ");
            input = Console.ReadLine();
            if (int.TryParse(input, out tmp))
            {
                fraction2.SetBottom(tmp);
            }
            else
            {
                Console.WriteLine("Введено некоррекное значение. Можно вводить только числа! Действие было отменено.");
                return fraction1;
            }

            return fraction1 / fraction2;
        }

        static void Main(string[] args)
        {
            string input;
            bool done = false;
            Fraction fraction = new Fraction();
            do
            {
                Console.WriteLine("Текущая дробь: {0}\nДоступные действия:\n" +
                    "1) Сложить\n" +
                    "2) Вычесть\n" +
                    "3) Перемножить\n" +
                    "4) Разелить\n" +
                    "5) Получить десятичное представление", fraction.ToString());

                input = Console.ReadLine();
                switch (input)
                {
                    case "1": fraction = AddFraction(fraction); break;
                    case "2": fraction = SubFraction(fraction); break;
                    case "3": fraction = MultFraction(fraction); break;
                    case "4": fraction = DivFraction(fraction); break;
                    case "5": Console.WriteLine("Десятичное представление: {0:F5}", fraction.GetDecimal()); break;
                    default: done = true; break;
                }

            } while (!done);
            Console.WriteLine("Сеанс окончен! Для выхода нажмите любую кнопку.");
            Console.ReadKey();
        }
    }
}
