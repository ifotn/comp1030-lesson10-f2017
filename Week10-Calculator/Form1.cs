using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week10_Calculator
{
    public partial class Form1 : Form
    {
        public decimal currentTotal;
        //decimal newValue;
        //decimal x;
        //decimal y;
        public string op;
        public bool firstInput = true;
        //bool firstCalc = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            btnDisplay.Text = "";
            currentTotal = 0;
            //newValue = 0;
            firstInput = true;
        }

        public void SetText(string value)
        {
            btnDisplay.Text += value;
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            SetText("7");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            SetText("8");
        }

        public void btn9_Click(object sender, EventArgs e)
        {
            SetText("9");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            SetText("4");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            SetText("5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            SetText("6");
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            SetText("1");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            SetText("2"); 
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            SetText("3");
        }

        public void btn0_Click(object sender, EventArgs e)
        {
           SetText("0");
        }

        private void btnDecimal_Click(object sender, EventArgs e)
        {
            btnDisplay.Text += ".";
        }

        public void Calculate(decimal newValue)
        {
            // don't calculate if we only have 1 input so far
            if (firstInput)
            {
                currentTotal = newValue;
                firstInput = false;         
            }

            else { 
                switch (op)
                {
                    case "+":
                        currentTotal += newValue;
                        break;
                    case "-":
                        currentTotal -= newValue;
                        break;
                    case "*":
                        currentTotal *= newValue;
                        break;
                    case "/":
                        if (newValue == 0) // cannot divide by zero
                        {
                            btnDisplay.Text = "ERROR";
                        }
                        else // 2nd number is not zero, so we can divide
                        {
                            currentTotal /= newValue;
                        } 
                        
                        break;
                    default:
                        currentTotal = newValue;
                        break;
                }
            }
            // clear display
            //btnDisplay.Text = "";

            //firstCalc = false;

            //return result;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // capture new value entered
            if (Decimal.TryParse(btnDisplay.Text, out Decimal x) == true) {
                // set operator
                op = "+";

                // perform calculation
                Calculate(x);
            }

            // clear display
            btnDisplay.Text = "";

        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            //newValue = Convert.ToDecimal(btnDisplay.Text);
            //Calculate();
            if (Decimal.TryParse(btnDisplay.Text, out Decimal x) == true)
            {
                // use last operator so don't specify any

                // perform calculation
                Calculate(x);
            }
            if (btnDisplay.Text != "ERROR")  // != means not equal to
            {
                btnDisplay.Text = Convert.ToString(currentTotal);
            }
            
            firstInput = true;
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            // capture new value entered
            if (Decimal.TryParse(btnDisplay.Text, out Decimal x) == true)
            {
                // set operator
                op = "-";

                // perform calculation
                Calculate(x);
            }
            btnDisplay.Text = "";
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            // capture new value entered
            if (Decimal.TryParse(btnDisplay.Text, out Decimal x) == true)
            {
                // set operator
                op = "*";

                // perform calculation
                Calculate(x);
            }
            btnDisplay.Text = "";
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            // capture new value entered
            if (Decimal.TryParse(btnDisplay.Text, out Decimal x) == true)
            {
                // set operator
                op = "/";

                // perform calculation
                Calculate(x);
            }
            btnDisplay.Text = "";
        }

        //private void Calc(decimal x, decimal y, string op)
        //{
        //    decimal result = 0;

        //    switch (op)
        //    {
        //        case "add":
        //            result = x + y;
        //            break;
        //        case "subtract":
        //            result = x - y;
        //            break;
        //        case "multiply":
        //            result = x * y;
        //            break;
        //        case "divide":
        //            result = x / y;
        //            break;
        //    }

        //    btnDisplay.Text = Convert.ToString(result);
        //}

        
    }
}
