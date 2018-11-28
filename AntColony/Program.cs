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
            var controller = new Controller();
            var result = controller.GetBestWays();

            var city = result.First().Cities.First();
            Console.WriteLine(city.Name);
            result.ForEach(x =>
            {
                
                Console.WriteLine(x.Cities.First(c => c != city).Name);
                city = x.Cities.First(c => c != city);
            }
            );

            Console.WriteLine(result.Sum(x => x.Distance));

            Console.ReadKey();
        }
    }
}
