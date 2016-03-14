using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace CallContextInitializers
{
    public class CultureSettingBehaviorElement : BehaviorExtensionElement
    {
        public override Type BehaviorType
        {
            get { return typeof(CultureSettingBehavior); }
        }

        protected override object CreateBehavior()
        {
            return new CultureSettingBehavior();
        }
    }
}
