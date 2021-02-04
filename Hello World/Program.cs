using System;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
// For collections that can contain multiple types
// For collections that only contain 1 type
using System.Net;
using Hello_World;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace CSMasterClass
{

    class Program
    {
        const int leet = 1337;
        const int weeks = 52, months = 12;
        const string bday = "05/16/1993";

        public static async Task Main(string[] args)
        {
            // Start here

            //ThreadJoining.Main();
            Task threadTask = ThreadPools.Main();
            Console.WriteLine("Awaiting Threadpools");
            //await threadTask;
            Console.WriteLine("ThreadPools completed");

            Console.ReadKey();

            return;
            //Console.Clear();

            // Example call to an external native library function
            //MessageBox(IntPtr.Zero, "Command-line message box", "Attention!", 0);

            // Example call to an external native library function that calls back to a managed function
            // EnumWindows(OutputWindow, IntPtr.Zero);
            // Convert is a useful class. 
        }

        static internal void GreetFriend(string friend)
        {
            Console.WriteLine("Hello {0}, my friend!", friend);
            return;
        }

        // From: https://docs.microsoft.com/en-us/dotnet/standard/native-interop/pinvoke
        // Example using P/Invoke to define a managed call to an unmanaged external library
        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern int MessageBox(IntPtr hWnd, string lpText, string lpCaption, uint uType);

        // The following example calls an unmanaged function that calls a callback function from managed code
        // Define a delegate that corresponds to the unmanaged function.
        private delegate bool EnumWC(IntPtr hwnd, IntPtr lParam); // IntPtr is used in place of the native HWND and LPARAM types used by Windows

        // Import user32.dll(containing the function we need) and define
        // the method corresponding to the native function.
        [DllImport("user32.dll")]
        private static extern int EnumWindows(EnumWC lpEnumFunc, IntPtr lParam);

        // Define the implementation of the delegate; here, we simply output the window handle.
        private static bool OutputWindow(IntPtr hwnd, IntPtr lParam)
        {
            Console.WriteLine(hwnd.ToInt64());
            return true;
        }

    }

    // ToC:

    // Sections 2 and 3: Basics and using the Console

    // Section 4: Making Decisions

    // Section 5: Loops

    // Section 6: Object Oriented Programming
    
    // Section 7: Arrays and Lists

    // Section 8: Debugging

    // Section 9: Inheritance
    // This is where we get into actual classes, so I am not sure how I will organize my code for this one.
    // See Company.cs, Inheritance.cs, and Interfaces.cs

    // Section 10: Polymorphism
    // See PolyChallenge.cs, FileIO.cs

    // Section 11: Advanced C# Topics
    // See: S11Enums.cs, S11Math.cs

    // Section 12: Events and Delegates

    // Section 13: Windows Presentation Foundation
    // I will Do this one in a new project.
}

