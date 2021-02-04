using System;
// For collections that can contain multiple types
using System.Collections;
// For collections that only contain 1 type
using System.Collections.Generic;

namespace CSMasterClass
{
    // Section 7: Arrays and Lists
    public class ArraysAndLists
    {
        public static void Lesson1()
        {
            int[] grades = new int[5];

            grades[0] = 20;
            grades[1] = 10;
            grades[2] = 18;
            grades[3] = 15;
            grades[4] = 5;

            Console.WriteLine($"Grades at index 0: {grades[0]}");

            string input = Console.ReadLine();
            try
            {
                grades[0] = int.Parse(input);
            }
            catch (Exception)
            {
                grades[0] = 0;
            }
            Console.WriteLine($"Grades at index 0: {grades[0]}");

            int[] gradesOfMathStudentsA = { 20, 13, 12, 8, 8 };

            int[] gradesOfMathStudentsB = new int[] { 15, 20, 3, 17, 18, 15 };

            Console.WriteLine($"Length of gradesOfMathStudentsA: {gradesOfMathStudentsA.Length}");

            return;
        }

        public static void Lesson2()
        {
            int[] nums = new int[10];

            for (int i = 0; i < 10; i++)
            {
                nums[i] = i + 10;
            }

            for (int j = 0; j < nums.Length; j++)
            {
                Console.WriteLine($"Element[{j}] = {nums[j]}");
            }

            Console.WriteLine("---------\n");

            int counter = 0;
            foreach (int k in nums)
            {
                Console.WriteLine($"Element[{counter}] = {k}");
                counter++;
            }

            string[] BestFriends = { "Jennifer", "Scott", "Mika", "Lilly", "Vara" };
            foreach (string friend in BestFriends)
            {
                Console.WriteLine($"Greetings, {friend}!");
            }

            return;
        }

        public static void Challenge1()
        {
            Console.Write("Please enter a value, anything will do: ");
            string Input1 = Console.ReadLine();
            bool Retry = true;
            int Selection = 0;
            string Input2 = null;
            do
            {
                Console.Write("Select the data type to validate the input you have entered\n" +
                "Press 1 for String\n" +
                "Press 2 for Integer\n" +
                "Press 3 for Boolean\n" +
                "> ");
                Input2 = Console.ReadLine();

                if (!int.TryParse(Input2, out Selection))
                {
                    Console.WriteLine("I couldn't recognize that selection, please try again or enter -1 to exit.\n");
                    Retry = true;
                }
                else Retry = false;
            } while (Retry);
            Console.WriteLine($"You entered a value: {Input1}");
            switch (Selection)
            {
                case 1:
                    bool IsValid = true;
                    foreach (char letter in Input1)
                    {
                        if (!char.IsLetter(letter))
                        {
                            IsValid = false;
                            break;
                        }
                    }
                    if (IsValid) Console.WriteLine("It is a valid String");
                    else Console.WriteLine("It is an invalid String");
                    break;
                case 2:
                    try
                    {
                        int Number = int.Parse(Input1);
                        Console.WriteLine("It is a valid Integer");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("It is an invalid Integer");
                    }
                    break;
                case 3:
                    try
                    {
                        bool Number = bool.Parse(Input1);
                        Console.WriteLine("It is a valid Boolean");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("It is an invalid Boolean");
                    }
                    break;
                case -1:
                    return;
                default:
                    Console.WriteLine("I couldn't understand your selection, exiting...");
                    break;
            }
        }

        public static void MultiDimentionalArrays()
        {
            // declaring 2D array
            string[,] matrix;

            // 3D array
            int[,,] threeD;

            // two diemensional array
            int[,] array2D = new int[,]
            {
                {1,2,3 }, // row 0
                {4,5,6 }, // row 1
                {7,8,9 }  // row 2
            };

            Console.WriteLine($"Central value is {array2D[1, 1]}");

            string[,,] array3D = new string[,,]
            {
                {
                    {"000", "001" },
                    {"010", "011" },
                    {"Hi there", "What's up" }
                },
                {
                    {"100", "101"},
                    {"110", "111" },
                    {"Another one", "Last entry" }
                }
            };

            int a1 = 0, a2 = 2, a3 = 1;
            Console.WriteLine($"Value of array3D[{a1},{a2},{a3}] = {array3D[a1, a2, a3]}");

            string[,] array2DString = new string[3, 2]
            {
                {"one","two" },
                {"three", "four" },
                {"five", "six" }
            };

            array2DString[1, 1] = "Chicken";
            Console.WriteLine(array2DString[1, 1]);

            int dimensions = array2DString.Rank;
            Console.WriteLine($"Dimensions = {dimensions}");

            int[,] array2D2 = { { 1, 2 }, { 3, 4 } }; // This only works for intializing, you cannot use this syntax to assign a new array to an existing variable.


            return;
        }

