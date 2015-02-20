using System;
using System.Globalization;
using System.Xml.Serialization;

namespace MirthConnectFX.Model
{
    [Serializable]
    public class MirthDateTime
    {
        [XmlElement("time")]
        public ulong Time { get; set; }
        [XmlElement("timezone")]
        public string Timezone { get; set; }
    }
}