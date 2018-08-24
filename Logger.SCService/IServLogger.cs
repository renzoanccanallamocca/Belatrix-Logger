using Logger.Entity;
using Logger.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace Logger.SCService
{
    [ServiceContract]
    public interface IServLogger
    {
        [OperationContract]
        [WebInvoke(Method = "POST",
            UriTemplate = "/wsSetSaveLogger",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        Operation wsSetSaveLogger(JobLogger oJobLogger);
    }
}
