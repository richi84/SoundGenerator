using SoundGenerator.Compose;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace WebService
{
    [ServiceContract]
    public interface IRestAPI
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "/rest/build",
                    Method = "POST",
                    ResponseFormat = WebMessageFormat.Json,
                    RequestFormat = WebMessageFormat.Json,
                    BodyStyle = WebMessageBodyStyle.Bare)]
        int Build(SongOption songOption);

        [OperationContract]
        [WebInvoke(UriTemplate = "/rest/state/{id}",
            Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        double State(String id);
    }
}
