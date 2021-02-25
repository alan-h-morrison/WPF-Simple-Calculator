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

            if(num != "0")
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
            operation = (string)b.Content;
            value = Double.Parse(txtAnswer.Text);
            operationPressed = true;

            
        }
    }
}
