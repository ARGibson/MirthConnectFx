using System;
using System.Xml.Serialization;

namespace MirthConnectFX.Model
{
    [Serializable, XmlRoot("channelSummary")]
    public class ChannelSummary
    {
        [XmlElement("id")]
        public string Id { get; set; }
        [XmlElement("added")]
        public bool Added { get; set; }
        [XmlElement("deleted")]
        public bool Deleted { get; set; }
    }
}