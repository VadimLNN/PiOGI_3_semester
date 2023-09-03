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
/*
В рамках выполнения лабораторной работы необходимо реализовать приложение WPF, содержащее 
несколько классов геометрических фигур на плоскости:

    1) Класс «двумерная точка». Класс должен содержать поля для хранения координат по осям X и       Y
    Y и методы, реализующие следующие операции:
         сдвиг точки по осям X и Y на заданное расстояние;                                         (Y)
         вычисление расстояния между двумя точками;                                                (Y)
    
    2) Класс «треугольник». Класс должен содержать поля для хранения вершин треугольника и           Y
    методы, реализующие следующие операции:
         вычисление площади и периметра;                                                           (Y)
         сдвиг треугольника по осям X и Y на заданное расстояние;                                  (Y)    
    
    3) Класс «прямоугольник». Класс должен содержать поля для хранения вершин прямоугольника         Y
    и методы, реализующие следующие операции:   
         вычисление площади и периметра;                                                           (Y)    
         сдвиг прямоугольника по осям X и Y на заданное расстояние;                                (Y)
    
    4) Класс для генерации геометрических фигур. Класс должен содержать статические методы           N
    создания геометрических фигур:
         создание произвольной («рандомной») точки;                                                (N)
         создание произвольного треугольника;                                                      (N)
         создание произвольного прямоугольника;                                                    (N)
         создание прямоугольника заданного размера.                                                (N)
*/
namespace GeomShapes
{
    public partial class MainWindow : Window
    {

        Random rng = new Random();
        Point2D p = new Point2D();
        Triangle tr = new Triangle();
        Rectangle rec = new Rectangle();
        
        void drawLine(Point2D start_p, Point2D end_p)  {
            Line line = new Line();
            line.Stroke = Brushes.Black;
            line.StrokeThickness = 2;

            line.X1 = start_p.getX();
            line.Y1 = start_p.getY();

            line.X2 = end_p.getX();
            line.Y2 = end_p.getY();

            scene.Children.Add(line);
        }
        
        public MainWindow()
        {
            InitializeComponent();


        }

        private void DrawPoint_Click(object sender, RoutedEventArgs e)
        {
            if (field_1.Text == "" && field_2.Text == "")
            {
                //ShapeGeneration.genRandPoint2D();
                p.setX(rng.NextDouble() * 560);
                p.setY(rng.NextDouble() * 388);
            }
            else
            { 
                p.setX(double.Parse(field_1.Text));
                p.setY(double.Parse(field_2.Text));
            }
            scene.Children.Clear();

            drawPoint(p);
        }
        void drawPoint(Point2D point)
        {
            Ellipse myEllipse = new Ellipse();
            myEllipse.Stroke = System.Windows.Media.Brushes.Black;
            myEllipse.Fill = System.Windows.Media.Brushes.White;
            myEllipse.HorizontalAlignment = HorizontalAlignment.Left;
            myEllipse.VerticalAlignment = VerticalAlignment.Center;
            
            myEllipse.Width = 7;
            myEllipse.Height = 7;

            myEllipse.RenderTransform = new TranslateTransform(point.getX(), point.getY());

            scene.Children.Add(myEllipse);
        }
        

        private void DrawTriangle_Click(object sender, RoutedEventArgs e)
        {
            Point2D a = new Point2D(rng.NextDouble() * 560, rng.NextDouble() * 388);
            Point2D b = new Point2D(rng.NextDouble() * 560, rng.NextDouble() * 388);
            Point2D c = new Point2D(rng.NextDouble() * 560, rng.NextDouble() * 388);

            tr = new Triangle(a, b, c);

            scene.Children.Clear();

            drawTriangle(tr);

            pr_res.Content = tr.getPerimeter();
            sq_res.Content = tr.getArea();
        }
        void drawTriangle(Triangle tr)
        {
            drawLine(tr.getA(), tr.getB());
            drawLine(tr.getB(), tr.getC());
            drawLine(tr.getC(), tr.getA());
        }
        

        private void DrawRectangle_Click(object sender, RoutedEventArgs e)
        {
            Point2D a = new Point2D(rng.NextDouble() * 560, rng.NextDouble() * 388);
            Point2D b = new Point2D(rng.NextDouble() * 560, rng.NextDouble() * 388);
            Point2D c = new Point2D(rng.NextDouble() * 560, rng.NextDouble() * 388);
            Point2D d = new Point2D(rng.NextDouble() * 560, rng.NextDouble() * 388);

            rec = new Rectangle(a, b, c, d);

            scene.Children.Clear();

            drawRectangle(rec);

            pr_res.Content = rec.getPerimeter();
            sq_res.Content = rec.getArea();
        }
        void drawRectangle(Rectangle rec)
        {
            drawLine(rec.getA(), rec.getB());
            drawLine(rec.getB(), rec.getC());
            drawLine(rec.getC(), rec.getD());
            drawLine(rec.getD(), rec.getA());
        }
    

        private void vert_bar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double value = e.NewValue - e.OldValue;

            if (scene.Children.Capacity == 1)
            {
                scene.Children.Clear();
                p.shiftY(value);
                drawPoint(p);
            }
            else if (scene.Children.Capacity == 3)
            {
                scene.Children.Clear();
                tr.shiftY(value);
                drawTriangle(tr);
            }
            else if (scene.Children.Capacity == 4)
            {
                scene.Children.Clear();
                rec.shiftY(value);
                drawRectangle(rec);
            }
        
            
        }
        private void hor_bar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double value = e.NewValue - e.OldValue;

            if (scene.Children.Capacity == 1)
            {
                scene.Children.Clear();
                p.shiftX(value);
                drawPoint(p);
            }
            else if (scene.Children.Capacity == 3)
            {
                scene.Children.Clear();
                tr.shiftX(value);
                drawTriangle(tr);
            }
            else if (scene.Children.Capacity == 4)
            {
                scene.Children.Clear();
                rec.shiftX(value);
                drawRectangle(rec);
            }
        }

        
            
        
    }
}
