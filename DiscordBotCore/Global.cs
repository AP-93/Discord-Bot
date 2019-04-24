using Discord.WebSocket;
using DiscordBotCore.Storage;

namespace DiscordBotCore
{
    internal static class Global
    {
        internal static DiscordSocketClient Client { get; set; } 
        internal static IDataStorage dataStorage { get; set; }
    }
}

