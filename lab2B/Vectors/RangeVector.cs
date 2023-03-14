namespace Vectors2.Vectors
{
    public class RangeVector
    {
        private int First { get; }

        public int Last { get; }

        public RangeVector(int first, int last)
        {
            First = first;
            Last = last;
        }
    }
}
