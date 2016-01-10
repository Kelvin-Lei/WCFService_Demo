using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceHierarchy.BusinessEntity
{
    [DataContract]
    [KnownType(typeof(WhetherConditions))]
    public class BasicWhetherInfo
    {
        private WhetherConditions _condition;
        private double _temperature;

        public BasicWhetherInfo(WhetherConditions condition, double temperature)
        {
            this._condition = condition;
            this._temperature = temperature;
        }

        [DataMember]
        public WhetherConditions Condition
        {
            get { return _condition; }
            set { _condition = value; }
        }

        [DataMember]
        public double Temperature
        {
            get { return _temperature; }
            set { _temperature = value; }
        }

        public override string ToString()
        {
            return string.Format("Conditions: {0}; Temperature: {1}", this._condition, this._temperature);
        }
    }

    public enum WhetherConditions
    {
        Clear,
        Cloudy,
        Overcost,
        Rainy
    }
}
