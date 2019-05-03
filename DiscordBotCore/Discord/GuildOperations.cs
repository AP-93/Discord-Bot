using Discord;
using Discord.WebSocket;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DiscordBotCore.Discord
{
    class GuildOperations : IGuildOperations
    {
        static SocketTextChannel channel;
        static DiscordSocketClient _client;

        public GuildOperations(DiscordSocketClient client)
        {
            _client = client;
        }

        public async Task CreateFortChannel(IGuild guild)
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
        public DiscordSocketClient GetDiscordSocketClient()
        {
            return _client;
        }

        public SocketTextChannel GetChannel()
        {
            return channel;
        }

        public EmbedBuilder GetBuilderl()
        {
            return new EmbedBuilder();
        }

        public Color GetColor(UInt32 color)
        {
            return new Color(color);
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
    }
}
