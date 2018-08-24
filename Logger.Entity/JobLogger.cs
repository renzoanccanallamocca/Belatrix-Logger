using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Entity
{
    using System;
    using System.Collections.Generic;
    public class JobLogger
    {
        public string Message { get; set; }
        public int TypeMessage { get; set; }
        public int Configuration { get; set; }
    }
}
