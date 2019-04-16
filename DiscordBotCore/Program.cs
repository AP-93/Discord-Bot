using System;
using System.Threading.Tasks;

namespace DiscordBotCore
{
    class Program
    {
        private static async Task Main()
        {
            Unity.RegisterTypes();
            Console.WriteLine("Hello World!");

            await Unity.Resolve<DiscordBot>().Run();

            //var playerStats = Unity.Resolve<ApiWebRequest>();
           // await playerStats.GetPlayerIdAsync("PuljEz");

        }
    }
}
