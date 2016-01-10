using InheritanceHierarchy.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceHierarchy.Service
{
    [ServiceContract]
    public interface ISimpleWhetherForecast
    {
        [OperationContract]
        BasicWhetherInfo GetBasicWhetherInfo(string postalcode);
    }
}
