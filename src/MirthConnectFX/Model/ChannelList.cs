using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace MirthConnectFX.Model
{
    [Serializable, XmlRoot("list")]
    public class ChannelList
    {
        public ChannelList()
        {
            Channels = new List<Channel>();
        }

        [XmlElement("channel")]
        public List<Channel> Channels { get; set; }

        [XmlElement("channelSummary")]
        public List<ChannelSummary> ChannelSummaries { get; set; }

        [XmlElement("channelStatus")]
        public List<ChannelStatus> ChannelStatuses { get; set; } 
    }
}
