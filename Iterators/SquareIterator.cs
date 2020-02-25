using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterators
{
    public class SquareIterator : Iterator
    {
        private Iterator iterator;
        public SquareIterator(Iterator iterator)
        {
            this.iterator = iterator;
            this.Current = this.iterator.Current;
        }

        public override bool MoveNext()
        {
            return this.iterator.MoveNext();
        }

        public override int Current { get { return this.iterator.Current * this.iterator.Current; } protected set { } }

        public override void Reset()
        {
            this.iterator.Reset();
        }
    }
}
