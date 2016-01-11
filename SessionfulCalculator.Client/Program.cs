using SessionfulCalculator.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SessionfulCalculator.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            ChannelFactory<ICalculator> calculatorChannelFactory = new ChannelFactory<ICalculator>("httpEndpoint");
            Console.WriteLine("Create a calculator proxy: proxy1");
            ICalculator proxy1 = calculatorChannelFactory.CreateChannel();
            Console.WriteLine("Invocate proxy1.Adds(1)");
            proxy1.Adds(1);
            Console.WriteLine("Invocate proxy1.Adds(2)");
            proxy1.Adds(2);
            Console.WriteLine("The result return via proxy1.GetResult() is : {0}", proxy1.GetResult());

            Console.WriteLine("Create a calculator proxy: proxy2");
            ICalculator proxy2 = calculatorChannelFactory.CreateChannel();
            Console.WriteLine("Invocate proxy2.Adds(1)");
            proxy2.Adds(1);
            Console.WriteLine("Invocate proxy2.Adds(2)");
            proxy2.Adds(2);
            Console.WriteLine("The result return via proxy2.GetResult() is: {0}", proxy2.GetResult());

            Console.Read();
        }
    }
}
