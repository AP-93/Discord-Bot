using System.Collections.Generic;

namespace DiscordBotCore.Fortnite.PlayerStats.FortniteApi
{
    public class PlayerID
    {
        public string uid { get; set; }
        public string username { get; set; }
        public List<string> platforms { get; set; }
        public List<string> seasons { get; set; }
    }
}
