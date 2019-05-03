using Discord;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace DiscordBotCore.Discord
{
    interface IGuildOperations
    {
        Task CreateFortChannel(IGuild guild);
        DiscordSocketClient GetDiscordSocketClient();
        SocketTextChannel GetChannel();
        EmbedBuilder GetBuilderl();
        Color GetColor(UInt32 color);
        bool CheckIfVoiceEmpty();
    }
}
