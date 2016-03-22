using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SessionManagement.Contract
{
    [DataContract]
    [KnownType(typeof(SessionClientInfo))]
    public class SessionInfo
    {
        [DataMember]
        public Guid SessionID { get; set; }

        [DataMember]
        public DateTime StartTime { get; set; }

        [DataMember]
        public DateTime LastActivityTime { get; set; }

        [DataMember]
        public SessionClientInfo ClientInfo { get; set; }

        public bool IsTimeout { get; set; }
    }
}
