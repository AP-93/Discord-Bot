using DiscordBotCore.Discord;
using DiscordBotCore.Discord.Entities;
using DiscordBotCore.Storage;
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

            var storage = Unity.Resolve<IDataStorage>();

            var connection = Unity.Resolve<Connection>();
            await connection.ConnectAsync(new BotConfig
            {
                Token = storage.RestoreObject<string>("Config/BotToken"),
            } );
        }
    }
}
