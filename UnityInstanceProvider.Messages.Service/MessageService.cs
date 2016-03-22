using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityInstanceProvider.Messages.Contract;
using UnityInstanceProvider.Messages.Service.Properties;

namespace UnityInstanceProvider.Messages.Service
{
    public class MessageService : IMessage
    {
        [Dependency]
        public IMessageManager MessageManager { get; set; }

        [InjectionMethod]
        public void Initialize()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("zh-CN");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("zh-CN");
        }

        public string GetMessage(string key)
        {
            return this.MessageManager.GetMessage(key, Thread.CurrentThread.CurrentUICulture);
        }
    }

    public interface IMessageManager
    {
        string GetMessage(string key, CultureInfo culture, params object[] parameters);
    }

    public class MessageManager : IMessageManager
    {
        public ResourceManager ResourceManager { get; set; }

        public MessageManager()
        {
            this.ResourceManager = new ResourceManager("UnityInstanceProvider.Messages.Service.Properties.Resources", typeof(Resources).Assembly);
        }

        public string GetMessage(string key, CultureInfo culture, params object[] parameters)
        {
            string message = ResourceManager.GetString(key, culture);
            return string.Format(culture, message, parameters);
        }
    }
}
