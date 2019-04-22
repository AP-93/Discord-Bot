using Discord.WebSocket;
using DiscordBotCore.Storage.Database;
using System;
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
                Interval = 30000,
                AutoReset = true,
                Enabled = true
            };
            loopingTimer.Elapsed +=  OnTimerTickedAsync;

            return Task.CompletedTask;
        }

        private static async void OnTimerTickedAsync(object sender, ElapsedEventArgs e)
        {
            List<Players> plyrList = new List<Players>();
            plyrList = Storage.Database.Data.GetData();
            int cnter = 0;
            foreach (Players plyr in plyrList)
            {
                
                await CheckDataChangesAsync(plyr, cnter);
                await Task.Delay(5000);
            }

            if (cnter == 0)
            {
                await channel.SendMessageAsync("NIKO NEGINE FORTNAJT PROPADA!!!");
            }
        }

        private static async Task CheckDataChangesAsync(Players plyrs, int counter)
        {
          

            var apiData = await ApiWebRequest.GetPlayerMatchesAsync(plyrs.FortniteID);

            Console.WriteLine(plyrs.FortniteName+"UPISANO::    "+plyrs.matchesPlayed + "IZVUCENO :    "+ apiData.matchesPlayed);
            if (plyrs.matchesPlayed != apiData.matchesPlayed)
                {

                     await   Storage.Database.Data.SaveChanges(plyrs.ID, apiData.matchesPlayed, apiData.FortniteName);
                    Console.WriteLine("upisano  "+ plyrs.FortniteName );
                     await channel.SendMessageAsync(apiData.FortniteName + " GINE!!!");
                    counter++;
                }

        }
    }
}
