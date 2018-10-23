using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntColony
{
    public class Setting
    {
        public static double DegreeOfPheromone { get; set; } = 1;
        public static double DegreeOfDistance { get; set; } = 1;
        public static double PheromonCountOfOneAnt { get; set; } = 1000;
    }
}
