using DiscordBotCore.Fortnite;
using System.Threading.Tasks;

namespace DiscordBotCore
{
    class Program
    {
        private static async Task Main()
        {
            Unity.RegisterTypes();
            //var a = Unity.Resolve<PlayersOnlineInfo>();
            await Unity.Resolve<DiscordBot>().Run();
        }
    }
}
