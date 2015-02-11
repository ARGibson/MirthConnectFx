using System;
using System.Xml.Serialization;

namespace MirthConnectFX.Model
{
    [Serializable, XmlRoot("map")]
    public class GlobalScripts
    {
        [XmlElement("entry")]
        public StringHashMapEntry[] Entries { get; set; }
    }
}