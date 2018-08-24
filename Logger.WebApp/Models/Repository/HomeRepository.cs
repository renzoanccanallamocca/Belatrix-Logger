using Logger.Entity;
using Logger.SCService;
using Logger.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Web;

namespace Logger.WebApp.Models.Repository
{
    public class HomeRepository
    {
        public Operation SaveLogger(JobLogger oJobLogger)
        {
            Operation oOperation = null;

            using (var canal = new ChannelFactory<IServLogger>("WHTTP_ServLogger"))
            {
                IServLogger imp = canal.CreateChannel();
                using (OperationContextScope scope = new OperationContextScope((IClientChannel)imp))
                {
                    WebOperationContext woc = new WebOperationContext(OperationContext.Current);
                    woc.OutgoingRequest.Headers["BelatrixId"] = WebConfig.WSKey;
                    
                    oOperation = imp.wsSetSaveLogger(oJobLogger);
                }
            }
            
            return oOperation;
        }
    }
}