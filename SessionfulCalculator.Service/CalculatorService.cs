using SessionfulCalculator.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SessionfulCalculator.Service
{
    public class CalculatorService : ICalculator
    {
        private double _result;

        public void Adds(double x)
        {
            Console.WriteLine("The Add method is invoked and the current session ID is: {0}", OperationContext.Current.SessionId);
            this._result += x;
        }

        public double GetResult()
        {
            Console.WriteLine("The GetResult method is invoked and the current session ID is: {0}", OperationContext.Current.SessionId);
            return this._result;
        }

        public CalculatorService()
        {
            Console.WriteLine("Calculator object has been creaded");
        }

        ~CalculatorService()
        {
            Console.WriteLine("Calculator object has been destoried");
        }
    }
}
