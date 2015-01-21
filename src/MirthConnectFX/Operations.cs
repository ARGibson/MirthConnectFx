namespace MirthConnectFX
{
    public static class Operations
    {
        public static class User
        {
            public static string Login { get { return "login"; } }
        }

        public static class Configuration
        {
            public static string GetVerson { get { return "getVersion"; } }
        }

        public static class Channels
        {
            public static string GetChannelSummary { get { return "getChannelSummary"; } }
            public static string GetChannel { get { return "getChannel"; } }
            public static string UpdateChannel { get { return "updateChannel"; } }
        }

        public static class ChannelStatus
        {
            public static string StopChannel { get { return "stopChannel"; } }
        }
    }
}