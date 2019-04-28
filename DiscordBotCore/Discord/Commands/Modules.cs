using Discord;
using Discord.Commands;
using DiscordBotCore.Fortnite;
using DiscordBotCore.Fortnite.FortniteTrackerApi;
using DiscordBotCore.Log;
using System.Threading.Tasks;

namespace DiscordBotCore.Discord.Commands
{
    public class InfoModule : ModuleBase<SocketCommandContext>
    {
        private readonly ILogger _log;
        private readonly IApiWebRequest _webRequest;
        private static Stats _stats;


        public InfoModule(ILogger log, IApiWebRequest webRequest, Stats stats)
        {
            _webRequest = webRequest;
            _log = log;
            _stats = stats;
        }

        [Command("Solo")]
        public async Task SoloStats([Remainder] string name)
        {
            _stats = await _webRequest.GetStats(name);
            var embed = new EmbedBuilder();

            embed.AddField("Solo Lifetime",
                    "Matches: " + _stats.p2.matches.value + "\n" +
                    "Wins: " + _stats.p2.top1.value + "\n" +
                    "Kills: " + _stats.p2.kills.value + "\n" +
                    "K/d: " + _stats.p2.kd.value + "\n" +
                    "WinRatio: " + _stats.p2.winRatio.value + "%")
                .WithColor(Color.Blue);
            await ReplyAsync(embed: embed.Build());
        }

        [Command("Duo")]
        public async Task DuoStats([Remainder] string name)
        {
            _stats = await _webRequest.GetStats(name);
            var embed = new EmbedBuilder();

            embed.AddField("Duo Lifetime",
                    "Matches: " + _stats.p10.matches.value + "\n" +
                    "Wins: " + _stats.p10.top1.value + "\n" +
                    "Kills: " + _stats.p10.kills.value + "\n" +
                    "K/d: " + _stats.p10.kd.value + "\n" +
                    "WinRatio: " + _stats.p10.winRatio.value + "%")
                .WithColor(Color.Blue);

            await ReplyAsync(embed: embed.Build());
        }

        [Command("Squad")]
        public async Task SquadStats([Remainder] string name)
        {
            _stats = await _webRequest.GetStats(name);
            var embed = new EmbedBuilder();

            embed.AddField("Squad Lifetime",
                    "Matches: " + _stats.p9.matches.value + "\n" +
                    "Wins: " + _stats.p9.top1.value + "\n" +
                    "Kills: " + _stats.p9.kills.value + "\n" +
                    "K/d: " + _stats.p9.kd.value + "\n" +
                    "WinRatio: " + _stats.p9.winRatio.value + "%")
                .WithColor(Color.Blue);

            await ReplyAsync(embed: embed.Build());
        }

        [Command("SoloX")]
        public async Task SoloStatsCurrent([Remainder] string name)
        {
            _stats = await _webRequest.GetStats(name);
            var embed = new EmbedBuilder();

            embed.AddField("Solo Current Season",
                    "Matches: " + _stats.curr_p2.matches.value + "\n" +
                    "Wins: " + _stats.curr_p2.top1.value + "\n" +
                    "Kills: " + _stats.curr_p2.kills.value + "\n" +
                    "K/d: " + _stats.curr_p2.kd.value + "\n" +
                    "WinRatio: " + _stats.curr_p2.winRatio.value + "%")
                .WithColor(Color.Gold);

            await ReplyAsync(embed: embed.Build());
        }

        [Command("DuoX")]
        public async Task DuoStatsCurrent([Remainder] string name)
        {
            _stats = await _webRequest.GetStats(name);
            var embed = new EmbedBuilder();

            embed.AddField("Duo Current Season",
                    "Matches: " + _stats.curr_p10.matches.value + "\n" +
                    "Wins: " + _stats.curr_p10.top1.value + "\n" +
                    "Kills: " + _stats.curr_p10.kills.value + "\n" +
                    "K/d: " + _stats.curr_p10.kd.value + "\n" +
                    "WinRatio: " + _stats.curr_p10.winRatio.value + "%")
                .WithColor(Color.Gold);

            await ReplyAsync(embed: embed.Build());
        }

        [Command("SquadX")]
        public async Task SquadStatsCurrent([Remainder] string name)
        {
            _stats = await _webRequest.GetStats(name);
            var embed = new EmbedBuilder();

            embed.AddField("Squad Current Season",
                    "Matches: " + _stats.curr_p9.matches.value + "\n" +
                    "Wins: " + _stats.curr_p9.top1.value + "\n" +
                    "Kills: " + _stats.curr_p9.kills.value + "\n" +
                    "K/d: " + _stats.curr_p9.kd.value + "\n" +
                    "WinRatio: " + _stats.curr_p9.winRatio.value + "%")
                .WithColor(Color.Gold);

            await ReplyAsync(embed: embed.Build());
        }
    }
}
