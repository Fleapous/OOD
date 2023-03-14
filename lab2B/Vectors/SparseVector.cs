namespace Vectors2.Vectors
{
    public class SparseVector
    {
        public int Size { get; }
        public (int, int)[] Vector { get; }

        public SparseVector(int size, (int, int)[] vector)
        {
            Size = size;
            Vector = vector;
        }
    }
}
