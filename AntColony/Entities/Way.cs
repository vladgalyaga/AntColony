using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntColony.Entities
{
    public class Way
    {
        public City[] Cities { get; }
        public double Distance { get; set; }
        public double Feromon { get; set; } = 1;

        public Way()
        {
            Cities = new City[2];
        }

        public Way(City city1, City city2) : this()
        {
            Cities[0] = city1;
            Cities[1] = city2;
            Distance = city1.GeoCoordinate.GetDistanceTo(city2.GeoCoordinate);
        }

        public double GetAttractiveness()
        {
            var result = Math.Pow(Feromon, Setting.DegreeOfPheromone) / Math.Pow(Distance, Setting.DegreeOfDistance);
            return result;
        }
    }
}
