using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILConvertersWordML
{
    // Used primarirly for carrying the log message
    public class ProcessIntermediateResult : ProcessResult
    {
        public string Message { get; set; }

        public ushort ProgressPercentage { get; set; }

        public MessageType TypeOfMessage { get; set; }

        public MessageLevel LevelOfMessage { get; set; }
    }
}
