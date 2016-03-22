using ContextPropagation.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextPropagation.Services
{
    public class Service : IContract
    {
        //[ContextReceivalBehavior(IsBidirectional = true)]
        public void DoSomething()
        {
            Console.WriteLine("ApplicationContext.Current.Count = {0}", ApplicationContext.Current.Counter);
            ApplicationContext.Current.Counter++;
        }
    }
}
