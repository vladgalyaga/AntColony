using AntColony.Entities;
using AntColony.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntColony
{
    public class Controller
    {
        public List<Way> Ways { get; set; }
        public List<City> Cities { get; set; }
        
        public Controller()
        {
            Cities = new CSVParser().ParseCities(Setting.FileName);
            FillWays();
        }

        private void FillWays()
        {
            Ways = new List<Way>();
            for (int i = 0; i < Cities.Count; i++)
            {
                for (int j = i + 1; j < Cities.Count; j++)
                {
                    Ways.Add(new Way(Cities[i], Cities[j]));
                }
            }
        }
        public List<Way> GetBestWays()
        {
            Ant luckyAnt = new Ant(null, null, 0) {SummOfDistance = Double.MaxValue };
            List<Way> result = null;
            Queue<Ant> colonyMemory = new Queue<Ant>(Setting.MemoryCount);
            object locker = new object();
            for (int i = 0; i < Setting.CountOfAnt; i++)
            {
                Ant ant = new Ant(Ways, Cities.First(), Cities.Count);
                result = ant.GetBetsPath();

                if (luckyAnt.SummOfDistance >= ant.SummOfDistance)
                    colonyMemory.Enqueue(ant);
                
                if (luckyAnt.SummOfDistance > ant.SummOfDistance)
                    luckyAnt = ant;

                Console.WriteLine(ant.SummOfDistance);
                Console.WriteLine(luckyAnt.SummOfDistance);

                if (colonyMemory.Count > Setting.MemoryCount)
                {
                    var oldAnt = colonyMemory.Peek();
                    oldAnt.Dispose();
                }
            }
            return result;
        }

    }
}
