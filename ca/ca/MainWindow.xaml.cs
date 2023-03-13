using System;
using System.Windows;
using System.Windows.Controls;

namespace MyCalculatorv1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            tb.Text += button.Content.ToString();
        }

        private void Result_click(object sender, RoutedEventArgs e)
        {
            try
            {
                CalculateResult();
            }
            catch (Exception exc)
            {
                tb.Text = "Error!";
            }
        }

        private void CalculateResult()
        {
            string input = tb.Text;
            string[] commands = input.Split(new char[] { '+', '-', '*', '/', '^' });

            double result = 0.0;
            char lastOperator = '+';

            foreach (string command in commands)
            {
                if (command.Trim() == "")
                {
                    continue;
                }

                double operand = Convert.ToDouble(command.Trim());

                switch (lastOperator)
                {
                    case '+':
                        result += operand;
                        break;
                    case '-':
                        result -= operand;
                        break;
                    case '*':
                        result *= operand;
                        break;
                    case '/':
                        result /= operand;
                        break;
                    case '^':
                        result = Math.Pow(result, operand);
                        break;
                    default:
                        throw new InvalidOperationException("Invalid operator.");
                }

                if (command.Length > 0)
                {
                    lastOperator = input[input.IndexOf(command) + command.Length];
                }
            }

            tb.Text += " = " + result.ToString();
        }

        private void Off_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            tb.Text = "";
        }

        private void R_Click(object sender, RoutedEventArgs e)
        {
            if (tb.Text.Length > 0)
            {
                tb.Text = tb.Text.Substring(0, tb.Text.Length - 1);
            }
        }
    }
}