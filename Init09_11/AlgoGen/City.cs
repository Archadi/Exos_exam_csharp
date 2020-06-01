using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoGen
{
    class City
    {
        public string Name { set; get; }
        public double Latitude { set; get; }
        public double Longitude { set; get; }

        public City(string aName, double aLatitude, double aLongitude) 
        {
            Name = aName;
            Latitude = aLatitude;
            Longitude = aLongitude;
        }

        public double DegreesToRadians(double degres)
        {
            return degres * (Math.PI / 180);
        }


        public double GetDistanceFromPosition(double latitude, double longitude)
        {
            var R = 6371; // radius of the earth in km
            var dLat = DegreesToRadians(latitude - Latitude);
            var dLon = DegreesToRadians(longitude - Longitude);
            var a =
                Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Cos(DegreesToRadians(Latitude)) * Math.Cos(DegreesToRadians(latitude)) *
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var d = R * c; // distance in km
            return d;
        }
    }
}
