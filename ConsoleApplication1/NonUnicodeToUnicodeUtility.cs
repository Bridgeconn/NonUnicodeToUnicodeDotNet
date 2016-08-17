using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NonUnicodetoUnicodeTool
{
    public static class NonUnicodeToUnicodeUtility
    {
        public static bool ConvertNonUnicodeToUnicode(int characterSetCode, string nonUnicodeTxtFilePath, string unicodeTxtFilePath)
        {
            bool isSuccesfull;
            try
            {
                // FOR TEST: Create a file that contains the Greek work ψυχή (psyche) when interpreted by using 
                /* code page 737 ((DOS) Greek). You can also create the file by using Character Map 
                to paste the characters into Microsoft Word and then "Save As" by using the DOS
                (Greek) encoding. (Word will actually create a six-byte file by appending "\r\n" at the end.)
                System.IO.File.WriteAllBytes(nonUnicodeTxtFilePath, new byte[] { 0xAF, 0xAC, 0xAE, 0x9E });
                
                Ha Ka La in Marathi
                  System.IO.File.WriteAllBytes(nonUnicodeTxtFilePath, new byte[] { 0xD1, 0xA7, 0xD7 });*/

                // Specify the code page to correctly interpret byte values
                Encoding encoding = Encoding.GetEncoding(characterSetCode); //(DOS) Greek code page
                byte[] codePageValues = System.IO.File.ReadAllBytes(nonUnicodeTxtFilePath);

                // Same content is now encoded as UTF-16
                string unicodeValues = encoding.GetString(codePageValues);

                // Show that the text content is still intact in Unicode string
                // (Add a reference to System.Windows.Forms.dll)
                //System.Windows.Forms.MessageBox.Show(unicodeValues);

                // Same content "ψυχή" is stored as UTF-8
                System.IO.File.WriteAllText(unicodeTxtFilePath, unicodeValues);

                // Conversion is complete. Check the bytes to prove the conversion. 
                /*
                 * Console.WriteLine("8-bit encoding byte values:");
                 foreach (byte b in codePageValues)
                     Console.Write("{0:X}-", b);

                 Console.WriteLine();
                 Console.WriteLine("Unicode values:");
                 string unicodeString = System.IO.File.ReadAllText(unicodeTxtFilePath);
                 System.Globalization.TextElementEnumerator enumerator =
                     System.Globalization.StringInfo.GetTextElementEnumerator(unicodeString);
                 while (enumerator.MoveNext())
                 {
                     string st = enumerator.GetTextElement();
                     int i = Char.ConvertToUtf32(st, 0);
                     Console.Write("{0:X}-", i);
                 }
                 */
                isSuccesfull = true;

            }
            catch (Exception exception)
            {
                isSuccesfull = false;
            }

            return isSuccesfull;
        }
    }
}
