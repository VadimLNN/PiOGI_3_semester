using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeomShapes
{
    internal class Rectangle
    {
        Point2D a;
        Point2D b;
        Point2D c;
        Point2D d;

        public Rectangle() { 
            a = new Point2D();
            b = new Point2D();
            c = new Point2D();
            d = new Point2D();
        }

        public Rectangle(Point2D A, Point2D B, Point2D C, Point2D D)
        {
            a = new Point2D(A);
            b = new Point2D(B);
            c = new Point2D(C);
            в = new Point2D(D);
        }

        public Point2D getA() { return a; }
        public Point2D getB() { return b; }
        public Point2D getC() { return c; }
        public Point2D getD() { return d; }

        public void setA(Point2D p)
        {
            a.setX(p.getX());
            a.setY(p.getY());
        }
        public void setB(Point2D p)
        {
            b.setX(p.getX());
            b.setY(p.getY());
        }
        public void setC(Point2D p)
        {
            c.setX(p.getX());
            c.setY(p.getY());
        }
        public void setD(Point2D p)
        {
            d.setX(p.getX());
            d.setY(p.getY());
        }

        public void shiftX(double value)
        {
            a.shiftX(value);
            b.shiftX(value);
            c.shiftX(value);
            d.shiftX(value);
        }
        public void shiftY(double value)
        {
            a.shiftY(value);
            b.shiftY(value);
            c.shiftY(value);
            d.shiftY(value);
        }

        public double perimeter()
        {
            return a.getDistance(b) + b.getDistance(c) + c.getDistance(d) + d.getDistance(a);
        }

        public double square()
        {
            return 1;
        }
    }
}
