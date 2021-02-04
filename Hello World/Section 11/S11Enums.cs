using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMasterClass
{
    class S11Enums
    {
        enum Day { Mo, Tu, We, Th, Fr, Sa, Su };
        // You can manually assign indicies, changing the first offsets the rest.
        enum Month { Jan = 1, Feb, Mar, Apr, May, Jun, Jul = 12, Aug, Sep, Oct, Nov, Dec }; // Changing Jul to 12 offsets the rest, Aug = 13, Sep = 14 and so on.
        static public void Main()
        {
            Day fr = Day.Fr;
            Day su = Day.Su;

            Day a = Day.Fr;

            Console.WriteLine(fr == a);
            Console.WriteLine(Day.Mo); //An Enum's ToString function returns the identifier, not the integer value. 
            Console.WriteLine((int)Day.Mo); // You can cast it to an integer.
            Console.WriteLine(Month.Apr.GetType());
            Console.WriteLine(Month.Feb);
            Console.WriteLine((int)Month.Jul);
            Console.WriteLine((int)Month.Aug);
            return;
        }
    }
}
