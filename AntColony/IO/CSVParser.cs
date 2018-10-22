using AntColony.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntColony.IO
{
    public class CSVParser
    {
        public List<City> ParseCities(string fileName, string format = "txt")
        {
            string str_directory = Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory.ToString()).FullName).FullName;
            List<string> strs = File.ReadAllLines($@"{str_directory}\Resources\{fileName}.{format}").ToList();
            strs.RemoveAt(0);
            List<City> result = strs.Select(x => GetCity(x)).ToList();
            return result;
        }

        private City GetCity(string str)
        {
            List<string> values = str.Split(',').ToList();
            return new City(values[0], ToDouble(values[1]), ToDouble(values[2]));
        }

        private double ToDouble(string str)
        {
            return Double.Parse(str.Replace('.', ','));
        }

    }
}
