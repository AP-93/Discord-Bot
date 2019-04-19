using Discord.WebSocket;
using DiscordBotCore.Storage.Database;
using System.Collections.Generic;
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
            await CheckDataChanges();
        }

        private static async Task CheckDataChanges()
        {
            List<Players> plyrList = new List<Players>();
            plyrList = Storage.Database.Data.GetData();
            int counter = 0;
            
          foreach(Players plyr  in plyrList)
            { 
                var apiData= await ApiWebRequest.GetPlayerMatches(plyr.FortniteID);
                if (plyr.matchesPlayed != apiData.matchesPlayed)
                { 
                    await channel.SendMessageAsync(apiData.FortniteName+ " GINE!!!");
                    await Storage.Database.Data.SaveChanges(plyr.ID, apiData.matchesPlayed, apiData.FortniteName);
                    counter++;
                }
                
            }
          if(counter == 0)
            await channel.SendMessageAsync("NIKO NEGINE FORTNAJT PROPADA!!!");
        }
    }
}
