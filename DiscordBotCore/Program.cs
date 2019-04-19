using System.Threading.Tasks;

namespace DiscordBotCore
{
    class Program
    {
        private static async Task Main()
        {
            Unity.RegisterTypes();
            await Unity.Resolve<DiscordBot>().Run();
        }
    }
}
