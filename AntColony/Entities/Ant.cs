using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntColony.Entities
{
    public class Ant
    {
        public List<City> VisitedCities { get; set; } = new List<City>();
        public List<Way> TraveledWays { get; set; } = new List<Way>();

        private Random _random = new Random();


        public Way ChouseWay(List<Way> ways, City currentCity)
        {
            var possibleWays = ways.Where(w => w.Cities.Any(c => c == currentCity) &&
                                              !w.Cities.Any(c => VisitedCities.Contains(c))).ToList();


            var summOfAttractiveness = possibleWays.Sum(x => x.GetAttractiveness());

            Dictionary<double, Way> ranges = new Dictionary<double, Way>();
            double lastValue = 0;

            possibleWays.ForEach(x =>
            {
                lastValue = x.GetAttractiveness() / summOfAttractiveness;
                ranges.Add(lastValue, x);
            });

            var rndValue = _random.NextDouble();
            var keyEnteredWay = ranges.Keys.Where(x => x > rndValue).Min();
            var enteredWay = ranges[keyEnteredWay];
            TraveledWays.Add(enteredWay);


            return enteredWay;
        }



    }
}
