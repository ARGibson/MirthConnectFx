using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace MirthConnectFX.Model
{
    [XmlRoot("messageObjectFilter")]
    public class MessageObjectFilter
    {
        [XmlElement("id")]
        public string Id { get; set; }
        [XmlElement("correlationId")]
        public string CorrelationId { get; set; }
        [XmlElement("channelId")]
        public string ChannelId { get; set; }
        [XmlElement("startDate")]
        public MirthDateTime StartDate { get; set; }
        [XmlElement("endDate")]
        public MirthDateTime EndDate { get; set; }
        [XmlElement("status")]
        public Status? Status { get; set; }
        [XmlElement("source")]
        public string Source { get; set; }
        [XmlElement("connectorName")]
        public string ConnectorName { get; set; }
        [XmlElement("searchRowData")]
        public bool? SearchRowData { get; set; }
        [XmlElement("searchTransformedData")]
        public bool? SearchTransformedData { get; set; }
        [XmlElement("searchEncodedData")]
        public bool? SearchEncodedData { get; set; }
        [XmlElement("searchErrors")]
        public bool? SearchErrors { get; set; }
        [XmlElement("quickSearch")]
        public string QuickSearch { get; set; }
        [XmlElement("searchCriteria")]
        public string SearchCriteria { get; set; }
        [XmlElement("type")]
        public string Type { get; set; }
        [XmlElement("protocol")]
        public Protocol? Protocol { get; set; }
        [XmlElement("ignoreQueued")]
        public bool? IgnoreQueued { get; set; }
        [XmlArray("channelIdList"), XmlArrayItem("string")]
        public List<string> ChannelIdList { get; set; }

        public MessageObjectFilter()
        {
            ChannelIdList = new List<string>();
        }

        public bool ShouldSerializeStatus()
        {
            return Status.HasValue;
        }

        public bool ShouldSerializeSearchRowData()
        {
            return SearchRowData.HasValue;
        }

        public bool ShouldSerializeSearchTransformedData()
        {
            return SearchTransformedData.HasValue;
        }

        public bool ShouldSerializeSearchEncodedData()
        {
            return SearchEncodedData.HasValue;
        }

        public bool ShouldSerializeSearchErrors()
        {
            return SearchErrors.HasValue;
        }

        public bool ShouldSerializeProtocol()
        {
            return Protocol.HasValue;
        }

        public bool ShouldSerializeIgnoreQueued()
        {
            return IgnoreQueued.HasValue;
        }

        public bool ShouldSerializeChannelIdList()
        {
            return ChannelIdList.Any();
        }
    }

    public enum Status
    {
        UNKNOWN, RECEIVED, ACCEPTED, FILTERED, TRANSFORMED, ERROR, SENT, QUEUED
    }

    public enum Protocol
    {
        HL7V2, X12, XML, HL7V3, EDI, NCPDP, DICOM, DELIMITED
    }
}