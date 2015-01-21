using System;
using System.Xml.Serialization;

namespace MirthConnectFX.Model
{
    [Serializable, XmlRoot("channelStatus")]
    public class ChannelStatus
    {
        [XmlElement("channelId")]
        public string ChannelId             { get; set; }
        [XmlElement("name")]
        public string Name                  { get; set; }
        [XmlElement("state")]
        public string State                 { get; set; }
        [XmlElement("deployedRevisionDelta")]
        public int DeployedRevisionDelta    { get; set; }
        [XmlElement("deployedDate")]
        public MirthDateTime DeployedDate   { get; set; }
    }
}