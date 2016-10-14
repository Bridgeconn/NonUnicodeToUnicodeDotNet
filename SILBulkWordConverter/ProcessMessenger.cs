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
        ushort progressPercentage;

        public ProcessMessenger(ILogger logger, string processID = "")
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

        public ushort ProgressPercentage
        {
            get
            {
                return progressPercentage;
            }

            set
            {
                progressPercentage = value;
                // call the notifier to update the status bar
            }
        }

        public void LogMessage(string message, ushort progressPercentage, MessageType typeOfMessage = MessageType.UserMessage, MessageLevel levelOfMessage = MessageLevel.Normal)
        {
            this.ProgressPercentage += progressPercentage;
            // can be logged in DB using the ProcessID

            // Notify to the user
            logger.LogMessage(DateTime.Now, typeOfMessage, levelOfMessage, message);
        }
    }
}
