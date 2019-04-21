using Newtonsoft.Json;
using System.IO;
using static System.IO.Directory;

namespace DiscordBotCore.Storage.Implementations
{
    class JsonStorage : IDataStorage
    {
        public string RestoreToken (string jsonFile)
        {

            var json = File.ReadAllText(GetCurrentDirectory()+jsonFile);
            dynamic array = JsonConvert.DeserializeObject(json);
            return array.token;
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
