using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILConvertersWordML
{
    /*  Each ProcessManager will have one ProcessMessenger attached to it. 
        This ProcessMessenger will notify the client's ILogger object.
        This is used as a logger/progress listener so that the client application can have its own logger */
    public class ProcessMessenger
    {
        ILogger logger;

        string processID;

        public ProcessMessenger(ILogger logger)
        {
            //ProcessID needs to be generated and stored
            this.logger = logger;
        }

        public string ProcessID
        {
            get
            {
                return processID;
            }
        }

        public void LogMessage(DateTime datetime, MessageType typeOfMessage, MessageLevel levelOfMessage, string message)
        {
            // can be logged in DB using the ProcessID

            // Notify to the user
            logger.LogMessage(datetime, typeOfMessage, levelOfMessage, message);
        }
    }
}
