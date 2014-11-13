using System;
using System.Xml.Serialization;

namespace MirthConnectFX.Model
{
    [Serializable]
    public class Transformer
    {
        [XmlElement("steps")]
        public object Steps { get; set; }
        [XmlElement("inboundTemplate")]
        public string InboundTemplate { get; set; }
        [XmlElement("outboundTemplate")]
        public string OutboundTemplate { get; set; }
        [XmlElement("inboundProtocol")]
        public string InboundProtocol { get; set; }
        [XmlElement("outboundProtocol")]
        public string OutboundProtocol { get; set; }
        [XmlArray("inboundProperties"), XmlArrayItem("property")]
        public Property[] InboundProperties { get; set; }
        [XmlArray("outboundProperties"), XmlArrayItem("property")]
        public Property[] OutboundProperties { get; set; }
    }
}