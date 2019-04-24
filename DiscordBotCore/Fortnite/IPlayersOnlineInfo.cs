using DiscordBotCore.Storage.Database;
using System.Threading.Tasks;
using System.Timers;

namespace DiscordBotCore.Fortnite
{
    public interface IPlayersOnlineInfo
    {
        Task StartTimer();
        void OnTimerTickedAsync(object sender, ElapsedEventArgs e);
        Task CheckDataChangesAsync(Players plyrs);
    }
}
