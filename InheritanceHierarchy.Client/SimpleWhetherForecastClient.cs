using InheritanceHierarchy.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceHierarchy.Client
{
    public class SimpleWhetherForecastClient : ClientBase<IFullWhetherForecast>, ISimpleWhetherForecast
    {
        public BasicWhetherInfo GetBasicWhetherInfo(string postalcode)
        {
            return this.Channel.GetBasicWhetherInfo(postalcode);
        }
    }
}
