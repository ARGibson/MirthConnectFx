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
            public static string SetGlobalScripts { get { return "setGlobalScripts"; } }
            public static string GetServerConfiguration { get { return "getServerConfiguration"; } }
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
            public static string StartChannel { get { return "startChannel"; } }
            public static string GetChannelStatus { get { return "getChannelStatusList"; } }
        }

        public static class Engine
        {
            public static string DeployChannels { get { return "deployChannels"; } }
            public static string UndeplyChannels { get { return "undeployChannels"; } }
        }

        public static class CodeTemplates
        {
            public static string UpdateCodeTemplatse { get { return "updateCodeTemplates"; } }
        }

        public static class Messages
        {
            public static string ClearMessages { get { return "clearMessages"; } }
            public static string CreateTempTable { get { return "createMessagesTempTable"; } }
        }
    }
}