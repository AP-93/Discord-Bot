using System.ComponentModel.DataAnnotations;

namespace DiscordBotCore.Storage.Database
{
    public class Players
    {
        [Key]
        public int ID { get; set; }
        public ulong DiscordId { get; set; }
        public string FortniteID { get; set; }
        public string FortniteName { get; set; }
        public int matchesPlayed { get; set; }
        public int wins { get; set; }
        public int kills { get; set; }

    }
}
