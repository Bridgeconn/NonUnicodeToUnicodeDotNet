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

        private object languageField;

        private string converterTypeField;

        private object converterNameField;

        private object lHEncodingField;

        private object rHEncodingField;

        private object pathField;

        private object toAndFroField;

        private byte idField;

        /// <remarks/>
        public object Language
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
        public object ConverterName
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
        public object LHEncoding
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
        public object RHEncoding
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
        public object Path
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
        public object ToAndFro
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
