using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Iterators
{
    public class PropertyIterator<T> : IEnumerator<PropertyValue>, IEnumerable<PropertyValue>
    {
        private T classObject;
        private int currentIndex = -1;
        private PropertyInfo[] properties;
        public PropertyIterator(T classObject)
        {
            this.classObject = classObject;
            this.properties = this.classObject.GetType().GetProperties();
        }

        private dynamic Cast(dynamic obj, Type castTo)
        {
            return Convert.ChangeType(obj, castTo);
        }

        public PropertyValue Current
        {
            get
            {
                Type generic = typeof(PropertyValue<>);
                Type[] typeArgs = { this.properties[currentIndex].PropertyType };
                Type constructed = generic.MakeGenericType(typeArgs);
                PropertyValue propValue = (PropertyValue)Activator.CreateInstance(constructed, this.properties[currentIndex].GetValue(this.classObject));

                return propValue;
            }
        }

        object IEnumerator.Current => this.Current;

        public void Dispose()
        {
        }

        public IEnumerator<PropertyValue> GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            return ++this.currentIndex < this.properties.Length;
        }

        public void Reset()
        {
            this.currentIndex = -1;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
