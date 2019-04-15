﻿using Discord;
using Discord.WebSocket;

namespace DiscordBotCore.Discord
{
    class SocketConfigCreator
    {
        public static DiscordSocketConfig GetDefault()
        {
            return new DiscordSocketConfig {

                LogLevel = LogSeverity.Debug,


            };
        }

        public static DiscordSocketConfig GetNew()
        {
            return new DiscordSocketConfig();        
        }
    }
}
