using System;
using System.Collections.Generic;
using System.Text;

namespace CSMasterClass
{
    class S6Human
    {
        private string FirstName = "";
        private string LastName = "";
        private string EyeColor = "";
        private int Age = 0;

        public S6Human()
        {
            Console.WriteLine("Object created");
        }

        public S6Human(string firstName)
        {
            this.FirstName = firstName;
            return;
        }

        public S6Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            return;
        }

        public S6Human(string firstName, string lastName, string eyeColor)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.EyeColor = eyeColor;
            return;
        }

        public S6Human(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            return;
        }

        public S6Human(string firstName, string lastName, string eyeColor, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.EyeColor = eyeColor;
            this.Age = age;
            return;
        }

        public void IntroduceMe()
        {
            // Intended output, but pieces can be left out:
            // Hi, I am {FirstName} {LastName}.
            // I am {Age} years old and my eye color is {EyeColor}
            StringBuilder Line1 = new StringBuilder();
            StringBuilder Line2 = new StringBuilder();
            Line1.Append("Hello");
            if (!FirstName.Equals("") || !LastName.Equals(""))
            {
                Line1.Append(", I am ");
                if (!FirstName.Equals("")) Line1.Append(FirstName);
                if (!FirstName.Equals("") && !LastName.Equals("")) Line1.Append(" ");
                if (!LastName.Equals("")) Line1.Append(LastName);
                Line1.Append(".");
            }
            else Line1.Append(".");

            if (!EyeColor.Equals("") && Age != 0) Line2.Append($"I am {Age} years old and my eye color is {EyeColor}.");
            else if (!EyeColor.Equals("")) Line2.Append($"My eye color is {EyeColor}.");
            else if (Age != 0) Line2.Append($"I am {Age} years old.");

            if (!Line1.Equals("")) Console.WriteLine(Line1);
            if (!Line2.Equals("")) Console.WriteLine(Line2);
            
            return;
        }
    }
}
