using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMasterClass
{
    class S15LinqDemo
    {
        public static void Main()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            OddNumbers(numbers);
            return;
        }

        static void OddNumbers(int[] nums)
        {
            Console.WriteLine("Odd Numbers: ");

            // Use Linq to create a new array of only the odd numbers.
            IEnumerable<int> oddNumbers = from number in nums where number % 2 != 0 select number;

            Console.WriteLine(oddNumbers);

            foreach(int i in oddNumbers)
            {
                Console.WriteLine(i);
            }
        }
    }
}
