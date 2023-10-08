using GMap.NET;
using GMap.NET.WindowsPresentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoInformApp
{
    public abstract class MapObject
    {
        string title;
        DateTime creationDate;

        public MapObject(string title)
        {
            this.title = title;
            creationDate = DateTime.Now;
        }

        public string getTitle() { return title; }
        DateTime getCreationDate() { return creationDate; }

        public abstract double getDistance(PointLatLng point);

        public abstract PointLatLng getFocus();

        public abstract GMapMarker getMarker();
    }
}
