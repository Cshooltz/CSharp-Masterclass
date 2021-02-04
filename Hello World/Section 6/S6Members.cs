using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace CSMasterClass
{
    class S6Members
    {
        // member - private field
        private string memberName;
        private string jobTitle;
        private int salary;

        // member - public field
        public int age;

        // member - properties
        public string Jobtitle
        {
            get => jobTitle;
            set => jobTitle = value;
        }

        // public member method - can be called from other classes
        public void Introducing(bool isFriend)
        {
            if (isFriend)
            {
                SharingPrivateInfo();
            }
            else
            {
                Console.WriteLine($"Hi, my name is {memberName}, and my job title is {jobTitle}. I'm {age} years old.");
            }
        }

        // private member method - can only be called from this class
        private void SharingPrivateInfo()
        {
            Console.WriteLine($"My salary is {salary}.");
        }

        // member Constructor
        public S6Members()
        {
            age = 30;
            memberName = "Lucy";
            salary = 60000;
            jobTitle = "Developer";
            Console.WriteLine("Object created");
        }

        // member - finalizer - destructor
        // Can only have 1
        // Cannot be inherited or overloaded, and cannot be called.
        ~S6Members()
        {
            // cleanup statements
            // Only use if necessary, otherwise best omitted. Declaring one adds it to the finlizer queue. 
            Debug.Write("Destruction of Members object");
        }
    }
}
