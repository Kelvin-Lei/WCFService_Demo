using InheritanceHierarchy.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceHierarchy.Client
{
    public class FullWhetherForecastClient : SimpleWhetherForecastClient, IFullWhetherForecast
    {
        public WindInfo GetWindInfo(string postalcode)
        {
            return this.Channel.GetWindInfo(postalcode);
        }
    }
}
