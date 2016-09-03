using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace UnitTestLibrary
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}

    /*
    TEST CASE: NEED TO MOVE!!
    
    // FOR TEST: Create a file that contains the Greek work ψυχή (psyche) when interpreted by using 
    code page 737 ((DOS) Greek). You can also create the file by using Character Map 
    to paste the characters into Microsoft Word and then "Save As" by using the DOS
    (Greek) encoding. (Word will actually create a six-byte file by appending "\r\n" at the end.)
    System.IO.File.WriteAllBytes(nonUnicodeTxtFilePath, new byte[] { 0xAF, 0xAC, 0xAE, 0x9E });
    
    The word 'red' in Marathi
    System.IO.File.WriteAllBytes(nonUnicodeTxtFilePath, new byte[] { 0x72, 0x65, 0x64 });

    // Show that the text content is still intact in Unicode string
    // (Add a reference to System.Windows.Forms.dll)
    //System.Windows.Forms.MessageBox.Show(unicodeValues);

    // Same content "ψυχή" is stored as UTF-8
     */


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
