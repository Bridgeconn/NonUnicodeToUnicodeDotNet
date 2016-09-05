using System.Configuration;

namespace NonUnicodetoUnicodeTool
{
    public class FontConverterConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("fontConverName")]
        public string FontConverName
        {
            get { return (string)this["fontConverName"]; }
            set { this["fontConverName"] = value; }
        }
    }
}
