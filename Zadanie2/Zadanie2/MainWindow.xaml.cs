using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System;


namespace Zadanie2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double _currentValue;
        private double _previousValue;
        private string _currentOperation;
        private bool _isOperationPending;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (_isOperationPending)
            {
                ResultLabel.Text = string.Empty;
                _isOperationPending = false;
            }
            ResultLabel.Text += button.Content.ToString();
        }
        private void OperationButton_Click(Object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (double.TryParse(ResultLabel.Text, out _currentValue))
            {
                _previousValue = _currentValue;
                _currentOperation = button.Content.ToString();
                PreviousOperationLabel.Text = $"{_previousValue} {_currentOperation}";
                _isOperationPending = true;
            }
        }
        private void unaryOperationButton_Click(object sender, RoutedEventArgs eventArgs) { 
            var button = sender as Button;
            if (double.TryParse(ResultLabel.Text, out _currentValue))
            {
                string operation = button.Content.ToString();
                _currentValue = operation switch
                {
                    "√" => Math.Sqrt(_currentValue),
                    "1/x" => 1 / _currentValue,
                    "n!" => Factorial(_currentValue),
                    "log" => Math.Log(_currentValue),
                    "ln" => Math.Log(_currentValue),
                    "log2" => Math.Log2(_currentValue),
                    "⌊x⌋" => Math.Floor(_currentValue),
                    "⌈x⌉" => Math.Ceiling(_currentValue),
                    _ => _currentValue
                };
                ResultLabel.Text = _currentValue.ToString();
                PreviousOperationLabel.Text = $"{operation}({_previousValue})";
            }
        }
        private void EqualsButton_Click(object sender, RoutedEventArgs e) { 
            if(double.TryParse(ResultLabel.Text, out _currentValue) && !string.IsNullOrEmpty(_currentOperation))
            {
                _previousValue = PerformOperation(_previousValue, _currentValue, _currentOperation);
                ResultLabel.Text = _previousValue.ToString();
                PreviousOperationLabel.Text = string.Empty;
                _currentOperation = string.Empty;
            }
        }
        private double PerformOperation(double value1, double value2, string operation)
        {
            return operation switch
            {
                "+" => value1 + value2,
                "-" => value1 - value2,
                "*" => value1 * value2,
                "/" => value1 / value2,
                "^" => Math.Pow(value1, value2),
                "%" => value1 % value2,
                _ => value1
            };
        }
        private double Factorial(double number)
        {
            if (number < 0) return double.NaN;
            if (number == 0) return 1;
            double result = 1;
            for (int i = 1; i <= Math.Floor(number); i++)
            {
                result *= i;
            }
            return result;
        }
    }

}