﻿using System;
using System.IO;
using SilEncConverters40;
using ECInterfaces;

namespace NonUnicodetoUnicodeTool
{
    class Program
    {
        static void Main(string[] args)
        {
            /********************* 
            
            // Get an instance of the repository object
            EncConverters aECs = new EncConverters();

            // Add Ticket tec file generated from the map file
            aECs.Add("DV_SHREE<>UNICODE", @"H:\WA\Scripts\Marathi NU - U\Font Study\Untitled.tec", ConvType.Legacy_to_from_Unicode, "DV_ME_80", "UNICODE", ProcessTypeFlags.NonUnicodeEncodingConversion);
            
            // Get a reference to the converter
            IEncConverter conv = aECs.GetMapByName("DV_SHREE<>UNICODE");

            // if we reach here, then the converter must have been 
            // configured; though, in fact, it might not have been
            // added to the System Repository (i.e. it might just 
            // be a temporary converter). You can use the 
            // rConfigurator.IsInRepository method to detect if it
            // was added or not
            // now, call the 'Convert' function to do a conversion
            string strIn = "ZàÐmàwÂàà - ¥§ý âkwÞm §ýnà";
            string strOut = conv.Convert(strIn);
            File.WriteAllText(@"H:\Test.txt", strOut);
            Console.WriteLine(String.Format("'{1}' became '{0}'", strOut, strIn));
            Console.Read();

            /********************* 

            /********************* 
            // Obtaining font File information - Only observation by debugging as of now
            */
            //TtfFontFileInformationUtility.GetFontInformation(@"H:\WA\Scripts\Marathi NU - U\Fonts as on 26072016\aksh.ttf");

            /*********************
            // Obtain the CharacterSet Code
            
            string sourceFilePath = @"H:\WA\Scripts\Marathi NU - U\greek.txt";
            var setCode = CharacterSetCodeUtility.GetCharacterSetCode(sourceFilePath);
            */

            /*********************
            // TXT FILE: Convert NonUnicode To Unicode
           
            string sourceFilePath = @"Demo\Greek\Greek.txt";
            string targetFilePath = @"Demo\Greek\GreekUnicode.txt";

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
            
            string demo2SourceFilePath = @"H:\WA\Scripts\Demos\Marathi DV font\shusha.txt";
            string demo2targetFilePath = @"H:\WA\Scripts\Demos\Marathi DV font\shushaUnicode.txt";

            // The word 'red' in Marathi is programmatically written as a non-unicode txt file - Devanagari code page (57002) code page needs to be used
            File.WriteAllBytes(demo2SourceFilePath, new byte[] { 0xac, 0xb4 }); 

            if (NonUnicodeToUnicodeUtility.ConvertNonUnicodeToUnicode(57002, demo2SourceFilePath, demo2targetFilePath))
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
           
            string demo3SourceFilePath = @"H:\WA\Scripts\Demos\Marathi DV font\marathi.txt";
            string demo3targetFilePath = @"H:\WA\Scripts\Demos\Marathi DV font\marathiUnicode.txt";

           var setCode31 = CharacterSetCodeUtility.GetCharacterSetCode(demo3SourceFilePath);
           if (NonUnicodeToUnicodeUtility.ConvertNonUnicodeToUnicode(57002, demo3SourceFilePath, demo3targetFilePath))
           {
               Console.WriteLine("Conversion is successful!");
           }
           else
           {
               Console.WriteLine("Conversion is failed!");
           }
           
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

           Console.Read();
           */
        }
    }
}
