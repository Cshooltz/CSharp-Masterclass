using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMasterClass
{
    class S11Nullables
    {
        static public void Main()
        {
            // The nullable data type
            //Nullable<Int32> someInt = null;

            int? num1 = null;
            int? num2 = 1337;
            int num5;// Cannot use this one when not initialized.

            double? num3 = new Double?();
            double? num4 = 3.14157;

            bool? boolval = new bool?();

            Console.WriteLine($"Our nullable numbers are: {num1}, {num2}, {num3}, {num4}");
            Console.WriteLine($"The nullable boolean value is: {boolval}");

            bool? isMale = null;
            if(isMale == true)
            {
                Console.WriteLine("User is male");
            }
            else if (isMale == false)
            {
                Console.WriteLine("User is female");
            }
            else
            {
                Console.WriteLine("No gender chosen");
            }

            double? num6 = 13.1;
            double? num7 = null;
            double num8;

            if (num6 == null)
            {
                num8 = 0.0;
            }
            else
            {
                num8 = (double)num6;
            }

            Console.WriteLine($"Value of num8 is {num8}");

            // Null coalescing operator ??
            num8 = num6 ?? 8.53;
            Console.WriteLine($"Value of num8 is {num8}");
            num8 = num7 ?? 8.53;
            Console.WriteLine($"Value of num8 is {num8}");

            // There is also the null forgiveness operator: num7! and that tells the compiler that the potentially null value is not expected to be null
            // The null forgiveness operator is really for the new strict null tracking mode for C# that I don't remember how to activate.

            return;
        }
    }
}
