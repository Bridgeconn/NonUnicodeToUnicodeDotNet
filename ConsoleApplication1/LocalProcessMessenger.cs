using SILConvertersWordML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonUnicodetoUnicodeTool
{
    /* 
     * 
     */
    public class LocalProcessMessenger 
    {
        public ResultMessage Initialize(string[] sourceFilePaths)
        {
            ProcessRequest processRequest = new ProcessRequest(sourceFilePaths, new Logger());
            ProcessManager processManager = new ProcessManager(processRequest);
            ResultMessage resultMessage = processManager.Initiatialize();

            return resultMessage;
        }
    }


}
