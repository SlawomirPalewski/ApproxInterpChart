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

namespace ApproxInterpChart
{
    /// <summary>
    /// Interaction logic for UserControlValueInput.xaml
    /// </summary>
    public partial class UserControlValueInput : UserControl
    {
        public UserControlValueInput()
        {
            InitializeComponent();
        }
        

        public static readonly DependencyProperty textValue = DependencyProperty.Register("TextValue", typeof(string), typeof(UserControlValueInput));

        public static readonly DependencyProperty basicColor = DependencyProperty.Register("BasicColor", typeof(Brush), typeof(UserControlValueInput));

        public static readonly DependencyProperty displayedText = DependencyProperty.Register("DisplayedText", typeof(string), typeof(UserControlValueInput));

        public string TextValue
        {
            get { return (string)GetValue(textValue); }
            set { SetValue(textValue, value); }
        }

        public string DisplayedText
        {
            get { return (string)GetValue(displayedText); }
            set { SetValue(displayedText, value); }
        }

        public Brush BasicColor
        {
            get { return (new SolidColorBrush((Color)GetValue(basicColor))); }
            set { SetValue(basicColor, value); }
        }

    }


}
