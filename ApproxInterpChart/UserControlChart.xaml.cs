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


// Przy załadowaniu apki ma nic nie robić (dać if null)
// Po kliknięciu buttona będzie wywoływać funkcję:
// Clear() - czyści mapę
// Draw() - rysuje punkty, potem aproksymację z interpolacją
// 
// Zaimplementować też trzeba rozrysowanie skali - czyli liczb na osiach X/Y
// Na pewno jest minimalny X i Y -> Z tego będzie skala osi Y (wykościowej)
// Oś X jest uzależniona od skoku. Zaczynać się będzie od zera, a kończyć na ilości razy skok.
//
// Kolejną rzeczą jest skalowanie programu.
// Wraz z rozszerzeniem i zmniejszeniem aplikacji data musi być przeskalowana o aktualną wielkość.
// Draw() powinien umieszczać punkt w oparciu o procent, wtedy za każdym razem jak walnie się resize, to umieści się Draw w evencie resize().

namespace ApproxInterpChart
{
    /// <summary>
    /// Interaction logic for UserControlChart.xaml
    /// </summary>
    public partial class UserControlChart : UserControl
    {
        private CanvasData _canvasData;

        public CanvasData CanvasData
        {
            get { return _canvasData; }
            set {
                _canvasData = value;
                LoadCanvasData();
            }
        }

        private double CanvasOffsetX
        {
            get { return grid.ColumnDefinitions[0].ActualWidth + grid.ColumnDefinitions[1].ActualWidth + grid.ColumnDefinitions[2].ActualWidth; }
        }

        private double CanvasOffsetY
        {
            get { return grid.RowDefinitions[0].ActualHeight; }
        }

        private double AxisHeight
        {
            get { return grid.RowDefinitions[1].ActualHeight; }
        }
        
        private double AxisWidth
        {
            get { return grid.ColumnDefinitions[3].ActualWidth; }
        }

        public UserControlChart()
        {
            InitializeComponent();            
        }

        private void Canvas_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void LoadCanvasData()
        {
            ClearCanvas();

            Random rand = new Random();

            foreach (Point point in _canvasData.RectanglePoints)
            {
                Rectangle rect = new Rectangle()
                {
                    Fill = new SolidColorBrush(Colors.Green),
                    Width = 5,
                    Height = 5,
                    Tag = "Point"
                };

                canvas.Children.Add(rect);

                Canvas.SetLeft(rect, CanvasOffsetX + point.X);
                Canvas.SetTop(rect, CanvasOffsetY + point.Y);
            }

            foreach(Points points in _canvasData.InterpolationPoints)
            {
                Line line = new Line()
                {
                    X1 =  points.X,
                    X2 =  points.X2,
                    Y1 =  points.Y,
                    Y2 =  points.Y2,
                    Stroke = new SolidColorBrush(Colors.Orange),
                    StrokeThickness = 2,
                    Tag = "Line"
                    
            };

                canvas.Children.Add(line);
                Canvas.SetLeft(line, CanvasOffsetX);
                Canvas.SetTop(line, CanvasOffsetY);
            }
        }

        private void ClearCanvas()
        {
            List<Rectangle> selectedRectangles = new List<Rectangle>();
            List<Line> selectedIntepolations = new List<Line>();
            Line selectedApproximation;

            foreach(UIElement ui in canvas.Children)
            {
                if (ui.GetType().Equals(typeof(Rectangle)))
                {
                    Rectangle rect = (Rectangle) ui;
                    if (rect.Tag.Equals("Point"))
                        selectedRectangles.Add(rect);
                }
                else if (ui.GetType().Equals(typeof(Line)))
                {
                    Line line = (Line)ui;
                    if (line.Tag.Equals("Line"))
                        selectedIntepolations.Add(line);
                }
            }

            foreach(Rectangle rect in selectedRectangles)
            {
                canvas.Children.Remove(rect);
            }
            foreach (Line line in selectedIntepolations)
            {
                canvas.Children.Remove(line);
            }
        }
    }
}
