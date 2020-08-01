using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ3
{
    class Point
    {
        double x;
        double y;

        public Point()
        {
            x = 0;
            y = 0;
        }

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public Point(Point point)
        {
            x = point.x;
            y = point.y;
        }

        public double countDistance(Point point)
        {
            return Math.Sqrt((point.x - this.x) * (point.x - this.x) + (point.y - this.y) * (point.y - this.y));
        }

        public double getX()
        {
            return x;
        }

        public double getY()
        {
            return y;
        }

        public void setX(double x)
        {
            this.x = x;
        }

        public void setY(double y)
        {
            this.y = y;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string tmp = "";
            double x, y;
            Console.Write("X1: ");
            tmp = Console.ReadLine();
            if (!double.TryParse(tmp, out x))
            {
                Console.Write("\nWrong number. If you want to write a fractional number, use only ','.\n");
                return;
            }
            Console.Write("Y1: ");
            tmp = Console.ReadLine();
            if (!double.TryParse(tmp, out y))
            {
                Console.Write("\nWrong number. If you want to write a fractional number, use only ','.\n");
                return;
            }
            Point point1 = new Point(x, y);

            Console.Write("X2: ");
            tmp = Console.ReadLine();
            if (!double.TryParse(tmp, out x))
            {
                Console.Write("\nWrong number. If you want to write a fractional number, use only ','.\n");
                return;
            }
            Console.Write("Y2: ");
            tmp = Console.ReadLine();
            if (!double.TryParse(tmp, out y))
            {
                Console.Write("\nWrong number. If you want to write a fractional number, use only ','.\n");
                return;
            }
            Point point2 = new Point(x, y);

            Console.WriteLine("\nDistance between points: {0:F2}", point1.countDistance(point2));
        }
    }
}
