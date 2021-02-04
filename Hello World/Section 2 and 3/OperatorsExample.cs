using System;
// For collections that can contain multiple types
// For collections that only contain 1 type

namespace CSMasterClass
{
    // Covers almost all operators available in C#
    public static class OperatorsExample
    {
        static internal void Run()
        {
            int num1 = 5, num2 = 3, num3;

            // unary operators
            num3 = -num1; // negation
            Console.WriteLine("num3 is {0}", num3);

            bool isSunny = true;
            Console.WriteLine("Is it sunny? {0}", !isSunny);

            // increment operators
            int num = 0;
            num++;
            Console.WriteLine("num is {0}", num);
            Console.WriteLine("num is {0}", num++);
            Console.WriteLine("num is {0}", num);
            // pre increment
            Console.WriteLine("num is {0}", ++num);

            // decrement operator
            num--;
            Console.WriteLine("num is {0}", num);
            Console.WriteLine("num is {0}", num--);
            // pre decrement
            Console.WriteLine("num is {0}", --num);

            int result;
            result = num1 + num2;
            Console.WriteLine("result of num1 + num2 is {0}", result);
            result = num1 - num2;
            Console.WriteLine("result of num1 - num2 is {0}", result);
            result = num1 / num2;
            Console.WriteLine("result of num1 / num2 is {0}", result);
            result = num1 * num2;
            Console.WriteLine("result of num1 * num2 is {0}", result);
            result = num1 % num2;
            Console.WriteLine("result of num1 % num2 is {0}", result);

            // relational and type operators
            bool isLower;
            isLower = num1 < num2;
            Console.WriteLine("Result of num1 < nume2 is {0}", isLower);

            // equality operator
            bool isEqual;
            isEqual = num1 == num2;
            Console.WriteLine("Result of num1 == nume2 is {0}", isEqual);

            isEqual = num1 != num2;
            Console.WriteLine("Result of num1 != nume2 is {0}", isEqual);

            // conditional operators
            bool isLowerAndSunny;
            isLowerAndSunny = isLower && isSunny;
            Console.WriteLine("Result of isLower && isSunny is {0}", isLowerAndSunny);

            bool isLowerOrSunny;
            isLowerOrSunny = isLower || isSunny;
            Console.WriteLine("Result of isLower || isSunny is {0}", isLowerOrSunny);

            return;
        }
    }

    // Section 9: Inheritance
    // This is where we get into actual classes, so I am not sure how I will organize my code for this one.
    // See Company.cs, Inheritance.cs, and Interfaces.cs

    // Section 10: Polymorphism
    // See PolyChallenge.cs, FileIO.cs

    // Section 11: Advanced C# Topics
    // See: S11Enums.cs, S11Math.cs

    // Section 12: Events and Delegates
}

