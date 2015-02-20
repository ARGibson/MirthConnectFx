using System;
using System.Xml.Serialization;

namespace MirthConnectFX.Model
{
    [Serializable]
    public class MessageObject
    {
        [XmlElement("id")]
        public string Id { get; set; }
        [XmlElement("serverId")]
        public string ServerId { get; set; }
        [XmlElement("channelId")]
        public string ChannelId { get; set; }
        [XmlElement("source")]
        public string Source { get; set; }
        [XmlElement("type")]
        public string Type { get; set; }
        [XmlElement("status")]
        public Status? Status { get; set; }
        [XmlElement("dateCreated")]
        public MirthDateTime DateCreated { get; set; }
        [XmlElement("rawData")]
        public string RawData { get; set; }
        [XmlElement("rawDataProtocol")]
        public Protocol? RawDataProtocol { get; set; }
        [XmlElement("transformedData")]
        public string TransformedData { get; set; }
        [XmlElement("transformedDataProtocol")]
        public Protocol? TransformedDataProtocol { get; set; }
        [XmlElement("encodedData")]
        public string EncodedData { get; set; }
        [XmlElement("encodedDataProtocol")]
        public Protocol? EncodedDataProtocol { get; set; }
        [XmlElement("connectorName")]
        public string ConnectorName { get; set; }
        [XmlElement("encrypted")]
        public bool? Encrypted { get; set; }
        [XmlElement("version")]
        public string Version { get; set; }
        [XmlElement("correlationId")]
        public string CorrelationId { get; set; }
        [XmlElement("attachment")]
        public bool? Attachment { get; set; }
        [XmlElement("connectorMap")]
        public HashMapData ConnectorMap { get; set; }
        [XmlElement("responseMap")]
        public HashMapData ResponseMap { get; set; }
        [XmlElement("channelMap")]
        public HashMapData ChannelMap { get; set; }
        [XmlElement("context")]
        public HashMapData Context { get; set; }

        public MessageObject()
        {
            Status = Model.Status.UNKNOWN;
            ConnectorMap = new HashMapData();
            ResponseMap = new HashMapData();
            ChannelMap = new HashMapData();
            Context = new HashMapData();
        }

        public bool ShouldSerializeStatus() { return Status != null; }
        public bool ShouldSerializeRawDataProtocol() { return RawDataProtocol != null; }
        public bool ShouldSerializeTransformedDataProtocol() { return TransformedDataProtocol != null; }
        public bool ShouldSerializeEncrypted() { return Encrypted.HasValue; }
        public bool ShouldSerializeAttachment() { return Attachment.HasValue; }
        public bool ShouldSerializeEncodedDataProtocol() { return EncodedDataProtocol != null; }
        public bool ShouldSerializeConnectorMap() { return ConnectorMap != null; }
        public bool ShouldSerializeResponseMap() { return ResponseMap != null; }
        public bool ShouldSerializeChannelMap() { return ChannelMap != null; }
        public bool ShouldSerializeContext() { return Context != null; }
    }
}