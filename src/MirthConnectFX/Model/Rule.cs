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
        [XmlArray("data"), XmlArrayItem("entry")]
        public Entry[] Data { get; set; }
        [XmlElement("type")]
        public string Type { get; set; }
        [XmlElement("script")]
        public string Script { get; set; }
        [XmlElement("operator")]
        public string Operator { get; set; }
    }
}