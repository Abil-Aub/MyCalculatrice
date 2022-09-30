using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabelTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.')
            {
                label1.Text += e.KeyChar;
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            PushTheButton( e.KeyChar.ToString() );
        }
        private void PushTheButton(String s)
        {
            textBox1.Text += s;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            PushTheButton(button.Text);
        }
    }
}
