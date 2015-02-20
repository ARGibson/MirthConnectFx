using System;
using System.Xml.Serialization;

namespace MirthConnectFX.Model
{
    [Serializable]
    [XmlRoot("list")]
    public class MessageObjectList
    {
        [XmlElement("messageObject")]
        public MessageObject[] MessageObjects { get; set; }
    }
}