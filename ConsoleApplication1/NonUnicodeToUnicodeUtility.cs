using System;
using System.IO;
using System.Text;
using SilEncConverters40;
using ECInterfaces;

namespace NonUnicodetoUnicodeTool
{
    public static class NonUnicodeToUnicodeUtility
    {
      public static string Convert(string fontConversionID, string sourceFilePath, string targetFilePath)
        {
            string resultStatus = string.Empty;

            // Get an instance of the repository object
            EncConverters aECs = new EncConverters();

            // Add Ticket tec file generated from the map file
            aECs.Add("S_D_708<>Unicode", "SD708.tec", ConvType.Legacy_to_from_Unicode, "SD708", "UNICODE", ProcessTypeFlags.NonUnicodeEncodingConversion);

            // Get a reference to the converter
            IEncConverter conv = aECs.GetMapByName("S_D_708<>Unicode");

            string strIn = File.ReadAllText(sourceFilePath);
            string strOut = conv.Convert(strIn);
            File.WriteAllText(targetFilePath, strOut);
            Console.WriteLine("Unicode conversion is completed!");

            return resultStatus;
        }
    }
}