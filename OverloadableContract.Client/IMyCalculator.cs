using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace OverloadableContract.Client
{
    [ServiceContract(Name="ICalculator")]
    public interface IMyCalculator
    {
        [OperationContract(Name = "AddWithTwoOperans")]
        double Add(double x, double y);

        [OperationContract(Name = "AddWithThreeOperands")]
        double Add(double x, double y, double z);
    }
}
