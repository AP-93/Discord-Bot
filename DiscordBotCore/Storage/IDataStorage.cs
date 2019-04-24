using DiscordBotCore.Storage.Implementations;

namespace DiscordBotCore.Storage
{
    public interface IDataStorage
    {
        void StoreObject(object obj, string key);

        AuthToken RestoreToken ();
    }
}
