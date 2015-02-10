using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace MirthConnectFX.Model
{
    [Serializable, XmlRoot("transformer")]
    public class Transformer
    {
        [XmlArray("steps"), XmlArrayItem("step")]
        public Step[] Steps { get; set; }

        [XmlElement("inboundTemplate")]
        public string InboundTemplate { get; set; }

        [XmlElement("outboundTemplate")]
        public string OutboundTemplate { get; set; }

        [XmlElement("inboundProtocol")]
        public string InboundProtocol { get; set; }

        [XmlElement("outboundProtocol")]
        public string OutboundProtocol { get; set; }

        [XmlArray("inboundProperties"), XmlArrayItem("property")]
        public List<Property> InboundProperties { get; set; }

        [XmlArray("outboundProperties"), XmlArrayItem("property")]
        public List<Property> OutboundProperties { get; set; }
    }
}