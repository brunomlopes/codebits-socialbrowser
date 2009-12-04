using System;
using System.Collections.Generic;
using System.Linq;
using DataEntities;

namespace SoBrow.Web
{
    [Serializable]
    public class ProfileView
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public string Blog { get; set; }
        public string Twitter { get; set; }
        public IEnumerable<string> Skills { get; set; }

        public IEnumerable<int> FriendUids { get; set; }
        public string Project { get; set; }

        public ProfileView(Profile profile)
        {
            ID = profile.ID;
            Name = profile.Name;
            PhotoUrl = profile.PhotoUrl;
            Blog = profile.Blog;
            Twitter = profile.Twitter;

            Skills = profile.Skills.Select(s => s.Name);
            FriendUids = profile.Friends.Select(f => f.ID);
            Project = profile.Project.ProjectName;
        }
    }
}