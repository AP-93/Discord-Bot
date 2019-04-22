using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using static System.IO.Directory;

namespace DiscordBotCore.Storage.Implementations
{
    class JsonStorage : IDataStorage
    {
        public string RestoreToken (string jsonKey)
        {

            var json = File.ReadAllText(GetCurrentDirectory()+@"\Config.json");
            var array = (JObject)JsonConvert.DeserializeObject(json);
            return array[jsonKey].ToString();
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
