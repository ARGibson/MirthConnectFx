using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace MirthConnectFX.Utility
{
    public static class XmlExtensions
    {
        public static string ToXml(this object source)
        {
            var stream = new MemoryStream();
            var settings = new XmlWriterSettings
            {
                OmitXmlDeclaration = true,
                ConformanceLevel = ConformanceLevel.Auto,
                Indent = true
            };

            using (var writer = XmlTextWriter.Create(stream, settings))
            {
                new XmlSerializer(source.GetType()).Serialize(writer, source);
                var output = Encoding.UTF8.GetString(stream.ToArray());

                return output.Replace("﻿<?xml version=\"1.0\" encoding=\"utf-8\"?>", string.Empty);
            }
        }

        public static string ToXmlCollection(this IEnumerable<string> source, string collectionType = "list")
        {
            var sb = new StringBuilder(string.Format("<{0}>", collectionType));
            foreach (var item in source)
                sb.AppendFormat("<string>{0}</string>", item);

            sb.AppendFormat("</{0}>", collectionType);

            return sb.ToString();
        }

        public static TOutput ToObject<TOutput>(this string source)
        {
            var xmlSerializer = new XmlSerializer(typeof(TOutput));
            return (TOutput)xmlSerializer.Deserialize(new StringReader(source));
        }
    }

    public class MirthXmlTextWriter : XmlTextWriter
    {
        public MirthXmlTextWriter(Stream stream) : base(stream, Encoding.UTF8)
        {

        }

        public static XmlWriter CreateWriter(Stream stream, XmlWriterSettings settings)
        {
            return Create(new MirthXmlTextWriter(stream), settings);
        }

        public override void WriteEndElement()
        {
            base.WriteFullEndElement();
        }
    }
}