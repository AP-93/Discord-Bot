using DiscordBotCore.Discord;
using DiscordBotCore.EpicGamesAPI;
using DiscordBotCore.Storage.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace DiscordBotCore.Fortnite
{
    internal class PlayersOnlineInfo : IPlayersOnlineInfo
    {
        private static Timer loopingTimer;
        private static IApiWebRequest _apiWebRequest;
        private static IGuildOperations _guildOperations;
        private static ILogin _login;

        public PlayersOnlineInfo(IApiWebRequest apiWebRequest,  ILogin login, IGuildOperations guildOperations)
        {
            _apiWebRequest = apiWebRequest;
            _login = login;
            _guildOperations = guildOperations;
        }

        public Task StartTimer()
        {
            loopingTimer = new Timer()
            {
                Interval = 90000,
                AutoReset = true,
                Enabled = true
            };
            loopingTimer.Elapsed += OnTimerTickedAsync;

            return Task.CompletedTask;
        }

        public async void OnTimerTickedAsync(object sender, ElapsedEventArgs e)
        {
            await _guildOperations.CreateFortChannel(_guildOperations.GetDiscordSocketClient().Guilds.FirstOrDefault());

            if (_guildOperations.CheckIfVoiceEmpty())
            {
                List<Players> plyrList = new List<Players>();
                plyrList = Storage.Database.Data.GetData();

                foreach (Players plyr in plyrList)
                {
                    await CheckNameChangeAsync(plyr.FortniteID, plyr.ID, plyr.FortniteName);
                    plyrList = Storage.Database.Data.GetData();
                }

                foreach (Players plyr in plyrList)
                {
                    try
                    {
                        await CheckDataChangesAsyncTracker(plyr);
                    }
                    catch (Exception) { }

                    await Task.Delay(10000);
                }
            }
        }
        /*
        public async Task CheckDataChangesAsync(Players plyrs)
        {
            var apiData = await _apiWebRequest.GetPlayerMatchesAsync(plyrs.FortniteID);

            Console.WriteLine(plyrs.FortniteName + "\n" + "UPISANO " + plyrs.matchesPlayed + "\n " + "DOBAVLJENO " + apiData.matchesPlayed);

            if ((plyrs.matchesPlayed != apiData.matchesPlayed) && (apiData.matchesPlayed != 0))
            {
                var embed = new EmbedBuilder();

                embed.AddField(apiData.FortniteName + " GINE!!!",
                               "Matches: " + (apiData.matchesPlayed - plyrs.matchesPlayed) + "\n" +
                               "Wins: " + (apiData.wins - plyrs.wins) + "\n" +
                               "Kills: " + (apiData.kills - plyrs.kills) + "\n")
                    .WithColor(Color.Red)
                    .WithCurrentTimestamp();
                await channel.SendMessageAsync(embed: embed.Build());

                await Storage.Database.Data.SaveChanges(plyrs.ID, apiData.matchesPlayed, apiData.FortniteName, apiData.kills, apiData.wins);
            }
        }*/

        //check lifteime stats changes fortnitetracker.com
        public async Task CheckDataChangesAsyncTracker(Players plyrs)
        {
            var apiData = await _apiWebRequest.GetLifetimeStats(plyrs.FortniteName);

            if (plyrs.matchesPlayed != int.Parse(apiData[7].value) && plyrs.matchesPlayed < int.Parse(apiData[7].value))
            {
                var embed = _guildOperations.GetBuilderl();

                embed.AddField(plyrs.FortniteName + " GINE!!!",
                               "Matches: " + (int.Parse(apiData[7].value)- plyrs.matchesPlayed) + "\n" +
                               "Wins: " + (int.Parse(apiData[8].value)- plyrs.wins) + "\n" +
                               "Kills: " + (int.Parse(apiData[10].value) - plyrs.kills) + "\n")
                    .WithColor(_guildOperations.GetColor(0xD81813))
                    .WithCurrentTimestamp();
                await _guildOperations.GetChannel().SendMessageAsync(embed: embed.Build());

                await Storage.Database.Data.SaveChanges(plyrs.ID, int.Parse(apiData[7].value), plyrs.FortniteName, int.Parse(apiData[10].value), int.Parse(apiData[8].value));
            }
        }

        public async Task CheckNameChangeAsync(string FortniteId , int id , string currentName)
        {
            string newName = await _login.GetNameFromID(FortniteId);
           
            if (!newName.Equals(currentName))
            {
                await Storage.Database.Data.SaveName(id, newName);
            }
        }
    }
}
