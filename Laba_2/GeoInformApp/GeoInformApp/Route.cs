using GMap.NET.WindowsPresentation;
using GMap.NET;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.IO;
using System.Windows.Media;

namespace GeoInformApp
{
    internal class Route : MapObject
    {
        List <PointLatLng> locations;
        GMapMarker path;
        public Route(string title, List<PointLatLng> Locations) : base(title)
        {
            if (Locations.Count < 2)
                return;

            this.locations = new List<PointLatLng>(Locations);

            path = new GMapRoute(locations)
            {
                Shape = new System.Windows.Shapes.Path()
                {
                    Stroke = Brushes.DarkBlue, // цвет обводки
                    Fill = Brushes.DarkBlue, // цвет заливки
                    StrokeThickness = 4 // толщина обводки
                }
            };

        }
        public override double getDistance(PointLatLng point)
        {
            double min = 0;
            GeoCoordinate c2 = new GeoCoordinate(point.Lat, point.Lng);

            for (int i = 0; i < locations.Count; i++)
            {
                GeoCoordinate c1 = new GeoCoordinate(locations[i].Lat, locations[i].Lng);

                if (min < c2.GetDistanceTo(c1))
                    min = c2.GetDistanceTo(c1);
            }

            return min; 
        }

        public override PointLatLng getFocus()
        {
            return locations[0];
        }

        public override GMapMarker getMarker()
        {
            return path;
        }
    }
}
