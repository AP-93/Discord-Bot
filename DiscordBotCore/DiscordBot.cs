using DiscordBotCore.Discord;
using DiscordBotCore.Discord.Commands;
using DiscordBotCore.Discord.Entities;
using DiscordBotCore.Storage;
using System;
using System.Threading.Tasks;

namespace DiscordBotCore
{
     class DiscordBot
    {
        private readonly IConnection _connection;
        private readonly ICommandHandler _commandHandler;

        public DiscordBot(IConnection connection, ICommandHandler commandHandler )
        {
            _connection = connection;
            _commandHandler = commandHandler;
        }

        public async Task Run()
        {
            await _connection.ConnectAsync(new BotConfig
            {
                Token = "enter token",
            });

            await _commandHandler.InstallCommandsAsync();
            await Task.Delay(-1);
        }
    }
}
