using Logger.Entity;
using Logger.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.ILogic
{
    public interface ILoggerFileLogic
    {
        Operation SaveLogger(Entity.JobLogger oJobLogger);
    }
}
