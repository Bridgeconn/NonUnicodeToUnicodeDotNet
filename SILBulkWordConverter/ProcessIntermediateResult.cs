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
        public ProcessIntermediateResult()
        {
            DateTime = DateTime.Now;
        }

        public DateTime DateTime { get; }

        public string Message { get; set; }

        public ushort ProgressPercentage { get; set; }

        public MessageType TypeOfMessage { get; set; }

        public MessageLevel LevelOfMessage { get; set; }

        public override string ToString()
        {
            return string.Format("[{0}] {1} - {2}: {3}", DateTime, TypeOfMessage, LevelOfMessage, Message);
        }
    }
}
