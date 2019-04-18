using Discord.WebSocket;
using System.Threading.Tasks;
using System.Timers;

namespace DiscordBotCore.Fortnite
{
    internal static class PlayersOnlineInfo
    {
        private static Timer loopingTimer;
        private static SocketTextChannel channel;
      
        internal static Task StartTimer()
        {
            channel = Global.Client.GetGuild(565554856132345856).GetTextChannel(565554856132345858);

            loopingTimer = new Timer()
            {
                Interval = 10000,
                AutoReset = true,
                Enabled = true
            };
            loopingTimer.Elapsed += OnTimerTicked;

            return Task.CompletedTask;
        }

        private static async void OnTimerTicked(object sender, ElapsedEventArgs e)
        {
            await channel.SendMessageAsync(await ApiWebRequest.GetPlayerStats("8ed3293f263b44f1963fb3b4388d1b98"));
        }
    }
}
