using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PolicyInjectionInstanceProvider.TimeService.Contract
{
    [ServiceContract]
    public interface ITime
    {
        [OperationContract]
        DateTime GetCurrentTime();
    }
}
