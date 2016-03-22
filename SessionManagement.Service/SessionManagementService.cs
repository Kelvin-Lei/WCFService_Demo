using SessionManagement.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionManagement.Service
{
    public class SessionManagementService : ISessionManagement
    {

        public Guid StartSession(SessionClientInfo clientInfo, out TimeSpan timeout)
        {
            timeout = SessionManager.Timeout;
            return SessionManager.StartSession(clientInfo);
        }

        public void EndSession(Guid sessionID)
        {
            SessionManager.EndSession(sessionID);
        }

        public IList<SessionInfo> GetActiveSession()
        {
            return new List<SessionInfo>(SessionManager.CurrentSessionList.Values.ToArray<SessionInfo>());
        }

        public void KillSessions(IList<Guid> sessionIDs)
        {
            SessionManager.KillSessions(sessionIDs);
        }
    }
}
