using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordBotCore.Discord.Entities
{
    //holds info about bot and its behaviour
    class BotConfig
    {
        public string Token { get; set; }
        public DiscordSocketConfig SocketConfig { get; set; }
    }
}
