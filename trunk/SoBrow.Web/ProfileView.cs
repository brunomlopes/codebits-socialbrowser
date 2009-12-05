using System;
using System.Collections.Generic;
using System.Linq;
using DataEntities;

namespace SoBrow.Web
{
    [Serializable]
    public class ProfileView
    {
        public string ID;
        public string Name;
        public string PhotoUrl;
        public string Blog;
        public string Twitter;
        public string[] Skills;

        public string[] FriendUids;
        public string ProjectName;
        public string ProjectDescription;

        public ProfileView(Profile profile)
        {
            ID = profile.ID;
            Name = profile.Name;
            PhotoUrl = profile.PhotoUrl;
            Blog = profile.Blog;
            Twitter = profile.Twitter;

            Skills = profile.Skills.Select(s => s.Name).ToArray();
            FriendUids = profile.Friends.Select(f => f.ID).ToArray();
            ProjectName = profile.Project.ProjectName;
            ProjectDescription = profile.Project.Description;
        }
    }
}