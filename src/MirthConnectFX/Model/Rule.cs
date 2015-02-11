using System;
using System.Xml.Serialization;

namespace MirthConnectFX.Model
{
    [Serializable]
    public class Rule
    {
        [XmlElement("sequenceNumber")]
        public byte SequenceNumber { get; set; }
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("data")]
        public HashMapData Data { get; set; }
        [XmlElement("type")]
        public string Type { get; set; }
        [XmlElement("script")]
        public string Script { get; set; }
        [XmlElement("operator")]
        public string Operator { get; set; }
    }
}