using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SessionManagement.Contract
{
    [ServiceContract(CallbackContract = typeof(ISessionCallback))]
    public interface ISessionManagement
    {
        [OperationContract]
        Guid StartSession(SessionClientInfo clientInfo, out TimeSpan timeout);

        [OperationContract]
        void EndSession(Guid sessionID);

        [OperationContract]
        IList<SessionInfo> GetActiveSession();

        [OperationContract]
        void KillSessions(IList<Guid> sessionIDs);
    }
}
