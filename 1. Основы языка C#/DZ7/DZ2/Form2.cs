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
    public partial class Form2 : Form
    {
        private Form1 parent;
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(Form1 parent) : this()
        {
            this.parent = parent;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int input;
            if(!int.TryParse(tbInput.Text, out input))
            {
                lblError.Visible = true;
                return;
            }
            lblError.Visible = false;
            if (parent.CheckNumber(input))
            {
                this.Enabled = false;
            }
        }

        private void Form2_FormClosing(Object sender, FormClosingEventArgs e)
        {
            parent.Close();
        }
    }
}
