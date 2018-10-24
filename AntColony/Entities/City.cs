using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntColony.Entities
{
    public class City
    {
        public string Name { get; set; }
        public GeoCoordinate GeoCoordinate { get; set; }

        public City(string name, GeoCoordinate geoCoordinate)
        {
            GeoCoordinate = geoCoordinate;
            Name = name;
        }
        public City(string name, double latitude, double longitude)
        {
            GeoCoordinate = new GeoCoordinate(latitude, longitude);
            Name = name;
        }
    }
}
