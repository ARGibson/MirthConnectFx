using System;
using System.Security;
using System.Xml.Serialization;

namespace MirthConnectFX.Model
{
    [Serializable]
    public class Property
    {
        [XmlText]
        public string Value { get; set; }
        
        [XmlAttribute("name")]
        public string Name { get; set; }
    }
}