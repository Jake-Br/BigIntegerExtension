using System;


/* In lecture 4, we had a very illuminating discussion on number representation
 * in binary:  unsigned, sign-magnitude, 1's complement and 2's complement.
 * We realized that atomic types (int, long) have finite precision.
 * Modern languages (like C#) support arbitrary precision arithmetic, through 
 * the use of lazy evaluation.
 * 
 * Purpose of this design:  Implement arbitrary precision INTEGER arithmetic.  
 * That is, provide support for the set of integers:
 * 
 * Z = {...,-3,-2,-1,0,1,2,3,...} U (-infinity,infinity) U NaN
 * 
 * So, our program will be able to do this:
 * infinity + 3 = infinity
 * infinity + infinity = infinity
 * infinity - infinity = undefined
 * 1/0 = infinity (think about 1/x graph, as x->0)
 * -1/0 = -infinity
 * 0/0 = NaN (as represented in computing systems)
 * 
 * But first, we NEED to pick our data structure!  Remember:  
 * show me your data and I will show the program.
 * Data structures we know are:
 * List,
 * Stack,
 * Queue,
 * Linked List,
 * Dictionary,
 * HashSet
 * 
 * To bound our design even further, we will utilize the already
 * existing BigInteger struct in C# .NET framework
 * 
 */

namespace BigIntegerExtension {
    class BigIntegerExtension {
        static void Main(string[] args) {
            Console.WriteLine("Arbitrary Precision Integer Arithmetic with " +
            	"Support for (-infinity,infinity) and NaN");
        }
    }
}
