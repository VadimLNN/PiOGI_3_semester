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

    1) Класс «двумерная точка». Класс должен содержать поля для хранения координат по осям X и      NO
    Y и методы, реализующие следующие операции:
         сдвиг точки по осям X и Y на заданное расстояние;                                         (NO)
         вычисление расстояния между двумя точками;                                                (NO)
    
    2) Класс «треугольник». Класс должен содержать поля для хранения вершин треугольника и          NO
    методы, реализующие следующие операции:
         вычисление площади и периметра;                                                           (NO)
         сдвиг треугольника по осям X и Y на заданное расстояние;                                  (NO)    
    
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
        public MainWindow()
        {
            InitializeComponent();


        }


    }
}
