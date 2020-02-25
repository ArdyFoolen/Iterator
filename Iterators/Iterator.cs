using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterators
{
    public abstract class Iterator : IEnumerator<int>, IEnumerable<int>
    {
        //protected abstract bool HasNext { get; }
        public abstract int Current { get; protected set; }

        object IEnumerator.Current { get { return Current; } }

        public void Dispose()
        {
        }

        public IEnumerator<int> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public abstract bool MoveNext();
        public abstract void Reset();
    }
}
