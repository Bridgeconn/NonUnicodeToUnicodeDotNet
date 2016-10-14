using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILConvertersWordML
{   
    public interface ILogger
    {
        void LogMessage(DateTime datetime, ushort progressPercentage, MessageType typeOfMessage, MessageLevel levelOfMessage, string message);
    }
}
