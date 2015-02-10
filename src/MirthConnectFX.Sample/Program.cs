using System;
using System.IO;
using System.Linq;
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

            const string channelId = "2b0a4fe9-98c7-44b3-8f66-732dc18a300b";
            var client = MirthConnectClient.Create("https://eml066:443/");
            
            var session = client.Login("admin", "admin", "0.0.0");
            Console.WriteLine("Session Id: {0}, Version: {1}", session.SessionID, session.Version);

            DisplayAllChannelStatus(client);

            var channel = LoadChannelFromFile();

            client.Channels.Update(channel);

            channel = client.Channels.GetChannel(channelId);
            Console.WriteLine("{0} - {1} (Enabled: {2})", channel.Id, channel.Name, channel.Enabled);

            client.Channels.EnableChannel(channelId);

            channel = client.Channels.GetChannel(channelId);
            Console.WriteLine("{0} - {1} (Enabled: {2})", channel.Id, channel.Name, channel.Enabled);

            client.Engine.DeployChannels(new[] { channelId });
            DisplayChannelStatus(client, channelId);

            client.ChannelStatus.StopChannel(channelId);
            DisplayChannelStatus(client, channelId);

            client.ChannelStatus.StartChannel(channelId);
            DisplayChannelStatus(client, channelId);

            client.Engine.UndeployChannels(new[] { channelId });

            Console.Read();
        }

        private static Channel LoadChannelFromFile()
        {
            var channelFile = File.ReadAllText(@"..\..\..\..\lib\FX Test Channel.xml");
            var xmlSerializer = new XmlSerializer(typeof (Channel));
            var channel = (Channel) xmlSerializer.Deserialize(new StringReader(channelFile));
            return channel;
        }

        private static void DisplayAllChannelStatus(IMirthConnectClient client)
        {
            var status = client.ChannelStatus.GetChannelStatus();
            foreach (var channelStatus in status)
                Console.Write("{0}\r\n ({1}) {2}\r\n\r\n", channelStatus.Name, channelStatus.ChannelId, channelStatus.State);
        }

        private static void DisplayChannelStatus(IMirthConnectClient client, string channelId)
        {
            var status = client.ChannelStatus.GetChannelStatus();
            var channel = status.Single(x => x.ChannelId == channelId);

            Console.Write("{0}\r\n ({1}) {2}\r\n\r\n", channel.Name, channel.ChannelId, channel.State);
        }
    }
}
