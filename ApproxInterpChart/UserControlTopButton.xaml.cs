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
    /// Interaction logic for UserControlTopButton.xaml
    /// </summary>
    public partial class UserControlTopButton : UserControl
    {
        public UserControlTopButton()
        {
            InitializeComponent();
        }

        

        public static readonly DependencyProperty pressedColor =
            DependencyProperty.Register("PressedColor", typeof(Brush), typeof(UserControlTopButton));

        public static readonly DependencyProperty basicColor =
            DependencyProperty.Register("BasicColor", typeof(Brush), typeof(UserControlTopButton));

        public static readonly DependencyProperty displayedText =
            DependencyProperty.Register("DisplayedText", typeof(string), typeof(UserControlTopButton));

        public Brush PressedColor
        {
            get { return (new SolidColorBrush((Color)GetValue(pressedColor))); }
            set { SetValue(pressedColor, value); }
        }

        public Brush BasicColor
        {
            get { return (new SolidColorBrush((Color)GetValue(basicColor))); }
            set { SetValue(basicColor, value); }
        }

        public string DisplayedText
        {
            get { return (string)GetValue(displayedText); }
            set { SetValue(displayedText, value); }
        }
    }
}
