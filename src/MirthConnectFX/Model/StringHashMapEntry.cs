using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Xml.Serialization;

namespace MirthConnectFX.Model
{
    [Serializable, XmlRoot("entry")]
    public class StringHashMapEntry
    {
        [XmlIgnore]
        public string Key
        {
            get { return Strings.FirstOrDefault(); }
        }

        [XmlIgnore]
        public string Value
        {
            get { return Strings.LastOrDefault(); }
        }
        
        [XmlElement("string")]
        public List<string> Strings { get; set; }

        public StringHashMapEntry() { }

        public StringHashMapEntry(string key, string value)
        {
            Strings[0] = key;
            Strings[1] = value;
        }

        public StringHashMapEntry Encode()
        {
            if (Strings == null)
                return this;

            //Strings[1] = Value.Replace("'", "&apos;");

            return this;
        }
    }
}