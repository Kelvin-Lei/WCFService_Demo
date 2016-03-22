using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CallContextInitializers
{
    public class CultureSettingCallContextInitializer : ICallContextInitializer
    {
        private const string CultureInfoHeadLocalName = "__CultureInfo";
        private const string CultureInfoHeaderNamespace = "urn:artech.com";
        public void AfterInvoke(object correlationState)
        {
            CultureInfo[] currentCulture = correlationState as CultureInfo[];
            Thread.CurrentThread.CurrentCulture = currentCulture[0];
            Thread.CurrentThread.CurrentUICulture = currentCulture[1];
        }

        public object BeforeInvoke(System.ServiceModel.InstanceContext instanceContext, System.ServiceModel.IClientChannel channel, System.ServiceModel.Channels.Message message)
        {
            CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
            CultureInfo currentUICulture = Thread.CurrentThread.CurrentUICulture;

            if (message.Headers.FindHeader(CultureInfoHeadLocalName, CultureInfoHeaderNamespace) > -1)
            {
                CultureInfo cultureInfo = message.Headers.GetHeader<CultureInfo>(CultureInfoHeadLocalName, CultureInfoHeaderNamespace);
                Thread.CurrentThread.CurrentCulture = cultureInfo;
                Thread.CurrentThread.CurrentUICulture = cultureInfo;
            }

            return new CultureInfo[] { currentCulture, currentUICulture };
        }
    }
}
