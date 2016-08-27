using System;
using System.IO;

namespace NonUnicodetoUnicodeTool
{
    class Program
    {
        static void Main(string[] args)
        {

            /********************* 
            // Obtaining font File information - Only observation by debugging as of now
            */
            //TtfFontFileInformationUtility.GetFontInformation(@"H:\WA\Scripts\Marathi NU - U\MANGAL\MANGAL.TTF");
            //TtfFontFileInformationUtility.GetFontInformation(@"H:\WA\Scripts\Marathi NU - U\DV_ME_Shree0708.TTF");
            //TtfFontFileInformationUtility.GetFontInformation(@"H:\WA\Scripts\Marathi NU - U\Fonts as on 26072016\akshar_0.ttf");

            /*********************
            // Obtain the CharacterSet Code
            
            string sourceFilePath = @"H:\WA\Scripts\Marathi NU - U\greek.txt";
            var setCode = CharacterSetCodeUtility.GetCharacterSetCode(sourceFilePath);
            */

            /*********************
            // TXT FILE: Convert NonUnicode To Unicode
           
            string sourceFilePath = @"H:\WA\Scripts\Demos\Greek\Greek.txt";
            string targetFilePath = @"H:\WA\Scripts\Demos\Greek\GreekUnicode.txt";

            // Create a file that contains the Greek work ψυχή (psyche) - encoding 737 (DOS) Greek code page
            File.WriteAllBytes(sourceFilePath, new byte[] { 0xAF, 0xAC, 0xAE, 0x9E });

            if (NonUnicodeToUnicodeUtility.ConvertNonUnicodeToUnicode(737, sourceFilePath, targetFilePath))
            {
                Console.WriteLine("Conversion is successful!");
            }
            else
            {
                Console.WriteLine("Conversion is failed!");
            }
            var setCode1 = CharacterSetCodeUtility.GetCharacterSetCode(sourceFilePath);
            var setCode2 = CharacterSetCodeUtility.GetCharacterSetCode(targetFilePath);

            Console.Read();
            */


            /*********************
            // TXT FILE: Convert NonUnicode To Unicode
         
            string demo2SourceFilePath = @"H:\WA\Scripts\Demos\Marathi by code\Marathi37.txt";
            string demo2targetFilePath = @"H:\WA\Scripts\Demos\Marathi by code\Marathi37Unicode.txt";

            // The word 'red' in Marathi is programmatically written as a non-unicode txt file - 37 code page needs to be used
            File.WriteAllBytes(demo2SourceFilePath, new byte[] { 0x72, 0x65, 0x64 }); 

            if (NonUnicodeToUnicodeUtility.ConvertNonUnicodeToUnicode(437, demo2SourceFilePath, demo2targetFilePath))
            {
                Console.WriteLine("Conversion is successful!");
            }
            else
            {
                Console.WriteLine("Conversion is failed!");
            }
            var setCode21 = CharacterSetCodeUtility.GetCharacterSetCode(demo2SourceFilePath);
            var setCode22 = CharacterSetCodeUtility.GetCharacterSetCode(demo2targetFilePath);

            Console.Read();
            */

            /*********************
           // TXT FILE: Convert NonUnicode To Unicode
           
           string demo3SourceFilePath = @"H:\WA\Scripts\Demos\Marathi DV font\Marathi.txt";
           string demo3targetFilePath = @"H:\WA\Scripts\Demos\Marathi DV font\MarathiUnicode.txt";

           if (NonUnicodeToUnicodeUtility.ConvertNonUnicodeToUnicode(1252, demo3SourceFilePath, demo3targetFilePath))
           {
               Console.WriteLine("Conversion is successful!");
           }
           else
           {
               Console.WriteLine("Conversion is failed!");
           }
           var setCode31 = CharacterSetCodeUtility.GetCharacterSetCode(demo3SourceFilePath);
           var setCode32 = CharacterSetCodeUtility.GetCharacterSetCode(demo3targetFilePath);

           Console.Read();
           */

            /*********************
           // RTF FILE: Convert NonUnicode To Unicode

           string sourceFilePath = @"H:\WA\Scripts\Marathi NU - U\export - copy.rtf";
           string targetFilePath = @"H:\WA\Scripts\Marathi NU - U\exportOutput.rtf";

           if (NonUnicodeToUnicodeUtility.ConvertNonUnicodeToUnicode(1252, sourceFilePath, targetFilePath))
           {
               Console.WriteLine("Conversion is successful!");
           }
           else
           {
               Console.WriteLine("Conversion is failed!");
           }
           var setCode1 = CharacterSetCodeUtility.GetCharacterSetCode(sourceFilePath);
           var setCode2 = CharacterSetCodeUtility.GetCharacterSetCode(targetFilePath);
           */

            Console.Read();
        }
    }
}
