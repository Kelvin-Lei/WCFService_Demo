using InheritanceHierarchy.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceHierarchy.Service
{
    public class SimpleWhetherForecastService : ISimpleWhetherForecast
    {
        public BasicWhetherInfo GetBasicWhetherInfo(string postalcode)
        {
            BasicWhetherInfo info = new BasicWhetherInfo(WhetherConditions.Overcost, 23);
            return info;
        }
    }
}
