using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ5
{
    class Program
    {
        static void printToCenter(string msg)
        {
            int w = Console.WindowWidth / 2 - (msg.Length / 2);
            int h = Console.WindowHeight / 2;
            Console.SetCursorPosition(w, h);
            Console.Write(msg);
        } 

        static void Main(string[] args)
        {
            printToCenter("Korbun Tatiana, Moscow\n");
        }
    }
}
