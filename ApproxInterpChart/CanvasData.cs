using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApproxInterpChart
{
    public class CanvasData
    {
        private int _amount, _step, _maxValue, _minValue;
        private List<Point> _rectanglePoints = new List<Point>();
        private List<Point> _interpolationPoints = new List<Point>();

        public List<Point> RectanglePoints
        {
            get { return _rectanglePoints; }
            set { _rectanglePoints = value; }
        }

        public List<Point> InterpolationPoints
        {
            get { return _interpolationPoints; }
            set { _interpolationPoints = value; }
        }

        public int Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        public int Step
        {
            get { return _step; }
            set { _step = value; }
        }

        public int MaxValue
        {
            get { return _maxValue; }
            set { _maxValue = value; }
        }

        public int MinValue
        {
            get { return _minValue; }
            set { _minValue = value; }
        }

        public CanvasData()
        {
            CreateRectanglePointsFromData();
            CreateInterpolationPointsFromData();

        }

        public CanvasData(int amount, int step, int maxValue, int minValue)
        {
            Amount = amount;
            Step = step;
            MaxValue = maxValue;
            MinValue = minValue;
            CreateRectanglePointsFromData();
            CreateInterpolationPointsFromData();

        }

        private void CreateRectanglePointsFromData()
        {
            Random rand = new Random();
            for(int i = 0; i < Amount; i++)
            {
                double x = Step * i;
                double y = rand.NextDouble() * (MaxValue - MinValue) + MinValue;
                _rectanglePoints.Add(new Point(x, y));
            }
            
        }

        private void CreateInterpolationPointsFromData()
        {
            for (int i = 0; i < Amount - 1; i++)
            {
                _interpolationPoints.Add(new Points(_rectanglePoints[i].X, _rectanglePoints[i].Y, _rectanglePoints[i + 1].X, _rectanglePoints[i + 1].Y));
            }
        }

    }
    
    public class Point
    {
        private double _x, _y;

        public double X
        {
            get { return _x; }
            set { _x = value; }
        }

        public double Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public Point(double x, double y)
        {
        X = x;
        Y = y;
        }
    }

    public class Points : Point
    {
        private double _x2, _y2;

        public double X2
        {
            get { return _x2; }
            set { _x2 = value; }
        }

        public double Y2
        {
            get { return _y2; }
            set { _y2 = value; }
        }

        public Points(double x, double y, double x2, double y2) : base(x, y)
        {
            X2 = x2;
            Y2 = y2;
        }
    }
}
