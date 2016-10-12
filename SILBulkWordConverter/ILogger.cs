using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILConvertersWordML
{
    public enum MessageType
    {
        UserMessage,
        UserErrorMessage,
        SystemMessage,
        SystemErrorMessage
    }

    public enum MessageLevel
    {
        Normal,
        Critical
    }

    public interface ILogger
    {
        void LogMessage(DateTime datetime, MessageType typeOfMessage, MessageLevel levelOfMessage, string message);
    }
}
