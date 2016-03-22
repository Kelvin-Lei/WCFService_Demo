using SessionManagement.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SessionManagement.Client
{
    public static class SessionUtility
    {
        private static ISessionManagement Channel { get; set; }

        private static ISessionCallback Callback { get; set; }

        public static DateTime LastActivityTime { get; set; }

        public static Guid SessionID { get; set; }

        public static TimeSpan Timeout { get; set; }

        static SessionUtility()
        {
            Callback = new SessionCallback();
            Channel = new DuplexChannelFactory<ISessionManagement>(Callback, "sessionservice").CreateChannel();
        }

        public static void StartSession(SessionClientInfo clientInfo)
        {
            TimeSpan timeout;
            SessionID = Channel.StartSession(clientInfo, out timeout);
            Timeout = timeout;
        }

        public static IList<SessionInfo> GetActiveSessions()
        {
            return Channel.GetActiveSession();
        }

        public static void KillSessions(IList<Guid> sessionIDs)
        {
            Channel.KillSessions(sessionIDs);
        }

    }

    public class SessionCallback : ISessionCallback
    {

        public TimeSpan Renew()
        {
            return SessionUtility.Timeout - (DateTime.Now - SessionUtility.LastActivityTime);
        }

        public void OnSessionKilled(SessionInfo sessionInfo)
        {
            MessageBox.Show("The current session has been killed!", sessionInfo.SessionID.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Exit();
        }

        public void OnSessionTimeout(SessionInfo sessionInfo)
        {
            MessageBox.Show("The current session timeout!", sessionInfo.SessionID.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Exit();
        }
    }
}
