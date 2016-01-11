using ExceptionHandling.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            ChannelFactory<ICalculator> calculatorFactory = new ChannelFactory<ICalculator>("defaultEndpoint");
            ICalculator calculator = calculatorFactory.CreateChannel();
            try
            {
                Console.WriteLine("Try to invoke Divide method");
                Console.WriteLine("x / y = {2} when x = {0} and y = {1}", 2, 0, calculator.Divide(2, 0));
            }
            catch (FaultException<MathError> ex)
            {
                MathError error = ex.Detail;
                Console.WriteLine("An Fault is thrown.\n\tFault code:{0}\n\tFault Reason:{1}\n\tOperation:{2}\n\tMessage:{3}", ex.Code, ex.Reason, error.Operation, error.ErrorMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Exception is thrown.\n\tException Type:{0}\n\tError Message:{1}", ex.GetType(), ex.Message);
            }
            Console.Read();
        }
    }
}
