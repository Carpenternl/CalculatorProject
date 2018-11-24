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
    /// Interaction logic for EquationControl.xaml
    /// </summary>
    public partial class EquationControl : UserControl
    {

        public EquationControl()
        {
            InitializeComponent();
        }
        // Add a number to the buffer
        public void AddNumber(int nr)
        {
            string nrString = nr.ToString();
            string Current = Buffer.Content.ToString();
            string PossibleNewValue = Current + nrString;
            double result;
            if(double.TryParse(PossibleNewValue,out result))
            {
                Buffer.Content = PossibleNewValue;
            }
        }
        public void ToggleComma()
        {
            string Current = Buffer.Content.ToString();
            if (Current.IndexOf(",")>=0)
            {
                Current = Current.Remove(Current.IndexOf(","),1);
            }
            else
            {
                Current += ",";
            }
            Buffer.Content = Current;
        }
         
        internal void AddOperator(operation newOperator)
        {
        }
    }
}
