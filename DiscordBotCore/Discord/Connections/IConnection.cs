using DiscordBotCore.Discord.Entities;
using System.Threading.Tasks;

namespace DiscordBotCore.Discord
{
    interface IConnection
    {
        Task ConnectAsync(BotConfig config);
    }
}
