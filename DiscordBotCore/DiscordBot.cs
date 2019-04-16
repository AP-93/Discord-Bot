using DiscordBotCore.Discord;
using DiscordBotCore.Discord.Entities;
using DiscordBotCore.Storage;
using System.Threading.Tasks;

namespace DiscordBotCore
{
     class DiscordBot
    {
        private readonly IConnection _connection;
        //private readonly ICommandHandler commandHandler;

        public DiscordBot(IConnection connection)
        {
            _connection = connection;
           // this.commandHandler = commandHandler;
        }

        public async Task Run()
        {
            await _connection.ConnectAsync(new BotConfig
            {
                Token = Unity.Resolve<IDataStorage>().RestoreObject<string>("Config/BotToken"),
            });
            //await commandHandler.InitializeAsync();
            await Task.Delay(-1);
        }
    }
}
