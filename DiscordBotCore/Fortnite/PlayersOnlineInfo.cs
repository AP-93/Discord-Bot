using Discord;
using Discord.WebSocket;
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
            await CreateFortChannel(_client.Guilds.FirstOrDefault(), channel);

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
        }


        public async Task CheckDataChangesAsyncTracker(Players plyrs)
        {
            var apiData = await _apiWebRequest.GetPlayerMatchesFortniteTrackerAsync(plyrs.FortniteID);

            Console.WriteLine(plyrs.FortniteName + "\n" + "UPISANO " + plyrs.matchesPlayed + "\n " + "DOBAVLJENO " + apiData.matches);

            if ((plyrs.lastMatchId != apiData.id))
            {
                var embed = new EmbedBuilder();

                embed.AddField(plyrs.FortniteName + " GINE!!!",
                               "Matches: " + (apiData.matches) + "\n" +
                               "Wins: " + (apiData.top1) + "\n" +
                               "Kills: " + (apiData.kills) + "\n"+
                               "Time: "+apiData.dateCollected + "\n")
                    .WithColor(Color.Red)
                    .WithCurrentTimestamp();
                await channel.SendMessageAsync(embed: embed.Build());

                await Storage.Database.Data.SaveMatchId(plyrs.ID,apiData.id);
            }
        }

        public bool CheckIfVoiceEmpty()
        {
            var chnls = _client.Guilds.FirstOrDefault().VoiceChannels;
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

        public async Task CreateFortChannel(IGuild guild, ITextChannel textChannel)
        {
            if (((await guild.GetChannelsAsync()).FirstOrDefault(x => x.Name == "kotogine")) == null)
            {
                 await guild.CreateTextChannelAsync("kotogine", x =>
                {
                    x.Topic = "Ko tajno gine bot ga razotkrije";  
                });
            }
            channel = ((await guild.GetChannelsAsync()).FirstOrDefault(x => x.Name == "kotogine")) as SocketTextChannel;
        }
    }
}
