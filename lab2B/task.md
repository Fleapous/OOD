# Vectors 

Two different different representations of vectors are given.
The task is to write such a code, that algorithms will be written only once and will work for any vector representation.
Code must be extensible - adding any new vector representation shouldn't cause any changes in algorithms code.
Solution should be presented on the example of two algorithms.
You should also fill PrintVector method, to print the given vector, the result of Normalize or the result of ReversedDotProduct.

## Vectors representations

### Sparse vector (SparseVector)

Vector stored in an array of tuples. There is only stored information about non-zero values.
Tuple template - (element_value, element_position).
Example - [0, 0, 2, 0, 0, 0, 4, 0, 2] - [(2, 2), (4, 6), (2, 8)]

### Range vector (RangeVector)

The vector is stored in a form of first and last elements values. The vector elements are the next integers, staring from first number, and finishing on the last one.
If the the last value is less than the first, the next numbers should be in descending order.
Example 1 - [1, 2, 3, 4] - (1, 4)
Example 2 - [4, 3, 2, 1] - (4, 1)

## Algorithms

### Normalized vector (Normalize)

Returns normalized vector.

### Hadamard product of two vectors (ReversedHadamardProduct)

Returns Hadamard product (element-by-element multiplication) of vectors, but second vector should be applied in reversed order.
It is not allowed to reverse second vector in the algorithm.

**Required memory complexity for the algorithm - O(1)**

## What is allowed

Extending existing classes, adding new classes and interfaces, implementing algorithms.

## What is not allowed

Modifying existing properties and methods in given classes, adding different representations of collections stored in classes, using yield keyword.
