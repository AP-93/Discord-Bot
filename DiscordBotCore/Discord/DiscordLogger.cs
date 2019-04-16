using Discord;
using DiscordBotCore.Log;
using System.Threading.Tasks;

namespace DiscordBotCore.Discord
{
    class DiscordLogger
    {
        ILogger _logger;

        public DiscordLogger(ILogger logger)
        {
            _logger = logger;
        }

        public Task Log(LogMessage logMsg)
        {
            _logger.Log(logMsg.Message);
            return Task.CompletedTask;
        }
    }
}
