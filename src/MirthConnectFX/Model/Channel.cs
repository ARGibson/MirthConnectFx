using System;
using System.Xml.Serialization;

namespace MirthConnectFX.Model
{
    [Serializable, XmlRoot("channel")]
    public class Channel
    {
        [XmlElement("id")]
        public string            Id                     { get; set; }
        [XmlElement("name")]
        public string            Name                   { get; set; }
        [XmlElement("description")]
        public string            Description            { get; set; }
        [XmlElement("enabled")]
        public bool              Enabled                { get; set; }
        [XmlElement("version")]
        public string            Version                { get; set; }
        [XmlElement("lastModified")]
        public MirthDateTime     LastModified           { get; set; }
        [XmlElement("revision")]
        public string            Revision               { get; set; }
        [XmlElement("sourceConnector")]
        public Connector         SourceConnector { get; set; }
        [XmlArray("destinationConnectors"), XmlArrayItem("connector")]
        public Connector[]       DestinationConnectors  { get; set; }
        [XmlArray("properties"), XmlArrayItem("property")]
        public PropertyList     Properties { get; set; }
        [XmlElement("preprocessingScript")]
        public string            PreprocessingScript    { get; set; }
        [XmlElement("postprocessingScript")]
        public string            PostprocessingScript   { get; set; }
        [XmlElement("deployScript")]
        public string            DeployScript           { get; set; }
        [XmlElement("shutdownScript")]
        public string            ShutdownScript         { get; set; }
    }
}