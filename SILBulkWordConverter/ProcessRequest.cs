using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILConvertersWordML
{   
    /*
     * For each conversion request a ProcessRequest is expected.
     * This would have all the settings that are required for the conversion.
     */
    public class ProcessRequest
    {
        string[] inputFiles;
        string[] outputFiles;
        bool leaveXMLFileInFolder;
        bool useLinqConversion;
        bool singleStep;

        ConversionElements conversionElements;

        public ProcessRequest(string[] inputFiles, bool leaveXMLFileInFolder = false)
        {
            this.inputFiles = inputFiles;
            this.leaveXMLFileInFolder = leaveXMLFileInFolder;
            // ConversionElements.FontsAndStyles TBD
        }

        public string[] InputFiles
        {
            get
            {
                return inputFiles;
            }
        }

        public string[] OutputFiles
        {
            get
            {
                return outputFiles;
            }

            set
            {
                outputFiles = value;
            }
        }

        public bool LeaveXMLFileInFolder
        {
            get
            {
                return leaveXMLFileInFolder;
            }
        }

        public ConversionElements ConversionElements
        {
            get
            {
                return conversionElements;
            }

            set
            {
                conversionElements = value;
            }
        }

        public bool UseLinqConversion
        {
            get
            {
                return useLinqConversion;
            }
        }

        public bool SingleStep
        {
            get
            {
                return singleStep;
            }
        }
    }
}
