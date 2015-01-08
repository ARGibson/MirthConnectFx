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
            using (var stream = new MemoryStream())
            {
                using (var writer = XmlWriter.Create(stream))
                {
                    new XmlSerializer(source.GetType()).Serialize(writer, source);
                    return Encoding.UTF8.GetString(stream.ToArray());
                }
            }
        }

        public static TOutput ToObject<TOutput>(this string source)
        {
            var xmlSerializer = new XmlSerializer(typeof(TOutput));
            return (TOutput)xmlSerializer.Deserialize(new StringReader(source));
        }
    }
}