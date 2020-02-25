using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterators
{
    public interface PropertyValue
    {
        object Value { get; }
    }
    public class PropertyValue<T> : PropertyValue
    {
        public object Value { get; private set; }
        public PropertyValue(T value)
        {
            this.Value = value;
        }
    }

}
