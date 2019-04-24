using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using static System.IO.Directory;

namespace DiscordBotCore.Storage.Implementations
{
    public class JsonStorage : IDataStorage
    {
        public string RestoreToken(string key)
        {
            var json = File.ReadAllText(GetCurrentDirectory() + @"\Config.json");
            var array = (JObject)JsonConvert.DeserializeObject(json);
            return array[key].Value<string>();
        }
    }
}
