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
    1. Реализовать отображение пользовательских объектов в виде маркеров на карте: местоположение,              Y
    область, маршрут, человек, автомобиль. Для каждого вида объектов необходимо создать 
    отдельный класс, реализующий создание маркера и его отображение. Иерархия и структура 
    классов представлена на UML-диаграмме
    Все экземпляры данных классов должны храниться в одной коллекции (в списке или словаре) и                   Y
    использовать общие методы, определенные в базовом классе MapObject.

    2. Реализовать 2 режима работы курсора:                                                                     Y
        - режим создания объектов (позволяет сохранять координаты точек при нажатии на карту, см. пункт 3);
        - режим поиска ближайших объектов (при нажатии на карту выводит список объектов, 
        отсортированных по расстоянию, см. пункт 5).

    3. Реализовать возможность добавления объектов на карту по точкам, заданным пользователем на                Y
    карте (для местоположения, автомобиля и человека достаточно одной точки, для маршрута –
    минимум две точки, для области – минимум три).

    4. Реализовать возможность поиска объектов по названию (если подходит несколько объектов,                   Y
    выводить их списком, а при выделении – показывать в фокусе).

    5. Для каждого из объектов реализовать метод для определения расстояния до произвольной точки.              Y
    С помощью этого метода реализовать поиск ближайших объектов.
*/
/*
    Доработать приложение из лабораторной работы №2.1 и внести следующий функционал:
    1. Симулировать процесс заказа такси, описанный диаграммой деятельности:
        1.1. Реализовать методы перемещения для классов Car и Human.                                    N

        1.2. Выбор пункта отправления и пункта назначения реализовать двойным нажатием курсора на       N
        карту.

        1.3. Реализовать взаимодействие объектов «Пассажир» и «Такси» с помощью событий. В данном       N
        случае, события соответствуют переходам от одного потока к другому в диаграмме
        деятельности (событие вызова такси, событие прибытия такси, событие посадки).

        1.4. Перемещение пассажира после посадки реализовать с помощью агрегации (при изменении         N
        местоположения такси меняется и местоположение пассажира).

        1.5. Реализовать отрисовку маршрута и индикатора прогресса.                                     N

        1.6. Во время поездки карта должна фокусироваться на автомобиле, при этом маркер автомобиля     N
        должен поворачиваться согласно своему направлению движения.
*/
namespace GeoInformApp
{
    public partial class MainWindow : Window
    {
        List<PointLatLng> points = new List<PointLatLng>();
        List<MapObject> objects = new List<MapObject>();
        GMapMarker lastPath = null;
        GMapMarker lastArea = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MapLoaded(object sender, RoutedEventArgs e)
        {
            GMaps.Instance.Mode = AccessMode.ServerAndCache; // настройка доступа к данным
            // ключ проверки подлинности карт
            BingMapProvider.Instance.ClientKey = "9c20Y4eqPpx1xMu0lmor~sNbgMB8wEWudshcBad5TYA~AnMs7-dXI4O8C3a0ZXj-cUsXEUSmprSh6JNBTVgVN9WleaiP8XWYXUTA8XLh0e5W";

            // установка провайдера карт
            Map.MapProvider = BingMapProvider.Instance;
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
            switch (typeMarker.SelectedIndex)
            {
                case 0:
                    objects.Add(new Human(nameMark.Text, Map.FromLocalToLatLng((int)e.GetPosition(Map).X, (int)e.GetPosition(Map).Y), "human.png"));
                    Map.Markers.Add(objects[objects.Count-1].getMarker());
                    nameList.Items.Add(nameMark.Text + " " + (objects.Count - 1).ToString());
                    break;

                case 1:
                    objects.Add(new Car(nameMark.Text, Map.FromLocalToLatLng((int)e.GetPosition(Map).X, (int)e.GetPosition(Map).Y), "car.png"));
                    Map.Markers.Add(objects[objects.Count - 1].getMarker());
                    nameList.Items.Add(nameMark.Text + " " + (objects.Count - 1).ToString());
                    break;

                case 2:
                    objects.Add(new Location(nameMark.Text, Map.FromLocalToLatLng((int)e.GetPosition(Map).X, (int)e.GetPosition(Map).Y), "mark.png"));
                    Map.Markers.Add(objects[objects.Count - 1].getMarker());
                    nameList.Items.Add(nameMark.Text + " " + (objects.Count - 1).ToString());
                    break;

                case 3:
                    points.Add(Map.FromLocalToLatLng((int)e.GetPosition(Map).X, (int)e.GetPosition(Map).Y));
                    addPath();
                    break;

                case 4:
                    points.Add(Map.FromLocalToLatLng((int)e.GetPosition(Map).X, (int)e.GetPosition(Map).Y));
                    addArea();
                    break;

                default: MessageBox.Show("Unknown marker type");
                        break;

            }
        }

        private void Add_Path(object sender, RoutedEventArgs e)
        {
            objects.Add(new Route(nameMark.Text, points));

            if (lastPath != null)
                Map.Markers.Remove(lastPath);

            Map.Markers.Add(objects[objects.Count - 1].getMarker());
            nameList.Items.Add(nameMark.Text + " " + (objects.Count - 1).ToString());
        }
        private void Add_Area(object sender, RoutedEventArgs e)
        {
            objects.Add(new Area(nameMark.Text, points));

            if (lastArea != null)
                Map.Markers.Remove(lastArea);

            Map.Markers.Add(objects[objects.Count - 1].getMarker());
            nameList.Items.Add(nameMark.Text + " " + (objects.Count - 1).ToString());
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
            objects.Clear(); 
            nameList.Items.Clear();
        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            if (objects.Count == 0) return;

            nameList.Items.Clear();

            for (int i = 0; i < objects.Count; i++)
            {
                if (objects[i].getTitle() == findName.Text)
                {
                    Map.Position = objects[i].getFocus();
                    nameList.Items.Add(objects[i].getTitle() + " " + i.ToString());
                }
            }

            if (nameList.Items.Count == 0)
                nameList.Items.Add("unknown name");
        }

        private void nameList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (nameList.SelectedItem == null) return;

            var nameMark = nameList.SelectedItem.ToString();

            for (int i = 0; i < objects.Count; i++)
                if (nameMark.Contains(objects[i].getTitle()) && nameMark.Substring(nameMark.LastIndexOf(" ") + 1) == i.ToString())
                    Map.Position = objects[i].getFocus();

        }

        private void Map_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            PointLatLng point = Map.FromLocalToLatLng((int)e.GetPosition(Map).X, (int)e.GetPosition(Map).Y);
            double min = 100000;
            PointLatLng locMin = Map.FromLocalToLatLng(0, 0);

            Dictionary<int, double> distances = new Dictionary<int, double>();

            for (int i = 0; i < objects.Count; i++)
            {
                double temp = objects[i].getDistance(point);
                distances.Add(i, temp);
                if (temp < min)
                {
                    min = temp;
                    locMin = objects[i].getFocus();
                }
            }

            Map.Position = locMin;

            var sortedDict = distances.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            nameList.Items.Clear();

            foreach (var temp in sortedDict)
                nameList.Items.Add(objects[temp.Key].getTitle() + " " + temp.Key.ToString());
        }

        //#################################### Lab 2 #############################################

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            ((Car)objects[1]).moveTo(objects[0].getFocus());
        }

    }
}
