using System;
using System.Numerics;


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
        private static bool DEBUG = true;

        public static void Main(String[] args) {
            BigInteger num = (BigInteger)double.MaxValue;

            Console.WriteLine($"Sine({num}) = {Sine(num)}\n");
            Console.WriteLine($"Math.Sin({num}) = {Math.Sin(Double.Parse(num.ToString()))}\n\n");

            num *= 2;
            Console.WriteLine($"Sine({num}) = {Sine(num)}\n");
            Console.WriteLine($"Math.Sin({num}) = {Math.Sin(Double.Parse(num.ToString()))}");
        }

        private static double Sine(BigInteger radians) {
            double sine = 0;

            if (radians > (BigInteger)double.MaxValue / 2) { // if radians are larger than the max value of double 1.7e+308
                BigInteger divisions = 0;
                double remainder = 0.0;
                double[] sinArr = new double[2];
                double[] cosArr = new double[2]; 

                while (radians > (BigInteger)double.MaxValue / 2) { // make the radians less than 0.8e+308
                    remainder = (remainder * 0.5);
                    if (!radians.IsEven)
                        remainder += 0.5;
                    radians /= 2;
                    divisions++;
                }

                double radiansAsDouble = Double.Parse(radians.ToString()) + remainder; // convert BigInt to double
                sinArr[0] = Math.Sin(radiansAsDouble); // calculate Sine
                cosArr[0] = Math.Cos(radiansAsDouble); // calculate Cose

                while (divisions > 0) { // use double-angle Sine formula to work back up to original radians
                    sinArr[1] = 2 * sinArr[0] * cosArr[0]; // Sin(2*theta) = 2*Sin(theta)*cos(theta)
                    cosArr[1] = 1 - (2 * sinArr[0] * sinArr[0]); // Cos(2*theta) = 1 - 2*Sin^2(theta)

                    sinArr[0] = sinArr[1];
                    cosArr[0] = cosArr[1];
                    divisions--;
                }

                sine = sinArr[1]; // final value of Sin(radians)
            }
            else { // convert the BigInt to double and use Math.Sin()
                double value = Double.Parse(radians.ToString());
                sine = Math.Sin(value);
            }

            return sine;
        }      
    }
}
