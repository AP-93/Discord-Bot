using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using static System.IO.Directory;

namespace DiscordBotCore.Storage.Implementations
{
    public class JsonStorage : IDataStorage
    {
        public AuthToken RestoreToken()
        {

            var json = File.ReadAllText(GetCurrentDirectory() + @"\Config.json");
            var array = JsonConvert.DeserializeObject<AuthToken>(json);
            return array;

        }

        public void StoreObject(object obj, string key)
        {
            var file = $"{key}.json";
            CreateDirectory(Path.GetDirectoryName(file));

            var json = JsonConvert.SerializeObject(obj);
            File.WriteAllText(file, json);
        }
    }
}
