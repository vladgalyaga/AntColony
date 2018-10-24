using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntColony
{
    public class Setting
    {
        public static int DegreeOfPheromone { get; set; } = 10;
        public static double DegreeOfDistance { get; set; } = 1;
        public static double PheromonCountOfOneAnt { get; set; } = 1000;
        public static double CountOfAnt { get; set; } = 10000000;

    }
}
