using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.XPath;

namespace Calculator
{
    public partial class Calculator : Form
    {
        double value = 0;
        string operation = " ";
        bool operationPressed = false;
        double memory;
        public Calculator()
        {
            InitializeComponent();
            buttonMC.Enabled = false;
            buttonMR.Enabled = false;
        }

        private void Calculator_Load(object sender, EventArgs e)
        {

        }

        private void button_Click(object sender, EventArgs e)
        {
            if ((result.Text == "0") || operationPressed)
                result.Clear();

            operationPressed = false;
            Button b = (Button)sender;
            if (b.Text == ".")
            {
                if (!(result.Text.Contains(".")))
                    result.Text = result.Text + b.Text;
            }

            else
            {
                result.Text = result.Text + b.Text;
            }
        }

        private void buttonCE_Click(object sender, EventArgs e)
        {
            result.Text = "0";
        }

        private void oprtator_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (value != 0)
            {   
                operationPressed = true;
                operation = b.Text;
                equation.Text = value + " " + operation;
            }
            else
            {
                operation = b.Text;
                value = Double.Parse(result.Text);
                operationPressed = true;
                equation.Text = value + " " + operation;
            }
        }

        private void equal_Click(object sender, EventArgs e)
        {
            equation.Text = " ";
            switch (operation)
            {
                case "+":
                    result.Text = (value + Double.Parse(result.Text)).ToString();
                    break;
                case "-":
                    result.Text = (value - Double.Parse(result.Text)).ToString();
                    break;
                case "*":
                    result.Text = (value * Double.Parse(result.Text)).ToString();
                    break;
                case "/":
                    result.Text = (value / Double.Parse(result.Text)).ToString();
                    break;
                default:
                    break;
            }
            value = Double.Parse(result.Text);
            operation = " ";
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            result.Text = "0";
            value = 0;
            equation.Text = " ";
        }

        private void Calculator_KeyPress(object sender, KeyPressEventArgs e)
        {
            equal.Focus();
            switch (e.KeyChar.ToString())
            {
                case "0":
                    button0.PerformClick();
                    break;
                case "1":
                    button1.PerformClick();
                    break;
                case "2":
                    button9.PerformClick();
                    break;
                case "3":
                    button8.PerformClick();
                    break;
                case "4":
                    button7.PerformClick();
                    break;
                case "5":
                    button6.PerformClick();
                    break;
                case "6":
                    button5.PerformClick();
                    break;
                case "7":
                    button4.PerformClick();
                    break;
                case "8":
                    button3.PerformClick();
                    break;
                case "9":
                    button02.PerformClick();
                    break;
                case "+":
                    plus.PerformClick();
                    break;
                case "-":
                    minus.PerformClick();
                    break;
                case "*":
                    multiplication.PerformClick();
                    break;
                case "/":
                    divison.PerformClick();
                    break;
                case "=":
                    equal.PerformClick();
                    break;
                default:
                    break;
            }
        }

        private void backSpace_Click(object sender, EventArgs e)
        {
            if (result.Text.Length > 0) 
            {
                result.Text = result.Text.Remove(result.Text.Length - 1, 1);
            }
            else if (result.Text == " ")
            {
                result.Text = "0";
            }
        }

        private void root_Click(object sender, EventArgs e)
        {
            try
            {
                double squareRoot = Double.Parse(result.Text);
                if (squareRoot > 0)
                {
                    equation.Text = System.Convert.ToString(result.Text);
                    squareRoot = Math.Sqrt(squareRoot);
                    result.Text = System.Convert.ToString(squareRoot);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void oneByx_Click(object sender, EventArgs e)
        {
            Double index;
            index = Convert.ToDouble(1.0 / Convert.ToDouble(result.Text));
            result.Text = System.Convert.ToString(index);
        }

        private void modulo_Click(object sender, EventArgs e)
        {
            Double index;
            index = Convert.ToDouble(result.Text) / Convert.ToDouble(100);
            result.Text = System.Convert.ToString(index);
        }

        private void memory_Click(object sender, EventArgs e)
        {
            Button MemoryButton = (Button)sender;
            switch (MemoryButton.Text)
            {
                case "MC":
                    result.Text = "0";
                    memory = 0;
                    buttonMR.Enabled = false;
                    buttonMC.Enabled = false;
                    break;
                case "MS":
                    memory = Double.Parse(result.Text);
                    buttonMC.Enabled = true;
                    buttonMR.Enabled = true;
                    break;
                case "MR":
                    result.Text =memory.ToString();
                break;
                case "M+":
                    memory = memory + Double.Parse(result.Text);
                    result.Text = memory.ToString();
                    break;
                case "M-":
                    memory = Double.Parse(result.Text) - memory;
                    result.Text = memory.ToString();
                    break;
                default:
                    break;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Will be developed!");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Application will be terminated!");
            Application.Exit();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Will be developed!");
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Adds the current result to the one in memory");

        }

        private void mToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Substracts the current result to the one in memory");
        }

        private void mCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Clears the memory ");
        }

        private void mRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Paste value from memory to textbox");
        }

        private void mSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Copy result into memory");
        }

        private void plusOrminus_Click(object sender, EventArgs e)
        {
            double value = Double.Parse(result.Text);
            value = value * -1;
            result.Text = value.ToString();
        }
    }
}
