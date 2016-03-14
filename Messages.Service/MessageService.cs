using Messages.Contract;
using Messages.Service.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages.Service
{
    public class MessageService : IMessage
    {
        public string GetMessage()
        {
            return Resources.HelloWorld;
        }
    }
}
