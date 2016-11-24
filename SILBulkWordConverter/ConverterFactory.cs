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

        public static void LoadConverter(ConverterRequest converterRequest)
        {
            IEncConverter encConverter = null;
            bool isFound = false;

            try
            {
                if (xmlUnicodeConverters == null)
                {
                    initialize();
                }
                else    // check if the required converter has been already instantiated.
                {
                    string key = converterRequest.LHEncodingField;
                    if (unicodeConverters.Keys.Contains(key))
                    {
                        return; // unicodeConverters[key] as IEncConverter;
                    }
                }
             

                if (converterRequest.ConverterType == ConverterType.CP)
                {


                }
                else if (converterRequest.ConverterType == ConverterType.TEC)
                {
                    // Else create one from the information provided
                    foreach (UnicodeConvertersTECConverter unicodeConverter in xmlUnicodeConverters.TECConverters)
                    {
                        string key = converterRequest.LHEncodingField;
                         if (converterRequest.LHEncodingField == unicodeConverter.LHEncoding)
                        {
                            if (unicodeConverter.ToAndFro == "True")
                            {
                                // TBD
                            }
                                isFound = true;
                        }

                        if (isFound)
                        {
                            EncConverters aECs = new EncConverters();
                            IEncConverter tecConverter = aECs.InstantiateIEncConverter("SilEncConverters40.TecEncConverter", null);
                            ConvType conversionType = ConvType.Legacy_to_from_Unicode;
                            string lhs = converterRequest.LHEncodingField; //"SD708";
                            string rhs = converterRequest.RHEncodingField; //"Unicode";
                            int pt = 0;
                            tecConverter.Initialize(unicodeConverter.ConverterName, unicodeConverter.Path, ref lhs, ref rhs, ref conversionType, ref pt, 0, 0, false);
                            encConverter = new DirectableEncConverter(tecConverter) as IEncConverter;

                            if (!unicodeConverters.Keys.Contains(key))
                            {
                                unicodeConverters.Add(key, encConverter);
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
        }

        ///  Based on the converterRequest 
        ///  1) read from the XMLUnicodeConverters
        ///  2) Instantiate and return the DirectableEncConverter  
        public static IEncConverter GetConverter(ConverterRequest converterRequest)
        {
            IEncConverter converter = null;
            try
            {
                if (xmlUnicodeConverters == null)
                {
                    initialize();
                }
                else    // check if the required converter has been already instantiated.
                {
                    string key = converterRequest.LHEncodingField;
                    if (unicodeConverters.Keys.Contains(key))
                    {
                        return unicodeConverters[key] as IEncConverter;
                    }
                }

                LoadConverter(converterRequest);
                    
            }
            catch (Exception exception)
            {
                // log the  exception
            }

            return converter;
        }

        public static bool IsConverterDefined(ConverterRequest converterRequest)
        {
            bool isDefined = false;

            isDefined = unicodeConverters.ContainsKey(converterRequest.LHEncodingField);
            if(!isDefined)
            {
                isDefined = (GetConverter(converterRequest) != null);
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
        public static void DefineConverter(ConverterRequest converterRequest, DirectableEncConverter aEC)
        {
            if (IsConverterDefined(converterRequest))
                encConvertersDictionary.Remove(converterRequest.LHEncodingField);
            encConvertersDictionary.Add(converterRequest.LHEncodingField, aEC);
        }

        public static DirectableEncConverter GetConverter(string strFontName)
        {
            return encConvertersDictionary[strFontName];
        }
    }
}
