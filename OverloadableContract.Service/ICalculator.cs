using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace OverloadableContract.Service
{
    [ServiceContract]
    public interface ICalculator
    {
        /// <summary>
        /// 
        /// 定义两个Add方法，为把两个方法映射到两个不同的Operation中，
        /// 通过System.ServiceModel.OperatonAttribute的Name属性为Operation指定一个Name;
        /// 
        /// </summary>
        
        [OperationContract(Name="AddWithTwoOperans")]
        double Add(double x, double y);

        [OperationContract(Name="AddWithThreeOperands")]
        double Add(double x, double y, double z);
    }
}
