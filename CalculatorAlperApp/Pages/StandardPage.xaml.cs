using System;
using Microsoft.Maui.Controls;

namespace CalculatorAlperApp.Pages
{
    public partial class StandardPage : ContentPage
    {
        private string _currentInput = "0";
        private string _operator = "";
        private double _firstNumber = 0;
        private bool _isNewInput = false;

        public StandardPage()
        {
            InitializeComponent();
        }

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
                }

                Display.Text = result.ToString();
                _currentInput = result.ToString();
                _isNewInput = true;
            }
        }

        private void OnClearClicked(object sender, EventArgs e)
        {
            _currentInput = "0";
            _firstNumber = 0;
            _operator = "";
            _isNewInput = false;
            Display.Text = "0";
        }

        private void OnDeleteClicked(object sender, EventArgs e)
        {
            if (_currentInput.Length > 1)
            {
                _currentInput = _currentInput.Substring(0, _currentInput.Length - 1);
                Display.Text = _currentInput;
            }
            else
            {
                _currentInput = "0";
                Display.Text = "0";
            }
        }

        private void OnFunctionClicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                double number = double.Parse(_currentInput);
                double result = 0;

                switch (button.Text)
                {
                    case "1/x":
                        result = 1 / number;
                        break;
                    case "x²":
                        result = Math.Pow(number, 2);
                        break;
                    case "√x":
                        result = Math.Sqrt(number);
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
    }
}
