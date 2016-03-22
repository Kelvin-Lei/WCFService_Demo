using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PooledInstanceProvider.WCFExtensions
{
    public class WeakReferenceDictionary : Dictionary<Type, WeakReferenceCollection>
    {
    }
}
