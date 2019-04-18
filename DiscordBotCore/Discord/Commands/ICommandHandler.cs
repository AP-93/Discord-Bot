using System.Threading.Tasks;

namespace DiscordBotCore.Discord.Commands
{
    public interface ICommandHandler
    {
        Task InstallCommandsAsync(); 
    }
}
