// For collections that can contain multiple types
// For collections that only contain 1 type

namespace CSMasterClass
{
    // Section 6: Object Oriented Programming
    public class OOPExamples
    {
        public static void run()
        {

        }

        public static void HumanTest()
        {
            S6Human Rocky1 = new S6Human("Rocky", "Balboa", "blue", 64);
            Rocky1.IntroduceMe();

            S6Human Rocky2 = new S6Human("Rocky", "Balboa", "blue");
            Rocky2.IntroduceMe();

            S6Human Rocky3 = new S6Human("Rocky", "Balboa");
            Rocky3.IntroduceMe();

            S6Human Rocky4 = new S6Human("Rocky");
            Rocky4.IntroduceMe();

            S6Human Rocky5 = new S6Human("Rocky", "blue", 64);
            Rocky5.IntroduceMe();

            S6Human Rocky6 = new S6Human();
            Rocky6.IntroduceMe();

            return;
        }

        public static void BoxTest()
        {
            S6Box box = new S6Box(3, 4, 5);
            box.DisplayInfo();
            return;
        }

        public static void MembersTest()
        {
            S6Members member1 = new S6Members();
            member1.Introducing(true);
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

