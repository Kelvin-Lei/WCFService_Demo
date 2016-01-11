using ExceptionHandling.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling.Contract
{
    [ServiceContract]
    public interface ICalculator
    {
        [OperationContract]
        [FaultContract(typeof(MathError))]
        double Divide(double x, double y);
    }
}
