using System;
using System.IO;
using System.Text;
using SilEncConverters40;
using ECInterfaces;

namespace NonUnicodetoUnicodeTool
{
    public static class NonUnicodeToUnicodeUtility
    {
      public static string Convert()
        {
            string resultStatus = string.Empty;

            // Get an instance of the repository object
            EncConverters aECs = new EncConverters();

            // Add Ticket tec file generated from the map file
            aECs.Add("DV_SHREE<>UNICODE", @"H:\WA\Scripts\Marathi NU - U\Font Study\Untitled.tec", ConvType.Legacy_to_from_Unicode, "DV_ME_80", "UNICODE", ProcessTypeFlags.NonUnicodeEncodingConversion);

            // Get a reference to the converter
            IEncConverter conv = aECs.GetMapByName("DV_SHREE<>UNICODE");

            string strIn = "ZàÐmàwÂàà - ¥§ý âkwÞm §ýnà";
            string strOut = conv.Convert(strIn);
            File.WriteAllText(@"H:\Test.txt", strOut);
            Console.WriteLine(String.Format("'{1}' became '{0}'", strOut, strIn));

            return resultStatus;
        }
    }
}