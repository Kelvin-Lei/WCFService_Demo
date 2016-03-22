using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SessionManagement.Contract
{
    [DataContract]
    public class SessionClientInfo
    {
        [DataMember]
        public string IPAddress { get; set; }

        [DataMember]
        public string HostName { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public IDictionary<string, string> ExtendedProperties { get; set; }
    }
}