        // A Jagged Array is an array that stores arrays. 
        public static void JaggedArray()
        {
            // declare jagged array
            int[][] JaggedArray = new int[3][];

            JaggedArray[0] = new int[5];
            JaggedArray[1] = new int[3];
            JaggedArray[2] = new int[2];

            JaggedArray[0] = new int[] { 2, 3, 5, 7, 11 };
            JaggedArray[1] = new int[] { 1, 2, 3 };
            JaggedArray[2] = new int[] { 13, 21 };

            // alternative initialization
            int[][] JaggedArray2 = new int[][]
            {
                new int[] { 2, 3, 5, 7, 11 },
                new int[] { 1, 2, 3 },
                new int[] { 13, 21 }
            };

            Console.WriteLine($"The value in the middle of the first entry is {JaggedArray2[0][2]}");

            for (int i = 0; i < JaggedArray2.Length; i++)
            {
                Console.Write($"Element {i}: [");
                for (int j = 0; j < JaggedArray2[i].Length; j++)
                {
                    Console.Write(JaggedArray2[i][j]);
                    if (j < JaggedArray2[i].Length - 1) Console.Write(",");
                }
                Console.WriteLine("]");
            }

            return;
        }

        public static void JaggedArrayChallenge()
        {
            string[][] Friends = new string[3][];
            string[] Taylor = { "Adam", "Becca" };
            string[] Dan = { "Laurie", "Ben" };
            string[] TJ = { "Mel", "Molly" };
            Friends[0] = Taylor;
            Friends[1] = Dan;
            Friends[2] = TJ;

            Console.WriteLine($"Hi {Friends[0][0]}, I would like to introduce {Friends[1][0]} to you.");
            Console.WriteLine($"Hi {Friends[0][1]}, I would like to introduce {Friends[2][0]} to you.");
            Console.WriteLine($"Hi {Friends[0][1]}, I would like to introduce {Friends[2][1]} to you.");
        }

        public static void ArraysAsParameters()
        {
            int[] StudentGrades = new int[] { 15, 13, 8, 12, 6, 16 };
            double AverageResult = GetAverage(StudentGrades);

            foreach (int grade in StudentGrades)
            {
                Console.WriteLine($"{grade}");
            }

            Console.WriteLine($"The average is: {AverageResult}");

            int[] Happiness = new int[] { 0, 5, 3, 2, 4 };
            SunIsShining(Happiness);
            int Counter = 0;
            foreach (int Score in Happiness)
            {
                Console.WriteLine($"Happiness score {Counter} is: {Score}");
                Counter++;
            }

            return;
        }

        private static double GetAverage(int[] gradesArray)
        {
            int size = gradesArray.Length;
            double Average;
            int sum = 0;

            for (int i = 0; i < size; i++)
            {
                sum += gradesArray[i];
            }
            Average = (double)sum / size;
            return Average;
        }

        private static void SunIsShining(int[] HapArray)
        {
            for (int i = 0; i < HapArray.Length; i++)
            {
                HapArray[i] += 2;
            }

            return;
        }

        public static void ArrayListLesson()
        {
            // declaring an ArrayList with undefined amount of objects
            ArrayList myArrayList = new ArrayList();
            // declaring an ArrayList with a defined amount of objects
            ArrayList myArrayList2 = new ArrayList(100);

            myArrayList.Add(25);
            myArrayList.Add("Hello");
            myArrayList.Add(13.37);
            myArrayList.Add(13);
            myArrayList.Add(128);
            myArrayList.Add(25.3);

            // delete element with specific value from the arraylist
            myArrayList.Remove(13);

            // delete element at specific position
            myArrayList.RemoveAt(0);

            Console.WriteLine(myArrayList.Count);

            double sum = 0;

            foreach (object obj in myArrayList)
            {
                if (obj is int)
                {
                    sum += Convert.ToDouble(obj);
                }
                else if (obj is double)
                {
                    sum += (double)obj;
                }
                else if (obj is string)
                {
                    Console.WriteLine(obj);
                }
            }

            Console.WriteLine(sum);
            return;
        }

        public static void ListsCompared()
        {
            // Immutable - limited to one type
            int[] scores = new int[] { 99, 96, 87, 76 };

            List<int> list = new List<int> { 1, 2, 3, 4, 5 };
            list.Add(0);
            list.Add(32);

            foreach (int i in list)
            {
                Console.WriteLine(i);
            }

            list.Sort();

            foreach (int i in list)
            {
                Console.WriteLine(i);
            }

            list.RemoveRange(2, 2);

            foreach (int i in list)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine(list.Contains(4));

            int index = list.FindIndex(x => x == 4);
            Console.WriteLine(list[index]);
            list.RemoveAt(index);

            list.ForEach(i => Console.WriteLine(i));
            Console.WriteLine("----");

            ArrayList arrayList = new ArrayList();
            arrayList.Add(1);
            arrayList.Add("two");
            arrayList.Add("3");
            arrayList.Add(new Number() { n = 4 });

            foreach (object o in arrayList)
            {
                Console.WriteLine(o);
            }

            return;
        }
        public class Number
        {
            public int n { get; set; }

            public override string ToString()
            {
                return n.ToString();
            }
        }
    }
}

   

