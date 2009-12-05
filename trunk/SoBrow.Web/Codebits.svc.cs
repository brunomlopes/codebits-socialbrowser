using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using DataLayer;

namespace SoBrow.Web
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Codebits
    {
        private Operations Operations;

        public Codebits()
        {
            this.Operations = new Operations();
        }

        [OperationContract]
        public ProfileView GetUserProfile(string uid)
        {
            return new ProfileView(this.Operations.GetProfileForUid(uid));
        }
    }
}
