using Discord;
using Discord.WebSocket;
using DiscordBotCore.Discord.Entities;
using DiscordBotCore.Fortnite;
using System.Threading.Tasks;

namespace DiscordBotCore.Discord.Connections
{
    class Connection : IConnection
    {
        private readonly DiscordSocketClient _client;
        private readonly DiscordLogger _logger;
        private static IPlayersOnlineInfo _playersOnlineInfo;

        public Connection(DiscordLogger logger, DiscordSocketClient client ,IPlayersOnlineInfo playersOnlineInfo)
        {
            _logger = logger;
            _client = client;
            _playersOnlineInfo = playersOnlineInfo;
        }

        public async Task ConnectAsync(BotConfig config)
        {
            _client.Log += _logger.Log;
            await _client.LoginAsync(TokenType.Bot, config.Token);
            await _client.StartAsync();
            _client.Ready += _playersOnlineInfo.StartTimer;
        }
    }
}
