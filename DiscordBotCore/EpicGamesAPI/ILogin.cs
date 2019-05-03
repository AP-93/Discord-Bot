using System.Threading.Tasks;

namespace DiscordBotCore.EpicGamesAPI
{
    public interface ILogin
    {
        Task <AccessToken> GetToken();
        Task <string> GetNameFromID(string id);
    }
}
