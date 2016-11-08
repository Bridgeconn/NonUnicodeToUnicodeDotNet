using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SilEncConverters40;
using ECInterfaces;

namespace SILConvertersWordML
{
    public static class ConverterFactory
    {
        private static Dictionary<string, object> unicodeConverters;
        private static UnicodeConverters xmlUnicodeConverters;


        public static bool IsLoaded
        {
            get
            {
                return (xmlUnicodeConverters != null);
            }
        }

        public static void initialize()
        {
            unicodeConverters = new Dictionary<string, object>();

            // read the xml file, have the XMLUnicodeConverters object populated

            string xml = File.ReadAllText(@"D:\file.xml"); // TBD Path storage
            var catalog1 = xml.ParseXML<UnicodeConverters>();
        }

        ///  Based on the converterRequest 
        ///  1) read from the XMLUnicodeConverters
        ///  2) Instantiate and return the DirectableEncConverter  
        public static IEncConverter GetConverter(ConverterRequest converterRequest)
        {
            IEncConverter encConverter = null;
            bool isFound = false;
            string key1 = string.Empty, key2 = string.Empty;

            try
            {
                if (xmlUnicodeConverters == null)
                {
                    initialize();
                }
                else    // check if the required converter has been already instantiated.
                {
                    string key = converterRequest.LHEncodingField + ":" + converterRequest.RHEncodingField;
                    if (unicodeConverters.Keys.Contains(key))
                    {
                        return unicodeConverters[key] as IEncConverter;
                    }
                }

                // Else create one from the information provided
                foreach (UnicodeConvertersConverter unicodeConverter in xmlUnicodeConverters.Converter)
                {
                    if (unicodeConverter.ToAndFro == "True")
                    {
                        if ((converterRequest.LHEncodingField == unicodeConverter.LHEncoding && converterRequest.RHEncodingField == unicodeConverter.RHEncoding)
                            || (converterRequest.RHEncodingField == unicodeConverter.LHEncoding && converterRequest.LHEncodingField == unicodeConverter.RHEncoding))
                        {
                            key1 = converterRequest.LHEncodingField + ":" + converterRequest.RHEncodingField;
                            key2 = converterRequest.RHEncodingField + ":" + converterRequest.LHEncodingField;
                            isFound = true;
                        }
                    }
                    else if ((converterRequest.LHEncodingField == unicodeConverter.LHEncoding && converterRequest.RHEncodingField == unicodeConverter.RHEncoding))
                    {
                        key1 = converterRequest.LHEncodingField + ":" + converterRequest.RHEncodingField;
                        isFound = true;
                    }

                    if (isFound)
                    {
                        if (converterRequest.ConverterType == ConverterType.TEC)
                        {
                            EncConverters aECs = new EncConverters();
                            IEncConverter tecConverter = aECs.InstantiateIEncConverter("SilEncConverters40.TecEncConverter", null);
                            ConvType conversionType = ConvType.Legacy_to_from_Unicode;
                            string lhs = (converterRequest.LHEncodingField == unicodeConverter.LHEncoding) ? converterRequest.LHEncodingField : converterRequest.RHEncodingField; //"SD708";
                            string rhs = (converterRequest.RHEncodingField == unicodeConverter.RHEncoding) ? converterRequest.RHEncodingField : converterRequest.LHEncodingField; //"Unicode";
                            int pt = (int)((converterRequest.LHEncodingField != "Unicode") ? ProcessTypeFlags.UnicodeEncodingConversion : ProcessTypeFlags.NonUnicodeEncodingConversion);
                            tecConverter.Initialize(unicodeConverter.ConverterName, unicodeConverter.Path, ref lhs, ref rhs, ref conversionType, ref pt, 0, 0, false);
                            encConverter = new DirectableEncConverter(tecConverter) as IEncConverter;
                        }
                        else if (converterRequest.ConverterType == ConverterType.CP) // TBD 
                        {
                            encConverter = new CpEncConverter();
                        }

                        if (!unicodeConverters.Keys.Contains(key1))
                        {
                            unicodeConverters.Add(key1, encConverter);
                        }

                        if (key2 != string.Empty && !unicodeConverters.Keys.Contains(key2))
                        {
                            unicodeConverters.Add(key2, encConverter);
                        }

                        break;
                    }
                }
            }
            catch (Exception exception)
            {
                // log the  exception
            }

            return encConverter;
        }
    }
}
