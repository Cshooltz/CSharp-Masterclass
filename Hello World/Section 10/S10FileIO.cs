using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSMasterClass
{
    // Section 10, lesson 113, reading from text files.
    class S10FileIO
    {
        static public void Main()
        {
            // Example 1 - reading text
            // I haven't seen the '@' used before. It looks like it removes the need to escape the '\' characters in the path. Useful!
            string text = System.IO.File.ReadAllText(@"C:\Users\NO3fu\sync.com\Sync\Documents\Software Projects\C# Masterclass\Hello World\Hello World\MyData.txt");

            Console.WriteLine(text);

            // Example 2 - reading text line by line
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\NO3fu\sync.com\Sync\Documents\Software Projects\C# Masterclass\Hello World\Hello World\MyData.txt");

            Console.WriteLine($"Contents of MyData.txt = ");
            foreach(string line in lines)
            {
                Console.WriteLine("\t" + line);
            }

            // Writing to files
            // From lines
            string[] writeLines = { "first line", "second line", "third line" };
            System.IO.File.WriteAllLines(@"C:\Users\NO3fu\sync.com\Sync\Documents\Software Projects\C# Masterclass\Hello World\Hello World\Written Data.txt", writeLines);

            string[] scoreLines = new string[] { "Score 1: 34", "Score 2: 18", "Score 3: 1"};
            System.IO.File.WriteAllLines(@"C:\Users\NO3fu\sync.com\Sync\Documents\Software Projects\C# Masterclass\Hello World\Hello World\Scores Data.txt", scoreLines);

            /*
            // From whole text
            Console.Write("Please enter a file name: ");
            string fileName = Console.ReadLine();
            Console.WriteLine("Enter some text:");
            string input = Console.ReadLine();
            

            File.WriteAllText(@"C:\Users\NO3fu\sync.com\Sync\Documents\Software Projects\C# Masterclass\Hello World\Hello World\" + fileName + ".txt", input);
            */

            // From stream writer
            // The 'using' operator handles opening and closing the stream automatically
            using (StreamWriter file = new StreamWriter(@"C:\Users\NO3fu\sync.com\Sync\Documents\Software Projects\C# Masterclass\Hello World\Hello World\StreamWriter.txt"))
            {
                foreach(string line in writeLines)
                {
                    if (line.Contains("third") || line.Contains("second"))
                    {
                        file.WriteLine(line);
                    }
                }
            }

            using (StreamWriter file = new StreamWriter(@"C:\Users\NO3fu\sync.com\Sync\Documents\Software Projects\C# Masterclass\Hello World\Hello World\StreamWriter.txt", true))
            {
                file.WriteLine("Additional line");
            }

            return;
        }
    }
}
