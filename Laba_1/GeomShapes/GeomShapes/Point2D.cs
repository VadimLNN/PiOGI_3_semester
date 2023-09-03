using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    1) Класс «двумерная точка». Класс должен содержать поля для хранения координат по осям X и       Y
    Y и методы, реализующие следующие операции:
         сдвиг точки по осям X и Y на заданное расстояние;                                         (Y)
         вычисление расстояния между двумя точками;                                                (Y)
*/

namespace GeomShapes
{
    public class Point2D
    {
        private double x;
        private double y;

        public Point2D() { x = 0; y = 0; }
        public Point2D(double X, double Y) { x = X; y = Y; }

        public Point2D(Point2D point)
        {
            x = point.x;
            y = point.y;
        }

        public double getX() { return x; }
        public double getY() { return y; }

        public void setX(double X) { x = X; }
        public void setY(double Y) { y = Y; }

        public void shiftX(double shift) { x += shift; }
        public void shiftY(double shift) { y += shift; }

        public double getDistance(Point2D next)
        {
             return Math.Sqrt(Math.Pow(next.x - x, 2) + Math.Pow(next.y - y, 2));
        }
    }
}
