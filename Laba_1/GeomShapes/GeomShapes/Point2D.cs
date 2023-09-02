using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeomShapes
{
    public class Point2D
    {
        private double x;
        private double y;

        public Point2D()
        {
            x = 0;
            y = 0;
        }
        public Point2D(double X, double Y)
        {
            x = X;
            y = Y;
        }

        public double getX()
        {
            return x;
        }

        public double getY()
        {
            return y;
        }

        public void setX(double X)
        {
            x = X;
        }

        public void setY(double Y)
        {
            y = Y;
        }

        public void shiftX(double shift)
        {
            x += shift;
        }

        public void shiftY(double shift)
        {
            y += shift;
        }

        public double GetDistance()
        {
            double res = 0;

            return res;
        }
    }
}
