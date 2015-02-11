using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace MirthConnectFX.Model
{
    [Serializable, XmlRoot("serverConfiguration")]
    public class ServerConfiguration
    {
        [XmlElement("channels")]
        public List<Channel> Channels { get; set; }

        [XmlElement("codeTemplates")]
        public List<CodeTemplate> CodeTemplates { get; set; }

        [XmlElement("globalScripts")]
        public List<StringHashMapEntry> GlobalScripts { get; set; }
    }
}