using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CalculatorService : ICalculator
    {
        public void Add(double x, double y)
        {
            //return x + y;
            double result = x + y;
            ICallback callback = OperationContext.Current.GetCallbackChannel<ICallback>();
            callback.DisplayResult(x, y, result);
        }

        public double Subtract(double x, double y)
        {
            return x - y;
        }

        public double Multiply(double x, double y)
        {
            return x * y;
        }

        public double Divide(double x, double y)
        {
            return x / y;
        }
    }
}
