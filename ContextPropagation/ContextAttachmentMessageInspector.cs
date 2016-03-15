using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace ContextPropagation
{
    public class ContextAttachmentMessageInspector : IClientMessageInspector
    {
        public bool IsBidirectional { get; set; }

        public ContextAttachmentMessageInspector()
            : this(false)
        { }

        public ContextAttachmentMessageInspector(bool isBidirectional)
        {
            this.IsBidirectional = isBidirectional;
        }



        public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        {
            if (!IsBidirectional)
            {
                return;
            }

            if (reply.Headers.FindHeader(ApplicationContext.ContextHeaderLocalName, ApplicationContext.ContextHeaderNamespace) < 0)
            {
                return;
            }

            ApplicationContext context = reply.Headers.GetHeader<ApplicationContext>(ApplicationContext.ContextHeaderLocalName, ApplicationContext.ContextHeaderNamespace);
            if (context == null)
            {
                return;
            }

            ApplicationContext.Current = context;
        }

        public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel)
        {
            MessageHeader<ApplicationContext> contextHeader = new MessageHeader<ApplicationContext>(ApplicationContext.Current);
            request.Headers.Add(contextHeader.GetUntypedHeader(ApplicationContext.ContextHeaderLocalName, ApplicationContext.ContextHeaderNamespace));
            return null;
        }
    }
}
