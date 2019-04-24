using DiscordBotCore.Discord.Entities;
using System.Threading.Tasks;

namespace DiscordBotCore.Discord.Connections
{
    interface IConnection
    {
        Task ConnectAsync(BotConfig config);
    }
}
