using GMap.NET.WindowsPresentation;
using GMap.NET;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GeoInformApp
{
    public class Area : MapObject
    {
        List<PointLatLng> locations;
        GMapMarker area;
        public Area(string title, List<PointLatLng> Locations) : base(title)
        {
            if (Locations.Count < 3)
                return;

            this.locations = new List<PointLatLng>(Locations);

            area = new GMapPolygon(locations)
            {
                Shape = new System.Windows.Shapes.Path
                {
                    Stroke = Brushes.Black, // стиль обводки
                    Fill = Brushes.LightGoldenrodYellow, // стиль заливки
                    Opacity = 0.5 // прозрачность
                }
            };

        }
        public override double getDistance(PointLatLng point)
        {
            double min = 10000000;
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
            return area;
        }
    }
}
