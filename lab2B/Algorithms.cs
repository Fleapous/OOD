using System;
using Vectors2.Vectors;

namespace Vectors2
{
    public static class Algorithms
    {
        // public static baseIterator Normalize(baseIterator iterator)
        // {
        //     baseIterator _itertater;
        //     iterator.First();
        //     while (iterator.Next())
        //     {
        //         _itertater.Current.value = 1;
        //     }
        //
        //     return iterator;
        // }

        // public static /* returned type */ ReversedHadamardProduct( /* arguments */)
        // {
        //     throw new NotImplementedException();
        // }

        public static void PrintVector(baseIterator iterator)
        {
            while (iterator.Next())
            {
                Console.Write(iterator.Current);
            }
           
        }
    }
}
