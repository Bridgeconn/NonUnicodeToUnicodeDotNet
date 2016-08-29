using System;
using System.IO;
using System.Text;

namespace NonUnicodetoUnicodeTool
{
    public static class NonUnicodeToUnicodeUtility
    {
        public static bool ConvertNonUnicodeToUnicode(int characterSetCode, string nonUnicodeTxtFilePath, string unicodeTxtFilePath)
        {
            bool isSuccesfull;
            try
            {
                string extension = Path.GetExtension(unicodeTxtFilePath).ToLower();

                if (extension == ".txt")
                {
                    // Specify the code page to correctly interpret byte values
                    Encoding encoding = Encoding.GetEncoding(characterSetCode);

                    // Read bytes from the non-unicode file
                    byte[] codePageValues = File.ReadAllBytes(nonUnicodeTxtFilePath);

                    // Same content is now encoded as UTF-16
                    string unicodeValues = encoding.GetString(codePageValues);

                    // Write the unicode txt file as UTF-8
                    File.WriteAllText(unicodeTxtFilePath, unicodeValues, Encoding.UTF8);
                }
                else if (extension == ".rtf")
                {
                    // Specify the code page to correctly interpret byte values
                    Encoding encoding = Encoding.GetEncoding(characterSetCode);

                    var file = new StreamReader(nonUnicodeTxtFilePath);
                    string line;
                    var sb = new StringBuilder();

                    // Read from the non-unicode file
                    while ((line = file.ReadLine()) != null)
                    {
                        // Read bytes from the non-unicode file and encode
                        byte[] codePageValues = Encoding.Convert(encoding, Encoding.UTF8, StringAndBytesUtility.GetBytes(line));
                        sb.AppendLine(Encoding.UTF8.GetString(codePageValues));
                    }

                    file.Close();

                    // Write the encoded strings to a new file
                    var rtfFile = new System.IO.StreamWriter(unicodeTxtFilePath);
                    using (StringReader reader = new StringReader(sb.ToString()))
                    {
                        while ((line = reader.ReadLine()) != null)
                        {
                            rtfFile.WriteLine(line);
                        }
                    }

                    rtfFile.Close();
                }

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