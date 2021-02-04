using System;
// For collections that can contain multiple types
// For collections that only contain 1 type

namespace CSMasterClass
{
    // Challenge Loops 1
    public class LoopChallenge1
    {
        private const int SCOREMAX = 20, SCOREMIN = 0;
        private int Count = 0;
        private int ScoreSum = 0;
        private float Average = 0f;
        public void Run()
        {
            Console.WriteLine("Please enter the scores you want to average one at a time hitting enter between them.");
            bool Continue = true;
            while (Continue)
            {
                Console.Write("Enter number {0}: ", Count + 1);
                int input;
                if (!Int32.TryParse(Console.ReadLine().Trim(), out input))
                {
                    Console.WriteLine("Invalid input, try again.");
                    continue;
                }
                else if (input == -1)
                {
                    Continue = false;
                }
                else if (input > SCOREMAX || input < SCOREMIN)
                {
                    Console.WriteLine("Invalid input, please only enter a score between {0} and {1}.", SCOREMIN, SCOREMAX);
                    continue;
                }
                else
                {
                    Count++;
                    ScoreSum += input;
                    Console.WriteLine("Current sum = {0}", ScoreSum);
                }
            }
            if (Count != 0) Average = (float)ScoreSum / (float)Count;
            Console.WriteLine("Your average score is: {0}", Average);
            return;
        }

        public void LoopRun()
        {
            bool Continue = false;
            do
            {
                Reset();
                Run();
                Console.Write("\nRun again (Y/N)? ");
                string input = Console.ReadLine().Trim();
                input = input.ToLower();
                if (input.Contains('y')) Continue = true;
                else Continue = false;
            } while (Continue);
        }

        public int CountValue => Count;
        public int ScoreSumValue => ScoreSum;
        public float AverageValue => Average;

        public void Reset()
        {
            Count = 0;
            ScoreSum = 0;
            Average = 0;
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

