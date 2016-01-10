using InheritanceHierarchy.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceHierarchy.Service
{
    public class FullWhetherForecastService : SimpleWhetherForecastService, IFullWhetherForecast
    {
        public WindInfo GetWindInfo(string postalcode)
        {
            WindInfo info = new WindInfo(WindDirection.Northwest, "12km/h");
            return info;
        }
    }
}
