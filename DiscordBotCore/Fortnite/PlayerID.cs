using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordBotCore.Fortnite.PlayerStats
{
    class PlayerID
    {
        public string uid { get; set; }
        public string username { get; set; }
        public List<string> platforms { get; set; }
        public List<string> seasons { get; set; }
    }
}
