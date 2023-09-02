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
         вычисление площади и периметра;                                                           (NO)
         сдвиг треугольника по осям X и Y на заданное расстояние;                                  (Y)    
    
    3) Класс «прямоугольник». Класс должен содержать поля для хранения вершин прямоугольника        NO
    и методы, реализующие следующие операции:   
         вычисление площади и периметра;                                                           (NO)    
         сдвиг прямоугольника по осям X и Y на заданное расстояние;                                (NO)
    
    4) Класс для генерации геометрических фигур. Класс должен содержать статические методы          NO
    создания геометрических фигур:
         создание произвольной («рандомной») точки;                                                (NO)
         создание произвольного треугольника;                                                      (NO)
         создание произвольного прямоугольника;                                                    (NO)
         создание прямоугольника заданного размера.                                                (NO)
*/
namespace GeomShapes
{
    public partial class MainWindow : Window
    {
        Point2D p = new Point2D();
        
        Random rng = new Random();
        
        Triangle tr = new Triangle();
        void drawPoint(Point2D point){
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
            p.setX(double.Parse(x_coordinate.Text));
            p.setY(double.Parse(y_coordinate.Text));

            scene.Children.Clear();

            drawPoint(p);
        }

        private void vert_bar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double value = e.NewValue - e.OldValue;
            
            //if(e.NewValue != tr.getA().getY())
                p.shiftY(value);

            scene.Children.Clear();

            drawPoint(p);
        }

        private void hor_bar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double value = e.NewValue - e.OldValue;

            //if (e.NewValue != tr.getA().getX())
                p.shiftX(value);

            scene.Children.Clear();

            drawPoint(p);
        }

        private void DrawTriangle_Click(object sender, RoutedEventArgs e)
        {
            Point2D a = new Point2D(rng.NextDouble() * 560, rng.NextDouble() * 388);
            Point2D b = new Point2D(rng.NextDouble() * 560, rng.NextDouble() * 388);
            Point2D c = new Point2D(rng.NextDouble() * 560, rng.NextDouble() * 388);

            tr = new Triangle(a, b, c);

            scene.Children.Clear();

            drawLine(tr.getA(), tr.getB());
            drawLine(tr.getB(), tr.getC());
            drawLine(tr.getC(), tr.getA());

            pr_res.Content = tr.perimeter();
            sq_res.Content = tr.square();
        }
    }
}
