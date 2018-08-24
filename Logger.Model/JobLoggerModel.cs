using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Model
{
    public class JobLoggerModel
    {
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public int TypeMessage { get; set; }
        [DataMember]
        public int Configuration { get; set; }
    }
}
