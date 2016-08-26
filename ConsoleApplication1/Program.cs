using System;
//using System.Text;
namespace NonUnicodetoUnicodeTool
{
    class Program
    {

        static void Main(string[] args)
        {
            /* 
            // Obtaining font File information - Only observation by debugging as of now
            
            TtfFontFileInformationUtility.GetFontInformation(@"H:\WA\Scripts\Marathi NU - U\Fonts as on 26072016\DV_ME_Shree0715.TTF");
            */

            /*
            // Obtain the CharacterSet Code
            
            string sourceFilePath = @"H:\WA\Scripts\Marathi NU - U\greek.txt";
            var setCode = CharacterSetCodeUtility.GetCharacterSetCode(sourceFilePath);
            */

            /*
            // TXT FILE: Convert NonUnicode To Unicode
            
            string sourceFilePath = @"H:\WA\Scripts\Marathi NU - U\export.txt";
            string targetFilePath = @"H:\WA\Scripts\Marathi NU - U\exportOutput.txt";

            // The word 'red' in Marathi is programmatically written as a non-unicode txt file
            System.IO.File.WriteAllBytes(nonUnicodeTxtFilePath, new byte[] { 0x72, 0x65, 0x64 });

            if (NonUnicodeToUnicodeUtility.ConvertNonUnicodeToUnicode(37, sourceFilePath, targetFilePath))
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

            /*
           // RTF FILE: Convert NonUnicode To Unicode

           string sourceFilePath = @"H:\WA\Scripts\Marathi NU - U\export.rtf";
           string targetFilePath = @"H:\WA\Scripts\Marathi NU - U\exportOutput.rtf";

           if (NonUnicodeToUnicodeUtility.ConvertNonUnicodeToUnicode(37, sourceFilePath, targetFilePath))
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
