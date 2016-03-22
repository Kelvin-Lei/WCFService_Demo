using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace ContextPropagation
{
    public class ContextPropagationBehaviorElement : BehaviorExtensionElement
    {
        [ConfigurationProperty("isBidirectional", DefaultValue = false)]
        public bool IsBidirectional
        {
            get
            {
                return (bool)this["isBidirectional"];
            }
            set
            {
                this["isBidirectional"] = value;
            }
        }


        public override Type BehaviorType
        {
            get
            {
                return typeof(ContextPropagationBehavior);
            }
        }

        protected override object CreateBehavior()
        {
            return new ContextPropagationBehavior(this.IsBidirectional);
        }
    }
}
