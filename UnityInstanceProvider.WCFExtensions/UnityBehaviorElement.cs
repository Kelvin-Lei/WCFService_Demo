using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace UnityInstanceProvider.WCFExtensions
{
    public class UnityBehaviorElement : BehaviorExtensionElement
    {
        [ConfigurationProperty("containerName", IsRequired = false, DefaultValue = "")]
        public string ContainerName
        {
            get
            {
                return this["containerName"] as string;
            }
            set
            {
                this["containerName"] = value;
            }
        }

        public override Type BehaviorType
        {
            get 
            {
                return typeof(UnityBehavior);
            }
        }

        protected override object CreateBehavior()
        {
            return new UnityBehavior(this.ContainerName);
        }
    }
}
