using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CSMasterClass
{
    // Section 9, lesson 107, Interfaces
    // An interface is a syntactical contract that all classes that inherit the interface should follow.
    class S9Interfaces
    {
        public static void run()
        {
            Notification n1 = new Notification("Collin", "Sup bro?", "9/28/2020");
            Notification n2 = new Notification("Frank", "All good buddy", "9/28/2020");
            n1.ShowNotification();
            n2.ShowNotification();

            return;
        }
    }

    public interface INotifications
    {
        // Members
        void ShowNotification();
        string GetDate();
    }

    public class Notification : INotifications
    {
        private string Sender;
        private string Message;
        private string Date;

        public Notification()
        {
            Sender = "Admin";
            Message = "Yo, what's up?";
            Date = " ";
        }

        public Notification(string mySender, string myMessage, string myDate)
        {
            Sender = mySender;
            Message = myMessage;
            Date = myDate;

            return;
        }

        public void ShowNotification()
        {
            Console.WriteLine($"Message: {Message} - was sent by {Sender} - at {Date}");
            return;
        }

        public string GetDate()
        {
            return Date;
        }
    }
}
