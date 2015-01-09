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

            var client = MirthConnectClient.Create("https://localhost:8443/");
            
            var session = client.Login("admin", "admin", "0.0.0");
            Console.WriteLine(session.SessionID);
            Console.WriteLine(session.Version);

            var summary = client.Channels.GetChannelSummary();
            foreach (var channelSummary in summary)
                Console.WriteLine("{0}", channelSummary.Id);

            var channelFile = File.ReadAllText(@"..\..\..\..\lib\FX Test Channel.xml");

            var xmlSerializer = new XmlSerializer(typeof(Channel));
            var channel = (Channel)xmlSerializer.Deserialize(new StringReader(channelFile));

            client.Channels.Update(channel);
            
            var channel2 = client.Channels.GetChannel("2b0a4fe9-98c7-44b3-8f66-732dc18a300b");
            Console.WriteLine("{0} - {1} ({2})", channel2.Id, channel2.Name, channel2.Enabled);

            client.Channels.EnableChannel("2b0a4fe9-98c7-44b3-8f66-732dc18a300b");

            var channel3 = client.Channels.GetChannel("2b0a4fe9-98c7-44b3-8f66-732dc18a300b");
            Console.WriteLine("{0} - {1} ({2})", channel3.Id, channel3.Name, channel3.Enabled);

            Console.Read();
        }
    }
}
