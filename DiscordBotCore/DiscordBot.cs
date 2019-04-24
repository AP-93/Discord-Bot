using DiscordBotCore.Discord;
using DiscordBotCore.Discord.Commands;
using DiscordBotCore.Discord.Entities;
using DiscordBotCore.Storage;
using DiscordBotCore.Storage.Implementations;
using System.Threading.Tasks;

namespace DiscordBotCore
{
     class DiscordBot
    {
        private readonly IConnection _connection;
        private readonly ICommandHandler _commandHandler;
        private readonly IDataStorage _dataStorage;

        public DiscordBot(IConnection connection, ICommandHandler commandHandler, IDataStorage dataStorage)
        {
            _connection = connection;
            _commandHandler = commandHandler;
            _dataStorage = dataStorage;
        }

        public async Task Run()
        {
           
            await _connection.ConnectAsync(new BotConfig
            {
                Token = _dataStorage.RestoreToken().token,
            });

            await _commandHandler.InstallCommandsAsync();
            await Task.Delay(-1);
        }
    }
}
