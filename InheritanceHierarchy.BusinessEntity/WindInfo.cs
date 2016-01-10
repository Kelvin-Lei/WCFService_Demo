using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceHierarchy.BusinessEntity
{
    [DataContract]
    [KnownType(typeof(WindDirection))]
    public class WindInfo
    {
        private WindDirection _direction;
        private string _speed;

        public WindInfo(WindDirection direction, string speed)
        {
            this._direction = direction;
            this._speed = speed;
        }

        [DataMember]
        public WindDirection Direction
        {
            get { return _direction; }
            set { _direction = value; }
        }

        [DataMember]
        public string Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public override string ToString()
        {
            return string.Format("Direction: {0}; Speed: {1}", this._direction, this._speed);
        }
    }

    public enum WindDirection
    {
        East,
        South,
        West,
        North,
        Northeast,
        Southeast,
        Northwest,
        Southwest
    }
}
