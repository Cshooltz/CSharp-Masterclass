using System;
// For collections that can contain multiple types
// For collections that only contain 1 type

namespace CSMasterClass
{
    // Section 4
    // If/else if/else statements
    public static class MakingDecisions
    {
        static internal void run()
        {
            return;
        }

        static internal void lesson1()
        {
            const int ComfortTemp = 20;
            int temperature = 10;

            Console.Write("What is the temperature outside (in Celsius)? ");
            // Skip using a string variable, but is less readable as a result
            if (Int32.TryParse(Console.ReadLine().Trim(), out temperature))
            {
                if (temperature < ComfortTemp)
                {
                    Console.WriteLine("Take a coat!");
                }
                else if (temperature == ComfortTemp)
                {
                    Console.WriteLine("It's {0} degrees C", ComfortTemp);
                }
                else if (temperature > ComfortTemp)
                {
                    Console.WriteLine("It is cozy and warm!");
                }
            } 
            else
            {
                Console.WriteLine("That doesn't look like a valid number, sorry!");
            }
            return;
        }

        static internal void lesson2()
        {
            bool isAdmin = false, isRegistered = true;
            string userName = "";
            Console.Write("Please enter your user name: ");
            userName = Console.ReadLine();

            if (isRegistered && userName != "" && userName.Equals("admin"))
            {
                Console.WriteLine("Hi there, registered user");

                Console.WriteLine("Hi there, " + userName);

                Console.WriteLine("Hi there, Admin");
            }

            if(isAdmin || isRegistered)
            {
                Console.WriteLine("You are logged in");
            }
        }

        static internal void Challenge1()
        {
            // This is effectively functional programming in C#
            
            string UserAdmin = "Admin";
            string? UserName = null;
            string AdminPass = "123abc";
            string? UserPass = null;
            bool selected = false;

            string? option = null;
            Console.Write("Welcome\nWould you like to register or login (enter 1 or 2)? ");
            option = Console.ReadLine().Trim();

            while (selected == false)
            {

                if (option.ToLower().Equals("exit"))
                {
                    return;
                }
                else if (!option.Equals("1") && !option.Equals("2"))
                {
                    selected = false;
                    Console.WriteLine("Sorry, your input is not one of the available options.");
                    Console.WriteLine("Please enter 1 to register, 2 to login, or \"exit\" to exit: ");
                    option = Console.ReadLine().Trim();
                }
                else
                {
                    selected = true;
                }
            }

            if (option.Equals("1"))
            {
                Register(out UserName, out UserPass);
                Console.WriteLine("Thank you for registering, you may now log in.");
                UserLogin();
            }
            else if (option.Equals("2"))
            {
                UserLogin();
            }
            
            return;

            // this could be implemented with a class and properties, which would probably be better
            bool Register(out string? userName, out string? password)
            {
                Console.WriteLine("You have selected to register.");
                Console.Write("Please enter your desired user name: ");
                userName = Console.ReadLine().Trim();
                Console.WriteLine("Your user name is: {0}", userName);
                Console.Write("Please enter your password: ");
                password = Console.ReadLine().Trim();
                Console.WriteLine("Your password is: {0}", password);
                return true;
            }

            bool UserLogin()
            {
                string? inputName = null, inputPass = null;
                Console.Write("Please enter your user name: ");
                inputName = Console.ReadLine().Trim();
                if (!inputName.Equals(UserAdmin) && !inputName.Equals(UserName))
                {
                    Console.WriteLine("Invalid user name, exiting...");
                    return false;
                }
                Console.Write("Please enter your password: ");
                inputPass = Console.ReadLine();
                if (!inputPass.Equals(AdminPass) && !inputPass.Equals(UserPass))
                {
                    Console.WriteLine("Password is incorrect, exiting...");
                    return false;
                }

                if (inputName.Equals(UserAdmin))
                {
                    Console.WriteLine("Welcome Administrator, you have been successfully logged in.");
                }
                else
                {
                    Console.WriteLine("Login successful! Thanks and have a nice day.");
                }
                return true;
            }
        }

        static internal void SwitchAndCase()
        {
            int age = 25;

            switch (age)
            {
                case 15:
                    Console.WriteLine("Too young to party in the club!");
                    break;
                case 25:
                    Console.WriteLine("Good to go!");
                    break;
                default:
                    Console.WriteLine("How old are you then?");
                    break;
            }

            if (age == 15) Console.WriteLine("Too young to party in the club!");
            else if (age == 25) Console.WriteLine("Good to go!");
            else Console.WriteLine("How old are you then?");

            string username = "Collin";

            switch (username)
            {
                case "Collin":
                    Console.WriteLine("Username is Collin");
                    break;
                case "root":
                    Console.WriteLine("Username is root");
                    break;
                default:
                    Console.WriteLine("Username is unknown");
                    break;
            }
        }

        static internal void TernaryOperator()
        {
            int Temperature = -5;
            string StateOfMatter;

            StateOfMatter = Temperature < 0 ? "solid" : Temperature < 100 ? "liquid" : "gas";
            Console.WriteLine("State of matter is {0}", StateOfMatter);

            Temperature = 30;
            StateOfMatter = Temperature < 0 ? "solid" : Temperature < 100 ? "liquid" : "gas";
            Console.WriteLine("State of matter is {0}", StateOfMatter);

            Temperature = 150;
            StateOfMatter = Temperature < 0 ? "solid" : Temperature < 100 ? "liquid" : "gas";
            Console.WriteLine("State of matter is {0}", StateOfMatter);
            return;
        }

        // Ternary operator challenge
        static internal void TemperatureChallenge()
        {
            string InputTemp = string.Empty;
            int Temperature = 20;
            bool Continue = true;

            while (Continue)
            {
                Console.Write("Please enter the temperature: ");
                InputTemp = Console.ReadLine().Trim();
                if (!Int32.TryParse(InputTemp, out Temperature))
                {
                    Console.WriteLine("Not a valid temperature. Try again (Y/N)?");
                    string Choice = Console.ReadLine().Trim();
                    if (Choice.ToUpper().Contains("N")) return;
                }
                else Continue = false;
            }

            string Output = Temperature <= 15 ? "It is too cold here." : (Temperature >= 16 && Temperature <= 28 ? "It is ok" : "It is hot here");
            Console.WriteLine(Output);

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

