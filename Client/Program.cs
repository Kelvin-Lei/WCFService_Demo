using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //InvocateCalculatorServiceViaCode();

                InvocateCalculatorServcieViaConfiguration();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.Read();

            //using (ChannelFactory<ICalculator> channelFactory = new ChannelFactory<ICalculator>(new WSHttpBinding(), "http://127.0.0.1:9999/calculatorservice"))
            //using (ChannelFactory<ICalculator> channelFactory = new ChannelFactory<ICalculator>("calculatorservice"))
            //{
            //    ICalculator proxy = channelFactory.CreateChannel();
            //    using (proxy as IDisposable)
            //    {
            //        Console.WriteLine("x + y = {2} when x = {0} and y = {1}", 1, 2, proxy.Add(1, 2));
            //        Console.WriteLine("x - y = {2} when x = {0} and y = {1}", 1, 2, proxy.Subtract(1, 2));
            //        Console.WriteLine("x * y = {2} when x = {0} and y = {1}", 1, 2, proxy.Multiply(1, 2));
            //        Console.WriteLine("x / y = {2} when x = {0} and y = {1}", 1, 2, proxy.Divide(1, 2));
            //    }
            //}
        }

        static void InvocateCalculatorServiceViaCode()
        {
            Binding httpBinding = new BasicHttpBinding();
            Binding tcpBinding = new NetTcpBinding();

            EndpointAddress httpAddress = new EndpointAddress("http://localhost:8888/calculatorservice");
            EndpointAddress tcpAddress = new EndpointAddress("net.tcp://localhost:9999/calculatorservice");
            EndpointAddress httpAddress_iisHost = new EndpointAddress("http://localhost:49804/CalculatorService.svc");

            Console.WriteLine("Invocate self-host calculator service ...");

            using (CalculatorClient calculator_http = new CalculatorClient(httpBinding, httpAddress))
            {
                using (CalculatorClient calculator_tcp = new CalculatorClient(tcpBinding, tcpAddress))
                {
                    try
                    {
                        Console.WriteLine("Begin to invocate calculator service via http transport ...");
                        Console.WriteLine("x + y = {2} where x = {0} and y = {1}", 1, 2, calculator_http.Add(1, 2));

                        Console.WriteLine("Begin to invocate calculator service via tcp transport ...");
                        Console.WriteLine("x + y = {2} where x = {0} and y = {1}", 1, 2, calculator_tcp.Add(1, 2));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            Console.WriteLine("\n\nInvocate IIS-host calculator service ...");

            using (CalculatorClient calculator = new CalculatorClient(httpBinding, httpAddress_iisHost))
            {
                try
                {
                    Console.WriteLine("Begin to invocate calculator service http transport ...");
                    Console.WriteLine("x + y = {2} where x = {0} and y = {1}", 1, 2, calculator.Add(1, 2));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static void InvocateCalculatorServcieViaConfiguration()
        {
            Console.WriteLine("Invocate self-host calculator service ...");

            using (CalculatorClient calculator_http = new CalculatorClient("selfHostEndpoint_http"))
            {
                using (CalculatorClient calculator_tcp = new CalculatorClient("selfHostEndpoint_tcp"))
                {
                    try
                    {
                        Console.WriteLine("Begin to invocate calculator service via http transport ...");
                        Console.WriteLine("x + y = {2} where x = {0} and y = {1}", 1, 2, calculator_http.Add(1, 2));

                        Console.WriteLine("Begin to invocate calculator service via tcp transport ...");
                        Console.WriteLine("x + y = {2} where x = {0} and y = {1}", 1, 2, calculator_tcp.Add(1, 2));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            Console.WriteLine("\n\nInvocate IIS-host calculator service ...");

            using (CalculatorClient calculator = new CalculatorClient("iisHostEndpoint"))
            {
                try
                {
                    Console.WriteLine("Begin to invocate calculator service via http transport ...");
                    Console.WriteLine("x + y = {2} where x = {0} and y = {1}", 1, 2, calculator.Add(1, 2));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
