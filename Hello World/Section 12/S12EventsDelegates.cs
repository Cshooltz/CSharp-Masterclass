using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CSMasterClass
{
    class S12EventsDelegates
    {
        static public void Main()
        {
            Events.run();
            return;
        }
        // Delegates:
        /* A delegate is a type that represents the references to methods
         * with a particular parameter list and return type. When you
         * instantiate a delegate, you can associate its instance with any
         * method with a compatible signature and return type. You can
         * invoke (or call) the method through the delegate instance.
         * 
         * Basically, you make a delegate that has a method signature
         * Any method that matches that signature to can be assigned to a
         * variable of that delegate type, or passed as a parameter
         * to any function that takes that delegate type.
         * 
         * It is a contract that defines what a function reference
         * needs to have for a given context. It basically replaces function
         * pointers from C++ using ahead-of-time defined types.
         */
    }

    class Delegates
    {
        public delegate double PerformCalculation(double x, double y);

        public static double Addition(double a, double b)
        {
            Console.WriteLine("a+b is: " + (a + b));
            return a + b;
        }

        public static double Division(double a, double b)
        {
            Console.WriteLine("a/b is: " + (a / b));
            return a / b;
        }

        public static double Subtraction(double a, double b)
        {
            Console.WriteLine("a-b is: " + (a - b));
            return a - b;
        }

        static public void run()
        {
            PerformCalculation getSum = Addition; // Not calling, just pointing to.
            getSum(5.0, 5.0);

            PerformCalculation getQuotiant = Division;
            getQuotiant(5.0, 5.0);

            // Multicasting delegates, calling multiple methods at once
            // It works by adding function references together (or in this case delegates)? 
            // We have seen it before using += on the Timer callback. 
            PerformCalculation multiCalc = getSum + getQuotiant;
            multiCalc += Subtraction;
            multiCalc -= getSum; // Can remove specific functions too. 
            multiCalc(3.2, 3.2);

            return;
        }
    }

    // Anonymous Methods
    class AnonMethods
    {
        public delegate string GetTextDelegate(string name);

        static public void run()
        {
            // Anonymous method is defined with the delegate keyword;
            GetTextDelegate getTextDelegate = delegate (string name)
            {
                return "Hello, " + name;
            };
            Console.WriteLine(getTextDelegate("Rayleigh"));
            Display(getTextDelegate);
            SayHello();
            return;
        }

        // It is important that anonymous methods do not use jump statements
        // like goto, break, and continue.
        public static void Display(GetTextDelegate textDelegate)
        {
            Console.WriteLine(textDelegate("World"));
        }
        
        // Named methods are always compiled before anonymous methods
        static public void SayHello()
        {
            Console.WriteLine("Hello 👋");
        }
    }

    class Lambdas
    {
        internal static void run()
        {
            AnonMethods.GetTextDelegate getTextDelegate = delegate (string name)
            {
                return "Hello, " + name;
            };

            // Lambda expression (expression lambda)
            AnonMethods.GetTextDelegate getHelloText = (string name) => { return "Hello, " + name; };

            // Statement lambda
            AnonMethods.GetTextDelegate getGoodbyeText = (string name) =>
            {
                Console.WriteLine("I'm inside of a statement lambda.");
                return "Goodbye, " + name;
            };

            // Condensed expression lambda. Parameter name types are inferred from delegate type.
            // Parameter list paranthenses () can be omitted if there is only one parameter.
            AnonMethods.GetTextDelegate getWelcomeText = name => "Welcome, " + name; // Expression is 1 line, statement is multiple expressions. 

            Delegates.PerformCalculation getSum = (a, b) => a + b;
            Delegates.PerformCalculation getProduct = (a, b) => a * b;

            DisplayNum(getSum);
            DisplayNum(getProduct);

            Console.WriteLine(getWelcomeText("Rayleigh"));

            return;
        }

        static void DisplayNum(Delegates.PerformCalculation getResult)
        {
            Console.WriteLine(getResult(3.5,2.5));
        }
    }

    // Events!
    public class Events
    {
        static public void run()
        {
            var file = new File() { Title = "File 1" };
            var downloadHelper = new DownloadHelper(); // publisher
            var unpackService = new UnpackService(); // reciever
            var notificationService = new NotificationService(); // Reciever
            downloadHelper.FileDownloaded += unpackService.OnFileDownloaded; // Add your callback to the event to be called when the event is raised. 
            downloadHelper.FileDownloaded += notificationService.OnFileDownloaded;

            downloadHelper.Download(file);
            return;
        }
    }

    /* Events are a handy system. The basic pattern is:
     * Any object that can emit an event can define the event object in itself.
     * The object can emit the event by calling the event with the assigned delegate's parameters.
     * Any object can subscribe to an event by adding any function to the event object
     *      that matches the event's delegate type. 
     * When the event is raised, all functions added to the event are called.
     * In this way you can arrange for decoupled communication between objects. 
     */

    public class NotificationService
    {
        public void OnFileDownloaded(object source, FileEventArgs e)
        {
            Console.WriteLine($"File '{e.file.Title}' download completed successfully");
        }
    }
    
    public class UnpackService
    {
        public void OnFileDownloaded(object source, FileEventArgs e)
        {
            Console.WriteLine("UnpackerService: Unpacking the file..." + e.file.Title);
        }
    }
    
    public class FileEventArgs : EventArgs
    {
        public File file { get; set; }
    }

    public class DownloadHelper
    {
        // Step 1 - create a delegate
        // public delegate void FileDownloadedEventHandler(object source, FileEventArgs args); // While this works, it is not needed as C# provides the EventHandler delegate already

        // Step 2 - create an event based on that delegate
        // public event FileDownloadedEventHandler FileDownloaded; // Based on making my own delegate
        // The <T> defines the object that is sent in place of EventArgs.
        public event EventHandler<FileEventArgs> FileDownloaded;

        // Step 3 - raise the events
        protected virtual void OnFileDownloaded(File file) // Protected virtual is convention
        {
            if (FileDownloaded != null)
            {
                FileDownloaded(this, new FileEventArgs() { file = file });
            }
        }
        public void Download(File file)
        {
            Console.WriteLine("Downloading file...");
            Thread.Sleep(4000);

            // Step 3.1
            OnFileDownloaded(file);
        }
    }

    public class File
    {
        public string Title { get; set; }
    }
}
