using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace OverloadableContract.Client
{
    class MyCalculatorClient : ClientBase<IMyCalculator>, IMyCalculator
    {
        public double Add(double x, double y)
        {
            return this.Channel.Add(x, y);
        }

        public double Add(double x, double y, double z)
        {
            return this.Channel.Add(x, y, z);
        }
    }
}
