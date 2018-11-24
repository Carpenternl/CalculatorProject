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

namespace BasicCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string valueBuffer = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            Button Target = sender as Button;
           
        }
        // Gets the double value from the buffer and clears the data 
        private double extract(string valueBuffer)
        {
            double result = double.Parse(valueBuffer);
            valueBuffer = new string(' ', 0);
            return result;
        }
        bool isnum = false;
        private void Number_Click(object sender, RoutedEventArgs e)
        {
            Button Target = sender as Button;
            string a = Target.Content.ToString();
            int aInt = int.Parse(a);
            this.CurrentEquation.AddNumber(aInt);
        }

        private void Comma_Click(object sender, RoutedEventArgs e)
        {
            CurrentEquation.ToggleComma();
        }


    }


}
