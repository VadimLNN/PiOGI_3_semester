using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeomShapes
{
    internal class Point2D
    {
        private double x;
        private double y;

        public Point2D(double acquired_x, double acquired_y)
        {
            x = acquired_x;
            y = acquired_y;
        }

        public double getX()
        {
            return x;
        }

        public double getY()
        {
            return y;
        }
    
        public void shiftX(double shift)
        {

        }

        public void shiftY(double shift)
        {

        }

        public double GetDistance()
        {
            double res = 0;

            return res;
        }
    }
}
