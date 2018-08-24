using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Util
{
    public enum Configuration
    {
        File = 1,
        Database = 2
    }

    public enum TypeMessage
    {
        Error = 1,
        Warning = 2,
        Message = 3
    }
}
