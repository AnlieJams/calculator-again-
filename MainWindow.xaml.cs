using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfApp10
{
    public partial class MainWindow : Window
    {
        private string _displayText = "";

        public string DisplayText
        {
            get { return _displayText; }
            set
            {
                _displayText = value;
                UpdateDisplay();
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            AppendToInput(button.Content.ToString());
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            AppendToInput(" " + button.Content + " ");
        }

        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {
            PerformCalculation();
        }

        private void AppendToInput(string input)
        {
            DisplayText += input;
        }

        private void PerformCalculation()
        {
            try
            {
                var result = new System.Data.DataTable().Compute(DisplayText, "");
                DisplayText = result.ToString();
            }
            catch
            {
                DisplayText = "Error";
            }
        }

        private void UpdateDisplay()
        {
            display.Text = DisplayText;
        }
    }
}
