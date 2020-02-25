using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterators
{
    public class IntegerIterator : Iterator
    {
        public override bool MoveNext()
        {
            bool hasNext = this.hasNext();
            if (hasNext)
                ++this.Current;
            return hasNext;
        }

        private bool hasNext()
        {
            return int.MaxValue == this.Current ? false : true;
        }

        public override void Reset()
        {
            this.Current = 0;
        }

        public override int Current { get; protected set; } = 0;
    }
}
