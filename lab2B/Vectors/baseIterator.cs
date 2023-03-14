using System.Collections;
using System.Collections.Generic;

namespace Vectors2.Vectors
{
    public abstract class baseIterator
    {

        public abstract bool Next();
        public abstract void First();

        public abstract (int value, int pos) Current { get; }
    }

    public class RangeVectorIterator : baseIterator
    {
        private readonly RangeVector rangevec;
        public int last, first = 0;

        public RangeVectorIterator(RangeVector _rangeVector)
        {
            rangevec = _rangeVector;
            last = _rangeVector.Last;
        }
        
        public override bool Next()
        {
            ++first;
            if (!(first > last))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void First()
        {
            first = 0;
        }

        public override (int value, int pos) Current => (first, first);
           
            
            
        
        
    }

    public class SparseVectorIterator : baseIterator
    {
        private readonly SparseVector sparcevec;
        public int index = 0;
        public int size = 0;
        public (int value, int size) vec;

        public SparseVectorIterator(SparseVector _sparceVctor)
        {
            sparcevec = _sparceVctor;
            size = _sparceVctor.Size;
        }
        
        public override bool Next()
        {
            ++index;
            vec = Current;
            if (!(index > size))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void First()
        {
            index = 0;
        }

        public override (int value, int pos) Current => sparcevec.Vector[index];
            
        
    }
}