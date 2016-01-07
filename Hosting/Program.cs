using Contracts;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace Hosting
{
    class Program
    {
        static void Main(string[] args)
        {
            HostCalculatorServiceViaConfiguration();

            //HostCalculatorServiceViaCode();

            //using (ServiceHost host = new ServiceHost(typeof(CalculatorService)))
            //{
            //    host.AddServiceEndpoint(typeof(ICalculator), 
            //                            new WSHttpBinding(), 
            //                            "http://127.0.0.1:9999/calculatorservice");

            //    if (host.Description.Behaviors.Find<ServiceMetadataBehavior>() == null)
            //    {
            //        ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
            //        behavior.HttpGetEnabled = true;
            //        behavior.HttpGetUrl = new Uri("http://127.0.0.1:9999/calculatorservice/metadata");
            //        host.Description.Behaviors.Add(behavior);
            //    }

            //    host.Opened += delegate
            //    {
            //        Console.WriteLine("CalculatorService已经启动，按任意键终止服务！");
            //    };

            //    host.Open();
            //    Console.Read();
            //}
        }

        static void HostCalculatorServiceViaCode()
        {
            Uri httpBaseAddress = new Uri("http://localhost:8888/calculatorservice");
            Uri tcpBaseAddress = new Uri("net.tcp://localhost:9999/calculatorservice");

            using (ServiceHost host = new ServiceHost(typeof(CalculatorService), httpBaseAddress, tcpBaseAddress))
            {
                BasicHttpBinding httpBinding = new BasicHttpBinding();
                NetTcpBinding tcpBinding = new NetTcpBinding();

                host.AddServiceEndpoint(typeof(ICalculator), httpBinding, string.Empty);
                host.AddServiceEndpoint(typeof(ICalculator), tcpBinding, string.Empty);

                ServiceMetadataBehavior behavior = host.Description.Behaviors.Find<ServiceMetadataBehavior>();
                {
                    if (behavior == null)
                    {
                        behavior = new ServiceMetadataBehavior();
                        behavior.HttpGetEnabled = true;
                        host.Description.Behaviors.Add(behavior);
                    }
                    else
                    {
                        behavior.HttpGetEnabled = true;
                    }
                }

                host.Opened += delegate
                {
                    Console.WriteLine("Calculator Service has began to listen ...");
                };

                host.Open();

                Console.Read();
            }
        }

        static void HostCalculatorServiceViaConfiguration()
        {
            using (ServiceHost host = new ServiceHost(typeof(CalculatorService)))
            {
                host.Opened += delegate
                {
                    Console.WriteLine("Calculator Service has begun to listen ...");
                };

                host.Open();

                Console.Read();
            }
        }
    }
}
