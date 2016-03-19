using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;
using UnityInstanceProvider.WCFExtensions.Properties;

namespace UnityInstanceProvider.WCFExtensions
{
    public class UnityInstanceProvider : IInstanceProvider
    {
        private Type _contractType;
        private string _containerName;

        public UnityInstanceProvider(Type contractType, string containerName)
        {
            if (contractType == null)
            {
                throw new ArgumentNullException("contractType");
            }

            this._containerName = containerName;
            this._contractType = contractType;
        }



        public object GetInstance(System.ServiceModel.InstanceContext instanceContext, System.ServiceModel.Channels.Message message)
        {
            //UnityConfigurationSection unitySection = ConfigurationManager.GetSection("unity") as UnityConfigurationSection;
            
            //if (unitySection == null)
            //{
            //    throw new ConfigurationErrorsException(string.Format(CultureInfo.CurrentCulture, Resources.MissUnityConfiguration));
            //}

            //IUnityContainer container = new UnityContainer();

            //ContainerElement containerElement;
            //if (string.IsNullOrEmpty(this._containerName))
            //{
            //    containerElement = unitySection.Containers.Default;
            //}
            //else
            //{
            //    containerElement = unitySection.Containers[this._containerName];
            //}

            //unitySection.Configure(container);

            //UnityTypeElement[] unityTypeElements = Array.CreateInstance(typeof(UnityTypeElement), containerElement.GetType()) as UnityTypeElement[];
            //containerElement.GetType;

            //if (unityTypeElements.Where(element => element.type == this._contractType).Count() == 0)
            //{
            //    container.RegisterType(this._contractType, instanceContext.Host.Description.ServiceType);
            //}



            //return container.Resolve(this._contractType);

            IUnityContainer container = new UnityContainer();
            UnityConfigurationSection configuration = ConfigurationManager.GetSection(UnityConfigurationSection.SectionName) as UnityConfigurationSection;
            configuration.Configure(container, this._containerName);
            //注册契约接口与其对应的服务类
            container.RegisterType(this._contractType, instanceContext.Host.Description.ServiceType);
            return container.Resolve(this._contractType);

        }

        public object GetInstance(System.ServiceModel.InstanceContext instanceContext)
        {
            return this.GetInstance(instanceContext, null);
        }

        public void ReleaseInstance(System.ServiceModel.InstanceContext instanceContext, object instance)
        {
            IDisposable disposable = instance as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
    }
}
