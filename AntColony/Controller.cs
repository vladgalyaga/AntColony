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
            Cities = new CSVParser().ParseCities("Switzerland");
            FillWays();
        }

        private void FillWays()
        {
            Ways = new List<Way>();
            for (int i = 0; i < Cities.Count; i++)
            {
                for (int j = i; j < Cities.Count; j++)
                {
                    Ways.Add(new Way(Cities[i], Cities[j]));
                }
            }
        }

    }
}
