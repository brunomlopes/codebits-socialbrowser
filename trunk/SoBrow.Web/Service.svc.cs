using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using DataLayer;

namespace SoBrow.Web
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service
    {
        private IOperations Operations;

        public Service(IOperations operations)
        {
            Operations = operations;
        }

        public Service()
        {
            Operations = new Operations();
        }

        // To use HTTP GET, add [WebGet] attribute. (Default ResponseFormat is WebMessageFormat.Json)
        // To create an operation that returns XML,
        //     add [WebGet(ResponseFormat=WebMessageFormat.Xml)],
        //     and include the following line in the operation body:
        //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
        [OperationContract]
        [WebGet(UriTemplate = "GetUserProfile/{uid}")]
        public ProfileView GetUserProfile(string uid)
        {
            return new ProfileView(Operations.GetProfileForUid(int.Parse(uid)));
        }

        // Add more operations here and mark them with [OperationContract]
    }
}
