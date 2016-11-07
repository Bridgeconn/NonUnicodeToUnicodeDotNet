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

          IEncConverter aec =  aECs.InstantiateIEncConverter("SilEncConverters40.TecEncConverter", null);
            ConvType conversionType = ConvType.Legacy_to_from_Unicode;
            string lhs = "SD708";
            string rhs = "Unicode";
            int pt = (int)ProcessTypeFlags.UnicodeEncodingConversion;
            aec.Initialize("S_D_708<>Unicode", "SD708.tec", ref lhs, ref rhs,ref conversionType, ref pt, 0, 0, false);
                      
            //// Add TECkit tec file generated from the map file
            //aECs.Add("S_D_708<>Unicode", "SD708.tec", ConvType.Legacy_to_from_Unicode, "SD708", "UNICODE", ProcessTypeFlags.UnicodeEncodingConversion);

            //// Get a reference to the converter
            //IEncConverter conv = aECs.GetMapByName("S_D_708<>Unicode");
      
            //conv.DirectionForward = true;
            //conv.NormalizeOutput = NormalizeFlags.None;

            string strIn = File.ReadAllText(sourceFilePath);
            string strOut = aec.Convert(strIn);
            File.WriteAllText(targetFilePath, strOut);
            Console.WriteLine("Unicode conversion is completed!");

            return resultStatus;
        }
    }
}