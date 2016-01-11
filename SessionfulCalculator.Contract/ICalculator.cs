using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SessionfulCalculator.Contract
{
    [ServiceContract]
    public interface ICalculator
    {
        [OperationContract(IsOneWay=true)]
        void Adds(double x);

        [OperationContract]
        double GetResult();
    }
}
