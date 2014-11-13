using System;
using System.Xml.Serialization;

namespace MirthConnectFX.Model
{
    [Serializable]
    public class Entry
    {
        [XmlArrayItem("string")]
        public string[] Strings { get; set; }
    }
}