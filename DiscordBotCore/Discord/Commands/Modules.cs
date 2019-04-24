using Discord.Commands;
using DiscordBotCore.Fortnite;
using DiscordBotCore.Log;
using System.Threading.Tasks;

namespace DiscordBotCore.Discord.Commands
{
    public class InfoModule : ModuleBase<SocketCommandContext>
    {
        private readonly ILogger _log;
        private readonly IApiWebRequest _webRequest;
        
        public InfoModule(ILogger log, IApiWebRequest webRequest)
        {
            _webRequest = webRequest;
            _log = log;
        }
       
        [Command("Solo")]
        public async Task Solo([Remainder] string name)
        {
            await ReplyAsync(await _webRequest.GetSoloStats(name));
        }

        [Command("Duo")]
        public async Task DuoStats([Remainder] string name)
        {
            await ReplyAsync(await _webRequest.GetDuoStats(name));
        }
    }
}
