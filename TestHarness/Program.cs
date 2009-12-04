using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataEntities;
using DataLayer;

namespace TestHarness
{
    class Program
    {
        static void Main(string[] args)
        {
            var operations = new Operations();
            var profile = operations.GetProfileForUid(506);

            printProfile(profile);
            foreach (var friend in profile.Friends)
            {
                Console.Out.WriteLine("- - - Friend");
                printProfile(friend);
                foreach (var friendOfAFriend in friend.Friends)
                {
                    Console.Out.WriteLine("- - - - - - Friend");
                    printProfile(friendOfAFriend);
                }
            }
        }

        private static void printProfile(Profile profile)
        {
            Console.Out.WriteLine("Name:"+profile.Name);
            Console.Out.WriteLine("profile.ID = {0}", profile.ID);
            Console.Out.WriteLine("profile.Blog = {0}", profile.Blog);
            Console.Out.WriteLine("profile.Skills.Select(s => s.Name) = {0}", profile.Skills.Select(s => s.Name));
            Console.Out.WriteLine("profile.Twitter = {0}", profile.Twitter);
            if (profile.Project != null)
            {
                Console.Out.WriteLine("profile.Project.ProjectName = {0}", profile.Project.ProjectName);
                Console.Out.WriteLine("profile.Project.Description = {0}", profile.Project.Description);
            }
        }
    }
}
