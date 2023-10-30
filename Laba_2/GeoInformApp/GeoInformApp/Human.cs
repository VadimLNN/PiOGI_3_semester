﻿using GMap.NET.WindowsPresentation;
using GMap.NET;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Windows;

namespace GeoInformApp
{
    public class Human : MapObject
    {
        PointLatLng location;
        GMapMarker marker;
        public Human(string title, PointLatLng location, string img) : base(title)
        {
            this.location = location;

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
        
        PointLatLng destination;

        public event EventHandler passengerSeated;

        public void setLocation(PointLatLng loc) { location = loc; }

        // обработчик события прибытия такси
        public void CarArrived(object sender, EventArgs e)
        {
            passengerSeated?.Invoke(this, EventArgs.Empty);
        }
        public void endOfRoad()
        {
            MessageBox.Show("Win");
        }

        public void setDestanation(PointLatLng dest) { destination = dest; }
        public PointLatLng getDestanation() { return destination; }  
    }
}