using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ContextPropagation.Contract
{
    [ServiceContract]
    public interface IContract
    {
        [OperationContract]
        void DoSomething();
    }
}
