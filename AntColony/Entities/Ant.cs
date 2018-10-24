using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntColony.Entities
{
    public class Ant : IDisposable
    {
        public List<City> VisitedCities { get; set; } = new List<City>();
        public List<Way> TraveledWays { get; set; } = new List<Way>();
        public List<Way> AllWays { get; set; }
        public City StartCity { get; set; }
        public double FeromomForOneWay { get; set; }

        private Random _random = new Random();

        public Ant(List<Way> allWays, City startCity)
        {
            StartCity = startCity;
            AllWays = allWays;
        }


        public List<Way> GetBetsPath()
        {
            City city = null;
            var lastCity = StartCity;

            var tmp = ChouseWay(lastCity).Cities;
            lastCity = tmp.First(x => x != lastCity);
            while (lastCity != StartCity)
            {
                tmp = ChouseWay(lastCity).Cities;
                lastCity = tmp.First(x => x != lastCity);
            }

            var summOfDistance = TraveledWays.Sum(x => x.Distance);
            FeromomForOneWay = Setting.PheromonCountOfOneAnt / summOfDistance;
            TraveledWays.ForEach(x => x.Feromon += FeromomForOneWay);

            return TraveledWays;
        }

        public void Dispose()
        {
            TraveledWays.ForEach(x => x.Feromon -= FeromomForOneWay);
        }

        private Way ChouseWay(City currentCity)
        {
            Way enteredWay = null;


            var a = AllWays.Where(w => w.Cities.Any(c => c == currentCity)).ToList();
            var b = a.Where(w => w.Cities.Any(c => !VisitedCities.Contains(c))).ToList();

            var possibleWays = AllWays.Where(w => w.Cities.Any(c => c == currentCity) &&
                                        !w.Cities.Any(c => VisitedCities.Contains(c))).ToList();
            if (possibleWays.Count == 0)
            {
                enteredWay = AllWays.First(w => w.Cities.Any(c => c == currentCity) && w.Cities.Any(c => c == StartCity));
            }
            else
            {
                var summOfAttractiveness = possibleWays.Sum(x => x.GetAttractiveness());

                Dictionary<double, Way> ranges = new Dictionary<double, Way>();
                double lastValue = 0;

                possibleWays.ForEach(x =>
                {
                    lastValue += x.GetAttractiveness() / summOfAttractiveness;
                    if (!ranges.Keys.Contains(lastValue))
                        ranges.Add(lastValue, x);
                });

                var rndValue = _random.NextDouble();
                var keyEnteredWay = ranges.Keys.Where(x => x > rndValue).Min();
                enteredWay = ranges[keyEnteredWay];

            }
            if (!VisitedCities.Contains(currentCity))
                VisitedCities.Add(currentCity);
            TraveledWays.Add(enteredWay);
            return enteredWay;
        }



    }
}
