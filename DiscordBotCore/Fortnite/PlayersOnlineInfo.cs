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
                Interval = 600000,
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

                //await CheckDataChangesFortniteTrackerAsync(plyr, cnter);
                await CheckDataChangesAsync(plyr, cnter);
                await Task.Delay(10000);
            }

            /*if (cnter == 0)
            {
                await channel.SendMessageAsync("NIKO NEGINE FORTNAJT PROPADA!!!");
            }*/
        }

        private static async Task CheckDataChangesAsync(Players plyrs, int counter)
        {
          

            var apiData = await ApiWebRequest.GetPlayerMatchesAsync(plyrs.FortniteID);

            Console.WriteLine(plyrs.FortniteName+"UPISANO:: "+plyrs.matchesPlayed + "  IZVUCENO :    "+ apiData.matchesPlayed);
            if (plyrs.matchesPlayed != apiData.matchesPlayed)
            {

                await channel.SendMessageAsync(apiData.FortniteName + " GINE!!! \n" +
                                            "Matches: " + (apiData.matchesPlayed - plyrs.matchesPlayed) + "\n" +
                                            "Wins: " + (apiData.wins - plyrs.wins) + "\n" +
                                            "Kills: " + (apiData.kills - plyrs.kills) + "\n");
                await Storage.Database.Data.SaveChanges(plyrs.ID, apiData.matchesPlayed, apiData.FortniteName, apiData.kills,apiData.wins);
            }


        }
        private static async Task CheckDataChangesFortniteTrackerAsync(Players plyrs, int counter)
        {

            var apiData = await ApiWebRequest.GetPlayerMatchesFortniteTrackerAsync(await ApiWebRequest.GetPlayerName(plyrs.FortniteID));

            if (plyrs.matchesPlayed != apiData.matchesPlayed)
            {

                await Storage.Database.Data.SaveChanges(plyrs.ID, apiData.matchesPlayed, apiData.FortniteName ,apiData.kills, apiData.wins);
                await channel.SendMessageAsync(apiData.FortniteName + " GINE!!! \n" + 
                                                "broj meceva:  "+apiData.matchesPlayed+"\n" + 
                                                "broj winova  " + apiData.wins+ "\n" +
                                                "broj killova  " + apiData.kills);
                counter++;
            }
        }
    }
}
