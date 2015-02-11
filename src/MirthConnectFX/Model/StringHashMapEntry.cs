using System;
using System.Collections.Generic;
using System.Linq;
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

        [XmlElement("list")]
        public StringHashMapEntryList List { get; set; } 

        public StringHashMapEntry() { }

        public StringHashMapEntry(string key, string value)
        {
            Strings = new List<string>(2);
            Strings.Insert(0,key);
            Strings.Insert(1,value);
        }
    }
}