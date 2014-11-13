using System;
using System.Xml.Serialization;

namespace MirthConnectFX.Model
{
    [Serializable]
    public class Filter
    {
        [XmlArray("rules"), XmlArrayItem("rule")]
        public Rule[] Rules { get; set; }
    }
}