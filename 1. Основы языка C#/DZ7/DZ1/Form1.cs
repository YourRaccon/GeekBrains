using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DZ7
{
    public partial class Form1 : Form
    {
        private int goalNumber = 0;
        private int minSteps = 0;
        private Stack<int> steps;

        public Form1()
        {
            InitializeComponent();
            steps = new Stack<int>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveStep();
            lblNumber.Text = (int.Parse(lblNumber.Text) + 1).ToString();
            updateComandCounter();
        }

        private void btnCommand2_Click(object sender, EventArgs e)
        {
            SaveStep();
            lblNumber.Text = (int.Parse(lblNumber.Text) * 2).ToString();
            updateComandCounter();
        }

        private void SaveStep()
        {
            steps.Push(int.Parse(lblNumber.Text));
            btnGoBack.Enabled = true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            lblNumber.Text = "0";
            resetComandCounter();
            StopGame();
        }

        private void updateComandCounter()
        {
            lblComandCounter.Text = (int.Parse(lblComandCounter.Text) + 1).ToString();
            CheckWin();
        }

        private void resetComandCounter()
        {
            lblComandCounter.Text = "0";
            steps.Clear();
            btnGoBack.Enabled = false;
        }

        private void CheckWin()
        {
            if (goalNumber != 0)
            {
                if (goalNumber == int.Parse(lblNumber.Text))
                {
                    MessageBox.Show("Вы выиграли!^^");
                    StopGame();
                } else if(minSteps == int.Parse(lblComandCounter.Text))
                {
                    MessageBox.Show("Вы проиграли! :(\nПревышено минимальное число команд.");
                    StopGame();
                }
            }
        }

        private void StopGame()
        {
            lblGoal.Visible = false;
            goalNumber = 0;
            lblGoalNumber.Text = "0";
            lblGoalNumber.Visible = false;
        }

        int GetMinSteps(int num)
        {
            int counter = 0;
            while(num != 0)
            {
                if(num % 2 == 0)
                {
                    num /= 2;
                } else
                {
                    num--;
                }
                counter++;
            }
            return counter;
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            btnReset_Click(sender, e);
            var rnd = new Random();
            goalNumber = rnd.Next(1, 100);
            minSteps = GetMinSteps(goalNumber);
            MessageBox.Show("Ваша цель: получить число " + goalNumber + " за минимальное количество ходов!");
            lblGoal.Visible = true;
            lblGoalNumber.Text = goalNumber.ToString();
            lblGoalNumber.Visible = true;
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            lblNumber.Text = steps.Pop().ToString();
            lblComandCounter.Text = (int.Parse(lblComandCounter.Text) - 1).ToString();
            if(steps.Count == 0)
            {
                btnGoBack.Enabled = false;
            }
        }
    }
}
