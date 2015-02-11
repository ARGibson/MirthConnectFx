using System.Collections.Generic;
using System.Xml.Serialization;

namespace MirthConnectFX.Model
{
    public class StringHashMapEntryList
    {
        [XmlElement("string")]
        public List<string> Strings { get; set; }
    }
}