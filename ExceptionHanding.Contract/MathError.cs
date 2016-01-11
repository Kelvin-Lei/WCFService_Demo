using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling.Contract
{
    [DataContract]
    public class MathError
    {
        private string _operation;
        private string _errorMessage;

        public MathError(string operation, string errorMessage)
        {
            this._operation = operation;
            this._errorMessage = errorMessage;
        }

        [DataMember]
        public string Operation
        {
            get { return _operation; }
            set { _operation = value; }
        }

        [DataMember]
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }
    }
}
