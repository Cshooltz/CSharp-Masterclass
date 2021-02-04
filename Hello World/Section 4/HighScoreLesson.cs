using System;
// For collections that can contain multiple types
// For collections that only contain 1 type

namespace CSMasterClass
{
    public class HighScoreLesson
    {
        // This class is intended to be instanced. 
        // Variables (fields) here
        int HighScore = 100961;
        String HighScorePlayer = "Lilly Ferrowleaf";

        public void Run()
        {
            Console.Write("Enter your player name: ");
            string Name = Console.ReadLine().Trim();
            Console.Write("Enter your score: ");
            int ScoreInput;
            Int32.TryParse(Console.ReadLine().Trim(), out ScoreInput);
            CheckScore(ScoreInput, Name);
            return;
        }

        // Methods here
        private void CheckScore(int score, string playerName)
        {
            if (score > HighScore)
            {
                Console.WriteLine("New high score is {0}!", score);
                Console.WriteLine("New high score holder is " + playerName);
                HighScore = score;
                HighScorePlayer = playerName;
            }
            else
            {
                Console.WriteLine("The old high score of {0} could not be broken and is still held by {1}", HighScore, HighScorePlayer);
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

