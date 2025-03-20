using System;
using Microsoft.Maui.Controls;

namespace CalculatorAlperApp.Pages
{
    public partial class ScientificPage : ContentPage
    {
        private string _currentInput = "0";
        private string _operator = "";
        private double _firstNumber = 0;
        private bool _isNewInput = false;

        public ScientificPage()
        {
            InitializeComponent();
        }

        // Number button click handler
        private void OnNumberClicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if (_isNewInput)
                {
                    _currentInput = "";
                    _isNewInput = false;
                }

                if (_currentInput == "0") _currentInput = "";

                _currentInput += button.Text;
                Display.Text = _currentInput;
            }
        }

        // Operator button click handler
        private void OnOperatorClicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if (!string.IsNullOrEmpty(_currentInput))
                {
                    _firstNumber = double.Parse(_currentInput);
                    _operator = button.Text;
                    _isNewInput = true;
                }
            }
        }

        // Equals button click handler
        private void OnEqualsClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_currentInput))
            {
                double secondNumber = double.Parse(_currentInput);
                double result = 0;

                switch (_operator)
                {
                    case "+":
                        result = _firstNumber + secondNumber;
                        break;
                    case "−":
                        result = _firstNumber - secondNumber;
                        break;
                    case "×":
                        result = _firstNumber * secondNumber;
                        break;
                    case "÷":
                        if (secondNumber != 0)
                            result = _firstNumber / secondNumber;
                        else
                        {
                            Display.Text = "Error";
                            return;
                        }
                        break;
                    case "mod":
                        result = _firstNumber % secondNumber;
                        break;
                    case "xʸ":
                        result = Math.Pow(_firstNumber, secondNumber);
                        break;
                }

                Display.Text = result.ToString();
                _currentInput = result.ToString();
                _isNewInput = true;
            }
        }

        // Clear button click handler
        private void OnClearClicked(object sender, EventArgs e)
        {
            _currentInput = "0";
            _firstNumber = 0;
            _operator = "";
            _isNewInput = false;
            Display.Text = "0";
        }

        // Function button click handler (e.g., sin, cos, ln)
        private void OnFunctionClicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                double number = double.Parse(_currentInput);
                double result = 0;

                switch (button.Text)
                {
                    case "sin":
                        result = Math.Sin(number * Math.PI / 180);
                        break;
                    case "cos":
                        result = Math.Cos(number * Math.PI / 180);
                        break;
                    case "tan":
                        result = Math.Tan(number * Math.PI / 180);
                        break;
                    case "ln":
                        if (number > 0)
                            result = Math.Log(number);
                        else
                        {
                            Display.Text = "Error";
                            return;
                        }
                        break;
                    case "log":
                        if (number > 0)
                            result = Math.Log10(number);
                        else
                        {
                            Display.Text = "Error";
                            return;
                        }
                        break;
                    case "π":
                        result = Math.PI;
                        break;
                    case "e":
                        result = Math.E;
                        break;
                    case "√x":
                        if (number >= 0)
                            result = Math.Sqrt(number);
                        else
                        {
                            Display.Text = "Error";
                            return;
                        }
                        break;
                    case "x!":
                        result = Factorial((int)number);
                        break;
                    case "+/-":
                        result = -number;
                        break;
                }

                Display.Text = result.ToString();
                _currentInput = result.ToString();
                _isNewInput = true;
            }
        }

        // Parenthesis button click handler
        private void OnParenthesisClicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                _currentInput += button.Text;
                Display.Text = _currentInput;
            }
        }

        // Factorial calculation
        private double Factorial(int n)
        {
            if (n < 0) return double.NaN;
            if (n == 0 || n == 1) return 1;
            double fact = 1;
            for (int i = 2; i <= n; i++)
                fact *= i;
            return fact;
        }
    }
}
