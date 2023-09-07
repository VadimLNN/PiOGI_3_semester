using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    4) Класс для генерации геометрических фигур. Класс должен содержать статические методы           N
    создания геометрических фигур:
         создание произвольной («рандомной») точки;                                                (Y)
         создание произвольного треугольника;                                                      (Y)
         создание произвольного прямоугольника;                                                    (N)
         создание прямоугольника заданного размера.                                                (N) 
*/
namespace GeomShapes
{
    internal class ShapeGeneration
    {
        public static Point2D genRandPoint2D()
        {
            Random rng = new Random();
            return new Point2D(rng.NextDouble() * 568, rng.NextDouble() * 343);
        }
        
        public static Triangle genRandTriangle()
        {
            Random rng = new Random();

            Point2D a = new Point2D(rng.NextDouble() * 568, rng.NextDouble() * 343);
            Point2D b = new Point2D(rng.NextDouble() * 568, rng.NextDouble() * 343);
            Point2D c = new Point2D(rng.NextDouble() * 568, rng.NextDouble() * 343);

            return new Triangle(a, b, c);
        }
        

        public static Rectangle genRandRectangle()
        {
            Random rng = new Random();

            Point2D a = new Point2D(rng.NextDouble() * 100, rng.NextDouble() * 100);
            Point2D b = new Point2D(rng.NextDouble() * (568 - a.getX()), a.getY());
            Point2D c = new Point2D(b.getX(), rng.NextDouble() * (343 - a.getY()));
            Point2D d = new Point2D(a.getX() ,c.getY());

            return new Rectangle(a, b, c, d);
        }
        public static Rectangle genRectangle(double width, double height)
        {
            Random rng = new Random();

            Point2D a = new Point2D( rng.NextDouble() * 100, rng.NextDouble() * 100 );
            Point2D b = new Point2D( a.getX() + width, a.getY()) ;
            Point2D c = new Point2D( b.getX(), a.getY() + height );
            Point2D d = new Point2D( a.getX(), c.getY());

            return new Rectangle(a, b, c, d);
        }
    }
}
