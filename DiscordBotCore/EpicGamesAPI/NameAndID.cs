using Newtonsoft.Json;

namespace DiscordBotCore.EpicGamesAPI
{
    public class NameAndID
    {
        [JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("displayName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayName { get; set; }

        [JsonProperty("externalAuths", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public ExternalAuths ExternalAuths { get; set; }  
    }

    public partial class ExternalAuths {}  
}
