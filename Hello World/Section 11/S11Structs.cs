using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMasterClass
{
    class S11Structs
    {
        // Classes always go on the heap, structs always go on the stack. Passed by value, not reference.
        public struct Game // : Cannot inherit from anything, but I think can use interfaces?
        {
            // Virtual and abstract are forbidden, goes hand in hand with no inheritance.
            public string name;
            public string developer;
            public double rating;
            public string releaseDate;

            // Cannot have a parameterless constructor
            //public Game() { }

            // Can have a parameterized constructor
            public Game(string name, string developer, double rating, string releaseDate)
            {
                this.name = name;
                this.developer = developer;
                this.rating = rating;
                this.releaseDate = releaseDate;
                return;
            }

            // Kinda makes C structs look lame by comparison.
            public void Display()
            {
                Console.WriteLine($"Game 1's name is: {name}");
                Console.WriteLine($"Game 1's was developed by: {developer}");
                Console.WriteLine($"Game 1's rating is: {rating}");
                Console.WriteLine($"Game 1's was released: {releaseDate}");
            }
        }
        
        static public void Main()
        {
            Game game1;
            game1.name = "Pokemon GO";
            game1.developer = "Niantic";
            // You cannot access a struct until all values are assigned.
            // game1.Display(); // Throws error
            game1.rating = 3.5;
            game1.releaseDate = "01.07.2016";

            game1.Display();

            return;
        }
    }
}
