using SILConvertersWordML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonUnicodetoUnicodeTool
{
    public class Logger: ILogger
    {
        public void LogMessage(DateTime datetime, ushort progressPercentage, MessageType typeOfMessage, MessageLevel levelOfMessage, string message)
        {

        }
    }
}
