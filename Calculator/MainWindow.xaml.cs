using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double value = 0;
        string operation = "";
        bool operationPressed = false;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            
            Button b = (Button)sender;
            string num = (string)b.Content;

            if ((txtAnswer.Text == "0" && num != "." && num != "0") || (operationPressed))
            {
                txtAnswer.Clear();
            }

            operationPressed = false;

            if (num == ".")
            {
                if (!txtAnswer.Text.Contains("."))
                {
                    txtAnswer.Text = txtAnswer.Text + b.Content;
                }
            }
            else if (num == "0")
            {
                if(!txtAnswer.Text.Equals("0"))
                {
                    txtAnswer.Text = txtAnswer.Text + b.Content;
                }
            }
            else
            {
                txtAnswer.Text = txtAnswer.Text + b.Content;
            }
        }

        private void btnCLearEntry_Click(object sender, RoutedEventArgs e)
        {
            txtAnswer.Text = "0";
        }

        private void operator_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            if(value != 0)
            {
                btnEquals_Click(this, null);
                operationPressed = true;
                operation = (string)b.Content;
                lblEquation.Content = value + " " + operation;
            }
            else
            {
                operation = (string)b.Content;
                value = Double.Parse(txtAnswer.Text);
                operationPressed = true;
                lblEquation.Content = value + " " + operation;
            }  
        }

        private void btnEquals_Click(object sender, RoutedEventArgs e)
        {
            lblEquation.Content = "";
            switch (operation)
            {
                case "+":
                    txtAnswer.Text = (value + Double.Parse(txtAnswer.Text)).ToString();
                    break;
                case "-":
                    txtAnswer.Text = (value - Double.Parse(txtAnswer.Text)).ToString();
                    break;
                case "×":
                    txtAnswer.Text = (value * Double.Parse(txtAnswer.Text)).ToString();
                    break;
                case "÷":
                    txtAnswer.Text = (value / Double.Parse(txtAnswer.Text)).ToString();
                    break;
                default:
                    break;
            }
            value = Double.Parse(txtAnswer.Text);
            operation = "";
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtAnswer.Text = "0";

            value = 0;
        }
    }
}
