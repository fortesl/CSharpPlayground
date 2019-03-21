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
using System.Windows.Shapes;

namespace WpfApp1.DataBinding
{
    /// <summary>
    /// Interaction logic for Bindings.xaml
    /// </summary>
    public partial class Bindings : Window
    {
        public Bindings()
        {
            InitializeComponent();

            SetBindings();
        }

        private void SetBindings()
        {
            var b = new Binding();

            b.Source = mySB;
            b.Path = new PropertyPath("Value");
            b.Converter = new DoubleToIntConverter();

            labelSBThumb.SetBinding(Label.ContentProperty, b);
        }
    }
}
