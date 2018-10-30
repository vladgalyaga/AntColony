using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;

namespace AntColony
{
    public class Setting
    {

        public static int DegreeOfPheromone => Int32.Parse(ConfigurationSettings.AppSettings["DegreeOfPheromone"]);
        public static double DegreeOfDistance => Double.Parse(ConfigurationSettings.AppSettings["DegreeOfDistance"]);
        public static double PheromonCountOfOneAnt => Double.Parse(ConfigurationSettings.AppSettings["PheromonCountOfOneAnt"]);
        public static double CountOfAnt => Double.Parse(ConfigurationSettings.AppSettings["CountOfAnt"]);
        public static int MemoryCount => Int32.Parse(ConfigurationSettings.AppSettings["MemoryCount"]);
        public static string FileName => ConfigurationSettings.AppSettings["FileName"];

    }
}
