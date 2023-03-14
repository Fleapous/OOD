using System;
using Vectors2.Vectors;

namespace Vectors2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sparseVector = new SparseVector(10, new (int, int)[] { (2, 2), (4, 6), (2, 8) });

            var rangeVector = new RangeVector(10, 1);

            Console.WriteLine("Sparse Vector");
            Algorithms.PrintVector(new SparseVectorIterator(sparseVector)); // sparseVector

            // Console.WriteLine("Normalized vector");
            // Algorithms.PrintVector(Algorithms.Normalize(new  SparseVectorIterator(sparseVector))); // sparseVector

            Console.WriteLine("-------------------------------------------------");
            
            Console.WriteLine("Range Vector");
            Algorithms.PrintVector(new RangeVectorIterator(rangeVector)); // rangeVector
            
            // Console.WriteLine("Normalized vector");
            // Algorithms.PrintVector(Algorithms.Normalize(new RangeVectorIterator(rangeVector))); // rangeVector
            
            // Console.WriteLine("-------------------------------------------------");
            //
            // Console.WriteLine("Reversed Hadamard Product: sparseVector * rangeVector");
            // Algorithms.PrintVector(Algorithms.ReversedHadamardProduct(/* arguments */));
            //
            // Console.WriteLine("Reversed Hadamard Product: rangeVector * sparseVector");
            // Algorithms.PrintVector(Algorithms.ReversedHadamardProduct(/* arguments */));
        }
    }
}
