using System;
using System.Xml.Serialization;

namespace MirthConnectFX.Model
{
    [Serializable]
    public class Connector
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlArray("properties"), XmlArrayItem("property")]
        public PropertyList Properties { get; set; }
        [XmlElement("transformer")]
        public Transformer Transformer { get; set; }
        [XmlElement("filter")]
        public Filter Filter { get; set; }
        [XmlElement("transportName")]
        public string TransportName { get; set; }
        [XmlElement("mode")]
        public string Mode { get; set; }
        [XmlElement("enabled")]
        public bool Enabled { get; set; }
        [XmlElement("version")]
        public string Version { get; set; }
    }
}