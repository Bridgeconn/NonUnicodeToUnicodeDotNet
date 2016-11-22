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
        private static Dictionary<string, DirectableEncConverter> encConvertersDictionary;
        private const string configurationFilePath = @"Converters.xml";

        public static void initialize()
        {
            // read the xml file, have the XMLUnicodeConverters object populated
            if (!IsConfigurationFilePathValid)
            {
                throw (new FileNotFoundException("ConverterFactory's configuration file is not found!"));
            }

            unicodeConverters = new Dictionary<string, object>();
            encConvertersDictionary = new Dictionary<string, DirectableEncConverter>();

            string xml = File.ReadAllText(configurationFilePath); 
            xmlUnicodeConverters = xml.ParseXML<UnicodeConverters>();
        }

        public static bool IsConfigurationFilePathValid
        {
            get
            {
                return File.Exists(configurationFilePath);
            }
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

                if(converterRequest.ConverterType == ConverterType.CP)
                {


                }
                else if(converterRequest.ConverterType == ConverterType.TEC)
                {
                    // Else create one from the information provided
                    foreach (UnicodeConvertersTECConverter unicodeConverter in xmlUnicodeConverters.TECConverters)
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
                            EncConverters aECs = new EncConverters();
                            IEncConverter tecConverter = aECs.InstantiateIEncConverter("SilEncConverters40.TecEncConverter", null);
                            ConvType conversionType = ConvType.Legacy_to_from_Unicode;
                            string lhs = (converterRequest.LHEncodingField == unicodeConverter.LHEncoding) ? converterRequest.LHEncodingField : converterRequest.RHEncodingField; //"SD708";
                            string rhs = (converterRequest.RHEncodingField == unicodeConverter.RHEncoding) ? converterRequest.RHEncodingField : converterRequest.LHEncodingField; //"Unicode";
                            int pt = (int)((converterRequest.LHEncodingField != "Unicode") ? ProcessTypeFlags.UnicodeEncodingConversion : ProcessTypeFlags.NonUnicodeEncodingConversion);
                            tecConverter.Initialize(unicodeConverter.ConverterName, unicodeConverter.Path, ref lhs, ref rhs, ref conversionType, ref pt, 0, 0, false);
                            encConverter = new DirectableEncConverter(tecConverter) as IEncConverter;

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
                    
            }
            catch (Exception exception)
            {
                // log the  exception
            }

            return encConverter;
        }

        public static bool IsConverterDefined(string strFontStyleName)
        {
            bool isDefined = false;

            isDefined = unicodeConverters.ContainsKey(strFontStyleName+":Unicode");
            if(!isDefined)
            {
                isDefined = (GetConverter(new ConverterRequest {  }) != null);
            }

            return isDefined;
        }

        public static bool IsLoaded
        {
            get
            {
                return (xmlUnicodeConverters != null);
            }
        }

        public static EncConverters EncConvertersList
        {
            get
            {
                EncConverters list = new EncConverters();
                foreach(string key in encConvertersDictionary.Keys)
                {
                    list.Add(encConvertersDictionary[key].Name, encConvertersDictionary[key]);
                }

                return  list;
            }
        }

        // This is where the respective EncConverter is mapped for font name
        public static void DefineConverter(string strFontStyleName, DirectableEncConverter aEC)
        {
            if (IsConverterDefined(strFontStyleName))
                encConvertersDictionary.Remove(strFontStyleName);
            encConvertersDictionary.Add(strFontStyleName, aEC);
        }

        public static DirectableEncConverter GetConverter(string strFontName)
        {
            return encConvertersDictionary[strFontName];
        }
    }
}
