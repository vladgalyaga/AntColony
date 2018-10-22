using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;
using AntColony.IO;

namespace AntColony
{
    class Program
    {
        static void Main(string[] args)
        {
            //GeoCoordinate geoLondon = new GeoCoordinate(51.3, -0.1);
            //GeoCoordinate geoMoskow = new GeoCoordinate(55.45, 37.36);
            //double distanceTo = geoLondon.GetDistanceTo(geoMoskow);
            //Console.WriteLine("Расстояние от Москвы до Лондона = {0:F} км.", distanceTo / 1000);]
            //  var result = new CSVParser().ParseCities("Switzerland");
            var a = new Controller();
            Console.ReadKey();
        }
    }
}
