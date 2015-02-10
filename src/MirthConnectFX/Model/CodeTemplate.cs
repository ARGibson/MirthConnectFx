using System;
using System.Xml.Serialization;

namespace MirthConnectFX.Model
{
    [Serializable, XmlRoot("codeTemplate")]
    public class CodeTemplate
    {
        [XmlElement("id")]
        public string Id { get; set; }
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("code")]
        public string Code { get; set; }
        [XmlElement("type")]
        public string Type { get; set; }
        [XmlElement("scope")]
        public string Scope { get; set; }
        [XmlElement("version")]
        public string Version { get; set; }
    }
}