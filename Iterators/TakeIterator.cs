using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterators
{
    public class TakeIterator : Iterator
    {
        private int saveTake;
        private int take;
        private Iterator iterator;
        public TakeIterator(int take, Iterator iterator)
        {
            this.iterator = iterator;
            this.take = this.saveTake = take + 1;
        }

        public override bool MoveNext()
        {
            this.take -= 1;
            return this.take > 0 && this.iterator.MoveNext();
        }

        public override void Reset()
        {
            this.iterator.Reset();
            this.take = this.saveTake;
        }

        public override int Current { get { return this.iterator.Current; } protected set { } }
    }
}
