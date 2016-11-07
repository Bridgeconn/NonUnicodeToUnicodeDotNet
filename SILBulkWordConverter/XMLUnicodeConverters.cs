using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILConvertersWordML
{

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.bridgeconn.com/computing/schemas/UnicodeConverters.xsd")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.bridgeconn.com/computing/schemas/UnicodeConverters.xsd", IsNullable = false)]
    public partial class UnicodeConverters
    {

        private UnicodeConvertersConverter[] converterField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Converter")]
        public UnicodeConvertersConverter[] Converter
        {
            get
            {
                return this.converterField;
            }
            set
            {
                this.converterField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.bridgeconn.com/computing/schemas/UnicodeConverters.xsd")]
    public partial class UnicodeConvertersConverter
    {

        private string languageField;

        private string converterTypeField;

        private string converterNameField;

        private string lHEncodingField;

        private string rHEncodingField;

        private string pathField;

        private string toAndFroField;

        private byte idField;

        /// <remarks/>
        public string Language
        {
            get
            {
                return this.languageField;
            }
            set
            {
                this.languageField = value;
            }
        }

        /// <remarks/>
        public string ConverterType
        {
            get
            {
                return this.converterTypeField;
            }
            set
            {
                this.converterTypeField = value;
            }
        }

        /// <remarks/>
        public string ConverterName
        {
            get
            {
                return this.converterNameField;
            }
            set
            {
                this.converterNameField = value;
            }
        }

        /// <remarks/>
        public string LHEncoding
        {
            get
            {
                return this.lHEncodingField;
            }
            set
            {
                this.lHEncodingField = value;
            }
        }

        /// <remarks/>
        public string RHEncoding
        {
            get
            {
                return this.rHEncodingField;
            }
            set
            {
                this.rHEncodingField = value;
            }
        }

        /// <remarks/>
        public string Path
        {
            get
            {
                return this.pathField;
            }
            set
            {
                this.pathField = value;
            }
        }

        /// <remarks/>
        public string ToAndFro
        {
            get
            {
                return this.toAndFroField;
            }
            set
            {
                this.toAndFroField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }



}
