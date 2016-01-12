using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ResponsiveQueuedService.Contract
{
    [DataContract]
    public class OrderResponseContext
    {
        private Uri _responseAddress;

        [DataMember]
        public Uri ResponseAddress
        {
            get { return _responseAddress; }
            set { _responseAddress = value; }
        }

        public static OrderResponseContext Current
        {
            get
            {
                if (OperationContext.Current == null)
                {
                    return null;
                }
                return OperationContext.Current.IncomingMessageHeaders.GetHeader<OrderResponseContext>("OrderResponseContext", "ResponsiveQueuedService.Contract");
            }

            set
            {
                MessageHeader<OrderResponseContext> header = new MessageHeader<OrderResponseContext>(value);
                OperationContext.Current.OutgoingMessageHeaders.Add(header.GetUntypedHeader("OrderResponseContext", "ResponsiveQueuedService.Contract"));
            }
        }
    }
}
