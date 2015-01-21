using System.Collections.Generic;
using System.Drawing;
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
            using (var writer = XmlWriter.Create(stream))
            {
                new XmlSerializer(source.GetType()).Serialize(writer, source);
                return Encoding.UTF8.GetString(stream.ToArray());
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
}