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
    /// Interaction logic for ValueNodeControl.xaml
    /// </summary>
    public partial class ValueNodeControl : UserControl
    {


        public bool isValuta
        {
            get { return (bool)GetValue(isValutaProperty); }
            set { SetValue(isValutaProperty, value); }
        }

        // Using a DependencyProperty as the backing store for isValuta.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty isValutaProperty =
            DependencyProperty.Register("isValuta", typeof(bool), typeof(ValueNodeControl), new PropertyMetadata(false,valuetachanged));

        private static void valuetachanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ValueNodeControl Target = d as ValueNodeControl;
            bool NewVal = (bool)e.NewValue;
            if (NewVal)
            {
                Target.Valut.Visibility = Visibility.Visible;
            }
            else
            {
                Target.Valut.Visibility = Visibility.Collapsed;
            }
        }

        public double internalval
        {
            get { return (double)GetValue(internalvalProperty); }
            set { SetValue(internalvalProperty, value); }
        }

        // Using a DependencyProperty as the backing store for internalval.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty internalvalProperty =
            DependencyProperty.Register("internalval", typeof(double), typeof(ValueNodeControl), new PropertyMetadata(0.0,internalvalChanged));

        private static void internalvalChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //the internal value has changed, we need to update our control
            ValueNodeControl Target = d as ValueNodeControl;
            double Nieuw = (double)e.NewValue;
            //a minus must become before a symbol
            if (Nieuw<0)
            {
                Target.digits.Content = Math.Abs(Nieuw);
                Target.Negative.Visibility = Visibility.Visible;
            }
            else
            {
                Target.digits.Content = Nieuw;
                Target.Negative.Visibility = Visibility.Collapsed;
            }
        }

        public ValueNodeControl()
        {
            InitializeComponent();
        }
    }
}
