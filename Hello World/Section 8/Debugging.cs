using System;
// For collections that can contain multiple types
// For collections that only contain 1 type
using System.Collections.Generic;

namespace CSMasterClass
{
    // Section 8: Debugging
    public class Debugging
    {
        public static void Party()
        {
            var friends = new List<string> { "Frank", "Joe", "Michelle", "Andy", "Maria", "Carlos", "Angelina" };
            //var friends = new List<string>();
            var partyFriends = GetPartyFriends(friends, 3);

            foreach (var name in partyFriends) Console.WriteLine(name);

            return;
        }

        public static List<string> GetPartyFriends(List<string> list, int count)
        {
            if (list == null) throw new ArgumentNullException("list", "The list is empty.");

            if (count > list.Count || count <= 0) throw new ArgumentOutOfRangeException("count", "Count cannot be greater than elements in the list or less than 0.");
            var buffer = new List<string>(list);
            var partyFriends = new List<string>();

            while(partyFriends.Count < count)
            {
                var currentFriend = GetPartyFriend(buffer);
                partyFriends.Add(currentFriend);
                buffer.Remove(currentFriend);
            }
            return partyFriends;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <returns>string containing the shortest name.</returns>
        public static string GetPartyFriend(List<string> list)
        {
            string shortestName = list[0];
            for (var i = 0; i < list.Count; i++)
            {
                // Intentional bugs here
                if (list[i].Length < shortestName.Length)
                {
                    shortestName = list[i];
                }
            }
            return shortestName;
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

