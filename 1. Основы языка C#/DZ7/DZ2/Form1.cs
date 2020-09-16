using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DZ2
{
    public partial class Form1 : Form
    {
        private Form2 child;
        private int number;

        public Form1()
        {
            InitializeComponent();
        }

        private void NextNumber()
        {
            Random rnd = new Random();
            number = rnd.Next(1, 100);
        }

        private void StartGame()
        {
            lblMessage.Text = @"Я загадал число от 1 до 100,
попробуй отгадать!";
            NextNumber();
            ResetCounter();
            child.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form2 inputForm = new Form2(this);
            child = inputForm;
            child.Show();
            StartGame();
        }

        public bool CheckNumber(int checkNumber)
        {
            if (!lblMessage.Text.Equals("Вы угадали!"))
            {
                if (checkNumber == number)
                {
                    lblMessage.Text = "Вы угадали!";
                    return true;
                } else if (checkNumber > number)
                {
                    lblMessage.Text = "↓ Бери меньше ↓";
                }
                else
                {
                    lblMessage.Text = "↑ Бери больше ↑";
                }
                UpdateCounter();
                return false;
            }
            return true;
        }

        private void UpdateCounter()
        {
            lblCounter.Text = (int.Parse(lblCounter.Text) + 1).ToString();
        }

        private void ResetCounter()
        {
            lblCounter.Text = "0";
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            StartGame();
        }
    }
}
