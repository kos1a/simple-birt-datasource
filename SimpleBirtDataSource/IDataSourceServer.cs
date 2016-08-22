using StandardLibrary.WCF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SimpleBirtDataSource
{
    [ServiceContract]
    public interface IDataSourceServer
    {

        [OperationContract]
        [WebInvoke(UriTemplate = "/put",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        GenericResponse<string> Put(GenericRequest<string> request);

        [OperationContract]
        [WebGet(UriTemplate = "/get/{uid}",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare)]
        Stream Get(string Uid);

    }

  }
