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
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using System.Device.Location;
using System.Windows.Media.Media3D;
using System.Security.Cryptography;
using System.Reflection;
using System.IO;
/*
Разработать геоинформационное приложение на базе библиотеки GMap.NET, а также:
1. Реализовать отображение пользовательских объектов в виде маркеров на карте: местоположение, 
область, маршрут, человек, автомобиль. Для каждого вида объектов необходимо создать 
отдельный класс, реализующий создание маркера и его отображение. Иерархия и структура 
классов представлена на UML-диаграмме
Все экземпляры данных классов должны храниться в одной коллекции (в списке или словаре) и 
использовать общие методы, определенные в базовом классе MapObject.

2. Реализовать 2 режима работы курсора:
- режим создания объектов (позволяет сохранять координаты точек при нажатии на карту, см. пункт 3);
- режим поиска ближайших объектов (при нажатии на карту выводит список объектов, 
отсортированных по расстоянию, см. пункт 5).

3. Реализовать возможность добавления объектов на карту по точкам, заданным пользователем на 
карте (для местоположения, автомобиля и человека достаточно одной точки, для маршрута –
минимум две точки, для области – минимум три).

4. Реализовать возможность поиска объектов по названию (если подходит несколько объектов, 
выводить их списком, а при выделении – показывать в фокусе).

5. Для каждого из объектов реализовать метод для определения расстояния до произвольной точки. 
С помощью этого метода реализовать поиск ближайших объектов.
*/
namespace GeoInformApp
{
    public partial class MainWindow : Window
    {
        List<PointLatLng> points = new List<PointLatLng>();
        GMapMarker lastPath = null;
        GMapMarker lastArea = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MapLoaded(object sender, RoutedEventArgs e)
        {
            // настройка доступа к данным
            GMaps.Instance.Mode = AccessMode.ServerAndCache;

            // установка провайдера карт
            Map.MapProvider = GoogleMapProvider.Instance;
            // GoogleMapProvider     +
            // OpenCycleMapProvider  +

            // установка зума карты
            Map.MinZoom = 2;
            Map.MaxZoom = 17;
            Map.Zoom = 15;
            // установка фокуса карты
            Map.Position = new PointLatLng(55.012823, 82.950359);

            // настройка взаимодействия с картой
            Map.MouseWheelZoomType = MouseWheelZoomType.MousePositionAndCenter;
            Map.CanDragMap = true;
            Map.DragButton = MouseButton.Left;
        }

        void addMarker(string toolTip, string img)
        {
            GMapMarker marker = new GMapMarker(points[0])
            {
                Shape = new Image
                {
                    Width = 32, // ширина маркера
                    Height = 32, // высота маркера
                    ToolTip = toolTip, // всплывающая подсказка
                    Source = new BitmapImage(new Uri("pack://application:,,,/imgs/" + img)) // картинка
                }
            };

            Map.Markers.Add(marker);

            points.Clear();
        }

        void addPath()
        {
            if (points.Count < 2)
                return;

            GMapMarker path = new GMapRoute(points)
            {
                Shape = new System.Windows.Shapes.Path()
                {
                    Stroke = Brushes.DarkBlue, // цвет обводки
                    Fill = Brushes.DarkBlue, // цвет заливки
                    StrokeThickness = 4 // толщина обводки
                }
            };

            if (lastPath != null)
                Map.Markers.Remove(lastPath);

            lastPath = path;
            Map.Markers.Add(path);
        }
        
        void addArea()
        {
            if (points.Count < 3)
                return;

            GMapMarker area = new GMapPolygon(points)
            {
                Shape = new System.Windows.Shapes.Path
                {
                    Stroke = Brushes.Black, // стиль обводки
                    Fill = Brushes.LightGoldenrodYellow, // стиль заливки
                    Opacity = 0.5 // прозрачность
                }
            };

            if (lastArea != null)
                Map.Markers.Remove(lastArea);

            lastArea = area;
            Map.Markers.Add(area); 

        }
        private void Map_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            points.Add(Map.FromLocalToLatLng((int)e.GetPosition(Map).X, (int)e.GetPosition(Map).Y));

            switch (typeMarker.SelectedIndex)
            {
                case 0:
                    addMarker("Person", "human.png");
                    break;
                case 1:
                    addMarker("Car", "car.png");
                    break;
                case 2:
                    addMarker("Place", "mark.png");
                    break;
                case 3:
                    addPath();
                    break;
                case 4:
                    addArea();
                    break;
                default: MessageBox.Show("Unknown marker type");
                        break;

            }
        }
        
        private void typeMarker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lastPath = null;
            lastArea = null;
            points.Clear();
        }

        private void Clear_Map(object sender, RoutedEventArgs e)
        {
            lastPath = null;
            lastArea = null;
            points.Clear();
            Map.Markers.Clear();
        }
    }
}
