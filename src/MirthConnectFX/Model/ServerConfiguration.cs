using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace MirthConnectFX.Model
{
    [Serializable, XmlRoot("serverConfiguration")]
    public class ServerConfiguration
    {
        public ServerConfiguration ()
        {
            Channels = new List<Channel>();
            CodeTemplates = new List<CodeTemplate>();
            GlobalScripts = new List<StringHashMapEntry>();
        }
        
        [XmlArray("channels"), XmlArrayItem("channel")]
        public List<Channel> Channels { get; set; }

        [XmlArray("codeTemplates"), XmlArrayItem("codeTemplate")]
        public List<CodeTemplate> CodeTemplates { get; set; }

        [XmlArray("globalScripts"), XmlArrayItem("entry")]
        public List<StringHashMapEntry> GlobalScripts { get; set; }
    }
}