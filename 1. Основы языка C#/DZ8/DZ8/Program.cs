using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DZ8
{
    static class Program
    {
        //Корбун Т.И.
        /*
         Создайте простую форму на котором свяжите свойство Text элемента TextBox со свойством Value элемента NumericUpDown
        */

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
