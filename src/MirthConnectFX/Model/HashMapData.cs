using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace MirthConnectFX.Model
{
    [Serializable]
    public class HashMapData
    {
        [XmlAttribute("class")]
        public string Class { get; set; }

        [XmlElement("entry")]
        public List<StringHashMapEntry> Entries { get; set; }
    }
}