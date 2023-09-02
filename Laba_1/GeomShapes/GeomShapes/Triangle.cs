using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeomShapes
{
    internal class Triangle
    {
        Point2D a;
        Point2D b;
        Point2D c;

        public Triangle()
        {
            a = new Point2D();
            b = new Point2D();
            c = new Point2D();
        }

        public Triangle(Point2D A, Point2D B, Point2D C)
        {
            a = new Point2D(A);
            b = new Point2D(B);
            c = new Point2D(C);
        }
    
        public Point2D getA() { return a; }
        public Point2D getB() { return b; }
        public Point2D getC() { return c; }

        public void setA(Point2D p) { 
            a.setX(p.getX());
            a.setY(p.getY());
        }
        public void setB(Point2D p) { 
            b.setX(p.getX());
            b.setY(p.getY());
        }
        public void setC(Point2D p) { 
            c.setX(p.getX());
            c.setY(p.getY());
        }

        public void shiftX(double value) {
            a.shiftX(value);
            b.shiftX(value); 

            c.shiftX(value);
        }

        public void shiftY(double value)
        {
            a.shiftY(value);
            b.shiftY(value);
            c.shiftY(value);
        }

        public double perimeter () 
        {
            return a.getDistance(b) + b.getDistance(c) + c.getDistance(a);
        }

        public double square()
        {
            // полупериметр 
            double pp = (a.getDistance(b) + b.getDistance(c) + c.getDistance(a)) / 2;
            return Math.Sqrt(pp * (pp - a.getDistance(b)) * (pp - b.getDistance(c)) * (pp - c.getDistance(a)));
        }
    }
}
