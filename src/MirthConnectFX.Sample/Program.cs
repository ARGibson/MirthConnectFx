using System;
using System.IO;
using System.Net;
using System.Xml.Serialization;
using MirthConnectFX.Model;

namespace MirthConnectFX.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, errors) => true;
            
            var client = new MirthConnectClient();
            
            var session = client.Login("admin", "admin", "0.0.0");
            Console.WriteLine(session.SessionID);
            Console.WriteLine(session.Version);

            var summary = client.Channels.GetChannelSummary();
            Console.Write(summary);

            var channelFile = File.ReadAllText(@"..\..\..\..\lib\FX Test Channel.xml");

            var xmlSerializer = new XmlSerializer(typeof(Channel));
            var channel = (Channel)xmlSerializer.Deserialize(new StringReader(channelFile));

            var result = client.Channels.Update(channel);

            Console.Read();
        }
    }
}
