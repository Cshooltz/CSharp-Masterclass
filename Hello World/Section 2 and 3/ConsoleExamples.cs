using System;
// For collections that can contain multiple types
// For collections that only contain 1 type

namespace CSMasterClass
{
    // Sections 2 and 3
    // Covers types, the Console class, user input, try and catch
    public static class ConsoleExamples
    {
        static public void InputOutput()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Enter a string and press enter: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            string readInput = Console.ReadLine();
            Console.WriteLine("You have entered: {0}", readInput);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Enter a string and press enter: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            int asciiValue = Console.Read();
            Console.WriteLine("ASCII value is: {0}", asciiValue);
            string asciiString = asciiValue.ToString();
            Console.WriteLine(asciiString);
            bool sunIsShining = false;
            string myBoolString = sunIsShining.ToString();
            Console.WriteLine(myBoolString);

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
            return;
        }

        static public void ParsingStrings()
        {
            // Parsing Strings
            string myString = "15";
            string mySecondString = "13";
            int num1 = Int32.Parse(myString);
            int num2 = Int32.Parse(mySecondString);
            int result = num1 + num2;

            Console.WriteLine(result);

            return;
        }

        static internal void StringChallenge1()
        {
            string myName;
            
            Console.Write("Please enter your name and press enter: ");
            myName = Console.ReadLine();
            Console.WriteLine("Challenge outputs:");
            Console.WriteLine(myName.ToUpper());
            Console.WriteLine(myName.ToLower());
            Console.WriteLine(myName.Trim());
            int nameLength = myName.Length;
            Console.WriteLine("nameLength: {0}", nameLength);
            int subStart = 1;
            int subEnd = 0;
            if (subEnd == 0 && subStart <= nameLength)
            {
                Console.WriteLine(myName.Substring(subStart));
            }
            else if(subStart >= 0 && subStart <= nameLength && subEnd <= nameLength + subStart)
            {
                Console.WriteLine(myName.Substring(subStart, subEnd));
            } 
            else
            {
                Console.WriteLine("Substring length exception!");
            }

            return;
        }

        static internal void StringChallenge2()
        {
            Console.Write("Enter string here: ");
            string userString = Console.ReadLine();
            Console.Write("Enter a character to search: ");
            char userChar = Console.ReadLine().Trim()[0];
            Console.WriteLine("Index of character {1} is {0}", userString.IndexOf(userChar), userChar);
            Console.WriteLine();

            Console.Write("Enter your first name: ");
            string firstName = Console.ReadLine().Trim();
            Console.Write("Enter your last name: ");
            string lastName = Console.ReadLine().Trim();
            string fullName = String.Concat(firstName, " ", lastName);
            Console.WriteLine("Your name is: " + fullName);

            return;
        }

        static internal void VariablesChallenge()
        {
            byte myByte = 255;
            sbyte mySByte = -128;
            int myInt = 21000000;
            uint myUInt = 4000000000;
            short myShort = 31000;
            ushort myUShort = 61000;
            long myLong = -198451269689987;
            ulong myULong = 654897543216549;
            float myFloat = 1.337f;
            double myDouble = 10071.33742424242;
            char myChar = 'z';
            bool myBool = true;
            string myString = "What up, doe?";
            decimal myDecimal = 1.2394848483928282839M;

            string controlText = "I control text";
            string numberText = "89";
            int textNumber = Int32.Parse(numberText);

            Console.WriteLine("Byte: {0}", myByte);
            Console.WriteLine("SByte: {0}", mySByte);
            Console.WriteLine("Int: {0}", myInt);
            Console.WriteLine("UInt: {0}", myUInt);
            Console.WriteLine("Short: {0}", myShort);
            Console.WriteLine("UShort: {0}", myUShort);
            Console.WriteLine("Long: {0}", myLong);
            Console.WriteLine("ULong: {0}", myULong);
            Console.WriteLine("Float: {0}", myFloat);
            Console.WriteLine("Double: {0}", myDouble);
            Console.WriteLine("Char: {0}", myChar);
            Console.WriteLine("Bool: {0}", myBool);
            Console.WriteLine("String: {0}", myString);
            Console.WriteLine("Decimal: {0}", myDecimal);
            Console.WriteLine("Control Text: {0}", controlText);
            Console.WriteLine("Parsed number: {0}", textNumber);
            return;
        }
    
        static internal void UserInputChallenge()
        {
            string input1, input2;
            double num1, num2;

            Console.WriteLine("Enter 2 numbers...");
            Console.Write("Number 1: ");
            input1 = Console.ReadLine().Trim();
            Console.Write("Number 2: ");
            input2 = Console.ReadLine().Trim();

            if (!Double.TryParse(input1, out num1)) Console.WriteLine("Error, input 1 was invalid. Please enter numeric characters 1-9 only.");
            if (!Double.TryParse(input2, out num2)) Console.WriteLine("Error, input 2 was invalid. Please enter numeric characters 1-9 only.");
            Console.WriteLine("\nThe sum of your numbers {1} & {2} is: {0}", num1 + num2, num1, num2);

            return;
        }

        static internal void UserInputChallengeTryCatch()
        {
            string input1, input2;
            double num1, num2;

            Console.WriteLine("Enter 2 numbers...");
            Console.Write("Number 1: ");
            input1 = Console.ReadLine().Trim();
            Console.Write("Number 2: ");
            input2 = Console.ReadLine().Trim();
            try
            {
                num1 = Double.Parse(input1);
                num2 = Double.Parse(input2);
                Console.WriteLine("\nThe sum of your numbers {1} & {2} is: {0}", num1 + num2, num1, num2);
            }
            catch (OverflowException)
            {
                Console.WriteLine("Error, the number you input is too large or too small for the Double number type.");
            }
            catch (Exception)
            {
                Console.WriteLine("Error, invalid input entered. Please enter numeric characters 1-9 only.");
            }
            finally
            {
                // This block will always run, regardless if an exception is raised or if not.
                //Console.WriteLine("Finally block.");
            }

            return;
        }
        static internal void DivideChallenge()
        {
            string input1, input2;
            double num1, num2;

            Console.WriteLine("Enter 2 numbers...");
            Console.Write("Number 1: ");
            input1 = Console.ReadLine().Trim();
            Console.Write("Number 2: ");
            input2 = Console.ReadLine().Trim();
            try
            {
                num1 = Double.Parse(input1);
                num2 = Double.Parse(input2);
                try
                {
                    // Fun fact, dividing by zero no longer raises an exception. It reports infinity or NaN and treats these as valid numbers.
                    Console.WriteLine("\nThe division of your numbers {1} & {2} is: {0}", num1 / num2, num1, num2);
                    // Actually, I think the exception is raised for integer types, not so much floating point types. 
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("\nThe division of your numbers {0} & {1} is: Undefined", num1, num2);
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine("Error, the number you input is too large or too small for the Double number type.");
            }
            catch (Exception)
            {
                Console.WriteLine("Error, invalid input entered. Please enter numeric characters 1-9 only.");
            }
            finally
            {
                // This block will always run, regardless if an exception is raised or if not.
                //Console.WriteLine("Finally block.");
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

