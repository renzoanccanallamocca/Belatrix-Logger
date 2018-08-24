using AutoMapper;
using Logger.Entity;
using Logger.Logic;
using Logger.SCService;
using Logger.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Logger.RestService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServLogger" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServLogger.svc o ServLogger.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServLogger : IServLogger
    {
        public Operation wsSetSaveLogger(Entity.JobLogger oJobLogger)
        {
            Operation oOperation = null;

            try
            {
                if (WebOperationContext.Current.IncomingRequest.Headers["BelatrixId"] == null)
                {
                    oOperation = new Operation()
                    {
                        Success = false,
                        Message = "Dont have permissions"
                    };
                }
                else
                {
                    string clave = WebOperationContext.Current.IncomingRequest.Headers["BelatrixId"];

                    if (clave == WebConfig.WSKey)
                    {
                        switch (oJobLogger.Configuration)
                        {
                            case (int)Configuration.File:
                                oOperation = new LoggerFileLogic().SaveLogger(oJobLogger);
                                break;
                            case (int)Configuration.Database:
                                oOperation = new LoggerDataLogic().Save(oJobLogger);
                                break;

                        }
                    }
                    else
                    {
                        oOperation = new Operation()
                        {
                            Success = false,
                            Message = "Dont have permissions"
                        };
                    }
                }
            }
            catch (Exception e)
            {
                oOperation = new Operation()
                {
                    Success = false,
                    Message = e.Message
                };
            }

            return oOperation;
        }
    }
}
