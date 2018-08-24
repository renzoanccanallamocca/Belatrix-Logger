using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Logger.WcfService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServLogger" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServLogger.svc o ServLogger.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServLogger : IServLogger
    {
        public void DoWork()
        {
        }
    }
}
