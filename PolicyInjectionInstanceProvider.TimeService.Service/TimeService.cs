using PolicyInjectionInstanceProvider.TimeService.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolicyInjectionInstanceProvider.TimeService.Service
{
    public class TimeService : ITime
    {
        public DateTime GetCurrentTime()
        {
            return DateTime.Now;
        }
    }
}
