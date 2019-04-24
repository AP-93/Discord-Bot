namespace DiscordBotCore.Storage.Implementations
{
    public class FotrniteTrackerApi
    {
        public string key { get; set; }
        public string value { get; set; }
    }

    public class FortniteApi
    {
        public string key { get; set; }
        public string value { get; set; }
    }

    public class AuthToken
    {
        public string token { get; set; }
        public FotrniteTrackerApi fotrniteTrackerApi { get; set; }
        public FortniteApi fortniteApi { get; set; }
    }
}
