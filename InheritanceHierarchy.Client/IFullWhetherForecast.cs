using InheritanceHierarchy.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceHierarchy.Client
{
    [ServiceContract]
    public interface IFullWhetherForecast : ISimpleWhetherForecast
    {
        [OperationContract]
        WindInfo GetWindInfo(string postalcode);
    }
}
