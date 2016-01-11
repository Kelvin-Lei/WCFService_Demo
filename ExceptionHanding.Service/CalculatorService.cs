using ExceptionHandling.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling.Service
{
    public class CalculatorService : ICalculator
    {
        public double Divide(double x, double y)
        {
            if (y == 0)
            {
                MathError error = new MathError("Divide", "Divided by zero");
                throw new FaultException<MathError>(error,
                                                    new FaultReason("Parameters passed are not valid"),
                                                    new FaultCode("sender"));
            }
            return x / y;
        }

    }
}
