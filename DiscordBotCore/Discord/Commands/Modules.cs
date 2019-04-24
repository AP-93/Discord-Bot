using Discord.Commands;
using DiscordBotCore.Fortnite;
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
       
        [Command("Solo")]
        public async Task Solo([Remainder] string echo)
        {
            await ReplyAsync(await ApiWebRequest.GetSoloStats(echo));
        }

        [Command("Duo")]
        public async Task DuoStats([Remainder] string echo)
        {
           
            await ReplyAsync(await ApiWebRequest.GetDuoStats(echo));
        }
    }
}
