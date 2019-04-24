using Discord.WebSocket;
using DiscordBotCore.Storage.Database;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;

namespace DiscordBotCore.Fortnite
{
    internal class PlayersOnlineInfo : IPlayersOnlineInfo
    {
        private static Timer loopingTimer;
        private static SocketTextChannel channel;
        private static DiscordSocketClient _client;
        private static IApiWebRequest _apiWebRequest;

        public PlayersOnlineInfo(IApiWebRequest apiWebRequest, DiscordSocketClient client)
        {
            _apiWebRequest = apiWebRequest;
            _client = client;
        }

        public Task StartTimer()
        {
            channel = _client.GetGuild(565554856132345856).GetTextChannel(565554856132345858);

            loopingTimer = new Timer()
            {
                Interval = 60000,
                AutoReset = true,
                Enabled = true
            };
            loopingTimer.Elapsed += OnTimerTickedAsync;

            return Task.CompletedTask;
        }

        public async void OnTimerTickedAsync(object sender, ElapsedEventArgs e)
        {
            if (CheckIfVoiceEmpty())
            {
                List<Players> plyrList = new List<Players>();
                plyrList = Storage.Database.Data.GetData();

                foreach (Players plyr in plyrList)
                {
                    await CheckDataChangesAsync(plyr);
                    await Task.Delay(10000);
                }
            }
        }

        public async Task CheckDataChangesAsync(Players plyrs)
        {
            var apiData = await _apiWebRequest.GetPlayerMatchesAsync(plyrs.FortniteID);

            if (plyrs.matchesPlayed != apiData.matchesPlayed && apiData.matchesPlayed != 0)
            {
                await channel.SendMessageAsync(apiData.FortniteName + " GINE!!! \n" +
                                            "Matches: " + (apiData.matchesPlayed - plyrs.matchesPlayed) + "\n" +
                                            "Wins: " + (apiData.wins - plyrs.wins) + "\n" +
                                            "Kills: " + (apiData.kills - plyrs.kills) + "\n");
                await Storage.Database.Data.SaveChanges(plyrs.ID, apiData.matchesPlayed, apiData.FortniteName, apiData.kills, apiData.wins);
            }
        }

        public bool CheckIfVoiceEmpty()
        {
            var chnls = _client.GetGuild(565554856132345856).VoiceChannels;
            int counter = 0;

            foreach (var chnl in chnls)
            {
                counter += chnl.Users.Count;
            }
            if (counter < 1)
                return true;
            else 
                return false;
        }
    }
}
