using DiscordBotCore.Discord;
using DiscordBotCore.Discord.Entities;
using System;

namespace DiscordBotCore
{
    class Program
    {
        private static void Main()
        {
            Unity.RegisterTypes();
            Console.WriteLine("Hello World!");

            var discordBotConfig = new BotConfig {

                Token = "",
                SocketConfig = SocketConfigCreator.GetDefault()

            };
            var connection = Unity.Resolve<Connection>();
        }
    }
}
