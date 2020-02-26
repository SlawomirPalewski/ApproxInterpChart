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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonNewChart_Click(object sender, RoutedEventArgs e)
        {
            int amount = Convert.ToInt32(TextBoxAmount.Text);
            int step = Convert.ToInt32(TextBoxStep.Text);
            int maxValue = Convert.ToInt32(TextBoxMaximum.Text);
            int minValue = Convert.ToInt32(TextBoxMinimum.Text);
            CanvasData canvasData = new CanvasData(amount, step, maxValue, minValue);

            CanvasChart.CanvasData = canvasData;

            // Sprawdzić czy nie ma tekstu zamiast liczb
            // Liczby mogą być tylko całkowite
            // Liczby muszą być dodatnie
            // Amount i step więsze niż 0
            // MaxValue większe od MinValue
            // Przesyła dane, dorób sprawdzanie czy wszystko się zgadza itp.
        }


        #region Buttons

        private void UserControlTopButton_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }


        #endregion

        private void UserControlTopButton_PreviewMouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            // WindowState = WindowState.Minimized;
        }
    }
}
