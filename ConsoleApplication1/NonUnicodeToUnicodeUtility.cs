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
            aECs.Add("DV_SHREE<>UNICODE", "dv_shree.tec", ConvType.Legacy_to_from_Unicode, "DV_ME_80", "UNICODE", ProcessTypeFlags.NonUnicodeEncodingConversion);

            // Get a reference to the converter
            IEncConverter conv = aECs.GetMapByName("DV_SHREE<>UNICODE");

            string strIn = File.ReadAllText(sourceFilePath);
            string strOut = conv.Convert(strIn);
            File.WriteAllText(targetFilePath, strOut);
            Console.WriteLine(String.Format("'{1}' became '{0}'", strOut, strIn));

            return resultStatus;
        }
    }
}