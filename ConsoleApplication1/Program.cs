using System;
using System.IO;

namespace NonUnicodetoUnicodeTool
{
    class Program
    {
        static void Main(string[] args)
        {
           if(args.Length == 3)     //  For Non-unicode to unicode conversion
            {
                if (IsValidInputArguments(args))
                {
                    NonUnicodeToUnicodeUtility.Convert(args[0], args[1], args[2]);
                }
                else
                {
                    Console.WriteLine("Check input file"); // other checks need to be made
                }
            }
           else
            {
                // Show help
                Console.WriteLine("Below is the Syntax expected!");
                Console.WriteLine("Mapcode  sourceFilePath targetFilePath");
                Console.WriteLine("Refer to FontConversion.Config for different Mapcodes available");
                Console.WriteLine("sourceFilePath is the file that's text needs to be converted");
                Console.WriteLine("targetFilePath is the file that's newly generated. If filename is not given, <old>-Unicode.txt gets created in the given folder path.");
            }
        }

        static bool IsValidInputArguments(string[] arguments)
        {
            // check if mapping code exists
            // check if source file path exists
            // check if target folder path exists
            return true;
        }
    }
}
