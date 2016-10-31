using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SilEncConverters40;

namespace SILConvertersWordML
{
    public static class ConverterFactory
    {
        private static UnicodeConverters xmlUnicodeConverters;
               

        public static void initialize()
        {
            // read the xml file, have the XMLUnicodeConverters object populated

            string xml = File.ReadAllText(@"D:\file.xml"); // TBD Path storage
            var catalog1 = xml.ParseXML<UnicodeConverters>();
        }

        public static DirectableEncConverter GetConverter(ConverterRequest converterRequest)
        {
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

                //xmlUnicodeConverters.Converter.Where(x => x.ConverterType == ConverterType.TEC)
            }
            catch (Exception exception)
            {
                // log the  exception
            }

            return new DirectableEncConverter();
        }
    }
}
