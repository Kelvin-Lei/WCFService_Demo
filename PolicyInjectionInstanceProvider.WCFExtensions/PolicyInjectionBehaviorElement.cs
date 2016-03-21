using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace PolicyInjectionInstanceProvider.WCFExtensions
{
    public class PolicyInjectionBehaviorElement : BehaviorExtensionElement
    {
        [ConfigurationProperty("policyInjectorName", IsRequired = false, DefaultValue = "")]
        public string PolicyInjectorName
        {
            get
            {
                return this["policyInjectorName"] as string;
            }
            set
            {
                this["policyInjectorName"] = value;
            }
        }

        public override Type BehaviorType
        {
            get { return typeof(PolicyInjectionBehavior); }
        }

        protected override object CreateBehavior()
        {
            return new PolicyInjectionBehavior(this.PolicyInjectorName);
        }
    }
}
