using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace UnityInstanceProvider.Messages.Contract
{
    [ServiceContract]
    public interface IMessage
    {
        [OperationContract]
        string GetMessage(string key);
    }
}
