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
            // read the xml file, have the XMLUnicodeConverters object populated

            string xml = File.ReadAllText(@"D:\file.xml"); // TBD Path storage
            var catalog1 = xml.ParseXML<UnicodeConverters>();
        }

        public static DirectableEncConverter GetConverter(ConverterRequest converterRequest)
        {
            DirectableEncConverter directableEncConverter = null;
            try
            {
                if (xmlUnicodeConverters == null)
                {
                    initialize();
                }

                /* Based on the converterRequest 
                *  1) read from the XMLUnicodeConverters
                *  2) Instantiate and return the DirectableEncConverter  
                */

                //xmlUnicodeConverters.Converter.Where(x => x.ConverterType == ConverterType.TEC.ToString())

                IEncConverter encConverter = null;

                // check if the required converter has been already instantiated.

                // Else create one from the information provided

                foreach (UnicodeConvertersConverter unicodeConverter in xmlUnicodeConverters.Converter)
                {
                    if ((converterRequest.LHEncodingField == unicodeConverter.LHEncoding && converterRequest.RHEncodingField == unicodeConverter.RHEncoding)
                        || (converterRequest.RHEncodingField == unicodeConverter.LHEncoding && converterRequest.LHEncodingField == unicodeConverter.RHEncoding))
                    {
                        EncConverters aECs = new EncConverters();
                        encConverter = aECs.InstantiateIEncConverter("SilEncConverters40.TecEncConverter", null);
                        ConvType conversionType = ConvType.Legacy_to_from_Unicode;
                        string lhs = (converterRequest.LHEncodingField == unicodeConverter.LHEncoding) ? converterRequest.LHEncodingField : converterRequest.RHEncodingField; //"SD708";
                        string rhs = (converterRequest.RHEncodingField == unicodeConverter.RHEncoding) ? converterRequest.RHEncodingField : converterRequest.LHEncodingField; //"Unicode";
                        int pt = (int)((converterRequest.LHEncodingField != "Unicode") ? ProcessTypeFlags.UnicodeEncodingConversion : ProcessTypeFlags.NonUnicodeEncodingConversion);
                        encConverter.Initialize(unicodeConverter.ConverterName, unicodeConverter.Path, ref lhs, ref rhs, ref conversionType, ref pt, 0, 0, false);
                        directableEncConverter = new DirectableEncConverter(encConverter);
                        break;
                    }
                }

                
            }
            catch (Exception exception)
            {
                // log the  exception
            }

            return directableEncConverter;
        }
    }
}
