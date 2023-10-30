using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml.Linq;

namespace GeoInformApp
{
    public class Car : MapObject
    {
        PointLatLng location;
        GMapMarker marker;

        public Car(string title, PointLatLng locftion, string img, GMapControl gMap) : base(title)
        {
            this.location = locftion;
            this.gMap = gMap;

            marker = new GMapMarker(location)
            {
                Shape = new Image
                {
                    Width = 32, // ширина маркера
                    Height = 32, // высота маркера
                    ToolTip = title, // всплывающая подсказка
                    Source = new BitmapImage(new Uri("pack://application:,,,/imgs/" + img)) // картинка
                }
            };
        }
        public override double getDistance(PointLatLng point)
        {
            // точки в формате System.Device.Location
            GeoCoordinate c1 = new GeoCoordinate(location.Lat, location.Lng);
            GeoCoordinate c2 = new GeoCoordinate(point.Lat, point.Lng);
            
            // вычисление расстояния между точками в метрах
            return c1.GetDistanceTo(c2);

        }
        public override PointLatLng getFocus() { return location; }
        public override GMapMarker getMarker() { return marker; }

        //#################################### Lab 2 #############################################

        Route route;
        Human person;
        GMapControl gMap;

        public int DEFAULT_ZOOM { get; private set; }

        // событие прибытия
        public event EventHandler Arrived;

        public void setPerson(Human human)
        {
            person = human;
        }

        public void passengerSeated(object sender, EventArgs e)
        {
            person = (Human)sender;

            Application.Current.Dispatcher.Invoke(delegate {
                gMap.Markers.Add(moveTo(person.getDestanation()));
            });
        }

        public void moveByRoute()
        {
            // последовательный перебор точек маршрута
            foreach (var point in route.getLocations())
            {
                this.location = point;
                // делегат, возвращающий управление в главный поток
                Application.Current.Dispatcher.Invoke(delegate {
                    // изменение позиции маркера
                    marker.Position = point;
                    gMap.Position = point;
                    if (person != null)
                    {
                        person.setLocation(point);
                        person.getMarker().Position = point;
                    }
                });
                // задержка 500 мс
                Thread.Sleep(500);
            }
            if (person == null)
                Arrived?.Invoke(this, null);
            else
            {
                person.endOfRoad();
                person = null;
            }
        }

        public GMapMarker moveTo(PointLatLng endLocation) 
        {
            // определение маршрута
            MapRoute route = BingMapProvider.Instance.GetRoute(
                 location, // начальная точка маршрута
                 endLocation, // конечная точка маршрута
                 false, // поиск по шоссе (false - включен)
                 false, // режим пешехода (false - выключен)
                 (int)15);

            // получение точек маршрута
            List<PointLatLng> routePoints = route.Points;
            this.route = new Route("r", routePoints);

            Thread newThread = new Thread(new ThreadStart(moveByRoute));
            newThread.Start();

            return this.route.getMarker();
        }
    }
}
