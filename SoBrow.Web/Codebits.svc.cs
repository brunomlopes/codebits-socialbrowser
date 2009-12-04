using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer;

namespace SoBrow.Web
{
    public class Codebits : ICodebits
    {
        private IOperations Operations;

        public Codebits(IOperations operations)
        {
            Operations = operations;
        }

        public Codebits()
        {
            Operations = new Operations();
        }

        public IEnumerable<ProfileView> GetUserProfiles(IEnumerable<int> profileUids)
        {
            return profileUids.Select(uid => new ProfileView(Operations.GetProfileForUid(uid)));
        }

        public ProfileView GetUserProfile(int uid)
        {
            return new ProfileView(Operations.GetProfileForUid(uid));
        }
    }
}
