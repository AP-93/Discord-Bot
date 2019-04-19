using Discord.Commands;
using DiscordBotCore.Log;
using System.Threading.Tasks;

namespace DiscordBotCore.Discord.Commands
{
    public class InfoModule : ModuleBase<SocketCommandContext>
    {
        private readonly ILogger _log;
        private readonly ApiWebRequest _webRequest;
       
        public InfoModule(ILogger log, ApiWebRequest webRequest)
        {
            _webRequest = webRequest;
            _log = log;
        }
       
        [Command("skeniraj")]
        public async Task SayAsync([Remainder] string echo)
        {
            await ReplyAsync(await ApiWebRequest.GetPlayerStats(await ApiWebRequest.GetPlayerIdAsync(echo)));
        }  
    }
}
