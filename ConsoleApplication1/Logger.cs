using SILConvertersWordML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonUnicodetoUnicodeTool
{
    public class Logger: IProcessMessenger
    {
        public delegate void GetNotifiedDelegate(ProcessIntermediateResult processResult);
        GetNotifiedDelegate GetNotified;

        // TBD temporary arragement
        public Logger(GetNotifiedDelegate GetNotified)
        {
            this.GetNotified = GetNotified;

        }
        public void LogMessage(ProcessIntermediateResult processIntermediateResult)
        {
            GetNotified(processIntermediateResult);
        }
    }
}
