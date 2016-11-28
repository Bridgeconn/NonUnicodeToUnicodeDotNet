using System;
using System.IO;
using System.Configuration;
using SILConvertersWordML;

namespace NonUnicodetoUnicodeTool
{
    class Program
    {
        static void Main(string[] args)
        {
            if (true/*args.Length!=0 && IsValidInputArguments(args)*/)
            {
                //NonUnicodeToUnicodeUtility.Convert("sd708", @"NU.txt", @"U.txt");
                //return;

                bool isProceedToNext = false;

                // Create a process request
                ProcessRequest processRequest = new ProcessRequest(new string[] { @"H:\WA\Scripts\MarathiNU-U\Font Study\MAP Files\DV_ME_SHREE\NU.docx" }, true, new Logger(GetNotified));
                ProcessManager processManager = new ProcessManager(processRequest);

                // ProcessResult is for the result for the steps & ProcessIntermediateResult is the in between messages
                ProcessResult resultMessage = processManager.Initialize();

                switch(resultMessage.ResultType)
                {
                    case ResultType.Completed:
                        isProceedToNext = true;
                        break;
                    case ResultType.Failed:
                        // Send ErrorMessage
                        break;
                }

                if (isProceedToNext)
                {
                    resultMessage = processManager.LoadInputDocuments(processRequest.InputFiles);
                }

                switch (resultMessage.ResultType)
                {
                    case ResultType.Completed:
                        isProceedToNext = true;
                        break;
                    case ResultType.Failed:
                        // Send ErrorMessage
                        break;
                }

                if (isProceedToNext)
                {
                    resultMessage = processManager.AutoChooseConverters();
                }

                switch (resultMessage.ResultType)
                {
                    case ResultType.Completed:
                        isProceedToNext = true;
                        break;
                    case ResultType.Failed:
                        // Send ErrorMessage
                        break;
                }

                if (isProceedToNext)
                {
                    resultMessage = processManager.ConvertAndSaveDocuments();
                }

                switch (resultMessage.ResultType)
                {
                    case ResultType.Completed:
                        isProceedToNext = true;
                        break;
                    case ResultType.Failed:
                        // Send ErrorMessage
                        break;
                }
                Console.Read();
            }
            else
            {
                PrintHelp();
            }
        }

        static void GetNotified(ProcessIntermediateResult processResult)
        {
            Console.WriteLine(processResult);
        }

        /*NonUnicodeToUnicodeUtility.Convert(args[0], args[1], args[2]);*/

        static void PrintHelp()
        {
            // Show help
            Console.WriteLine("Below is the Syntax expected!");
            Console.WriteLine("fontmapcode  sourceFilePath targetFilePath");
            Console.WriteLine("parameter mapcode: Refer to FontConversion.Config for different Mapcodes available");
            Console.WriteLine("parameter sourceFilePath: It is the file that's text needs to be converted");
            Console.WriteLine("parameter targetFilePath: It is the file that's newly generated. If filename is not given, <old>-Unicode.txt gets created in the given folder path.");
            Console.Read();
        }

        static bool IsValidInputArguments(string[] arguments)
        {
            bool isValid = true;

            //  For Non-unicode to unicode conversion
            if (arguments.Length == 3)     
            {
                // check if mapping code exists
                // refer config map
                if(arguments[0] != "sd708")
                {
                    Console.WriteLine("Conversion Code not found!");
                    isValid = false;
                }

                // check if source file path exists
                if (!File.Exists(arguments[1]))
                {
                    Console.WriteLine("Source File not found!");
                    isValid = false;
                }

                // check if target folder path exists
                //if (!(Directory.Exists(arguments[2]) || File.Exists(arguments[2])))
                //{
                //    Console.WriteLine("Target File not found!");
                //    isValid = false;
                //}
            }
            else
            {
                isValid = false;
            }

            return isValid;
        }
    }
}