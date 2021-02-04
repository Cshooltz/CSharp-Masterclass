using System;
// For collections that can contain multiple types
// For collections that only contain 1 type

namespace CSMasterClass
{
    // Section 5: Loops
    public class LoopExamples
    {
        public void Run()
        {
            
            return;
        }

        static public void ForLoops()
        {
            for(int counter = 0; counter <= 50; counter+=1)
            {
                if (counter % 2 != 0) Console.WriteLine(counter);
            }
            return;
        }

        static public void DoWhileLoop()
        {
            int counter = 0;
            int lengthOfText = 0;
            string wholeText = "";
            do
            {
                Console.WriteLine("Please enter the name of a frind:");
                string nameOfAFriend = Console.ReadLine();
                int currentLength = nameOfAFriend.Length;
                lengthOfText += currentLength;
                wholeText += nameOfAFriend;
            } while (lengthOfText < 20);
            Console.WriteLine("Thanks, that was enough! " + wholeText);
        }

        static public void WhileLoop()
        {
            int counter = 0;
            while(counter < 100)
            {
                Console.Write("Press enter to count... ");
                string next = Console.ReadLine();
                if (next.Length == 0)
                {
                    counter++;
                    Console.WriteLine("Count = {0}", counter);
                }
                else
                {
                    break;
                }
            }

            return;
        }

        static public void BreakAndContinue()
        {
            for(int counter = 0; counter < 10; counter++)
            {
                if(counter % 2 == 0)
                {
                    Console.WriteLine("We skip even numbers!");
                    continue;
                }
                Console.WriteLine(counter);
            }
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

