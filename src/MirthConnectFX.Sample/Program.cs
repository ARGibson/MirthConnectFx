using System;
using System.Net;

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

            Console.Read();
        }
    }
}
