using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCalculatrice
{
    public partial class Form1 : Form
    {
        private double result = 0;
        private string operation = "NA";
        private bool enterNumber = false;

        public Form1()
        {
            InitializeComponent();
            btnClickHandler();
        }

        private void btnClickHandler()
        {
            btn1.Click += new System.EventHandler(btn_Click);
            btn2.Click += new System.EventHandler(btn_Click);
            btn3.Click += new System.EventHandler(btn_Click);
            btn4.Click += new System.EventHandler(btn_Click);
            btn5.Click += new System.EventHandler(btn_Click);
            btn6.Click += new System.EventHandler(btn_Click);
            btn7.Click += new System.EventHandler(btn_Click);
            btn8.Click += new System.EventHandler(btn_Click);
            btn9.Click += new System.EventHandler(btn_Click);
            btn0.Click += new System.EventHandler(btn_Click);
            btnDiv.Click += new System.EventHandler(opr_Click);
            btnMult.Click += new System.EventHandler(opr_Click);
            btnMinus.Click += new System.EventHandler(opr_Click);
            btnPlus.Click += new System.EventHandler(opr_Click);
        }

        #region Enter Number
        // To-Do: Only numbers characters

        private void btn_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (tbScreen.Text == "0" || enterNumber == false)
            {
                tbScreen.Text = button.Text;
                enterNumber = true;
            }
            else
                tbScreen.Text += button.Text;
        }

        private void btnPoint_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (enterNumber == false)
            {
                tbScreen.Text = "0,";
                enterNumber = true;
            }
            else if (!tbScreen.Text.Contains(","))
                tbScreen.Text += ",";
        }
        #endregion

        #region Operations
        // To-Do: Divide by Zero correction
        private void opr_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;  
            if (operation == "NA")
            {
                try
                {
                    result = Convert.ToDouble(tbScreen.Text);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(tbScreen.Text);
                    Application.Exit();
                }
            }
            else
                btnEqual_Click(sender, e);

            operation = button.Text;
            enterNumber = false;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            var a = result;
            var b = new double();
            try
            {
                // b = double.Parse(tbScreen.Text, CultureInfo.InvariantCulture);
                b = Convert.ToDouble(tbScreen.Text);

            }
            catch(Exception ex)
            {
                Console.WriteLine(tbScreen.Text.GetType());
                Console.WriteLine(tbScreen.Text);
                Application.Exit();
            }

            result = myCalculate(a, b);
            tbScreen.Text = Convert.ToString(result);
            enterNumber = false;
        }
        
        private double myCalculate(double a, double b)
        {
            switch (operation)
            {
                case "/":
                    if (b != 0)
                        result = a / b;
                    else
                    {
                        MessageBox.Show("Division of by zero.");
                        result = a;
                    }
                    break;
                case "*":
                    result = a * b;
                    break;
                case "-":
                    result = a - b;
                    break;
                case "+":
                    result =a + b;
                    break;
            }
            return result;
        }
        #endregion

        #region Reinitition 
        private void btnC_Click(object sender, EventArgs e)
        {
            tbScreen.Text = "0";
            result = 0;
            operation = "NA";
            enterNumber = false;
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            tbScreen.Text = "0";
        }
        #endregion

        private void tbScreen_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (Char.IsDigit(e.KeyChar))
            {
                if (tbScreen.Text == "0" || enterNumber == false)
                {
                    tbScreen.Text = e.KeyChar.ToString();
                    enterNumber = true;
                }
                else
                    tbScreen.Text += e.KeyChar.ToString();
            }
            else if (e.KeyChar.ToString() == ".")
            {
                if (enterNumber == false)
                {
                    tbScreen.Text = "0,";
                    enterNumber = true;
                }
                else if (!tbScreen.Text.Contains(","))
                    tbScreen.Text += ",";
            }
            else if ("+-/*".Contains(e.KeyChar.ToString()) )
            {
                if (operation == "NA")
                {
                    try
                    {
                        result = Convert.ToDouble(tbScreen.Text);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(tbScreen.Text);
                        Application.Exit();
                    }
                }
                else
                    btnEqual_Click(sender, e);

                operation = e.KeyChar.ToString();
                enterNumber = false;
            }
            else if (e.KeyChar == (char)Keys.Return)
            {
                var a = result;
                var b = new double();
                try
                {
                    // b = double.Parse(tbScreen.Text, CultureInfo.InvariantCulture);
                    b = Convert.ToDouble(tbScreen.Text);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(tbScreen.Text.GetType());
                    Console.WriteLine(tbScreen.Text);
                    Application.Exit();
                }

                result = myCalculate(a, b);
                tbScreen.Text = Convert.ToString(result);
                enterNumber = false;
            }
        }
    }
}
