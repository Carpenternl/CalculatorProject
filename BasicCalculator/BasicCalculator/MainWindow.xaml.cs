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

        private Equation CurrentEquation = new Equation();

        private string valueBuffer = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            Button Target = sender as Button;
            string newOperator = Target.Content.ToString();
            // if there is an available value, add it and the new operator
            if (isnum)
            {
                isnum = false;
                CurrentEquation.Left.Add(new ValueNode(extract(valueBuffer)));
                CurrentEquation.Left.Add(new OperatorNode(newOperator));
            }
            else
            {
                // Add the new operator to the equation if the equation is empty
                if (CurrentEquation.Left.Count < 1)
                {
                    CurrentEquation.Left.Add(new OperatorNode(newOperator));
                }
                else
                {
                    OperatorNode Candidate = new OperatorNode(newOperator);
                    // subtract operators have special cases
                    if (Candidate.Operation == operation.subtract)
                    {
                        //the last node is also an operator
                        if (CurrentEquation.Left[CurrentEquation.Left.Count - 1] is OperatorNode)
                        {
                            OperatorNode LastNode = CurrentEquation.Left[CurrentEquation.Left.Count - 1] as OperatorNode;
                            switch (LastNode.Operation)
                            {
                                case operation.add: // change the last operator from a + to a -;
                                    LastNode.Operation = operation.subtract;
                                    break;
                                case operation.subtract: // change the last operator from a - to a +;
                                    LastNode.Operation = operation.add;
                                    break;
                                case operation.multiply:
                                case operation.divide:
                                case operation.modulo: //otherwise add the '-' operator to the equation
                                    CurrentEquation.Left.Add(Candidate);
                                    break;
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            CurrentEquation.Left.Add(Candidate);
                        }

                    }
                    else
                    {
                        //remove all trailing operatornodes
                        while (CurrentEquation.Left[CurrentEquation.Left.Count - 1] is OperatorNode)
                        {
                            CurrentEquation.Left.RemoveAt(CurrentEquation.Left.Count - 1);
                        }
                        // add the new operatornode
                        CurrentEquation.Left.Add(Candidate);
                    }
                }
            }
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
            isnum = true;
            Button Target = sender as Button;
            string ToAppend = Target.Content.ToString();
            valueBuffer += ToAppend;
            while (valueBuffer.Length > 1 && valueBuffer[0] == '0' && valueBuffer[1] == '0')
            {
                valueBuffer = valueBuffer.Remove(0, 1);
            }
            BufferDisplay.Content = valueBuffer;
        }

        private void Comma_Click(object sender, RoutedEventArgs e)
        {
            isnum = true;
            int index = valueBuffer.IndexOf(',');
            if (index >= 0)
            {
                valueBuffer = valueBuffer.Remove(index, 1);
            }
            else
            {
                valueBuffer += ',';
            }
            BufferDisplay.Content = valueBuffer;
        }


    }


}
