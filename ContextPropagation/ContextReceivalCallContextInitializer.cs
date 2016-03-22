using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace ContextPropagation
{
    public class ContextReceivalCallContextInitializer : ICallContextInitializer
    {
        public bool IsBidirectional { get; set; }

        public ContextReceivalCallContextInitializer() 
            : this(false)
        { }

        public ContextReceivalCallContextInitializer(bool isBidirectional)
        {
            this.IsBidirectional = isBidirectional;
        }



        public void AfterInvoke(object correlationState)
        {
            if (!this.IsBidirectional)
            {
                return;
            }

            ApplicationContext context = correlationState as ApplicationContext;

            if (context == null)
            {
                return;
            }

            MessageHeader<ApplicationContext> contextHeader = new MessageHeader<ApplicationContext>(context);
            OperationContext.Current.OutgoingMessageHeaders.Add(contextHeader.GetUntypedHeader(ApplicationContext.ContextHeaderLocalName, ApplicationContext.ContextHeaderNamespace));
            ApplicationContext.Current = null;
        }

        public object BeforeInvoke(System.ServiceModel.InstanceContext instanceContext, System.ServiceModel.IClientChannel channel, System.ServiceModel.Channels.Message message)
        {
            ApplicationContext context = message.Headers.GetHeader<ApplicationContext>(ApplicationContext.ContextHeaderLocalName, ApplicationContext.ContextHeaderNamespace);
            if (context == null)
            {
                return null;
            }

            ApplicationContext.Current = context;
            return ApplicationContext.Current;
        }
    }
}
