using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceHierarchy.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FullWhetherForecastClient fullWhetherForecast = new FullWhetherForecastClient())
            {
                Console.WriteLine("FullWhetherForecast：{0}\n", fullWhetherForecast.GetWindInfo("sz"));
            }

            using (SimpleWhetherForecastClient simpleWhetherForecast = new SimpleWhetherForecastClient())
            {
                Console.WriteLine("SimpleWhetherForecast：{0}\n", simpleWhetherForecast.GetBasicWhetherInfo("sz"));
            }
        }
    }
}
