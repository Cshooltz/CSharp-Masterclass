using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMasterClass
{
    class S11Math
    {

        static public void Main()
        {
            Console.WriteLine("Ceiling: " + Math.Ceiling(15.3));
            Console.WriteLine("Floor: " + Math.Floor(15.3));

            int num1 = 13, num2 = 9;
            Console.WriteLine($"Lower of num1 {num1} and num2 {num2} is {Math.Min(num1, num2)}");
            Console.WriteLine($"Higher of num1 {num1} and num2 {num2} is {Math.Max(num1, num2)}");

            Console.WriteLine($"3 to the power of 5 is {Math.Pow(3, 5)}");
            Console.WriteLine($"Pi is: {Math.PI}");

            Console.WriteLine($"The square root of 25 is {Math.Sqrt(25)}");
            Console.WriteLine($"Always positive is {Math.Abs(-25)}");

            Console.WriteLine($"cos of 1 is {Math.Cos(1)}");

            return;
        }
    }

    class S11Random
    {
        static public void Main()
        {
            Random dice = new Random();
            int numEyes;

            for(int i = 0; i < 10; i++)
            {
                numEyes = dice.Next(1, 7);
                Console.WriteLine(numEyes);
            }

        }

        static public void EightBall()
        {
            Random RandGen = new Random();
            Console.Write("Enter a question: ");
            Console.ReadLine();
            int Selection = RandGen.Next(1, 4);
            switch (Selection)
            {
                case 1:
                    Console.WriteLine("Yes");
                    break;
                case 2:
                    Console.WriteLine("No");
                    break;
                case 3:
                    Console.WriteLine("Maybe");
                    break;
                default:
                    Console.WriteLine("Response generator malfunction");
                    break;
            }

            return;
        }

        static public void EightBallTest()
        {
            Random RandGen = new Random();
            for (int i = 0; i < 11; i++)
            {
                int Selection = RandGen.Next(1, 4);
                switch (Selection)
                {
                    case 1:
                        Console.WriteLine("Yes");
                        break;
                    case 2:
                        Console.WriteLine("No");
                        break;
                    case 3:
                        Console.WriteLine("Maybe");
                        break;
                    default:
                        Console.WriteLine("Response generator malfunction");
                        break;
                }
            }
            return;
        }
    }
}
