using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace SoBrow.Web
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICodebits" in both code and config file together.
    [ServiceContract]
    public interface ICodebits
    {
        [OperationContract]
        IEnumerable<ProfileView> GetUserProfiles(IEnumerable<int> profileUids);

        [OperationContract]
        [WebGet]
        ProfileView GetUserProfile(int uid);
    }
}
